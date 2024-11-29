using Godot;
using System;

public partial class ProjectilePoisonArrow : CharacterBody2D
{

    public int speed;
    private Area2D area;
    public int damage;
    private Vector2 d;
    private Player player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        area = this.GetNode<Area2D>("Hitbox");
        area.BodyEntered += OnBodyEntered;
        player = (Player)GetTree().GetFirstNodeInGroup("Player");
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
            tmp.Take_dot_damage(5, 0, 1.0f);
            this.QueueFree();
        }
        if (body.GetType() == typeof(StaticBody2D))
        {
            this.QueueFree();
        }
    }


}
