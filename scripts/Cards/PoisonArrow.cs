using Godot;
using System;

public partial class PoisonArrow : Card
{
	
    public int damage = 0;
    public int speed = 200;
    public PackedScene projectile;
    private AudioStreamPlayer2D audio;

    public PoisonArrow()
    {
        this.nombre = "PoisonArrow";
        this.usages = 1;
        this.cooldown = 1;
    }

    public override void Effect_card(Player player)
    {
        projectile = GD.Load<PackedScene>("res://scenes/Cards/projectilePoisonArrow.tscn");
        ProjectilePoisonArrow n = (ProjectilePoisonArrow)projectile.Instantiate();
        n.speed = speed;
        n.damage = damage;

        audio = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
        audio.Play();
        
        player.GetTree().Root.AddChild(n);
        n.Transform = player.muzzle.GlobalTransform;
        GD.Print("Casted poisonArrow");
    }
	
}
