using Godot;
using System;

public partial class IdleState : State
{

	private CharacterBody2D player;

	public override void _Ready()
	{

		player = GetNode<CharacterBody2D>("player");

	}

    public override void Enter()
    {
        Vector2 v = player.Velocity;
		v.X = 0;
		v.Y = 0;
		player.Velocity = v;
		player.MoveAndSlide();
    }

	public override void _PhysicsProcess(double delta)
	{

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			fsm.TransitionTo("MoveState");
		}
	}

}
