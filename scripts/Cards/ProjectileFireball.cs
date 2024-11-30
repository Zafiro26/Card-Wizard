using Godot;
using System;

public partial class ProjectileFireball : CharacterBody2D
{

    public int speed;
    private Area2D area;
    public int damage;
    private Vector2 d;
    private Player player;
    private PackedScene explosion;
    private AnimatedSprite2D n;
    private Area2D explosionArea;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        area = this.GetNode<Area2D>("Hitbox");
        area.BodyEntered += OnBodyEntered;
        player = (Player)GetTree().GetFirstNodeInGroup("Player");
        explosionArea = GetNode<Area2D>("Explosion");

        PackedScene tmp = GD.Load<PackedScene>("res://scenes/VFX/animated_sprite_2d.tscn");
        n = (AnimatedSprite2D)tmp.Instantiate();

	}

    private void OnAnimationFinished()
    {
        this.QueueFree();
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
            //Enemy tmp = (Enemy)body;
            //tmp.Take_damage(damage);
            //tmp.Take_dot_damage(5, 20, 2.0f);
            explosionM();
            
            Node2D w = (Node2D)GetTree().GetFirstNodeInGroup("World");
            n.GlobalPosition = GlobalPosition;
            w.AddChild(n);
            n.Play();
            GD.Print(n.GlobalPosition);
            GD.Print(GlobalPosition);
            
            this.QueueFree();
            
        }

        else if (body.IsInGroup("Player"))
        {
            explosionM();
        }
        if (body.GetType() == typeof(StaticBody2D))
        {
            this.QueueFree();
        }
    }

    private void explosionM()
    {
        player.fireball_explosion();
        foreach (var body in explosionArea.GetOverlappingBodies())
        {
            if (body.IsInGroup("Enemy"))
            {
                Enemy tmp = (Enemy)body;
                tmp.Take_damage(damage);
                tmp.Take_dot_damage(5, 20, 2.0f);
            }
            else if (body.IsInGroup("Player"))
            {
                Player tmp = (Player)body;
                tmp.Take_damage(damage);
            }
        }
    }


}
