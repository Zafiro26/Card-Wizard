using Godot;
using System;

public partial class Attack : State
{

    public Hand hand;
	// Called when the node enters the scene tree for the first time.
	public override void Ready()
	{
        hand = GetNode<Hand>("hand");
	}

    public override void Enter()
    {
        if (Input.IsActionJustPressed("Cast_card1"))
        {
            hand.play_card(0);
        }
        else if (Input.IsActionJustPressed("Cast_card2"))
        {
            hand.play_card(1);
        }
        else if (Input.IsActionJustPressed("Cast_card3"))
        {
            hand.play_card(2);
        }
        else if (Input.IsActionJustPressed("Cast_card4"))
        {
            hand.play_card(3);
        }

        fsm.TransitionTo("castCard");

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
