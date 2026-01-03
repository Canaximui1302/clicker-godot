using Godot;
using System;

public partial class PauseMenu : Control
{
	private Control optionsMenu;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		optionsMenu = GetNode<Control>("Settings");
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	private void _Exit()
	{
		GetTree().Quit();
	}
}
