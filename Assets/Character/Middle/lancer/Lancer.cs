﻿using System.Collections.Generic;

public class Lancer : Unit
{
	public static readonly List<CommandType> CommandTypes = new List<CommandType> 
	{ 
		CommandType.Hold,
		CommandType.Forward, 
		CommandType.Retreat 
	};

}
