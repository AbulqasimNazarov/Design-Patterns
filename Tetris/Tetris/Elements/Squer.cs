

namespace Tetris.Elements;

public class Squer
{
    public string? ElementForm { get; set; }

    public Squer()
    {
        this.ElementForm = "██";
    }

    public override string ToString()
    {
        return this.ElementForm!;
    }
}
