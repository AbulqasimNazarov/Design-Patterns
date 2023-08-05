


namespace GunINVENTORY.Models;

using GunINVENTORY.Models.Base;
using System.Runtime.CompilerServices;

public class M416 : Gun
{
    
    public M416()
    {
       
        this.Power = 90;
        this.Recoil = 15;
        this.FiringSpeed = 65;
        this.Capacity = 30;
        this.Range = 80;
    }

}
