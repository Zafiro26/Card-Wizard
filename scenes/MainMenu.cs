using Godot;
using System;

public partial class MainMenu : Control
{

    private Button playButton;
    private Button obtionsButton;
    private Button exitButton;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

        playButton = GetNode<Button>("MarginContainer/VBoxContainer/PlayButton");
        obtionsButton = GetNode<Button>("MarginContainer/VBoxContainer/ObtionsButton");
        exitButton = GetNode<Button>("MarginContainer/VBoxContainer/ExitButton");

        playButton.Pressed += onPlayButtonPressed;
        obtionsButton.Pressed += onObtionsButtonPressed;
        exitButton.Pressed += onExitButtonPressed;
	}

    private void onExitButtonPressed()
    {
        GetTree().Quit();
    }


    private void onObtionsButtonPressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/world.tscn");
    }


    private void onPlayButtonPressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/world.tscn");
    }
}
