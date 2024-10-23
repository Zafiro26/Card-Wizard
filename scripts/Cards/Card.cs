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

    public void Cast_card()
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

    }

    public virtual void Effect_card() {}


}
