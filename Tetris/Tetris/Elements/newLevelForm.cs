

namespace Tetris.Elements;

using Tetris.Elements.Base;
public class newLevelForm : Element
{
    private string elementForm { get; set; }
    public override string Form { get => elementForm; set => elementForm = value; }
    //public override string Form { set => throw new NotImplementedException(); }

    public newLevelForm()
    {

        this.elementForm = "░░░░";

    }

    public override string ToString()
    {
        return this.Form!;
    }
}
