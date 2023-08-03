

using System.Windows.Media.Imaging;
using System;

namespace GunINVENTORY.Models.Base;

public abstract class Gun
{
    public virtual double Power { get; set; }
    public virtual double Recoil { get; set; }
    public virtual double FiringSpeed { get; set; }

    //public BitmapImage ChangePic(BitmapImage t, string path)
    //{
    //    t.BeginInit();
    //    t.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);

    //    t.EndInit();

    //    return t;
    //}





}
