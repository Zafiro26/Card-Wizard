using Godot;
using System;

public partial class MoveState : State
{

	public const float SPEED = 300.0f;

	private CharacterBody2D player;

	// Called when the node enters the scene tree for the first time.
	public override void Ready()
	{
		player = this.GetOwner<CharacterBody2D>();
	}

	public override void Enter()
	{
		
		
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void PhysicsUpdate(float delta)
	{
		
		movement(delta);
	}

	public void movement(float delta)
	{

		 Vector2 v = player.Velocity;   
		
		if (Input.IsActionPressed("ui_right"))
		{  
			//direction = 1;
			//play_animation(1);
			v.X = SPEED;
			v.Y = 0;
		}
		else if (Input.IsActionPressed("ui_left"))
		{
			//direction = 3;
			//play_animation(1);
			v.X = -SPEED;
			v.Y = 0;
		}
		else if (Input.IsActionPressed("ui_down"))
		{
			//direction = 2;
			//play_animation(1);
			v.X = 0;
			v.Y = SPEED;
		}
		else if (Input.IsActionPressed("ui_up"))
		{
			//direction = 4;
			//play_animation(1);
			v.X = 0;
			v.Y = -SPEED;
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
