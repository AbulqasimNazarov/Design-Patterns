
namespace GunINVENTORY.Decorators.Base;


using GunINVENTORY.Models.Base;

public abstract class GunDecorator : Gun
{
    protected Gun wrappe;

    protected double firingSpeed;
    protected double recoil;
    protected double power;

    
    public override double Power => this.wrappe.Power + this.power;
    public override double Recoil => this.wrappe.Recoil + this.recoil;
    public override double FiringSpeed => this.wrappe.FiringSpeed + this.firingSpeed;
    public GunDecorator(Gun wrappe) => this.wrappe = wrappe;
}
