using Godot;
using System;

public partial class Teleport : Card
{
	
    public int damage = 0;
    public int speed = 0;
    public PackedScene projectile;
    private AudioStreamPlayer2D audio;

    public Teleport()
    {
        this.nombre = "SpeedCard";
        this.usages = 1;
        this.cooldown = 1;
    }

    public override void Effect_card(Player player)
    {
        Godot.Vector2 v = GetGlobalMousePosition();
        Godot.Vector2 v2 = (v - player.GlobalPosition).Normalized();

        Godot.Vector2 d = player.GlobalPosition + v2 * 100;

        audio = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
        audio.Play();

        if (player.GlobalPosition.DistanceTo(v) < 100)
        {
            d = v;
        }
        player.GlobalPosition = d;
    }
	
}
