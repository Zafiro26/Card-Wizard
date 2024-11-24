using Godot;
using System;

public partial class Projectile : CharacterBody2D
{

    private int SPEED = 700;
    private Area2D area;
    private int damage = 10;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        area = this.GetNode<Area2D>("Hitbox");
        area.BodyEntered += OnBodyEntered;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
        
        this.Position += Transform.X * SPEED * (float)delta;
	}

    private void OnBodyEntered(Node2D body)
    {
        if (body.IsInGroup("Enemy"))
        {
            Enemy tmp = (Enemy)body;
            tmp.Take_damage(damage);
        }
        this.QueueFree();
    }

}
