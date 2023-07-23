
namespace Tetris.Factories.Base;


using Tetris.Elements;

public interface IElementFactory
{
    longForm GetStick();

    Squer GetSquer();

    newLevelForm GetNewLevelForm();
}
