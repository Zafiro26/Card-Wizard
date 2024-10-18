using Godot;
using System;

public partial class MoveMob : State
{

	private CharacterBody2D enemy;

	// Called when the node enters the scene tree for the first time.
	public override void Ready()
	{

		enemy = this.GetOwner<CharacterBody2D>();

	}

    public override void Enter()
    {
        base.Enter();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
