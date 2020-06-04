using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Unit : Object
{
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
		switch(CommandStatus)
		{
			case CommandType.Hold:
				Move(false);

				if (EnemyList.Count > 0)
				{
					Attack();
				}
				else
				{
					SelectCommand(CommandSelected.ToString());
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
		if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			Anim.Play("Attack");
			return true;
		}
		return false;
	}

	protected virtual void CalAttackDamage()
	{
		Object targetEmemy = EnemyList.First();
		bool isCirt = Random.Range(0, 100) < 30;
		DamagePopup.Create(targetEmemy.transform.position, isCirt ? 150 : 100, isCirt);
		targetEmemy.HealthPoint -= 1;
	}
}
