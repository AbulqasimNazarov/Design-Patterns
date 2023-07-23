

using Tetris.Elements;
using Tetris.Factories.Base;

namespace Tetris.Factories;

public class ElementFactory : IElementFactory
{
    public newLevelForm GetNewLevelForm()
    {
        newLevelForm razoqnutaya = new newLevelForm();
        return razoqnutaya; 
    }

    public Squer GetSquer()
    {
        Squer sq = new Squer();
        return sq;
    }

    public longForm GetStick()
    {
        longForm stick = new longForm();
        return stick;
    }
}
