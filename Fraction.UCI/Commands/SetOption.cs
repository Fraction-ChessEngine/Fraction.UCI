namespace Fraction.UCI;

public record SetOption(string Name, string? Value) : ICommand {
    public const string arg0 = "setoption";

    public string Serialize() {
        if (this.Value is null) return string.Join(' ', arg0, "name", this.Name);
        return string.Join(' ', arg0, "name", this.Name, "value", this.Value);
    }

    public class Parser : ICommandParser {
        public ICommand Parse(Engine engine, string[] args) {
            if (arg0 != args[0]) return new Unknown(args);
            int name = 0;
            int @value = 0;

            for (int i = 0; i < args.Length - 1; i++) {
                if (args[i] == "name" && name == 0)
                    name = i + 1;
                if (args[i] == "value" && name != 0 && @value == 0)
                    @value = i + 1;
            }

            if (name == 0) return new Unknown(args);

            if (@value == 0) return new SetOption(string.Join(' ', args[name..^0]), null);

            return new SetOption(
                string.Join(' ', args[name..@value]),
                string.Join(' ', args[@value..^0])
            );
        }
    }
}
