using Godot;
using System;

public partial class ObjectiveMenu : Control
{

    private Button back;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        back = GetNode<Button>("Button");

        back.Pressed += OnButtonBackPressed;
	}

    private void OnButtonBackPressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/UIs/menu.tscn");
    }

}
