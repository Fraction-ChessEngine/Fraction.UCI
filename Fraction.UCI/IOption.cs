using System.Text;

namespace Fraction.UCI;

public interface IOption {
    public string Get();
    public string Serialize();

    protected static string ToStringHelper(
        string type,
        string? @default = null,
        string? min = null,
        string? max = null,
        params string[] var
    ) {
        var sb = new StringBuilder();
        sb.Append("type");
        sb.Append(type);

        if (@default is not null) {
            sb.Append("default");
            sb.Append(@default);
        }

        if (min is not null) {
            sb.Append("min");
            sb.Append(min);
        }

        if (max is not null) {
            sb.Append("max");
            sb.Append(max);
        }

        foreach (var v in var) {
            sb.Append("var");
            sb.Append(v);
        }

        return sb.ToString();
    }
}
