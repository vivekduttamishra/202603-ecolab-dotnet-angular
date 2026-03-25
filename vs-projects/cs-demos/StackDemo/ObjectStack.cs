using System.Security.Cryptography;

namespace ConceptArchitect.Collection;

public class ObjectStack
{
    Object [] elements;
    int top=0;

    public ObjectStack(int size)
    {
        elements=new Object[size];
    }

    public bool IsEmpty{get{ return top==0; }}

    public bool IsFull { get {return top==elements.Length; }}

    public void Push(Object value)
    {
        if(IsFull)
            throw new StackOverflowException();
        elements[top++]=value;
    }

    public Object Pop()
    {
        if(IsEmpty)
            throw new StackUnderflowException();
        return elements[--top];
    }

    public Object Peek()
    {
        if(IsEmpty)
            throw new StackUnderflowException();
        return elements[top-1];
    }


    public void Clear()
    {
        top=0;
    }

    public override string ToString()
    {
        if(IsEmpty)
            return "Stack()";

        var str= "Stack" + ( IsFull? "[ ": "( " );

        for(var p = top-1; p>=0; p--)
            str+=$"{elements[p]}\t";

        str+= IsFull? "]" : ")";

        return str;
    }

}

