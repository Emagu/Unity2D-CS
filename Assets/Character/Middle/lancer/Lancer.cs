using System.Collections.Generic;
using UnityEngine;

public class Lancer : Unit
{
	public static readonly List<CommandType> CommandTypes = new List<CommandType> 
	{ 
		CommandType.Hold,
		CommandType.Forward, 
		CommandType.Retreat 
	};

	protected override bool Attack()
	{
		if(Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			Anim.Play(isRetreat ? "LancerLeftAttack" : "LancerRightAttack");
			return true;
		}
		return false;
	}
	
}
