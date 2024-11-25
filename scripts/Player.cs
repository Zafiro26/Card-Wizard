using Godot;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public partial class Player : CharacterBody2D
{
	private const int MAX_HP = 100;
	public StateMachine fsm;
	//public Deck deck;
	public Hand hand;
	public PackedScene projectile;
	public Marker2D muzzle;

	private int health;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Init_player();
		fsm = GetNode<StateMachine>("FSM");
		//deck = GetNode<Deck>("deck");
		hand = GetNode<Hand>("Hand");
		projectile = GD.Load<PackedScene>("res://scenes/projectile.tscn");
        muzzle = GetNode<Marker2D>("Muzzle");
	}

    public override void _PhysicsProcess(double delta)
    {
        LookAt(GetGlobalMousePosition());
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
		add_health(0 - damage);
		GD.Print("Player takes: " + damage);
		
	}

	/*
	* Player gains health equals to health till max health.
	* @param healing, health that the player gains.
	*/
	public void heal(int healing)
	{
		add_health(healing);
		GD.Print("Player heals: " + healing);
	}

	public void shoot()
	{
		Projectile n = (Projectile)projectile.Instantiate();
		GetTree().Root.AddChild(n);
		n.Transform = muzzle.GlobalTransform;
		
	}

	/*
	* Add player health with value.
	* @param n, value to add.
	*/
	private void add_health(int n)
	{
		health += n;
		if (health <= 0)
		{
			fsm.TransitionTo("die");
		}
		if (health > MAX_HP)
		{
			health = MAX_HP;
		}
	}
}
