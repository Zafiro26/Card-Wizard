using Godot;
using System;

public partial class Rock : Card
{
	
    public int damage;
    public int speed = 350;
    public PackedScene projectile;

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
        n.speed = speed;
        n.damage = damage;
        player.GetTree().Root.AddChild(n);
        n.Transform = player.muzzle.GlobalTransform;
        GD.Print("Casted Rock");
    }
	
}
