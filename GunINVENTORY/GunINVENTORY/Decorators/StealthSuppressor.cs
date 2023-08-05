namespace GunINVENTORY.Decorators;

using GunINVENTORY.Decorators.Base;
using GunINVENTORY.Models.Base;
public class StealthSuppressor : GunDecorator
{

    public StealthSuppressor(Gun wrappe) : base(wrappe)
    {
        this.range = -10;
        this.recoil = 10;
        this.capacity = 60;
        this.power = -50;
    }

}
