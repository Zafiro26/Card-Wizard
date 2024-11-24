using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class AttackMeleeMob : State
{
    private int damage = 10;
    private Area2D area;
    private Player player;
	// Called when the node enters the scene tree for the first time.
	public override void Ready()
	{
        CharacterBody2D p = GetOwner<CharacterBody2D>();
        player = (Player)GetTree().GetFirstNodeInGroup("Player");
	}

    public override void Enter()
    {
        DoDamage(player);
    }


    private void DoDamage(Player player)
    {
        player.Take_damage(damage);
    }

}
