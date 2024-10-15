using Godot;
using System;

public partial class MoveState : State
{

	public const float SPEED = 300.0f;

	private CharacterBody2D player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<CharacterBody2D>("player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{

		Vector2 velocity = player.Velocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * SPEED;
		}
		else
		{
			//velocity.X = Mathf.MoveToward(player.Velocity.X, 0, SPEED);
			fsm.TransitionTo("IdleState");
		}

		player.Velocity = velocity;
		player.MoveAndSlide();



	}
}
