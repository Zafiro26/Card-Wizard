using Godot;
using System;

public partial class Card : Node
{


    [Export] public int id;
    [Export] public String nombre;
    [Export] public int usages;
    [Export] public int cooldown = 0;

    public Card()
    {
    }

    public void Init_card()
    {

    }

    /*
    * Cast the effect of the card, reduce the usages.
    * @return false if it has more usages after cast and true if it does not
    */
    public bool Cast_card(Player player)
    {

        bool r = true;

        if (usages >= 0)
        {
            GD.Print("Carta " + nombre + id + " usada");
            this.Effect_card(player);
            usages--;
        }
        else
        {
            GD.Print("Carta %d sin usos", id);
            //GD.Print("Carta " + nombre + id + " usada");
        }

        if (usages <= 0)
        {
            r = false;
        }

        return r;

    }

    /*
    * The effect of the card, muest be override for each card
    */
    public virtual void Effect_card(Player player) {}


}
