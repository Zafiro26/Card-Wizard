using Godot;
using System;

public partial class Camera2dDungeon : Camera2D
{
    public DungeonRoom dungeonRoom;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        dungeonRoom = GetOwner().GetNode<DungeonRoom>("DungeonRoom");
        dungeonRoom.RoomEntered += OnRoomEntered;
	}

    private void OnRoomEntered(DungeonRoom room)
    {
        GlobalPosition = room.GlobalPosition;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
