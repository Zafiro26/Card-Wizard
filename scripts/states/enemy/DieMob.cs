using Godot;
using System;

public partial class DieMob : State
{

    private Enemy mob;
    public override void Enter()
    {
        mob = GetOwner<Enemy>();
        mob.QueueFree();
    }
}
