using Godot;
using System;
using System.Diagnostics.Tracing;

public partial class DungeonRoom : Node2D
{

    /*
    public Area2D area;

    [Signal] public delegate void RoomEntered(Node room);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        area = GetNode<Area2D>("DetectionPlayer");
        area.BodyEntered += OnBodyEntered;

        Connect(nameof(RoomEntered), this, nameof(OnRoomEntered));
	}

    private void OnRoomEntered(Node body)
    {
        EmitSignal(nameof(RoomEntered), this);
    }


    private void OnBodyEntered(Node2D body)
    {
        throw new NotImplementedException();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
    */
}
