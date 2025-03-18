namespace Fraction.UCI;
public class Check : IOption {
    private const string type = "check";

    public bool Value { get; set; }
    public bool Default { get; init; }

    public Check(bool @default) {
        this.Value = @default;
        this.Default = @default;
    }

    public string Get() {
        return this.Value.ToString();
    }

    public string Serialize() {
        return IOption.ToStringHelper(type, this.Default.ToString());
    }
}

