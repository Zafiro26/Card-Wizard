using System;
using System.Collections.Generic;
using System.Linq;

public static class ShuffleClass
{

    private static Random rnd = new Random();
    
    public static void Shuffle<T>(this Stack<T> stack)
    {
        var values = stack.ToArray();
        stack.Clear();
        foreach (var value in values.OrderBy(x => rnd.Next()))
        {
            stack.Push(value);
        }
    }


    public static Stack<T> ToStack<T> ( this List<T> list )
    {
        Stack<T> stack = new Stack<T> ();
        foreach ( T t in list )
            stack.Push ( t );

        return stack;
    }

}