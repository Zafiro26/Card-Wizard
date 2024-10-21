using Godot;
using System;

public partial class Card : Node
{

    enum type {PROJECTILE, DEFENSE, HEALTH}

    [Export] private int id;
    [Export] private type t;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
