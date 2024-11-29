using Godot;
using System;

public partial class BadCardSlow : Card
{

    private float duration = 5f;

    public BadCardSlow()
    {
        this.nombre = "Healing";
        this.usages = 1;
        this.cooldown = 1;
    }
	
	public override void Effect_card(Player player)
    {
        Timer timer = player.speedTimer;
        float b = player.base_speed;
        b = (float)b * (float)0.5;
        player.speed = b;
        timer.Start(duration);
        GD.Print("Casted bad slow");
    }

}
