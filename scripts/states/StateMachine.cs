using Godot;
using System;
using System.Collections.Generic;

public partial class StateMachine : Node
{

    private State current_state;
    private Dictionary<string, State> states = new Dictionary<string, State>();
    [Export] public NodePath initialState;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        foreach (Node child in this.GetChildren())
        {
            if (child is State s)
            {
                states[child.Name] = s;
                s.fsm = this;
                s.Ready();
                s.Exit();           //Reset all states
            }
        }
        this.current_state = GetNode<State>(initialState);
        this.current_state.Enter();
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
            current_state.PhysicsUpdate((float)delta);
        }
    }

    public void TransitionTo(string key)
    {
        if (!states.ContainsKey(key) || current_state == states[key])
        {
            return;
        }
        this.current_state.Exit();
        this.current_state = this.states[key];
        this.current_state.Enter();

    }
}
