using Godot;
using System;

public partial class CardsMenu : Control
{

    private Button next;
    private Button menu;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        next = GetNode<Button>("CanvasLayer/Button2");
        menu = GetNode<Button>("CanvasLayer/Button");

        next.Pressed += OnNextButtonPressed;
        menu.Pressed += OnMenuButtonPressed;
	}

    private void OnMenuButtonPressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/UIs/menu.tscn");
    }


    private void OnNextButtonPressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/UIs/cards_menu2.tscn");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
