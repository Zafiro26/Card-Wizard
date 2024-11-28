using Godot;
using System;

public partial class FrozenArrow : Card
{
	
    public int damage = 60;
    public int speed = 200;
    public PackedScene projectile;

    public FrozenArrow()
    {
        this.nombre = "FronzeArrow";
        this.usages = 1;
        this.cooldown = 1;
    }

    public override void Effect_card(Player player)
    {
        projectile = GD.Load<PackedScene>("res://scenes/Cards/projectileFrozenArrow.tscn");
        ProjectileFrozenArrow n = (ProjectileFrozenArrow)projectile.Instantiate();
        n.speed = speed;
        n.damage = damage;
        player.GetTree().Root.AddChild(n);
        n.Transform = player.muzzle.GlobalTransform;
        GD.Print("Casted fronzeArrow");
    }
	
}
