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

    /*
    * Player loses health equals to damage.
    * @param damage, damage that the player takes.
    */
	public void Take_damage(int damage)
    {
        GD.Print("Player takes: " + damage);
        health -= damage;
        GD.Print("Player health: " + health);
        if (health <= 0)
        {
            fsm.TransitionTo("die");
        }
    }

    /*
    * Player gains health equals to health till max health.
    * @param healing, health that the player gains.
    */
    public void heal(int healing)
    {
        GD.Print("Player heals: " + healing);
        health += healing;
        if (health > MAX_HP)
        {
            health = MAX_HP;
        }
        GD.Print("Player health: " + health);
    }
}
