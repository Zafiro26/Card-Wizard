using Godot;
using System;

public partial class Door : Area2D
{

    public Marker2D marker;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        marker = GetNode<Marker2D>("Marker2D");

        this.BodyEntered += onBodyEntered;
        
	}

    //Change the player of room
    private void onBodyEntered(Node2D body)
    {
        if (body.IsInGroup("Player"))
        {
            body.Position = marker.GlobalPosition;
            GD.Print(marker.GlobalPosition);
        }
    }

}
