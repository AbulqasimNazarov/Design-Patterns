using Memento.Users;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Blogs;

public class BlogCaretaker
{
    public int Counter = 0;
    public List<BlogMemento> mementos = new List<BlogMemento>();
    

    private readonly USER originator;
    public BlogCaretaker(USER blog)
	{
        this.originator = blog;
        
	}

    public void Save()
    {

        var memento = this.originator.Save();
        this.mementos.Add(memento);
    }

    public void Load()
    {

        if (this.mementos == null)
            return;

        if (this.Counter > 0)
        {
            this.Counter--;

        }
        var currentMemento = this.mementos[Counter];

        
        this.originator.Restore(currentMemento);
    }


    public void Redo()
    {
        if (this.mementos == null)
            return;


        if (this.Counter < mementos.Count - 1)
        {
            this.Counter++;
            
        }
        var currentMemento = this.mementos[Counter];

        this.originator.Restore(currentMemento);
        
        
    }
}
