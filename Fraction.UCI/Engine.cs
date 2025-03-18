using System;
using System.Collections.Generic;
using System.IO;

namespace Fraction.UCI;

public abstract class Engine {
    private TextReader @in;
    private TextWriter @out;

    protected IReadOnlyDictionary<string, ICommandParser> Commands { get; init; } = new Dictionary<string, ICommandParser>() {
        { Uci.arg0, new Uci.Parser() },
        { Debug.arg0, new Debug.Parser() },
        { IsReady.arg0, new IsReady.Parser() },
        { SetOption.arg0, new SetOption.Parser() },
        { UciNewGame.arg0, new UciNewGame.Parser() },
        { Position.arg0, new Position.Parser() },
        { Go.arg0, new Go.Parser() },
        { Stop.arg0, new Stop.Parser() },
        { PonderHit.arg0, new PonderHit.Parser() },
        { Quit.arg0, new Quit.Parser() },
    };

    protected LogLevel MinLogLevel { get; set; } = LogLevel.Info;

    protected Engine() : this(Console.In, Console.Out) {}
    protected Engine(TextReader stdin, TextWriter stdout) {
        this.@in = stdin;
        this.@out = stdout;
    }

    protected abstract void Handle(ICommand command);

    protected void Send(ICommand command) {
        this.@out.WriteLine(command.Serialize());
    }

    public void Run() {
        for (string? line = this.@in.ReadLine(); line is not null; line = this.@in.ReadLine()) {
            string[] args = line.Trim().Split();

            if (this.Commands.TryGetValue(args[0], out ICommandParser parser)) {
                this.Handle(parser.Parse(this, args));
            } else this.Handle(new Unknown(args));
        }
    }

    protected virtual void Log(LogLevel level, string message) {
        if (level < this.MinLogLevel) return;

        this.Send(Info.String($"[{level.ToString()}] {message}"));
    }

    protected enum LogLevel {
        Debug,
        Info,
        Warning,
        Error,
    }
}
