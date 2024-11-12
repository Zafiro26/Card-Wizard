using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

//Clase estatica que añade la funcion de mezclar para las pilas
public static class ShuffleClass
{

    private static Random rnd = new Random();
    
    /*
    * Shuffles the stack
    * @Param stack, the stack that is going to get shuffle
    */
    public static void Shuffle<T>(this Stack<T> stack)
    {
        var values = stack.ToArray();
        stack.Clear();
        foreach (var value in values.OrderBy(x => rnd.Next()))
        {
            stack.Push(value);
        }

        GD.Print("Shuffling deck");
    }


    public static Stack<T> ToStack<T> ( this List<T> list )
    {
        Stack<T> stack = new Stack<T> ();
        foreach ( T t in list )
            stack.Push ( t );

        return stack;
    }

}