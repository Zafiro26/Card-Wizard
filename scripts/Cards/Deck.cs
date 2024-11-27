using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

public partial class Deck : Node
{

    private Stack<Card> deck;
    private Stack<Card> used_deck;
    
    

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        deck = new Stack<Card>();
        used_deck = new Stack<Card>();
        

        //Test
        Card c1 = new Fireball();
        Card c2 = new Fireball();
        Card c3 = new Healing();
        Card c4 = new Healing();

        deck.Push(c1);
        deck.Push(c2);
        deck.Push(c3);
        deck.Push(c4);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
        
	}

    /*
    * Draws cards from the main deck and are moved to the used_deck.
    * @param ammount, number of cards that want to be drawn.
    * @return list of the cards drawn.
    */
    public List<Card> draw(int ammount)
    {

        List<Card> r = new List<Card>();

        if (deck.Count <= 0)
        {
            used_deck_to_deck();
        }

        for (int i = 0; i < ammount; i++)
        {
            
            Card c = deck.Pop();
            r.Add(c);
            used_deck.Push(c);
        }

        GD.Print("New hand");
        for (int i = 0; i < r.Count; i++)
        {
            GD.Print("Card in " + i + " is " + r[i].nombre);
        }

        return r;
        
    }

    //Moves the used_deck to the deck, meant to be used when deck is empty 
    private void used_deck_to_deck()
    {
        int f = used_deck.Count;
        for (int i = 0; i < f; i++)
        {
            deck.Push(used_deck.Pop());
        }
    }

    public void add_used_deck(Card c)
    {

    }

}
