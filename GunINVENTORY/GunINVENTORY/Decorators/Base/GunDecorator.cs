
namespace GunINVENTORY.Decorators.Base;


using GunINVENTORY.Models.Base;

public abstract class GunDecorator : Gun
{
    protected Gun wrappe;

    protected double firingSpeed;
    protected double recoil;
    protected double power;
    protected double capacity;
    protected double range;

    
    public override double Power => this.wrappe.Power + this.power;
    public override double Recoil => this.wrappe.Recoil + this.recoil;
    public override double FiringSpeed => this.wrappe.FiringSpeed + this.firingSpeed;
    public override double Capacity => this.wrappe.Capacity + this.capacity;
    public override double Range => this.wrappe.Range + this.range;
    public GunDecorator(Gun wrappe) => this.wrappe = wrappe;
}
