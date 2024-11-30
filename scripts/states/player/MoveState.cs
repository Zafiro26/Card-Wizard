using Godot;
using System;

public partial class MoveState : State
{

	private Player player;
    private AnimatedSprite2D anim;

	// Called when the node enters the scene tree for the first time.
	public override void Ready()
	{
		player = this.GetOwner<Player>();
        anim = player.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void PhysicsUpdate(float delta)
	{
		movement(delta);
        if (Input.IsActionJustPressed("Cast_card1"))
        {
            fsm.TransitionTo("castCard");
        }
        else if (Input.IsActionJustPressed("Cast_card2"))
        {
            fsm.TransitionTo("castCard");
        }
        else if (Input.IsActionJustPressed("Cast_card3"))
        {
            fsm.TransitionTo("castCard");
        }
        else if (Input.IsActionJustPressed("Cast_card4"))
        {
            fsm.TransitionTo("castCard");
        }
	}

	public void movement(float delta)
	{
        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        if (direction == Vector2.Zero)
        {
            fsm.TransitionTo("idle");
        }
        else
        {
            player.Velocity = direction * player.speed;
            player.MoveAndSlide();
            update_animation(player.Velocity);
        }

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
