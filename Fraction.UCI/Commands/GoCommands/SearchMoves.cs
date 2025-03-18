namespace Fraction.UCI;

public record SearchMoves(string[] moves) : Go.ICommand {
    public const string arg0 = "searchmoves";
    public string Serialize() {
        return string.Join(' ', arg0, this.moves);
    }

    public class Parser : Go.ICommandParser {
        public int Parse(Engine engine, string[] args, out Go.ICommand command) {
            if (arg0 != args[0] || args.Length < 2) {
                command = new Unknown(args[0..1]);
                return 0;
            }

            command = new SearchMoves(args[1..^0]);
            return args.Length - 1;
        }
    }
}
