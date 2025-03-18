namespace Fraction.UCI;
public record Infinite() : Go.ICommand {
    public const string arg0 = "infinite";
    public string Serialize() {
        return arg0;
    }

    public class Parser : Go.ICommandParser {
        public int Parse(Engine engine, string[] args, out Go.ICommand command) {
            command = arg0 == args[0] ? new Infinite() : new Unknown(args[0..1]);
            return 0;
        }
    }
}
