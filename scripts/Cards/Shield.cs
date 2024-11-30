using Godot;
using System;

public partial class Shield : Card
{
    private AudioStreamPlayer2D audio;

    public Shield()
    {
        this.nombre = "Healing";
        this.usages = 1;
        this.cooldown = 1;
    }
	
	public override void Effect_card(Player player)
    {
        audio = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
        audio.Play();
        player.inmortal = true;
        player.shield.Visible = true;
        GD.Print("Casted healing");
    }

}
