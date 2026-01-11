using Godot;
using System;
using System.Linq.Expressions;

public partial class Area2d : Area2D
{
	private RandomNumberGenerator rng = new RandomNumberGenerator();
	private Label UItimer;
	private Label Score;
	private Timer mytimer;
	private AudioStreamPlayer2D click_sfx;
	private float timeleft = 15f;
    private const float Margin = 50f;

	private Control pauseMenu;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		pauseMenu = GetParent().GetNode<Control>("PauseMenu");
		pauseMenu.Hide();
		rng.Randomize();
		// Place character at the center of the viewport
        Position = GetViewportRect().Size / 2;

		// Getting necessary Nodes for controlling the UI and the game timer
		mytimer = GetNode<Timer>("Timer");
		UItimer = GetParent().GetNode<Label>("gameUI/container/countdown");
		Score = GetParent().GetNode<Label>("gameUI/container/score");

		click_sfx = GetNode<AudioStreamPlayer2D>("click_sound");
		// Start count down of 15 seconds
		mytimer.Start(15);
	}

	// Process function is just for timer countdown since we do not have any physical movements or objects.
    public override void _Process(double delta)
    {
        timeleft -= (float)delta;
		if (timeleft < 0)
			timeleft = 0;
		UItimer.Text = "Time left: " + Mathf.Ceil(timeleft).ToString();
		Score.Text = "Score: " + GameState.Lastscore.ToString();
    }

	// Use InputEvent to take mouse left click input
	// InputEvent records input that happens on the node
	// In this case we want to detect clicks on the character
	// and generate new position for the character after each click, and increase the score as well
	public override void _InputEvent(Viewport viewport, InputEvent @ev, int shapeIdx)
	{
		if (@ev is InputEventMouseButton mouse && mouse.ButtonIndex == MouseButton.Left && mouse.Pressed)
        {
			click_sfx.Play();
            // GD.Print("Character clicked!"); // for debugging
            Vector2 screenSize = viewport.GetVisibleRect().Size;

            float x = rng.RandfRange(Margin, screenSize.X - Margin);
            float y = rng.RandfRange(Margin, screenSize.Y - Margin);
			GameState.Lastscore += 1;
            Position = new Vector2(x, y);
        }

		// If Esc key is pressed, show up the paused menu
	}


	// If Esc key is pressed, show up the paused menu\
	// Here we use Input because the key press event can be 
	// detected globally on the scene, not on any specific node
	public override void _Input(InputEvent @key)
	{
		if (@key is InputEventKey k && k.Pressed && k.Keycode == Key.Escape)
		{
			GetTree().Paused = true;
			Hide();
			pauseMenu.Show();
		}
	}

	// When timer is done counting down, change to the main menu scene 
	// and save the score of the last game
	public  void _Timeout()
	{
		GameState.Save_score();
		GetTree().ChangeSceneToFile("res://menu.tscn");
	}
}
