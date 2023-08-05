namespace GunINVENTORY.Decorators;

using GunINVENTORY.Decorators.Base;
using GunINVENTORY.Models.Base;

public class RedDot : GunDecorator
{
    public RedDot(Gun wrappe) : base(wrappe)
    {
        this.power = 5;
        this.recoil = 13;
        this.capacity = 0;
    }

}
