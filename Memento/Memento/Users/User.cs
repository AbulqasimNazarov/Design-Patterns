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

    private string _firstName;
    private string _lastName;


    public string FirstName
    {
        get => _firstName;
        set => _firstName = value;
    }

    public string LastName
    {
        get => _lastName;
        set => _lastName = value;
    }

    public BlogMemento CreateMemento(string _firstName,string _lastName)
    {
        return new BlogMemento(_firstName, _lastName);
    }

    public void SetMemento(BlogMemento memento)
    {
        _firstName = memento.FirstName;
        _lastName = memento.LastName;
    }

    //public string? Name { get; set; }
    //public string? SurName { get; set; }

    //public string? imagePath { get; set; }

    //public BlogMemento Save()
    //{
    //    return new BlogMemento()
    //    {
    //        Name = this.Name,
    //        SurName = this.SurName,
    //        imagePath = this.imagePath,
    //    };
    //}

    //public void Restore(BlogMemento memento)
    //{
    //    this.Name = memento.Name;
    //    this.SurName = memento.SurName;
    //    this.imagePath = memento.imagePath;
    //}


    //public static List<USER> loadFromJson()
    //{
    //    var json = File.ReadAllText("JsonFile/Users.json");

    //    return JsonSerializer.Deserialize<List<USER>>(json);
    //}
}
