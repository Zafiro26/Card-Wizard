using Godot;
using System;

public partial class Camera2dDungeon : Camera2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        
        foreach (Node n in GetOwner().GetChildren())
        {
            
            if (n.GetType() == typeof(DungeonRoom))
            {
                DungeonRoom tmp = (DungeonRoom)n;
                tmp.RoomEntered += OnRoomEntered;
                
            }
        }
    }
    
    
    private void OnRoomEntered(DungeonRoom room)
    {
        GD.Print(room.Name);
        this.GlobalPosition = room.GlobalPosition;
    }
    
}
