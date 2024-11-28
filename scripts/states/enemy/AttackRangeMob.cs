using Godot;
using System;

public partial class AttackRangeMob : State
{
	private int damage = 10;
	private Area2D area;
	private Player player;
	private Enemy mob;
	private bool attackCooldown;
	private Timer attackCooldownTimer;
	public AnimatedSprite2D anim;
	public PackedScene projectile;
	public Marker2D muzzle;
	// Called when the node enters the scene tree for the first time.
	public override void Ready()
	{
		mob = GetOwner<Enemy>();
		muzzle = mob.GetNode<Marker2D>("Muzzle");
		player = (Player)GetTree().GetFirstNodeInGroup("Player");
		attackCooldown = false;
		attackCooldownTimer = mob.GetNode<Timer>("AttackCooldown");
		anim = mob.GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		attackCooldownTimer.Timeout += onTimerEnd;
	}

    public override void Enter()
    {
		Vector2 v = new Vector2(0, 0);
        mob.Velocity = v;
		mob.MoveAndSlide();

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
		if (!attackCooldown)
		{
			//DoDamage(player);
			projectile = GD.Load<PackedScene>("res://scenes/Cards/projectileFrozenArrow.tscn");
			ProjecitleEnemy n = (ProjecitleEnemy)projectile.Instantiate();
			attackCooldown = true;
			attackCooldownTimer.Start(mob.attackCooldown);
			mob.GetTree().Root.AddChild(n);
			muzzle.LookAt(player.GlobalPosition);
			n.Transform = muzzle.GlobalTransform;
			//anim.Play("attack_front");
		}
	}

}
