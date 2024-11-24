using Godot;
using System;

public partial class Fireball : Card
{
	
    public int damage = 10;

    public Fireball()
    {
        this.nombre = "Fireball";
        this.id = 0;
        this.usages = 1;
        this.cooldown = 1;
    }

    public override void Effect_card(Player player)
    {
        player.shoot();
        GD.Print("Casted fireball");
    }
	
}
