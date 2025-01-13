using Godot;
using System;

public partial class InvisibleCard : Card
{
	
    public int damage = 50;
    public int speed = 100;

    public InvisibleCard()
    {
        this.nombre = "InvisibleCard";
        this.usages = 1;
        this.cooldown = 1;
    }

    public override void Effect_card(Player player)
    {

    }
	
}
