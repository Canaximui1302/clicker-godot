using Godot;
using System;

public partial class Menu : Control
{
	private Control mainMenu;
    private Control optionsMenu;

    public override void _Ready()
    {
        mainMenu = GetNode<Control>("Main");
        optionsMenu = GetNode<Control>("Settings");

		ShowMain();
    }

	private void ShowMain()
	{
		mainMenu.Show();
		optionsMenu.Hide();
	}

	private void ShowSettings()
	{
		mainMenu.Hide();
		optionsMenu.Show();
	}
	// Called when the node enters the scene tree for the first time.
	private void _Quit()
	{
		GetTree().Quit();
	}

	private void _Start()
	{
		GetTree().ChangeSceneToFile("res://main_scene.tscn");
	}

	private void _Settings()
	{
		ShowSettings();
	}

	private void _Back()
	{
		ShowMain();
	}
	
}
