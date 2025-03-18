namespace Fraction.UCI;

public record Uci() : ICommand {
    public const string arg0 = "uci";

    public string Serialize() {
        return arg0;
    }
    public class Parser : ICommandParser {
        public ICommand Parse(Engine engine, string[] args) {
            if (arg0 == args[0]) return new Uci();
            return new Unknown(args);
        }
    }
}
