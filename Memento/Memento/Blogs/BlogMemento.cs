using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Blogs;

public class BlogMemento
{
    public readonly DateTime CreationDate;


    public string FirstName { get; }
    public string LastName { get; }

    public BlogMemento(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    //public string? Name { get; set; }
    //public string? SurName { get; set; }

    //public string? imagePath { get; set; }


    //public BlogMemento()
    //{
    //    this.CreationDate = DateTime.Now;
    //}
}
