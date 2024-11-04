using Godot;
using System;

public partial class Card : Node
{

    enum type {PROJECTILE, DEFENSE, HEALTH}

    [Export] private int id;
    [Export] private type t;
    [Export] private String nombre;
    [Export] private int usages;

    public void Init_card()
    {

    }

    /*
    * Cast the effect of the card, reduce the usages.
    * @return true if it has more usages after cast and false if it does not
    */
    public bool Cast_card()
    {

        if (usages >= 0)
        {
            GD.Print("Carta %d usada", id);
            this.Effect_card();
            usages--;
        }
        else
        {
            GD.Print("Carta %d sin usos", id);
        }

        if (usages > 0)
        {
            return true;
        }

        return false;

    }

    /*
    * The effect of the card, muest be override for each card
    */
    public virtual void Effect_card() {}


}
