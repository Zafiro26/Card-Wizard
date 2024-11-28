using Godot;
using System;

public partial class DieMob : State
{

    private Enemy mob;
    public AnimatedSprite2D anim;
    public override async void Enter()
    {
        mob = GetOwner<Enemy>();
        anim = mob.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        //anim.AnimationFinished += OnAnimationFinished;
        anim.Play("died");
        await ToSignal(anim, "animation_finished");
        mob.QueueFree();
        
    }

}
