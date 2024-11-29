using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public partial class Player : CharacterBody2D
{
	private const int MAX_HP = 100;
    public float speed;
    public float base_speed;
	public StateMachine fsm;
	public Deck deck;
	public PackedScene projectile;
	public Marker2D muzzle;
	private int health;
    public HealthBar healthBar;
    public Timer speedTimer;
    public bool inmortal;
    public Sprite2D shield;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		fsm = GetNode<StateMachine>("FSM");
        deck = GetNode<Deck>("Deck");
		
        muzzle = GetNode<Marker2D>("Muzzle");
        healthBar = GetNode<HealthBar>("CanvasLayer/HealthBar");
        shield = GetNode<Sprite2D>("CanvasLayer/Sprite2D");

        speedTimer = GetNode<Timer>("SpeedTimer");
        speedTimer.Timeout += OnSpeedTimeout;
        
        healthBar.init_health(MAX_HP);
        speed = 300f;
        base_speed = 300f;
        inmortal = false;
        Init_player();
        
	}

    private void OnSpeedTimeout()
    {
        speed = base_speed;
    }


    public override void _PhysicsProcess(double delta)
    {
        //LookAt(GetGlobalMousePosition());
        muzzle.LookAt(GetGlobalMousePosition());
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
        if (!inmortal)
        {
            add_health(0 - damage);
            GD.Print("Player takes: " + damage);
        }
        else
        {
            inmortal = false;
            shield.Visible = false;
        }
		
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
        healthBar.set_health(health);
	}
}
