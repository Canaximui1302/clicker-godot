/* 
Autoload Node 
This file is for global variables, namely score and highest score.
These variables are to be accessed and used in many different scenes (scripts).

GameState Node can be accessed without any instantiation.

IMPORTANT: always build the project once before adding an Autoload.
*/

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
