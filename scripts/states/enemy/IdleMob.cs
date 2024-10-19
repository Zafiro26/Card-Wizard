using Godot;
using System;

public partial class IdleMob : State
{

    private CharacterBody2D enemy;
    private CharacterBody2D player;

	// Called when the node enters the scene tree for the first time.
	public override void Ready()
	{

        enemy = GetOwner<CharacterBody2D>();
        player = (CharacterBody2D)GetTree().GetFirstNodeInGroup("Player");

	}

    public override void Enter()
    {
        Vector2 v = enemy.Velocity;
        v.X = 0;
        v.Y = 0;

        if (enemy != null)
        {
            enemy.Velocity = v;
            enemy.MoveAndSlide();
        }
        else
        {
            GD.Print("No mob");
        }
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void PhysicsUpdate(float delta)
	{

        Vector2 d = player.GlobalPosition - enemy.GlobalPosition;

        if (d.Length() > 25 && d.Length() < 50)
        {
            fsm.TransitionTo("moveMob");
        }

	}
}
