using Godot;
using System;


public partial class Pearl : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Place character at the center of the viewport
        Position = GetViewportRect().Size / 2;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Input(InputEvent @ev)
	{
		var ScreenSize = GetViewportRect();
		int distance = 100;
		int X = (int) ScreenSize.Size.X;
		int Y = (int) ScreenSize.Size.Y;
		Random rnd = new Random();
		if (@ev is InputEventMouseButton mouseEv && mouseEv.Pressed)
		{
			if (mouseEv.ButtonIndex == MouseButton.Left)
			{
				GD.Print("Left clicked");
				var randX = rnd.Next(distance, X - distance + 1);
				var randY = rnd.Next(distance, Y - distance + 1);
				this.Position = new Vector2(randX, randY);
			}
		}
	}
}
