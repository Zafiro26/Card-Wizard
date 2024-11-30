using Godot;
using System;

public partial class Healing : Card
{

    private int heal = 20;
    private AudioStreamPlayer2D audio;

    public Healing()
    {
        this.nombre = "Healing";
        this.usages = 1;
        this.cooldown = 1;
    }
	
	public override void Effect_card(Player player)
    {
        audio = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
        audio.Play();
        player.heal(heal);
        GD.Print("Casted healing");
    }

}
