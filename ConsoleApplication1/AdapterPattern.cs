using System.Collections;

namespace ConsoleApplication1
{
    public class clsCollection : CollectionBase
    {
        public virtual void Add(string str)
        {
            List.Add(str);
        }
    }
    public class clsStack : Stack
    {
        public void Push(string str)
        {
            this.Push(str);
        }
    }

    //OBject adaper pattern

    public class clsObjectCollectionAdapter : CollectionBase
    {
        clsStack objStack = new clsStack();
        public void Add(string str)
        {
            objStack.Push(str);
        }
    }

    //Class Adapter pattern
    public class clsClassCollectionAdapter : clsStack
    {
        public void Add(string str)
        {
            this.Push(str);
        }
    }
}
