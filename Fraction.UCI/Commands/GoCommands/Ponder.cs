namespace Fraction.UCI;

public record Ponder() : Go.ICommand {
    public const string arg0 = "ponder";
    public string Serialize() {
        return arg0;
    }
    public class Parser : Go.ICommandParser {
        public int Parse(Engine engine, string[] args, out Go.ICommand command) {
            command = arg0 == args[0] ? new Ponder() : new Unknown(args[0..1]);
            return 0;
        }
    }
}
