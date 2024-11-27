using Godot;
using System;

public partial class Card : Node2D
{

    public String nombre;
    public int usages;
    public int cooldown;
    [Export] public Sprite2D sprite2D;
    //public Label lebel;

    public override void _Ready()
    {
        //lebel = GetNode<Label>("Cost/CostLabel");
    }

    public void Init_card(String name, int usages, int cooldown)
    {
        this.nombre = name;
        this.usages = usages;  
        this.cooldown = cooldown;
    }

    private void Update_cost()
    {
        //lebel.Text = usages.ToString();
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
            GD.Print("Carta " + nombre + " usada");
            this.Effect_card(player);
            usages--;
        }
        else
        {
            GD.Print("Carta " + nombre + " sin usos");
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
