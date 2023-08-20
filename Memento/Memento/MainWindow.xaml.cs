namespace Memento;

using Memento.Blogs;
using Memento.ChangePic;
using Memento.Users;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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
    public List<BlogMemento> blogs = new List<BlogMemento>();
    public int index = 0;

    public MainWindow()
    {
        InitializeComponent();
        
        this.blogs = USER.LoadJson();
        
        index = this.blogs.Count - 1;
        var bitmapImage = new BitmapImage();
        //"PathImage": "Assets/BobMarley.jpg"
        this.blog = new USER();
        this._caretaker = new BlogCaretaker(this.blog);
        this._caretaker.mementos = this.blogs;
        this._caretaker.Counter = this._caretaker.mementos.Count - 1;
        //this._caretaker.Save();
        this.textBoxName.Text = this.blogs[index].Name;
        this.textBoxSurName.Text = this.blogs[index].Surname;
        this.textBoxDescription.Text = this.blogs[index].Description;
        this.photoImage.Source = bitmapImage.ChangePic(this.blogs[index].PathImage);


    }





    private void UploadButton_Click(object sender, RoutedEventArgs e)
    {
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


    private void buttonSave_Click(object sender, RoutedEventArgs e)
    {
        this.blog.Name = this.textBoxName.Text;
        this.blog.Surname = this.textBoxSurName.Text;
        this.blog.Description = this.textBoxDescription.Text;
        this.blog.PathImage = this.photoImage.Source.ToString();

        //this.blogs.Add(this.blog);
        this._caretaker.Save();

    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        //this.blogs.Add(this.blog);
        //this.blogs?.Add(this.blog);
        string json = JsonSerializer.Serialize(this.blogs);

        File.WriteAllText("JsonFile/Users.json", json);
    }

    private void buttonBack_Click(object sender, RoutedEventArgs e)
    {
        this._caretaker.Load();
        //this._caretaker.Load();
        this.textBoxName.Text = this.blog.Name;
        this.textBoxSurName.Text = this.blog.Surname;
        this.textBoxDescription.Text = this.blog.Description;
        var bitmapImage = new BitmapImage();
        this.photoImage.Source = bitmapImage.ChangePic(this.blog.PathImage);
    }


    private void buttonNext_Click(object sender, RoutedEventArgs e)
    {
        this._caretaker.Redo(); // Move to the next saved state

        this.textBoxName.Text = this.blog.Name;
        this.textBoxSurName.Text = this.blog.Surname;
        this.textBoxDescription.Text = this.blog.Description;
        var bitmapImage = new BitmapImage();
        this.photoImage.Source = bitmapImage.ChangePic(this.blog.PathImage);
    }
}
