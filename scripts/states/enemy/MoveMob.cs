using Godot;
using System;

public partial class MoveMob : State
{

	public Enemy mob;
    public Player player;
    public Area2D area;
    public Area2D attackArea;
    public AnimatedSprite2D anim;

    //public int SPEED = 80;

	// Called when the node enters the scene tree for the first time.
	public override void Ready()
	{

		mob = GetOwner<Enemy>();
        player = (Player)GetTree().GetFirstNodeInGroup("Player");
        anim = mob.GetNode<AnimatedSprite2D>("AnimatedSprite2D");

	}


    // Called every frame. 'delta' is the elapsed time since the previous frame.

    public override void PhysicsUpdate(float delta)
	{
        Godot.Vector2 d = player.GlobalPosition - mob.GlobalPosition;
        d = d.Normalized();

        mob.Velocity = d * mob.SPEED;
        mob.MoveAndSlide();
        //update_animation(d);

	}

    private void update_animation(Godot.Vector2 v)
    {
        if (Math.Abs(v.X) > Math.Abs(v.Y))
        {
            // Horizontal movement
            if (v.X > 0)
            {
                anim.FlipH = false;
                anim.Play("walk_side");
            }
            else
            {
                anim.FlipH = true;
                anim.Play("walk_side");
            }
        }
        else
        {
            anim.Play("walk_side");
            /*
            // Vertical movement
            if (v.Y > 0)
            {
                anim.FlipH = false;
                anim.Play("walk_front");
            }
            else
            {
                anim.FlipH = false;
                anim.Play("walk_back");
            }
            */
        }

    }
}
