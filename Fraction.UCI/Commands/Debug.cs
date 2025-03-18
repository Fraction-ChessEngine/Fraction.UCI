namespace Fraction.UCI;

public record Debug(bool State) : ICommand {
    public const string arg0 = "debug";

    public string Serialize() {
        return string.Join(' ', arg0, this.State ? "on" : "off");
    }

    public class Parser : ICommandParser {
        public ICommand Parse(Engine engine, string[] args) {
            if (arg0 != args[0]) return new Unknown(args);

            foreach (var arg in args[1..^0]) {
                if (arg == "on") return new Debug(true);
                if (arg == "off") return new Debug(false);
            }

            return new Unknown(args);
        }
    }
}
