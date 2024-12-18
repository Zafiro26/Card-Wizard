using Godot;
using System;

public partial class CastCardState : State
{

    //public Hand hand;
    public Deck deck;
	// Called when the node enters the scene tree for the first time.
	public override void Ready()
	{
        //hand = GetOwner<CharacterBody2D>().GetNode<Hand>("Hand");
        deck = GetOwner<CharacterBody2D>().GetNode<Deck>("Deck");
	}

    public override void Enter()
    {
        if (Input.IsActionJustPressed("Cast_card1"))
        {
            deck.hand.play_card(0);
        }
        else if (Input.IsActionJustPressed("Cast_card2"))
        {
            deck.hand.play_card(1);
        }
        else if (Input.IsActionJustPressed("Cast_card3"))
        {
            deck.hand.play_card(2);
        }
        else if (Input.IsActionJustPressed("Cast_card4"))
        {
            deck.hand.play_card(3);
        }

        fsm.TransitionTo("idle");

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
