namespace Memento.Users;

using Memento.Blogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

public class USER
{
    public List<USER> uSERs= new List<USER>();
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Description { get; set; }
    public string? PathImage { get; set; }

    public BlogMemento Save()
    {
        var mem = new BlogMemento()
        {
            Name = this.Name,
            Surname = this.Surname,
            Description = this.Description,
            PathImage = this.PathImage,
        };


        return mem;
    }


    public void Restore(BlogMemento memento)
    {
        this.Name = memento.Name;
        this.Surname = memento.Surname;
        this.Description = memento.Description;
        this.PathImage = memento.PathImage;
    }

    public static List<BlogMemento> LoadJson()
    {
        string json = File.ReadAllText("JsonFile/Users.json");

        return JsonSerializer.Deserialize<List<BlogMemento>>(json)!;
    }

}
