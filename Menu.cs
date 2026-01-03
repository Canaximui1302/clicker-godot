using Godot;
using System;

public partial class Menu : Node2D
{
	// Called when the node enters the scene tree for the first time.
	private void _Quit()
	{
		GetTree().Quit();
	}

	private void _Start()
	{
		GetTree().ChangeSceneToFile("res://main_scene.tscn");
	}
	
}
