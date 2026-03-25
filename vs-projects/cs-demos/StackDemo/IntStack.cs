using System.Security.Cryptography;

namespace ConceptArchitect.Collection;

public class IntStack
{
    int [] elements;
    int top=0;

    public IntStack(int size)
    {
        elements=new int[size];
    }

    public bool IsEmpty{get{ return top==0; }}

    public bool IsFull { get {return top==elements.Length; }}

    public void Push(int value)
    {
        if(IsFull)
            throw new StackOverflowException();
        elements[top++]=value;
    }

    public int Pop()
    {
        if(IsEmpty)
            throw new StackUnderflowException();
        return elements[--top];
    }

    public int Peek()
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

[Serializable]
internal class StackUnderflowException : Exception
{
    public StackUnderflowException()
    {
    }

    public StackUnderflowException(string? message) : base(message)
    {
    }

    public StackUnderflowException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}