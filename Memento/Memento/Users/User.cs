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
    
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Description { get; set; }
    public BitmapImage? PathImage { get; set; }

    public BlogMemento Save()
    {
        return new BlogMemento()
        {
            Name = this.Name,
            Surname = this.Surname,
            Description = this.Description,
            PathImage = this.PathImage,
        };
    }


    public void Restore(BlogMemento memento)
    {
        this.Name = memento.Name;
        this.Surname = memento.Surname;
        this.Description = memento.Description;
        this.PathImage = memento.PathImage;
    }

}
