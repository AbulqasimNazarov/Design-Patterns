
namespace Tetris.Elements;


using Tetris.Elements.Base;

public class Squer : Element
{
    private string elementForm { get; set; }
    public override string Form { get => elementForm; set => elementForm = value; } 
    public Squer()
    {
        this.elementForm = "██";
    }

    public override string ToString()
    {
        return this.Form!;
    }
}
