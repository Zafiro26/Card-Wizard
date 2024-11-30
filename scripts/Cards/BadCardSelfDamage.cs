using Godot;
using System;

public partial class BadCardSelfDamage : Card
{


    public BadCardSelfDamage()
    {
        this.nombre = "Healing";
        this.usages = 1;
        this.cooldown = 1;
    }
	
	public override void Effect_card(Player player)
    {
        player.Take_damage(20);
        GD.Print("Casted bad take damage");
    }

}
