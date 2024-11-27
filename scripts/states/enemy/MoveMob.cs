using Godot;
using System;

public partial class MoveMob : State
{

	public Enemy mob;
    public Player player;
    public Area2D area;
    public Area2D attackArea;

    //public int SPEED = 80;

	// Called when the node enters the scene tree for the first time.
	public override void Ready()
	{

		mob = GetOwner<Enemy>();
        player = (Player)GetTree().GetFirstNodeInGroup("Player");

	}


    // Called every frame. 'delta' is the elapsed time since the previous frame.

    public override void PhysicsUpdate(float delta)
	{
        Vector2 d = player.GlobalPosition - mob.GlobalPosition;

        mob.Velocity = d.Normalized() * mob.SPEED;
        mob.MoveAndSlide();

	}
}
