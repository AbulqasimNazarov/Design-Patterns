namespace GunINVENTORY.Decorators;

using GunINVENTORY.Decorators.Base;
using GunINVENTORY.Models.Base;

public class RedDot : GunDecorator
{
    public RedDot(Gun wrappe) : base(wrappe)
    {
        this.Power = 20;
        this.Recoil = -3;
    }

}
