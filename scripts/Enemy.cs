using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
    public int MAX_HP = 100;
    public int health;
    public StateMachine fsm;
    public Area2D areaDetection;
    public Area2D attackArea;
    public float attackCooldown;

    
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        fsm = GetNode<StateMachine>("FSM");
        health = MAX_HP;
        areaDetection = GetNode<Area2D>("Detection");
        attackArea = GetNode<Area2D>("AttackArea");

        areaDetection.BodyEntered += OnBodyDetectionEntered;
        areaDetection.BodyExited += OnBodyDetectionExit;
        attackArea.BodyEntered += OnBodyAttackEnter;
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

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public void Take_damage(int damage)
    {
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
