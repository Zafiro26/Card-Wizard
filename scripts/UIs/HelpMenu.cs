using Godot;
using System;

public partial class HelpMenu : Control
{

    private Button objetive;
    private Button cards;
    private Button keybinds;
    private Button menu;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

        objetive = GetNode<Button>("MarginContainer/VBoxContainer/PlayButton");
        cards = GetNode<Button>("MarginContainer/VBoxContainer/ObtionsButton");
        keybinds = GetNode<Button>("MarginContainer/VBoxContainer/Keybinds");
        menu = GetNode<Button>("MarginContainer/VBoxContainer/ExitButton");
        objetive.GrabFocus();

        objetive.Pressed += onPlayButtonPressed;
        cards.Pressed += onObtionsButtonPressed;
        menu.Pressed += onExitButtonPressed;
        keybinds.Pressed += OnKeybindsButtonPressed;
	}

    private void OnKeybindsButtonPressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/UIs/keybinds_menu.tscn");
    }


    private void onExitButtonPressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/UIs/menu.tscn");
    }


    private void onObtionsButtonPressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/UIs/cards_menu.tscn");
    }


    private void onPlayButtonPressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/UIs/objective_menu.tscn");
    }
}
