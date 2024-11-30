using Godot;
using System;

public partial class Muzzle : Marker2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

    public override void _PhysicsProcess(double delta)
    {
        LookAt(GetGlobalMousePosition());
    }
}
