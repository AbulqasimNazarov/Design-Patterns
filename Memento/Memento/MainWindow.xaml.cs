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
using System.Reflection;
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
    public USER blog;
    public BlogCaretaker _caretaker;
    public List<USER> blogs = new List<USER>();

    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = this;
        this.blog = new USER();
        this._caretaker = new BlogCaretaker(this.blog);
        string json = File.ReadAllText("JsonFile/Users.json");

        //this.blogs = LoadJson();

        //this.textBoxName.Text = this.blogs[this.blogs.Count - 1].Name;
        //this.textBoxSurName.Text = this.blogs[this.blogs.Count - 1].Surname; 
        //this.textBoxDescription.Text = this.blogs[this.blogs.Count - 1].Description;
        //this.photoImage.Source = this.blogs[this.blogs.Count - 1].PathImage;  //(BitmapImage?)this.photoImage.Source;


    }

    public List<USER> LoadJson()
    {
        string json = File.ReadAllText("JsonFile/Users.json");

        return JsonSerializer.Deserialize<List<USER>>(json);
    }


    private void buttonSave_Click(object sender, RoutedEventArgs e)
    {
        this.blog.Name = this.textBoxName.Text;
        this.blog.Surname = this.textBoxSurName.Text;
        this.blog.Description = this.textBoxDescription.Text;
        this.blog.PathImage = (BitmapImage?)this.photoImage.Source;

        this._caretaker.Save();

    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        //this.blogs.Add(this.blog);
        string json = JsonSerializer.Serialize(this.blog);

        File.WriteAllText("JsonFile/Users.json", json);
    }

    private void buttonBack_Click(object sender, RoutedEventArgs e)
    {
        this._caretaker.Load();
        this._caretaker.Load();
        this.textBoxName.Text = this.blog.Name;
        this.textBoxSurName.Text = this.blog.Surname;
        this.textBoxDescription.Text = this.blog.Description;
        var bitmapImage = new BitmapImage();
        this.photoImage.Source = this.blog.PathImage;
    }


    private void buttonNext_Click(object sender, RoutedEventArgs e)
    {
        this._caretaker.Redo(); // Move to the next saved state

        this.textBoxName.Text = this.blog.Name;
        this.textBoxSurName.Text = this.blog.Surname;
        this.textBoxDescription.Text = this.blog.Description;
        var bitmapImage = new BitmapImage();
        this.photoImage.Source = this.blog.PathImage;
    }
}
