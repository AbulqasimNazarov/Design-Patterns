using Memento.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Blogs;

public class BlogCaretaker
{
    private List<BlogMemento> _mementos = new List<BlogMemento>();

    public void SaveMemento(BlogMemento memento)
    {
        _mementos.Add(memento);
    }

    public BlogMemento RestoreMemento(ref int index)
    {
        if (_mementos.Count > 0)
            return _mementos[index -1];
        else
            return null;
    }
    //private List<BlogMemento> mementos = new List<BlogMemento>();
    //public USER Originator;
    //public int loadCounter = 0;

    //public BlogCaretaker(USER originator)
    //{
    //    this.Originator = originator;
    //}

    //public void Save()
    //{
    //    this.loadCounter = 0;
    //    var memento = this.Originator.Save();
    //    this.mementos.Add(memento);
    //}

    //public void Load()
    //{
    //    if (this.mementos == null)
    //        return;

    //    var currentMemento = this.mementos.SkipLast(loadCounter++).LastOrDefault();

    //    if (currentMemento == null)
    //        return;

    //    this.Originator.Restore(currentMemento);
    //}
}
