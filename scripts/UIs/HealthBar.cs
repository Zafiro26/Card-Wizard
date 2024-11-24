using Godot;
using System;
using System.Runtime.InteropServices;

public partial class HealthBar : ProgressBar
{

    public int health = 0;
    public int prevHealth;
    public ProgressBar damageBar;
    public Timer timer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        damageBar = GetNode<ProgressBar>("DamageBar");
        timer = GetNode<Timer>("Timer");

        timer.Timeout += onTimerTimeout;
	}

    private void onTimerTimeout()
    {
        damageBar.Value = health;
    }

    public void init_health(int health)
    {
        this.health = health;
        MaxValue = health;
        Value = health;
        damageBar.MaxValue = health;
        damageBar.Value = health;

    }

    public void set_health(int newHealth)
    {
        prevHealth = health;
        health = Math.Min((int)MaxValue, newHealth);
        Value = health;

        if (health <= 0)
        {
            this.QueueFree();
        }
        if (health < prevHealth)
        {
            timer.Start(0.4f);
        }
        else
        {
            damageBar.Value = health;
        }

    }
}
