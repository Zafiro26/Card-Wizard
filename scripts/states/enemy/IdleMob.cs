using Godot;
using System;

public partial class IdleMob : State
{

    private CharacterBody2D mob;

	// Called when the node enters the scene tree for the first time.
	public override void Ready()
	{

        mob = GetOwner<CharacterBody2D>();

	}

    // Called every frame. 'delta' is the elapsed time since the previous frame.

}
