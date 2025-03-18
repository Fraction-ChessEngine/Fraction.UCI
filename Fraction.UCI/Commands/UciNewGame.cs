namespace Fraction.UCI;

public record UciNewGame() : ICommand {
    public const string arg0 = "ucinewgame";

    public string Serialize() {
        return arg0;
    }

    public class Parser : ICommandParser {
        public ICommand Parse(Engine engine, string[] args) {
            if (arg0 == args[0]) return new UciNewGame();
            return new Unknown(args);
        }
    }
}
