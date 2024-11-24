using Godot;
using System;
using System.ComponentModel;

public partial class Player : CharacterBody2D
{
    private const int MAX_HP = 100;
    public StateMachine fsm;
    //public Deck deck;
    public Hand hand;

    private int health;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        Init_player();
        fsm = GetNode<StateMachine>("FSM");
        //deck = GetNode<Deck>("deck");
        hand = GetNode<Hand>("Hand");
	}

    private void Init_player()
    {
        health = MAX_HP;
    }

	public void Take_damage(int damage)
    {
        GD.Print("Player takes: " + damage);
        health -= damage;
        if (health <= 0)
        {
            fsm.TransitionTo("die");
        }
    }

    public void heal(int healing)
    {
        health += healing;
        if (health > MAX_HP)
        {
            health = MAX_HP;
        }
    }
}
