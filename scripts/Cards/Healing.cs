using Godot;
using System;

public partial class Healing : Card
{

    private int heal = 20;
	
	public override void Effect_card()
    {
        Player player = GetTree().GetFirstNodeInGroup("player") as Player;
        player.heal(heal);
    }

}
