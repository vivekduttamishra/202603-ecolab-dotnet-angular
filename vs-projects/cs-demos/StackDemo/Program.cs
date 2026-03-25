using ConceptArchitect.Collection;


class Application
{
    static void Main()
    {
        TestGenericStack();
    }





    private static void TestGenericStack()
    {
        var names = new GenericStack<string>(5);

        var numbers = new GenericStack<int>(10);

        names.Push("India");
        names.Push("USA");

        while(! names.IsEmpty)
            System.Console.WriteLine(names.Pop().ToUpper());




    }

    private static void TestObjectStack2()
    {
        ObjectStack names = new ObjectStack(5);

        names.Push("India");
        names.Push("USA");
        names.Push("France");
        System.Console.WriteLine(names);

        //we know names should hold only string
        //C# doesn't

        names.Push(7);
        names.Push("Germany");

        while(! names.IsEmpty)
        {
            var name = (string) names.Pop();  //fails when converting 7 to string
            System.Console.WriteLine(name.ToUpper());
        }


    }

    private static void TestIntStack()
    {
        var stack = new IntStack(5);
        System.Console.WriteLine(stack);

        stack.Push(1);
        stack.Push(3);
        stack.Push(8);

        System.Console.WriteLine(stack);

        stack.Push(5);
        stack.Push(7);





        System.Console.WriteLine(stack);

        try
        {

            stack.Push(9); //will throw error
        }
        catch //catch anything
        {
            System.Console.WriteLine("Stack is full");
        }

        while (!stack.IsEmpty)
            System.Console.WriteLine("Popping " + stack.Pop());
    }
    private static void TestObjectStack()
    {
        var stack = new ObjectStack(5);
        System.Console.WriteLine(stack);

        stack.Push(1);
        stack.Push(3);
        stack.Push(8);

        System.Console.WriteLine(stack);

        stack.Push(5);
        stack.Push(7);





        System.Console.WriteLine(stack);

        try
        {

            stack.Push(9); //will throw error
        }
        catch //catch anything
        {
            System.Console.WriteLine("Stack is full");
        }

        while (!stack.IsEmpty)
            System.Console.WriteLine("Popping " + stack.Pop());
    }
}