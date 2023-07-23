
namespace Tetris.Services;


using Tetris.Elements;
using Tetris.Factories;
using Tetris.Factories.Base;

public class FormService
{
    private IElementFactory elementFactory;
    public FormService()
    {
        this.elementFactory = new ElementFactory();
    }
    public longForm GetStick() 
    {
        return this.elementFactory.GetStick();
    }  
    public Squer GetSquer()
    {
        return this.elementFactory.GetSquer();
    }

    public newLevelForm GetNewLevelForm()
    {
        return this.elementFactory.GetNewLevelForm();
    }
    
}
