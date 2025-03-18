
namespace Fraction.UCI;

public record ReadyOk() : ICommand {
    public const string arg0 = "readyok";
    public string Serialize() {
        return arg0;
    }

    public class Parser : ICommandParser {
        public ICommand Parse(Engine engine, string[] args) {
            return arg0 == args[0] ? new ReadyOk() : new Unknown(args);
        }
    }
}
