namespace Fraction.UCI;

public record UciOk() : ICommand {
    public const string arg0 = "uciok";
    public string Serialize() {
        return arg0;
    }

    public class Parser : ICommandParser {
        public ICommand Parse(Engine engine, string[] args) {
            return arg0 == args[0] ? new UciOk() : new Unknown(args);
        }
    }
}
