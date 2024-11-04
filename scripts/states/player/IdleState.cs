using Godot;
using System;

public partial class IdleState : State
{

	private CharacterBody2D player;

	public override void Ready()
	{

		player = this.GetOwner<CharacterBody2D>();

	}

	public override void Enter()
	{
		
		Vector2 v;
		v.X = 0;
		v.Y = 0;
        if (player != null)
        {
            player.Velocity = v;
		    player.MoveAndSlide();
        }
        else
        {
            GD.Print("No player");
        }
	}

	public override void PhysicsUpdate(float delta)
	{

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			fsm.TransitionTo("move");
		}
        if (Input.IsActionJustPressed("Cast_card1"))
        {
            fsm.TransitionTo("castCard");
        }
        else if (Input.IsActionJustPressed("Cast_card2"))
        {
            fsm.TransitionTo("castCard");
        }
        else if (Input.IsActionJustPressed("Cast_card3"))
        {
            fsm.TransitionTo("castCard");
        }
        else if (Input.IsActionJustPressed("Cast_card4"))
        {
            fsm.TransitionTo("castCard");
        }
		

	}

}
