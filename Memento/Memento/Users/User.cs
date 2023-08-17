namespace Memento.Users;

using Memento.Blogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


public class USER
{
    public string? Name { get; set; }
    public string? SurName { get; set; }

    public string? imagePath { get; set; }

    public BlogMemento Save()
    {
        return new BlogMemento()
        {
            Name = this.Name,
            SurName = this.SurName,
            imagePath = this.imagePath,
        };
    }

    public void Restore(BlogMemento memento)
    {
        this.Name = memento.Name;
        this.SurName = memento.SurName;
        this.imagePath = memento.imagePath;
    }

    //public USER(string name, string surName, string path)
    //{
    //    Name = name;
    //    SurName = surName;
    //    this.imagePath = path;

    //}

    public static List<USER> loadFromJson()
    {
        var json = File.ReadAllText("JsonFile/Users.json");

        return JsonSerializer.Deserialize<List<USER>>(json);
    }
}
