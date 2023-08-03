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
    public MainWindow()
    {
        InitializeComponent();
    }

    private void t(object sender, MouseButtonEventArgs e)
    {
        this.Red_Dot.IsEnabled = false;
        this.Red_Dot.Opacity = 0.2;
        Gun m416 = new M416();
        m416 = new RedDot(m416);
        this.PowerBar.Value = m416.Power;
        this.FiringSpeedBar.Value = m416.FiringSpeed;
        this.RecoilBar.Value = m416.Recoil;
        var bitmapImage1 = new BitmapImage();
        this.m_416.Source = bitmapImage1.ChangePic("Assets/m416Silenter.png");
    }

    private void Mag_Click(object sender, MouseButtonEventArgs e)
    {
        //this.Magazine.IsEnabled = false;
        //this.Magazine.Opacity = 0.2;
        //Gun m416 = new M416();
        ////this.PowerBar.Value = m416.Power;
        //var bitmapImage1 = new BitmapImage();
        //this.m_416.Source = bitmapImage1.ChangePic("Assets/m416Magazin.png");
    }







}
