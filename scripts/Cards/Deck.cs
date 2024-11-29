using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

public partial class Deck : Node
{

    private Stack<Card> deck;
    private Stack<Card> used_deck;
    public Hand hand;
    

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        hand = GetNode<Hand>("Hand");
        deck = new Stack<Card>();
        //used_deck = new Stack<Card>();
        load_cards();
        hand.hand = draw(hand.max_hand);
        hand.update_hand();
        
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{

        if (Input.IsActionJustPressed("Draw"))
        {
            hand.hand = draw(hand.max_hand);
            hand.update_hand();
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
            if (deck.Count <= 0)
            {
                //used_deck_to_deck();
                load_cards();
            }
            Card c = deck.Pop();
            r.Add(c);
            //used_deck.Push(c);
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

    public void load_cards()
    {
        PackedScene tmp;

        tmp = GD.Load<PackedScene>("res://scenes/Cards/fireball_card.tscn");
        Card n = (Card)tmp.Instantiate();
        deck.Push(n);

        tmp = GD.Load<PackedScene>("res://scenes/Cards/fireball_card.tscn");
        Card n2 = (Card)tmp.Instantiate();
        deck.Push(n2);

        tmp = GD.Load<PackedScene>("res://scenes/Cards/healing_card.tscn");
        Card n3 = (Card)tmp.Instantiate();
        deck.Push(n3);

        //tmp = GD.Load<PackedScene>("res://scenes/Cards/healing_card.tscn");
        //Card n4 = (Card)tmp.Instantiate();
        //deck.Push(n4);

        tmp = GD.Load<PackedScene>("res://scenes/Cards/fireball_card.tscn");
        Card n4 = (Card)tmp.Instantiate();
        deck.Push(n4);

        tmp = GD.Load<PackedScene>("res://scenes/Cards/frozen_arrow_card.tscn");
        Card n5 = (Card)tmp.Instantiate();
        deck.Push(n5);

        tmp = GD.Load<PackedScene>("res://scenes/Cards/frozen_arrow_card.tscn");
        Card n6 = (Card)tmp.Instantiate();
        deck.Push(n6);

        tmp = GD.Load<PackedScene>("res://scenes/Cards/poison_arrow_card.tscn");
        Card n7 = (Card)tmp.Instantiate();
        deck.Push(n7);

        tmp = GD.Load<PackedScene>("res://scenes/Cards/poison_arrow_card.tscn");
        Card n8 = (Card)tmp.Instantiate();
        deck.Push(n8);

        deck.Shuffle();

        
    }

}
