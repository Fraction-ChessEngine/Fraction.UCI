namespace Fraction.UCI;

public record Option(string Name, IOption Value) : ICommand {
    public const string arg0 = "option";
    public string Serialize() {
        return string.Join(' ', arg0, "name", this.Name, this.Value.Serialize());
    }
}
