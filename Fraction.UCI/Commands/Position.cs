using System.Text;

namespace Fraction.UCI;

public record Position(string? Fen, string[] moves) : ICommand {
    public const string arg0 = "position";

    public string Serialize() {
        var sb = new StringBuilder();
        sb.Append(arg0);
        sb.Append(' ');
        if (this.Fen is not null) {
            sb.AppendJoin(' ', "fen", this.Fen);
        } else sb.Append("startpos");
        if (moves.Length > 0){ 
            sb.Append(" moves ");
            sb.AppendJoin(' ', this.moves);
        }
        return sb.ToString();
    }

    public class Parser : ICommandParser {
        public ICommand Parse(Engine engine, string[] args) {
            if (arg0 != args[0]) return new Unknown(args);

            int startpos = 0;
            int fen = 0;
            int moves = 0;

            for (int i = 1; i < args.Length - 1; i++) {
                if (args[i] == "startpos" && (startpos | fen) == 0) startpos = i;
                if (args[i] == "fen" && (startpos | fen) == 0 && i + 6 < args.Length) {
                    fen = i + 1;
                    i += 6;
                }
                if (args[i] == "moves" && (startpos | fen) != 0) {
                    moves = ++i;
                    break;
                }
            }

            if ((startpos | fen) == 0 && args[^1] != "startpos") return new Unknown(args);

            return new Position(
                fen != 0 ? string.Join(' ', args[fen..(fen + 6)]) : null,
                moves != 0 ? args[moves..^0] : []
            );
        }
    }
}
