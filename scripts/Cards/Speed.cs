using Godot;
using System;

public partial class Speed : Card
{
	
    public int damage = 0;
    public int speed = 0;
    public PackedScene projectile;

    public Speed()
    {
        this.nombre = "SpeedCard";
        this.usages = 1;
        this.cooldown = 1;
    }

    public override void Effect_card(Player player)
    {
        Timer timer = player.speedTimer;
        float b = player.base_speed;
        b = (float)b * (float)1.2;
        player.speed = b;
        timer.Start(4.0f);
        GD.Print("Casted fronzeArrow");
    }
	
}
