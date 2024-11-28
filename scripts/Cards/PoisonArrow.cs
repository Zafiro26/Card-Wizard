using Godot;
using System;

public partial class PoisonArrow : Card
{
	
    public int damage = 0;
    public int speed = 200;
    public PackedScene projectile;

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
        player.GetTree().Root.AddChild(n);
        n.Transform = player.muzzle.GlobalTransform;
        GD.Print("Casted poisonArrow");
    }
	
}
