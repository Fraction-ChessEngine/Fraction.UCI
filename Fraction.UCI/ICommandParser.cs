namespace Fraction.UCI;

public interface ICommandParser {
    public ICommand Parse(Engine engine, string[] args);
}
