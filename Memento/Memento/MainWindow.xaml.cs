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
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<USER> people = new List<USER>();
    public List<string> titles = new List<string>();
    public USER u1 = new USER();
    public int Index = 0;
    private BlogCaretaker caretaker;
    private USER _originator = new USER();
    private BlogCaretaker _caretaker = new BlogCaretaker();
    private List<BlogMemento> _redoMementos = new List<BlogMemento>();

    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = this;
        //this.textBoxSurName.Text = "22";

        //this.people = USER.loadFromJson();
        //this.caretaker = new BlogCaretaker(this.u1);
        //u1.Name = people[Index].Name;
        //u1.SurName = people[Index].SurName;
        //u1.imagePath = people[Index].imagePath;
        //this.textBoxSurName.Text = u1.SurName;
        //this.textBoxName.Text = u1.Name;
        //caretaker.Save();
        //var bitmapImage1 = new BitmapImage();
        //this.photoImage.Source = bitmapImage1.ChangePic(u1.imagePath!);
        //caretaker.Save();
        //caretaker.Load();
        //people = User.loadFromJson("./JsonFile/Users.json");
        //this.textBoxSurName.Text = people[0].SurName;

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


    private void SaveState()
    {
        
    }

    private void UpdateTextBoxes()
    {
        
    }

    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        BlogMemento memento = _caretaker.RestoreMemento(ref this.Index);
        if (memento != null)
        {
            _originator.SetMemento(memento);
            this.textBoxName.Text = _originator.FirstName;
            this.textBoxSurName.Text = _originator.LastName;
        }
    }

    private void ForwardButton_Click(object sender, RoutedEventArgs e)
    {
        if (this.Index < _redoMementos.Count - 1)
        {
            this.Index++;
        }
        if (_redoMementos.Count > 0)
        {
            BlogMemento redoMemento = _redoMementos[this.Index];
            _caretaker.SaveMemento(_originator.CreateMemento(this.FirstName, this.LastName));

            _originator.SetMemento(redoMemento);
            this.textBoxName.Text = _originator.FirstName;
            this.textBoxSurName.Text = _originator.LastName;
        }

        
        //else
        //{
        //    this.textBoxName.Text = string.Empty;
        //    this.textBoxSurName.Text = string.Empty;
        //}
        
        //this.caretaker.Load();
        //this.Index++;
        //this.u1.Name = "OK";
    }



    



    private void buttonSave_Click(object sender, RoutedEventArgs e)
    {
        BlogMemento currentMemento = _originator.CreateMemento(this.FirstName, this.LastName);
        _caretaker.SaveMemento(currentMemento);
        _redoMementos.Add(currentMemento);
        this.textBoxName.Text = string.Empty;
        this.textBoxSurName.Text = string.Empty;
        this.Index++;
    }
}
