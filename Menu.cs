using Godot;
using GodotPlugins.Game;
using System;

public partial class Menu : Control
{
	private Control mainMenu;
    private Control SettingsMenu;
	private Label hiscore;
	private Label score;

	int high;
	int last;

    public override void _Ready()
    {
        mainMenu = GetNode<Control>("Main");
        SettingsMenu = GetNode<Control>("Settings");
		hiscore = GetNode<Label>("Main/VBoxContainer/hiscore");
		score = GetNode<Label>("Main/VBoxContainer/score");


		hiscore.Text = "HIGHEST SCORE: " + GameState.Highscore.ToString();
		score.Text = "Score: " + GameState.Lastscore.ToString();
		SettingsMenu.Hide();

    }

	// Called when the node enters the scene tree for the first time.
	private void _Quit()
	{
		GetTree().Quit();
	}

	private void _Start()
	{
		GameState.Reset_score();
		GetTree().ChangeSceneToFile("res://main_scene.tscn");
	}

	private void _Settings()
	{
		mainMenu.Hide();
		SettingsMenu.Show();
	}



	
}
