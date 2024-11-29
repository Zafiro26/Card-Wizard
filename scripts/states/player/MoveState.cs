using Godot;
using System;

public partial class MoveState : State
{

	private Player player;

	// Called when the node enters the scene tree for the first time.
	public override void Ready()
	{
		player = this.GetOwner<Player>();
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
		player.Velocity = direction * player.speed;
		player.MoveAndSlide();

	}
}
