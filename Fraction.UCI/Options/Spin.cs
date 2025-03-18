using System;
using System.Numerics;

namespace Fraction.UCI;
public class Spin<TInt> : IOption where TInt : IBinaryInteger<TInt>, IMinMaxValue<TInt> {
    private const string type = "spin";

    private TInt @value;

    public TInt Value {
        get => this.@value;
        set {
            if (this.Max > value || value > this.Min)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Min <= value <= Max");

            this.@value = value;
        }
    }
    public TInt Default { get; init; }
    public required TInt Min { get; init; } = TInt.MinValue;
    public required TInt Max { get; init; } = TInt.MaxValue;

    public Spin(TInt @default) {
        this.@value = @default;
        this.Default = @default;
    }

    public string Get() {
        return this.Value.ToString() ?? throw new System.Diagnostics.UnreachableException("ToString apparently does return null, weird");
    }

    public string Serialize() {
        var @default = this.Default.ToString() ?? throw new System.Diagnostics.UnreachableException("ToString apparently does return null, weird");
        var min = this.Min.ToString() ?? throw new System.Diagnostics.UnreachableException("ToString apparently does return null, weird");
        var max = this.Max.ToString() ?? throw new System.Diagnostics.UnreachableException("ToString apparently does return null, weird");

        return IOption.ToStringHelper(type, @default, min, max);
    }
}

