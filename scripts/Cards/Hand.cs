using Godot;
using System;
using System.Collections.Generic;

public partial class Hand : Node
{

    private int max_hand = 4;
    private List<Card> hand;
    private Deck deck;

    public override void _Ready()
	{
        hand = new List<Card>();
        deck = GetNode<Deck>("deck");
    }

    public override void _PhysicsProcess(double delta)
	{
        
    }

    /*
    * Cast the card
    * @param n, position in hand from right to left of the card to cast
    */
    public void play_card(int n)
    {
        if (n < 0 || n >= max_hand)
        {
            GD.Print("Carta fuera de mano");
        }
        else
        {
            Card c = hand[n];
            if (!c.Cast_card())
            {
                hand.RemoveAt(n);
            }
        }
    }

    public int add_max_hand(int add)
    {
        max_hand += add;
        return max_hand;
    }

    public int add_max_hand()
    {
        max_hand++;
        return max_hand;
    }

    public int reduce_max_hand(int reduce)
    {
        max_hand -= reduce;
        return max_hand;
    }

    public int reduce_max_hand()
    {
        max_hand--;
        return max_hand;
    }

}