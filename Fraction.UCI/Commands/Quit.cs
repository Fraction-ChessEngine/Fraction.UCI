namespace Fraction.UCI;

public record Quit() : ICommand {
    public const string arg0 = "quit";

    public string Serialize() {
        return arg0;
    }

    public class Parser : ICommandParser {
        public ICommand Parse(Engine engine, string[] args) {
            return arg0 == args[0] ? new Quit() : new Unknown(args);
        }
    }
}
