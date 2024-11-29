using Godot;
using System;

public partial class Teleport : Card
{
	
    public int damage = 0;
    public int speed = 0;
    public PackedScene projectile;

    public Teleport()
    {
        this.nombre = "SpeedCard";
        this.usages = 1;
        this.cooldown = 1;
    }

    public override void Effect_card(Player player)
    {
        Godot.Vector2 v = GetGlobalMousePosition();
        v = ToLocal(v);

        player.GlobalPosition = v;
        GD.Print("Casted teleport");
    }
	
}
