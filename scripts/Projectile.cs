using Godot;
using System;

public partial class Projectile : CharacterBody2D
{

    public int speed;
    private Area2D area;
    public int damage = 10;
    private Vector2 d;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        area = this.GetNode<Area2D>("Hitbox");
        area.BodyEntered += OnBodyEntered;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
        
        this.Position += Transform.X * speed * (float)delta;
	}

    private void OnBodyEntered(Node2D body)
    {
        if (body.IsInGroup("Enemy"))
        {
            Enemy tmp = (Enemy)body;
            tmp.Take_damage(damage);
            this.QueueFree();
        }
    }


}
