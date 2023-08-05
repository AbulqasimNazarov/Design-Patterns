

using System.Windows.Media.Imaging;
using System;

namespace GunINVENTORY.Models.Base;

public abstract class Gun
{
    public virtual double Power { get; set; }
    public virtual double Recoil { get; set; }
    public virtual double FiringSpeed { get; set; }
    public virtual double Capacity { get; set; }
    public virtual double Range { get; set; }

}
