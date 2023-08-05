namespace GunINVENTORY.Models; 

using GunINVENTORY.Decorators.Base;
using GunINVENTORY.Models.Base;
public class ExtendedQuickDrawMag : GunDecorator
{
    public ExtendedQuickDrawMag(Gun wrappe) : base(wrappe)
    {
        this.power = 4;
        this.recoil = 20;
        this.capacity = 20;
    }

}
