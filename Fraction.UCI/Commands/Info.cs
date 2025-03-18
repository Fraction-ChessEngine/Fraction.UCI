namespace Fraction.UCI;

public record Info(string Bare) : ICommand {
    public const string arg0 = "info";

    public static Info String(string @value) {
        return new Info(string.Join(' ', "string", @value));
    }

    public string Serialize() {
        return string.Join(' ', arg0, this.Bare);
    }

    public class Parser : ICommandParser {
        public ICommand Parse(Engine engine, string[] args) {
            return arg0 == args[0] ? new Info(string.Join(' ', args[1..^0])) : new Unknown(args);
        }
    }
}
