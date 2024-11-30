using Godot;
using System;

public partial class EndScreenArea : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        this.BodyEntered += OnBodyEntered;
	}

    private void OnBodyEntered(Node2D body)
    {
        if (body.IsInGroup("Player"))
        {
            GetTree().ChangeSceneToFile("res://scenes/UIs/end_game_menu.tscn");
        }
    }

}
