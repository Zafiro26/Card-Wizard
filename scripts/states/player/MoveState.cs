using Godot;
using System;

public partial class MoveState : State
{

	private Player player;

	// Called when the node enters the scene tree for the first time.
	public override void Ready()
	{
		player = this.GetOwner<Player>();
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void PhysicsUpdate(float delta)
	{
		movement(delta);
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

	public void movement(float delta)
	{

		 Vector2 v = player.Velocity;   
		
		if (Input.IsActionPressed("ui_right"))
		{  
			//direction = 1;
			//play_animation(1);
			v.X = player.speed;
			v.Y = 0;
		}
		else if (Input.IsActionPressed("ui_left"))
		{
			//direction = 3;
			//play_animation(1);
			v.X = -player.speed;
			v.Y = 0;
		}
		else if (Input.IsActionPressed("ui_down"))
		{
			//direction = 2;
			//play_animation(1);
			v.X = 0;
			v.Y = player.speed;
		}
		else if (Input.IsActionPressed("ui_up"))
		{
			//direction = 4;
			//play_animation(1);
			v.X = 0;
			v.Y = -player.speed;
		} 
		else 
		{
			//play_animation(0);
			fsm.TransitionTo("idle");
		}

		player.Velocity = v;

		player.MoveAndSlide();

	}
}
