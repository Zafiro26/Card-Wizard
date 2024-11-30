using Godot;
using System;

public partial class Rock : Card
{
	
    public int damage;
    public int speed = 350;
    public PackedScene projectile;
    private AudioStreamPlayer2D audio;

    public Rock()
    {
        this.nombre = "Rock";
        this.usages = 1;
        this.cooldown = 1;
    }

    public override void Effect_card(Player player)
    {
        projectile = GD.Load<PackedScene>("res://scenes/Cards/projectileRock.tscn");
        ProjectileRock n = (ProjectileRock)projectile.Instantiate();
        audio = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
        audio.Play();
        n.speed = speed;
        n.damage = damage;
        player.GetTree().Root.AddChild(n);
        n.Transform = player.muzzle.GlobalTransform;
        GD.Print("Casted Rock");
    }
	
}
