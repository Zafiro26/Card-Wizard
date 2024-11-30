using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

public partial class DungeonRoom : Node2D
{

    public Area2D area;
    [Signal] public delegate void RoomEnteredEventHandler(DungeonRoom room);
    public StaticBody2D doors;
    public Sprite2D opened;
    public Sprite2D closed;

    public override void _Ready()
    {
        area = GetNode<Area2D>("DetectionPlayer");
        area.BodyEntered += onBodyEntered;
        doors = GetNode<StaticBody2D>("ClosedDoors");
        opened = GetNode<Sprite2D>("Closed");
        closed = GetNode<Sprite2D>("Opened");

        opened.Visible = false;
        closed.Visible = true;
    }

    public override void _PhysicsProcess(double delta)
    {
        int i = 0;
        foreach (Node n in GetChildren())
        {
            if (n.GetType() == typeof(Enemy))
            {
                i++;
            }
        }
        if (i == 0)
        {
            foreach (Node n in doors.GetChildren())
            {
                CollisionShape2D tmp = (CollisionShape2D) n;
                tmp.Disabled = true;
            }
            opened.Visible = true;
            closed.Visible = false;
        }
    }

    private void onBodyEntered(Node2D body)
    {
        if (body.IsInGroup("Player"))
        {
            EmitSignal(SignalName.RoomEntered, this);
            make_mobs_attack();
        }
    }

    private void make_mobs_attack()
    {
        foreach (Node n in GetChildren())
        {
            if (n.GetType() == typeof(Enemy))
            {
                Enemy tmp = (Enemy)n;
                tmp.force_transition_move();
                
            }
        }
    }

}
