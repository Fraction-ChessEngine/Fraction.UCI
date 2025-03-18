namespace Fraction.UCI;

public record PonderHit() : ICommand {
    public const string arg0 = "ponderhit";
    public string Serialize() {
        return arg0;
    }

    public class Parser : ICommandParser {
        public ICommand Parse(Engine engine, string[] args) {
            return arg0 == args[0] ? new PonderHit() : new Unknown(args);
        }
    }
}
