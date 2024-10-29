using Godot;
using System;
using System.Collections.Generic;

public partial class Deck : Node
{

    private Stack<Card> deck;
    private Stack<Card> used_deck;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        deck = new Stack<Card>();
        used_deck = new Stack<Card>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
        if (deck.Count == 0) {
            deck = used_deck;
            used_deck.Clear();
            
        }
	}

    public static Stack<T> Shuffle<T>(this Stack<T> stack)
{
    List<T> list = stack.ToList();
    list.Shuffle();
    return list.ToStack();
}

    public static void Shuffle<T> ( this List<T> list )
    {
        for ( int i = 0; i < list.Count; i++ )
        {
            int num = Form1.rnd.Next ( list.Count );
            T temp = list[i];
            list[i] = list[num];
            list[num] = temp;
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
