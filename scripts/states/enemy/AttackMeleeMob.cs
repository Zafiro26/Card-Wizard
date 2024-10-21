using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class AttackMeleeMob : State
{
    private int damage = 10;
    private Area2D area;
	// Called when the node enters the scene tree for the first time.
	public override void Ready()
	{
        CharacterBody2D p = GetOwner<CharacterBody2D>();
        area = p.GetNode<Area2D>("Hitbox");
        
        
        area.BodyEntered += OnBodyEntered;
	}

    private void OnBodyEntered(Node2D body)
    {
        if (body.IsInGroup("Player"))
        {
            DoDamage((Player)body);
        }
    }

    private void DoDamage(Player player)
    {
        player.Take_damage(damage);
        //GD.Print("damage");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void PhysicsUpdate(float delta)
	{
        System.Threading.Thread.Sleep(100);
        fsm.TransitionTo("moveMob");
	}
}
