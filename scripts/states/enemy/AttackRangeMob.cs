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
    public AudioStreamPlayer2D bow;
    public Timer timer;
    public bool attack;

    public int bow_frame = 7;
	// Called when the node enters the scene tree for the first time.
	public override void Ready()
	{
		mob = GetOwner<Enemy>();
		muzzle = mob.GetNode<Marker2D>("Muzzle");
		player = (Player)GetTree().GetFirstNodeInGroup("Player");
		anim = mob.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        bow = mob.GetNode<AudioStreamPlayer2D>("BowSound");
        timer = mob.GetNode<Timer>("AttackCooldown");
        attack = true;
        

        anim.FrameChanged += OnFrameChanged;
        anim.AnimationFinished += OnAnimationFinished;
        timer.Timeout += OnTimerTimeout;

	}

    private void OnTimerTimeout()
    {
        attack = true;
    }


    private void OnAnimationFinished()
    {
        projectile = GD.Load<PackedScene>("res://scenes/Enemies/projectileEnemy.tscn");
        ProjectileEnemy n = (ProjectileEnemy)projectile.Instantiate();
        mob.GetTree().Root.AddChild(n);
        muzzle.LookAt(player.GlobalPosition);
        n.Transform = muzzle.GlobalTransform;
        attack = true;
        GD.Print("anim finished");
    }


    


    private void OnFrameChanged()
    {
        if (anim.Animation == "shoot")
        {
            if (anim.Frame == bow_frame)
            {
                bow.Play();
            }
        }
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

	public override void PhysicsUpdate(float delta)
	{
        if (attack)
        {   
            
            shoot_animation();
            attack = false;
            timer.Start(0.2f);
            
        }
        mob.MoveAndSlide();
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
