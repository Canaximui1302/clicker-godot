using Godot;
using System;

public partial class Area2d : Area2D
{
	private RandomNumberGenerator rng = new RandomNumberGenerator();
    private const float Margin = 50f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		rng.Randomize();
		// Place character at the center of the viewport
        Position = GetViewportRect().Size / 2;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _InputEvent(Viewport viewport, InputEvent @ev, int shapeIdx)
	{
		if (@ev is InputEventMouseButton mouse && mouse.ButtonIndex == MouseButton.Left && mouse.Pressed)
        {
            GD.Print("Character clicked!");

            Vector2 screenSize = viewport.GetVisibleRect().Size;

            float x = rng.RandfRange(Margin, screenSize.X - Margin);
            float y = rng.RandfRange(Margin, screenSize.Y - Margin);

            Position = new Vector2(x, y);
        }
	}
}
