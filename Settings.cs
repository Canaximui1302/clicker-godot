using Godot;
using System;

public partial class Settings : Control
{
	private Control Main;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Hide();
		Main = GetParent().GetNode<Control>("Main");
	}

	private void _Back()
	{
		Hide();
		Main.Show();
	} 
}
