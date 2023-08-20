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
    private int Counter = 0;
    private List<BlogMemento> mementos = new List<BlogMemento>();
    private List<BlogMemento> _redoStates = new List<BlogMemento>();

    private readonly USER originator;
    public BlogCaretaker(USER blog)
	{
        this.originator = blog;
	}

    public void Save()
    {
        this.Counter = 0;
        var memento = this.originator.Save();
        this.mementos.Add(memento);
    }

    public void Load()
    {
        if (this.mementos == null)
            return;

        var currentMemento = this.mementos.SkipLast(this.Counter++).LastOrDefault();

        if (currentMemento == null)
            return;

        this.originator.Restore(currentMemento);
    }


    public void Redo()
    {
        if (this.mementos == null)
            return;

        var currentMemento = this.mementos.SkipLast(this.Counter--).LastOrDefault();

        if (currentMemento == null)
            return;

        this.originator.Restore(currentMemento);
        
    }
}
