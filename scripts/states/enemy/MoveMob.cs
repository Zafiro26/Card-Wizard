using Godot;
using System;

public partial class MoveMob : State
{

	private CharacterBody2D enemy;
    private CharacterBody2D player;

    private int SPEED = 40;

	// Called when the node enters the scene tree for the first time.
	public override void Ready()
	{

		enemy = this.GetOwner<CharacterBody2D>();
        player = (CharacterBody2D)GetTree().GetFirstNodeInGroup("Player");

	}

    public override void Enter()
    {
        base.Enter();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void PhysicsUpdate(float delta)
	{
        Vector2 d = player.GlobalPosition - enemy.GlobalPosition;

        if (d.Length() > 200)
        {
            fsm.TransitionTo("idleMob");
        }
        else if (d.Length() > 25)
        {
            enemy.Velocity = d.Normalized() * SPEED;
            enemy.MoveAndSlide();
        }

        if (d.Length() < 10)
        {
            fsm.TransitionTo("attackMob");
        }


	}
}
