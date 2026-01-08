using Godot;
using System;
using System.Linq.Expressions;

public partial class Area2d : Area2D
{
	private RandomNumberGenerator rng = new RandomNumberGenerator();
	private Label UItimer;
	private Label Score;
	private Timer mytimer;
	private float timeleft = 15f;
    private const float Margin = 50f;
	private int score;
	private Control pauseMenu;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		pauseMenu = GetParent().GetNode<Control>("PauseMenu");
		pauseMenu.Hide();
		rng.Randomize();
		// Place character at the center of the viewport
        Position = GetViewportRect().Size / 2;

		mytimer = GetNode<Timer>("Timer");

		UItimer = GetParent().GetNode<Label>("gameUI/container/countdown");
		Score = GetParent().GetNode<Label>("gameUI/container/score");

		score = 0;

		mytimer.Start(15);
	}

    public override void _Process(double delta)
    {
        timeleft -= (float)delta;
		if (timeleft < 0)
			timeleft = 0;
		UItimer.Text = "Time left: " + Mathf.Ceil(timeleft).ToString();
		Score.Text = "Score: " + score.ToString();
    }


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _InputEvent(Viewport viewport, InputEvent @ev, int shapeIdx)
	{
		if (@ev is InputEventMouseButton mouse && mouse.ButtonIndex == MouseButton.Left && mouse.Pressed)
        {
            // GD.Print("Character clicked!");

            Vector2 screenSize = viewport.GetVisibleRect().Size;

            float x = rng.RandfRange(Margin, screenSize.X - Margin);
            float y = rng.RandfRange(Margin, screenSize.Y - Margin);
			score += 1;
            Position = new Vector2(x, y);
        }
		if (@ev is InputEventKey key && key.Pressed && key.Keycode == Key.Escape)
		{
			pauseMenu.Show();
		}
	}

	public override void _Input(InputEvent @key)
	{
		if (@key is InputEventKey k && k.Pressed && k.Keycode == Key.Escape)
		{
			Hide();
			pauseMenu.Show();
		}
	}

	public  void _Timeout()
	{
		GetTree().ChangeSceneToFile("res://menu.tscn");
	}
}
