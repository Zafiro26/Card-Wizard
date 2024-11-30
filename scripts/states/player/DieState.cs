using Godot;
using System;

public partial class DieState : State
{

    private AnimatedSprite2D anim;
	// Called when the node enters the scene tree for the first time.

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        Player a = (Player)GetTree().GetFirstNodeInGroup("Player");
        anim = a.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

    public override async void Enter()
    {
        anim.Play("died");
        await ToSignal(anim, "animation_finished");
        GetTree().ChangeSceneToFile("res://scenes/UIs/died_menu.tscn");
        //QueueFree();
    }
}
