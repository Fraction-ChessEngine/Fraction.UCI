using System;

namespace Fraction.UCI;
public class Combo<TEnum> : IOption where TEnum : Enum {
    private const string type = "combo";

    public TEnum Value { get; set; }
    public TEnum Default { get; init; }

    public Combo(TEnum @default) {
        this.Value = @default;
        this.Default = @default;
    }

    public string Get() {
        return this.Value.ToString();
    }

    public string Serialize() {
        return IOption.ToStringHelper(type, this.Default.ToString(), null, null, Enum.GetNames(typeof(TEnum)));
    }
}

