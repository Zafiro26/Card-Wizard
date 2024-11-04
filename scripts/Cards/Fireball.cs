using Godot;
using System;

public partial class Fireball : Card
{
	
    int damage = 10;

    public override void Effect_card()
    {
        Player player = GetTree().GetFirstNodeInGroup("player") as Player;
        player.Take_damage(damage);
        GD.Print("Casted fireball");
    }
	
}
