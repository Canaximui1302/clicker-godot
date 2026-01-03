using Godot;
using System;

public partial class Menu : Control
{
	private Control mainMenu;
    private Control SettingsMenu;

    public override void _Ready()
    {
        mainMenu = GetNode<Control>("Main");
        SettingsMenu = GetNode<Control>("Settings");

		SettingsMenu.Hide();

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
		mainMenu.Hide();
		SettingsMenu.Show();
	}

	private void _Back()
	{
		mainMenu.Show();
		SettingsMenu.Hide();
	}

	
}
