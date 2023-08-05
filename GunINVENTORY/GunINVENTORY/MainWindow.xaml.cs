using GunINVENTORY.ChangePicMethod;
using GunINVENTORY.Decorators;
using GunINVENTORY.Models;
using GunINVENTORY.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace GunINVENTORY;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public bool scoping { get; set; } = false;
    public bool maging { get; set; } = false;
    public bool silenting { get; set; } = false;


    public double DefaultBar { get; set; } = 60;  

    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = this;
        Console.WriteLine(this.DefaultBar);
    }

    private void t(object sender, MouseButtonEventArgs e)
    {
        this.silenting = true;
        this.Red_DotImage.IsEnabled = false;
        this.Red_DotImage.Opacity = 0.2;
        Gun m416 = new M416();
        m416 = new StealthSuppressor(m416);
        this.PowerBar.Value = m416.Power;
        this.CapacityBar.Value = m416.Capacity;
        this.RecoilBar.Value = m416.Recoil;
        var bitmapImage1 = new BitmapImage();
        if (this.scoping == true && this.maging == true)
        {
            this.m_416.Source = bitmapImage1.ChangePic("Assets/FullM416.png");
            

        }
        else if(this.scoping == false && this.maging == true)
        {
            this.m_416.Source = bitmapImage1.ChangePic("Assets/m416MagSilent.png");
        }
        else if(this.scoping == true && this.maging == false)
        {
            this.m_416.Source = bitmapImage1.ChangePic("Assets/m416ScopeSilent.png");
        }
        else
            this.m_416.Source = bitmapImage1.ChangePic("Assets/m416Silenter.png");

    }

    private void Mag_Click(object sender, MouseButtonEventArgs e)
    {
        this.maging = true;
        this.MagazineImage.IsEnabled = false;
        this.MagazineImage.Opacity = 0.2;
        Gun m416 = new M416();
        m416 = new ExtendedQuickDrawMag(m416);
        
        this.RecoilBar.Value = m416.Recoil;
        this.RangeBar.Value = m416.Range;
        
        var bitmapImage1 = new BitmapImage();

        if (this.scoping == true && this.silenting == true)
        {
            this.m_416.Source = bitmapImage1.ChangePic("Assets/FullM416.png");


        }
        else if (this.scoping == false && this.silenting == true)
        {
            this.m_416.Source = bitmapImage1.ChangePic("Assets/m416MagSilent.png");
        }
        else if (this.scoping == true && this.silenting == false)
        {
            this.m_416.Source = bitmapImage1.ChangePic("Assets/m416ScopMag.png");
        }
        else
            this.m_416.Source = bitmapImage1.ChangePic("Assets/m416Magazin.png");

    }

    private void Scope_Click(object sender, MouseButtonEventArgs e)
    {
        this.scoping = true;
        this.ScopeImage.IsEnabled = false;
        this.ScopeImage.Opacity = 0.2;
        Gun m416 = new M416();
        m416 = new RedDot(m416);
        
        this.FiringSpeedBar.Value = m416.FiringSpeed;
        this.RangeBar.Value = m416.Range;

        var bitmapImage1 = new BitmapImage();


        if (this.maging == true && this.silenting == true)
        {
            this.m_416.Source = bitmapImage1.ChangePic("Assets/FullM416.png");


        }
        else if (this.maging == false && this.silenting == true)
        {
            this.m_416.Source = bitmapImage1.ChangePic("Assets/m416ScopeSilent.png");
        }
        else if (this.maging == true && this.silenting == false)
        {
            this.m_416.Source = bitmapImage1.ChangePic("Assets/m416ScopMag.png");
        }
        else
            this.m_416.Source = bitmapImage1.ChangePic("Assets/m416Scope.png");

    }

    private void Again_Click(object sender, RoutedEventArgs e)
    {
        Console.WriteLine(this.DefaultBar);
        double defBar = 60;
        this.scoping = false;
        this.maging = false;
        this.silenting = false;
        this.Red_DotImage.IsEnabled = true;
        this.MagazineImage.IsEnabled = true;
        this.ScopeImage.IsEnabled = true;
        var bitmapImage1 = new BitmapImage();
        this.m_416.Source = bitmapImage1.ChangePic("Assets/M416.png");
        this.MagazineImage.Opacity = 1;
        this.Red_DotImage.Opacity = 1;
        this.ScopeImage.Opacity = 1;
        this.CapacityBar.Value = defBar;
        this.FiringSpeedBar.Value = defBar;
        this.RecoilBar.Value = defBar;
        this.PowerBar.Value = defBar;
        this.RangeBar.Value = defBar;
        

    }
}
