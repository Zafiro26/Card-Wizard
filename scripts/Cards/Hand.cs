using Godot;
using System;
using System.Collections.Generic;

public partial class Hand : Node2D
{

    private int max_hand = 4;
    private List<Card> hand;
    private Deck deck;
    private int used_hand = 0;
    private Player player;
    private List<Label> labels;
    
    public override void _Ready()
	{
        hand = new List<Card>();
        labels = new List<Label>();
        deck = GetNode<Deck>("Deck");
        hand = deck.draw(max_hand);
        player = (Player)GetTree().GetFirstNodeInGroup("Player");
        
        labels.Add(GetNode<Label>("CanvasLayer/Label"));
        labels.Add(GetNode<Label>("CanvasLayer/Label2"));
        labels.Add(GetNode<Label>("CanvasLayer/Label3"));
        labels.Add(GetNode<Label>("CanvasLayer/Label4"));
        update_card();
    }

    public override void _PhysicsProcess(double delta)
	{

        if (Input.IsActionJustPressed("Draw"))
        {
            hand = deck.draw(max_hand);
            update_card();
        }
        
    }

    private void update_card()
    {
        for (int i = 0; i < 4; i++)
        {
            labels[i].Text = "Name: " + hand[i].Name + " Usages: " + hand[i].usages;
            //labels[i].Text = "" + i;
        }
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
            
            if (c.Cast_card(player))
            {
                used_hand++;
            }
            
        }
        update_card();
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