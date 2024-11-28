using Godot;
using System;

public partial class AttackRangeMob : State
{
	private int damage = 10;
	private Area2D area;
	private Player player;
	private Enemy mob;
	public AnimatedSprite2D anim;
	public PackedScene projectile;
	public Marker2D muzzle;
	// Called when the node enters the scene tree for the first time.
	public override void Ready()
	{
		mob = GetOwner<Enemy>();
		muzzle = mob.GetNode<Marker2D>("Muzzle");
		player = (Player)GetTree().GetFirstNodeInGroup("Player");
		anim = mob.GetNode<AnimatedSprite2D>("AnimatedSprite2D");

	}

    public override void Enter()
    {
		Vector2 v = new Vector2(0, 0);
        mob.Velocity = v;
		mob.MoveAndSlide();

    }


	private void DoDamage(Player player)
	{
		player.Take_damage(damage);
	}

	public override async void PhysicsUpdate(float delta)
	{
		projectile = GD.Load<PackedScene>("res://scenes/Enemies/projectileEnemy.tscn");
		ProjectileEnemy n = (ProjectileEnemy)projectile.Instantiate();
        shoot_animation();
        await ToSignal(anim, "animation_looped");
		mob.GetTree().Root.AddChild(n);
        muzzle.LookAt(player.GlobalPosition);
		n.Transform = muzzle.GlobalTransform;
	}


    public void shoot_animation()
    {
        Godot.Vector2 d = player.GlobalPosition - mob.GlobalPosition;
        if (Math.Abs(d.X) > Math.Abs(d.Y))
        {
            // Horizontal movement
            if (d.X > 0)
            {
                anim.FlipH = false;
            }
            else
            {
                anim.FlipH = true;
            }
        }
        anim.Play("shoot");
    }

}
