using Godot;
using System;

public partial class FrozenArrow : Card
{
	
    public int damage = 60;
    public int speed = 200;
    public PackedScene projectile;
    private AudioStreamPlayer2D audio;

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

        audio = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
        audio.Play();
        
        player.GetTree().Root.AddChild(n);
        n.Transform = player.muzzle.GlobalTransform;
        GD.Print("Casted fronzeArrow");
    }
	
}
