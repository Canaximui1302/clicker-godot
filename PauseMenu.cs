using Godot;
using System;

public partial class PauseMenu : Control
{
	private string path_to_main_screen = "res://menu.tscn";
	private Node parent;

	public override void _Ready()
	{
		ProcessMode = Node.ProcessModeEnum.WhenPaused;
		parent = GetParent();
	}

	private void _Resume()
	{
		// Unpause the game scene tree and hide this menu
		GetTree().Paused = false;
		Hide();
		parent.GetNode<Area2D>("Area2D").Show();
	}

	private void _Exit()
	{
		// Unpause the game scene tree and exit
		GetTree().Paused = false;
		GetTree().Quit();
	}

	private void _Quit()
	{
		// Unpause the game scene tree and quit to the main menu scene
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile(path_to_main_screen);
	}
}
