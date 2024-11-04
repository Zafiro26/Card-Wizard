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
            deck.Shuffle();
            
        }
	}

    /*
    * Draws cards from the main deck and are moved to the used_deck.
    * @param ammount, number of cards that want to be drawn.
    * @return list of the cards drawn.
    */
    public List<Card> draw(int ammount)
    {

        List<Card> r = new List<Card>();

        for (int i = 0; i < ammount; i++)
        {
            Card c = deck.Pop();
            r.Add(c);
            used_deck.Push(c);
        }

        return r;
        
    }

    public void add_used_deck(Card c)
    {

    }

}
