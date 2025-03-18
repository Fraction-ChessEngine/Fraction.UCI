namespace Fraction.UCI;

public record IsReady() : ICommand {
    public const string arg0 = "isready";

    public string Serialize() {
        return arg0;
    }

    public class Parser() : ICommandParser {
        public ICommand Parse(Engine engine, string[] args) {
            if (arg0 == args[0]) return new IsReady();
            return new Unknown(args);
        }
    }
}
