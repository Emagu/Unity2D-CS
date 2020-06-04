using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		HandleWeaponTrigger(collision, true);
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		HandleWeaponTrigger(collision, true);
	}

    private void OnTriggerExit2D(Collider2D collision)
	{
		HandleWeaponTrigger(collision, false);
	}

    private void HandleWeaponTrigger(Collider2D collision, bool isContact)
	{
        Transform selfParent = transform.parent;
        GameObject enemy = collision.gameObject;
        Unit selfUnit = selfParent.gameObject.GetComponent<Unit>();
		if (collision.CompareTag("Body") && !selfParent.CompareTag(enemy.transform.parent.tag))
		{
			if (isContact)
			{
				selfUnit.EnemyList.Add(enemy.GetComponent<Unit>());
				selfUnit.SelectCommand(CommandType.Hold.ToString());
			}
			else 
			{
				selfUnit.EnemyList.Remove(enemy.GetComponent<Unit>());
			}
		}
	}
}
