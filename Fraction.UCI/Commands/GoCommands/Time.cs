namespace Fraction.UCI;

public record Time(Color Turn, int TimeLeft) : Go.ICommand {
    public string Serialize() {
        return string.Join(' ', this.Turn switch {
            Color.White => "wtime",
            Color.Black => "btime",
            _ => throw new System.Diagnostics.UnreachableException("dude, it's an enum, come on"),
        }, this.TimeLeft.ToString());
    }

    public class Parser : Go.ICommandParser {
        public int Parse(Engine engine, string[] args, out Go.ICommand command) {
            if (args.Length < 2) { 
                command = new Unknown(args[0..1]);
                return 0;
            }

            if (int.TryParse(args[1], out int time)) {
                command = args[0] switch {
                    "wtime" => new Time(Color.White, time),
                    "btime" => new Time(Color.Black, time),
                    _ => new Unknown(args[0..1]),
                };

                return args[0] is "wtime" or "btime" ? 1 : 0;
            }

            command = new Unknown(args[0..1]);
            return 0;
        }
    }
}
