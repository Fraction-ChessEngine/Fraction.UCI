using System.Collections.Generic;
using System.Text;

namespace Fraction.UCI;

public record Go(Go.ICommand[] Commands) : ICommand {
    public const string arg0 = "go";
    public string Serialize() {
        var sb = new StringBuilder();
        sb.Append(arg0);

        foreach (var command in this.Commands) {
            sb.Append(' ');
            sb.Append(command.Serialize());
        }

        return sb.ToString();
    }

    public class Parser : UCI.ICommandParser {
        private IReadOnlyDictionary<string, Go.ICommandParser> commands;

        public IReadOnlyDictionary<string, Go.ICommandParser> DefaultCommands = new Dictionary<string, Go.ICommandParser>() {
                { SearchMoves.arg0, new SearchMoves.Parser() },
                { Ponder.arg0, new Ponder.Parser() },
                { "wtime", new Time.Parser() },
                { "btime", new Time.Parser() },
                { "winc", new Inc.Parser() },
                { "binc", new Inc.Parser() },
                { MovesToGo.arg0, new MovesToGo.Parser() },
                { Depth.arg0, new Depth.Parser() },
                { Nodes.arg0, new Nodes.Parser() },
                { Mate.arg0, new Mate.Parser() },
                { MoveTime.arg0, new MoveTime.Parser() },
                { Infinite.arg0, new Infinite.Parser() },
        };

        public Parser() {
            this.commands = DefaultCommands;
        }

        public Parser(IReadOnlyDictionary<string, Go.ICommandParser> commands) {
            this.commands = commands;
        }

        public UCI.ICommand Parse(Engine engine, string[] args) {
            if (arg0 != args[0]) return new Unknown(args);

            var commands = new List<Go.ICommand>();
            int unknown = 0;

            for (int i = 1; i < args.Length; i++) {
                if (this.commands.TryGetValue(args[i], out Go.ICommandParser? parser)) {
                    if (unknown != 0) {
                        commands.Add(new Unknown(args[(i - unknown)..i]));
                        unknown = 0;
                    }

                    i += parser.Parse(engine, args[i..^0], out Go.ICommand cmd);
                    commands.Add(cmd);
                    continue;
                }
                unknown++;
            }
            if (unknown != 0) commands.Add(new Unknown(args[^unknown..^0]));

            return new Go(commands.ToArray());
        }
    }

    public interface ICommand {
        public string Serialize();
    }

    public interface ICommandParser {
        public int Parse(Engine engine, string[] args, out ICommand command);
    }
}
