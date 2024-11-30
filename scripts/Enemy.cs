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
    public AnimatedSprite2D anim;
    
    //Scorch timer and damage
    public Timer scorchTimer;
    public int scorchDamageTaken;
    public int scorchDamageMax;
    public int scorchDamage;

    //Posion timer
    public Timer poisonTimer;
    public int poisonDamage;

    //Slow timer
    public Timer slowTimer;
    public float oldSpeed;

    private AudioStreamPlayer2D audio;
    
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        fsm = GetNode<StateMachine>("FSM");
        health = MAX_HP;
        //areaDetection = GetNode<Area2D>("Detection");
        attackArea = GetNode<Area2D>("AttackArea");
        healthBar = GetNode<HealthBar>("HealthBar");
        healthBar.init_health(MAX_HP);
        anim = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

        scorchTimer = GetNode<Timer>("ScorchTimer");
        slowTimer = GetNode<Timer>("SlowTimer");
        poisonTimer = GetNode<Timer>("PoisonTimer");

        //areaDetection.BodyEntered += OnBodyDetectionEntered;
        //areaDetection.BodyExited += OnBodyDetectionExit;
        attackArea.BodyEntered += OnBodyAttackEnter;
        attackArea.BodyExited += OnBodyAttackExit;
        scorchTimer.Timeout += OnScorchTimeout;
        slowTimer.Timeout += OnSlowTimeout;
        poisonTimer.Timeout += OnPoisonTimeout;

        poisonDamage = 0;
        

	}



    private void OnSlowTimeout()
    {
        SPEED = oldSpeed;
    }

    private void OnPoisonTimeout()
    {
        Take_damage(poisonDamage);
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
            GD.Print("Mob change to move1");
        }
    }


    public void force_transition_move()
    {
        bool t = false;
        foreach(var c in attackArea.GetOverlappingBodies())
        {
            if (c.GetType() == typeof(Player))
            {
                t = true;
            }
        }

        if (t)
        {
            fsm.TransitionTo("attackMob");
            GD.Print("Mob change to attack");
        }
        else
        {
            fsm.TransitionTo("moveMob");
            GD.Print("Mob change to move2");
        }   
        

    }


    private void OnBodyAttackEnter(Node2D body)
    {
        if (body.IsInGroup("Player"))
        {
            fsm.TransitionTo("attackMob");
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
        anim.Play("take_damage");
        add_health(0 - damage);
        
    }
    public void Take_dot_damage(int damage, int total_damage, float intervale_damage)
    {
        if (total_damage > 0)
        {
            scorchDamageTaken = 0;
            scorchDamageMax = total_damage;
            scorchDamage = damage;
            scorchTimer.WaitTime = intervale_damage;
            scorchTimer.Start();
        }
        else
        {
            poisonDamage += damage;
            poisonTimer.WaitTime = intervale_damage;
            poisonTimer.Start();
        }
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
            fsm.TransitionTo("die");
        }
        if (health > MAX_HP)
        {
            health = MAX_HP;
        }
        healthBar.set_health(health);
    }

    public void hit()
    {
        audio = GetNode<AudioStreamPlayer2D>("Hit");
        audio.Play();
    }

    public void play_animation(String name)
    {

    }
}
