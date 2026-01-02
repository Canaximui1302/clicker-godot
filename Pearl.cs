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
	public override void _Process(double delta)
	{
		Vector2 movement = new Vector2(0, 0);
		if (Input.IsKeyPressed(Key.W)) {
			movement += new Vector2(0, -1);
		}
		if (Input.IsKeyPressed(Key.A)) {
			movement += new Vector2(-1, 0);
		}
		if (Input.IsKeyPressed(Key.S)) {
			movement += new Vector2(0, 1);
		}
		if (Input.IsKeyPressed(Key.D)) {
			movement += new Vector2(1, 0);
		}
		this.Position += movement.Normalized() * 3;
	}
}
