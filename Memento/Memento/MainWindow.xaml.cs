namespace Memento;

using Memento.Blogs;
using Memento.ChangePic;
using Memento.Users;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
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
using System.Xml.Linq;


/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public List<USER> people = new List<USER>();
    public USER u1 = new USER();
    public int Index = 0;
    private BlogCaretaker caretaker = new BlogCaretaker();


    public MainWindow()
    {
        InitializeComponent();
        this.people = USER.loadFromJson();
        
        u1.Name = people[Index].Name;
        u1.SurName = people[Index].SurName;
        u1.imagePath = people[Index].imagePath;
        this.textBoxSurName.Text = u1.SurName;
        this.textBoxName.Text = u1.Name;
        var bitmapImage1 = new BitmapImage();
        this.photoImage.Source = bitmapImage1.ChangePic(u1.imagePath!);
        //caretaker.Save();
        //caretaker.Load();
        //people = User.loadFromJson("./JsonFile/Users.json");
        //this.textBoxSurName.Text = people[0].SurName;

    }

    private void UploadButton_Click(object sender, RoutedEventArgs e)
    {
        //this.people[0].SurName = "ok";
        

        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";

        if (openFileDialog.ShowDialog() == true)
        {
            try
            {
                BitmapImage image = new BitmapImage(new Uri(openFileDialog.FileName));
                photoImage.Source = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }


    private void SaveState()
    {
        caretaker.AddMemento(new BlogMemento(this.textBoxName.Text, this.textBoxSurName.Text));
    }

    private void UpdateTextBoxes()
    {
        this.textBoxName.Text = people[this.Index].Name;
        this.textBoxSurName.Text = people[this.Index].SurName;
        var bitmapImage1 = new BitmapImage();
        this.photoImage.Source = bitmapImage1.ChangePic(people[this.Index].imagePath!);
    }

    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        BlogMemento previousMemento = caretaker.GetPreviousMemento();
        if (previousMemento != null)
        {
            this.textBoxName.Text = previousMemento.Name;
            this.textBoxSurName.Text = previousMemento.SurName;
        }
    }

    private void ForwardButton_Click(object sender, RoutedEventArgs e)
    {
        BlogMemento nextMemento = caretaker.GetNextMemento();
        if (nextMemento != null)
        {
            this.textBoxName.Text = nextMemento.Name;
            this.textBoxSurName.Text = nextMemento.SurName;
        }
    }

    
  
}
