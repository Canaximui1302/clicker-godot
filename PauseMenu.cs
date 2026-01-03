using Godot;
using System;

public partial class PauseMenu : Control
{
	private string path_to_main_screen = "res://menu.tscn";
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	private void _Exit()
	{
		GetTree().Quit();
	}

	private void _Quit()
	{
		GetTree().ChangeSceneToFile(path_to_main_screen);
	}
}
