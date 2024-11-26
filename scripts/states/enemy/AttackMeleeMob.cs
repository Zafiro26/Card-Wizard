using Godot;
using System;

public partial class AttackMeleeMob : State
{
    private int damage = 10;
    private Area2D area;
    private Player player;
    private Enemy mob;
    private bool attackCooldown;
    private Timer attackCooldownTimer;
	// Called when the node enters the scene tree for the first time.
	public override void Ready()
	{
        mob = GetOwner<Enemy>();
        player = (Player)GetTree().GetFirstNodeInGroup("Player");
        attackCooldown = false;
        attackCooldownTimer = mob.GetNode<Timer>("AttackCooldown");
        attackCooldownTimer.Timeout += onTimerEnd;
        GD.Print("hola");
	}

    private void onTimerEnd()
    {
        attackCooldown = false;
    }

    private void DoDamage(Player player)
    {
        player.Take_damage(damage);
    }

    public override void PhysicsUpdate(float delta)
    {
        if (attackCooldown)
        {
            //GD.Print("aa");
        }
        if (!attackCooldown)
        {
            DoDamage(player);
            attackCooldown = true;
            attackCooldownTimer.Start(mob.attackCooldown);
        }
    }

}
