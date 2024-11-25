using Godot;
using System;
using System.Diagnostics.Tracing;

public partial class DungeonRoom : Node2D
{

    public Area2D area;
    [Signal] public delegate void RoomEnteredEventHandler(DungeonRoom room);

    public override void _Ready()
    {
        area = GetNode<Area2D>("DetectionPlayer");
        area.BodyEntered += onBodyEntered;
    }

    private void onBodyEntered(Node2D body)
    {
        EmitSignal(SignalName.RoomEntered, this);
    }

}
