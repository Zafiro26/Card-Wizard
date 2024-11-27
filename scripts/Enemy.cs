using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
    public int MAX_HP = 100;
    public float SPEED = 80f;
    public int health;
    public StateMachine fsm;
    public Area2D areaDetection;
    public Area2D attackArea;
    public float attackCooldown;
    public HealthBar healthBar;
    
    //Scorch timer and damage
    public Timer scorchTimer;
    public int scorchDamageTaken;
    public int scorchDamageMax;
    public int scorchDamage;

    //Slow timer
    public Timer slowTimer;
    public float oldSpeed;
    
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        fsm = GetNode<StateMachine>("FSM");
        health = MAX_HP;
        areaDetection = GetNode<Area2D>("Detection");
        attackArea = GetNode<Area2D>("AttackArea");
        healthBar = GetNode<HealthBar>("HealthBar");
        healthBar.init_health(MAX_HP);

        scorchTimer = GetNode<Timer>("ScorchTimer");
        slowTimer = GetNode<Timer>("SlowTimer");

        //areaDetection.BodyEntered += OnBodyDetectionEntered;
        //areaDetection.BodyExited += OnBodyDetectionExit;
        attackArea.BodyEntered += OnBodyAttackEnter;
        attackArea.BodyExited += OnBodyAttackExit;
        scorchTimer.Timeout += OnScorchTimeout;
        slowTimer.Timeout += OnSlowTimeout;
        

	}

    private void OnSlowTimeout()
    {
        SPEED = oldSpeed;
    }


    private void OnScorchTimeout()
    {
        Take_damage(scorchDamage);
        scorchDamageTaken += scorchDamage;
        if (scorchDamageTaken < scorchDamageMax)
        {
            scorchTimer.Start();
        }
    }


    private void OnBodyAttackExit(Node2D body)
    {
        if (body.IsInGroup("Player"))
        {
            fsm.TransitionTo("moveMob");
        }
    }


    public void force_transition_move()
    {
        fsm.TransitionTo("moveMob");
    }


    private void OnBodyAttackEnter(Node2D body)
    {
        if (body.IsInGroup("Player"))
        {
            fsm.TransitionTo("attackMeleeMob");
            GD.Print("Mob change to attack");
        }
    }


    private void OnBodyDetectionExit(Node2D body)
    {
        if (body.IsInGroup("Player"))
        {
            fsm.TransitionTo("idleMob");
            GD.Print("Mob change to idle");
        }
    }


    private void OnBodyDetectionEntered(Node2D body)
    {
        if (body.IsInGroup("Player"))
        {
            fsm.TransitionTo("moveMob");
            GD.Print("Mob change to move");
        }
    }

    public void slow(float ammount)
    {
        float tmp = SPEED*((100 - ammount)/100);
        oldSpeed = SPEED;
        SPEED = tmp;
        slowTimer.Start(5.0f);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public void Take_damage(int damage)
    {
        add_health(0 - damage);
        
    }
    public void Take_dot_damage(int damage, int total_damage, float intervale_damage)
    {
        scorchDamageTaken = 0;
        scorchDamageMax = total_damage;
        scorchDamage = damage;
        scorchTimer.WaitTime = intervale_damage;
        scorchTimer.Start();
    }

    public void heal(int healing)
    {
        add_health(healing);
    }

    private void add_health(int n)
    {
        health += n;
        if (health <= 0)
        {
            fsm.TransitionTo("dieMob");
        }
        if (health > MAX_HP)
        {
            health = MAX_HP;
        }
        healthBar.set_health(health);
    }
}
