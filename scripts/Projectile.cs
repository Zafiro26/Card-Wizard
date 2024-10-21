using Godot;
using System;

public partial class Projectile : CharacterBody2D
{

    private int SPEED = 700;
    private Area2D area;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        area = this.GetNode<Area2D>("Hitbox");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
        
        this.Position += Transform.X * SPEED * (float)delta;
        area.BodyEntered += OnBodyEntered;
	}

    private void OnBodyEntered(Node2D body)
    {
        if (body.IsInGroup("Enemy"))
        {
            body.QueueFree();
        }
        this.QueueFree();
    }

}
