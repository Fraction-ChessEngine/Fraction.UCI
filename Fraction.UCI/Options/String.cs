namespace Fraction.UCI;
public class String : IOption {
    private const string type = "string";
    public string Value { get; set; }
    public string Default { get; set; }

    public String(string @default) {
        this.Value = @default;
        this.Default = @default;
    }

    public string Get() {
        return this.Value;
    }

    public string Serialize() {
        return IOption.ToStringHelper(type, this.Default);
    }
}
