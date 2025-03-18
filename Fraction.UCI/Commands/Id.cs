namespace Fraction.UCI;

public record Id(Id.Type Sort, string Value) : ICommand {
    public const string arg0 = "id";
    public string Serialize() {
        string @value = this.Sort switch {
            Type.Name => "name",
            Type.Author => "author",
            _ => throw new System.Diagnostics.UnreachableException(),
        };
        return string.Join(' ', arg0, @value, this.Value);
    }

    public enum Type {
        Name,
        Author,
    }

    public class Parser : ICommandParser {
        public ICommand Parse(Engine engine, string[] args) {
            if (args.Length < 3 || arg0 != args[0]) return new Unknown(args);

            Type sort;
           switch (args[1]) {
               case "name":
                   sort = Type.Name;
                   break;

               case "author":
                   sort = Type.Author;
                   break;
               default:
                   return new Unknown(args);
            }

           return new Id(sort, string.Join(' ', args[2..^0]));
        }
    }
}
