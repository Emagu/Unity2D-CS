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

    protected override void Update()
    {	
		bool isRun = false;
        if (Input.GetKey(KeyCode.A))
		{
			isRun = true;
			if(!isRetreat)
			{
				Filp();
			}
			transform.Translate(Vector2.right * Time.deltaTime); //往左
		}
		if (Input.GetKey(KeyCode.D))
		{
			isRun = true;
			if(isRetreat)
			{
				Filp();
			}
			transform.Translate(Vector2.right * Time.deltaTime); //往右
		}
		Move(isRun);
		base.Update();
    }
	
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
