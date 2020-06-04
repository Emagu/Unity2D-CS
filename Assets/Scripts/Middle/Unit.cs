using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Unit : Object
{
	protected CommandType CommandSelected = CommandType.Hold;
	protected Animator Anim;
	protected bool isRetreat = false;

	public List<Object> EnemyList = new List<Object>();

	private void Awake()
    {
        Anim = gameObject.GetComponent<Animator>();
    }
	
	protected virtual void Update()
	{
		CommandUpdateEvent();
	}
	
	protected void Move(bool isRun)
	{
		Anim.SetFloat("Direction", isRetreat ? 1 : -1);
		Anim.SetBool("Run", isRun);
		if(isRun)
		{
			transform.Translate(Vector2.right * Time.deltaTime);
		}
	}
	
	protected void Filp()
	{
		isRetreat = !isRetreat;
		transform.Rotate(Vector3.up * 180);
	}
	
	protected virtual void CommandUpdateEvent()
	{
		switch(CommandSelected)
		{
			case CommandType.Hold:
				Move(false);

				if (EnemyList.Count > 0 && Attack())
				{
                    Object targetEmemy = EnemyList.First();
					DamagePopup.Create(targetEmemy.transform.position, 100);
				}
				break;
			case CommandType.Forward:
				if(isRetreat)
				{
					Filp();
				}
				Move(true);
				break;
			case CommandType.Retreat:
				if(!isRetreat)
				{
					Filp();
				}
				Move(true);
				break;
		}
	}

	protected virtual bool Attack()
	{
		Debug.LogWarning("Not Set Attack Event");
		return false;
	}

	public void SelectCommand(string CommandKey)
	{
		CommandSelected = (CommandType)System.Enum.Parse(typeof(CommandType), CommandKey);
	}
}
