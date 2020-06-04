using UnityEngine;

public class Object : MonoBehaviour
{
	public int HealthPoint = 100;
	public int ManaPoint;
	public int ArmorPoint;//護甲值
	public int AttackPoint = 10;
	public int PenetrateMitigate;//穿透減傷(%)
	public int PenetrateResistance;//穿透抵抗
	public int PenetrateLevel;//穿透等級
	public int ChopMitigate;//劈砍減傷(%)
	public int ChopResistance;//劈砍抵抗
	public int ChopLevel;//劈砍等級
	public int InsightPoint;//洞察值
	public int BlockPoint;//格擋機率(%)
	public int DodgePoint;//迴避
	public int FocusPoint;//命中
	public int CritAddition;//爆擊傷害(%)
	public int CritResistance;//爆擊抵抗
	public int AttackAddition;//傷害提升(%)

	protected CommandType CommandSelected = CommandType.Hold;
	protected CommandType CommandStatus = CommandType.Hold;
	public static Object Create(Transform createObject, Vector3 posistion, bool isEnemy = false)
	{
        Transform ob = Instantiate(createObject, posistion, Quaternion.identity);
		if (isEnemy)
		{
			ob.tag = "Enemy";
			ob.Rotate(new Vector3(0, 180, 0));
		}
		
		return ob.gameObject.GetComponent<Object>();
	}

	protected int CalPenetrateRate(Object target)
	{
		int rank = PenetrateLevel - target.PenetrateResistance;
		return 100 - rank.RangeIn(Constant.MaxArmorRank, Constant.MinArmorRank) * Constant.ArmorRank;
	}
	
	protected int CalChopRate(Object target)
	{
		int rank = ChopLevel - target.ChopResistance;
		return 100 - rank.RangeIn(Constant.MaxArmorRank, Constant.MinArmorRank) * Constant.ArmorRank;
	}
	
	protected bool CalIsCrit(Object target)
	{
		int rank = InsightPoint - target.CritResistance;
		return Random.Range(0, Constant.MaxCritRate) < rank.RangeIn(Constant.MaxCritRate, Constant.MinCritRate);
	}
	
	protected bool CalIsBlock(Object target)
	{
		return Random.Range(0, Constant.MaxBlockRate) < target.BlockPoint;
	}
	
	protected bool CalIsDodge(Object target)
	{
		return Random.Range(0, Constant.MaxBlockRate) < target.BlockPoint;
	}
	
	protected int CalAttackDamage(Object target, int SkillAddition, int OverPowerDamage = 0)
	{
		int damageCritAddition = 100;
		int damageBlockAddition = 100;
		
		if(CalIsCrit(target))
		{
			damageCritAddition += CritAddition;
		}
		
		if(CalIsBlock(target))
		{
			damageBlockAddition = Constant.BlockCoefficient;
		}
		
		return (int)Mathf.Round(AttackPoint
								* SkillAddition.Rate()
								* (100 + AttackAddition).Rate() 
								* damageCritAddition.Rate() 
								* damageBlockAddition.Rate());
	}

	public void SelectCommand(string CommandKey, bool tempStatus = false)
	{
		CommandStatus = (CommandType)System.Enum.Parse(typeof(CommandType), CommandKey);
		if (!tempStatus)
		{
			CommandSelected = CommandStatus;
		}
	}
}
