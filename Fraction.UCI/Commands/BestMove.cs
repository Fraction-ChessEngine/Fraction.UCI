using System.Text;

namespace Fraction.UCI;

public record BestMove(string Move, string? Ponder = null) : ICommand {
    public const string arg0 = "bestmove";
    public string Serialize() {
        var sb = new StringBuilder();
        sb.AppendJoin(' ', arg0, this.Move);

        if (this.Ponder is null) return sb.ToString();

        sb.Append(' ');
        sb.AppendJoin(' ', "ponder", this.Ponder);

        return sb.ToString();
    }

    public class Parse : ICommandParser {
        ICommand ICommandParser.Parse(Engine engine, string[] args) {
            if (arg0 != args[0] || args.Length < 2) return new Unknown(args);

            int ponder = 0;
            for (int i = 2; i < args.Length - 1; i++)
                if (args[i] == "ponder") {
                    ponder = i + 1;
                    break;
                }

            return new BestMove(args[1], ponder != 0 ? args[ponder] : null);
        }
    }
}
