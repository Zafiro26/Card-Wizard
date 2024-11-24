using Godot;
using System;

public partial class Healing : Card
{

    private int heal = 20;

    public Healing()
    {
        this.nombre = "Healing";
        this.id = 1;
        this.usages = 1;
        this.cooldown = 1;
    }
	
	public override void Effect_card(Player player)
    {
        player.heal(heal);
        GD.Print("Casted healing");
    }

}
