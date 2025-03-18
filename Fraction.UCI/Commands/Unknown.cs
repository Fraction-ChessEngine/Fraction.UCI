namespace Fraction.UCI;

public record Unknown(string[] Args) : ICommand, Go.ICommand {
    public static ICommand Parse(Engine engine, string[] args) {
        return new Unknown(args);
    }

    public string Serialize() {
        return string.Join(' ', this.Args);
    }
}
