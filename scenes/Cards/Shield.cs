using Godot;
using System;

public partial class Shield : Card
{

    private int heal = 20;

    public Shield()
    {
        this.nombre = "Healing";
        this.usages = 1;
        this.cooldown = 1;
    }
	
	public override void Effect_card(Player player)
    {
        player.inmortal = true;
        player.shield.Visible = true;
        GD.Print("Casted healing");
    }

}
