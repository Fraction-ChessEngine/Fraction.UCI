namespace Fraction.UCI;

public record Inc(Color Turn, int Increment) : Go.ICommand {
    public string Serialize() {
        return string.Join(' ', this.Turn switch {
            Color.White => "winc",
            Color.Black => "binc",
            _ => throw new System.Diagnostics.UnreachableException("dude, it's an enum, come on"),
        }, this.Increment.ToString());
    }

    public class Parser : Go.ICommandParser {
        public int Parse(Engine engine, string[] args, out Go.ICommand command) {
            if (args.Length < 2) { 
                command = new Unknown(args[0..1]);
                return 0;
            }

            if (int.TryParse(args[1], out int inc)) {
                command = args[0] switch {
                    "winc" => new Inc(Color.White, inc),
                    "binc" => new Inc(Color.Black, inc),
                    _ => new Unknown(args[0..1]),
                };

                return args[0] is "winc" or "binc" ? 1 : 0;
            }

            command = new Unknown(args[0..1]);
            return 0;
        }
    }
}
