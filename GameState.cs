using Godot;
using System;


public partial class GameState : Node
{
	static public int Lastscore {get; set;} = 0;
	static public int Highscore {get; set;} = 0;

	static public void Reset_score()
	{
		Lastscore = 0;
	}
	
	static public void Save_score()
	{
		if (Lastscore > Highscore)
			Highscore = Lastscore;
	}

}
