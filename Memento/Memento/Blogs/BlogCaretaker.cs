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
    private int currentIndex = -1;
    private List<BlogMemento> mementos = new List<BlogMemento>();

    private readonly USER originator;
    public BlogCaretaker()
    {

    }
    public BlogCaretaker(USER originator)
    {
        this.originator = originator;
    }



    public BlogMemento GetPreviousMemento()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            return mementos[currentIndex];
        }
        return null;
    }

    public BlogMemento GetNextMemento()
    {
        if (currentIndex <= mementos.Count - 1)
        {
            currentIndex++;
            return mementos[currentIndex];
        }
        return null;
    }

    public void AddMemento(BlogMemento memento)
    {
        // Обрезать состояния после текущей позиции и добавить новое состояние
        mementos.RemoveRange(currentIndex + 1, mementos.Count - currentIndex - 1);
        mementos.Add(memento);
        currentIndex++;
    }
    //public void Save()
    //{
    //    loadCounter = 0;
    //    var memento = this.originator.Save();
    //    this.mementos.Add(memento);
    //}

    //public void Load()
    //{
    //    if (this.mementos == null)
    //        return;

    //    var currentMemento = this.mementos.SkipLast(loadCounter++).LastOrDefault();

    //    if (currentMemento == null)
    //        return;

    //    this.originator.Restore(currentMemento);
    //}
}
