using Godot;
using System;

public partial class Fireball : Card
{
	
    public int damage = 50;
    public int speed = 100;
    public PackedScene projectile;

    public Fireball()
    {
        this.nombre = "Fireball";
        this.usages = 1;
        this.cooldown = 1;
    }

    public override void Effect_card(Player player)
    {
        projectile = GD.Load<PackedScene>("res://scenes/Cards/projectileFireball.tscn");
        ProjectileFireball n = (ProjectileFireball)projectile.Instantiate();
        n.speed = speed;
        n.damage = damage;
        player.GetTree().Root.AddChild(n);
        n.Transform = player.muzzle.GlobalTransform;
        GD.Print("Casted fireball");
    }
	
}
