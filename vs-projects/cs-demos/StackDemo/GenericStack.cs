using System.Security.Cryptography;

namespace ConceptArchitect.Collection;


//Item is our own notion for a type
public class GenericStack<Item>
{
    Item [] elements;
    int top=0;

    public GenericStack(int size)
    {
        elements=new Item[size];
    }

    public bool IsEmpty{get{ return top==0; }}

    public bool IsFull { get {return top==elements.Length; }}

    public void Push(Item value)
    {
        if(IsFull)
            throw new StackOverflowException();
        elements[top++]=value;
    }

    public Item Pop()
    {
        if(IsEmpty)
            throw new StackUnderflowException();
        return elements[--top];
    }

    public Item Peek()
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

