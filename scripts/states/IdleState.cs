using Godot;
using System;

public partial class IdleState : State
{

	private CharacterBody2D player;

	public override void Ready()
	{

		//player = GetNode<CharacterBody2D>("player");
        player = this.GetOwner<CharacterBody2D>();

	}

	public override void Enter()
	{
        
		Vector2 v;
		v.X = 0;
		v.Y = 0;
		player.Velocity = v;
		player.MoveAndSlide();
	}

	public override void PhysicsUpdate(float delta)
    {


        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        if (direction == Vector2.Zero)
        {
            return;
        }
        fsm.TransitionTo("move");
    }

}
