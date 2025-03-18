namespace Fraction.UCI;

public record Stop() : ICommand {
    public const string arg0 = "stop";
    public string Serialize() {
        return arg0;
    }
    public class Parser : ICommandParser {
        public ICommand Parse(Engine engine, string[] args) {
            return arg0 == args[0] ? new Stop() : new Unknown(args);
        }
    }
}
