namespace Fraction.UCI;
public record MoveTime(int X) : Go.ICommand {
    public const string arg0 = "movetime";
    public string Serialize() {
        return string.Join(' ', arg0, this.X.ToString());
    }

    public class Parser : Go.ICommandParser {
        public int Parse(Engine engine, string[] args, out Go.ICommand command) {
            if (arg0 != args[0] || args.Length < 2) {
                command = new Unknown(args[0..1]);
                return 0;
            }

            if (int.TryParse(args[1], out int x)) {
                command = new MoveTime(x);
                return 1;
            }

            command = new Unknown(args[0..1]);
            return 0;
        }
    }
}
