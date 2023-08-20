using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Memento.Blogs;

public class BlogMemento
{
    public readonly DateTime snimok;

    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Description { get; set; }
    public BitmapImage? PathImage { get; set; }

    public BlogMemento()
    {
        this.snimok = DateTime.Now;
    }
}
