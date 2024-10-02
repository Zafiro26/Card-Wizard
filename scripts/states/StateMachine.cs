using Godot;
using System;
using System.Collections.Generic;

public partial class StateMachine : Node
{

    private state current_state;
    private Dictionary<string, state> states = new Dictionary<string, state>();
    [Export] public NodePath initialState;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        foreach (Node child in this.GetChildren())
        {
            if (child is state s)
            {
                states[child.Name] = s;
                
            }
        }
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        if (current_state != null) 
        {
            current_state.Update((float)delta);
        }
	}

    public override void _PhysicsProcess(double delta)
    {
        if (current_state != null) 
        {
            current_state.Update((float)delta);
        }
    }
}
