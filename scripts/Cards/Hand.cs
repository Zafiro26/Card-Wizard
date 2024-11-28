using Godot;
using System;
using System.Collections.Generic;

public partial class Hand : Node2D
{

    public int max_hand = 4;
    public List<Card> hand;
    //private Deck deck;
    public int used_hand = 0;
    public Player player;
    public Dictionary<int, Vector2> posiciones;
    public CanvasLayer canvas;
    
    public override void _Ready()
	{
        hand = new List<Card>();
        //labels = new List<Label>();
        //deck = GetNode<Deck>("Deck");
        //hand = deck.draw(max_hand);
        player = (Player)GetTree().GetFirstNodeInGroup("Player");
        posiciones = new Dictionary<int, Vector2>();
        fill_dicitonary(posiciones);
        canvas = this.GetNode<CanvasLayer>("CanvasLayer");

        
        //labels.Add(GetNode<Label>("CanvasLayer/Label"));
        //labels.Add(GetNode<Label>("CanvasLayer/Label2"));
        //labels.Add(GetNode<Label>("CanvasLayer/Label3"));
        //labels.Add(GetNode<Label>("CanvasLayer/Label4"));
        
        /*
        tmp.Add(GetNode<Card>("CanvasLayer/Card"));
        tmp.Add(GetNode<Card>("CanvasLayer/Card2"));
        tmp.Add(GetNode<Card>("CanvasLayer/Card3"));
        tmp.Add(GetNode<Card>("CanvasLayer/Card4"));
        */
        
        //System.Threading.Thread.Sleep(1000);
        //update_hand();
    }

    public void update_hand()
    {
        
        foreach (Node n in canvas.GetChildren())
        {
            canvas.RemoveChild(n);
        }
        for (int i = 0; i < 4; i++)
        {
            GD.Print(hand[i].Name);
            canvas.AddChild(hand[i]);
            Vector2 v = posiciones[i];
            hand[i].Position = v;
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
        //update_hand();
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

    private void fill_dicitonary(Dictionary<int, Vector2> d)
    {
        Vector2 v;
        v.Y = 600;

        v.X = 750;
        d[0] = v;

        v.X = 850;
        d[1] = v;

        v.X = 950;
        d[2] = v;

        v.X = 1050;
        d[3] = v;
    }

}