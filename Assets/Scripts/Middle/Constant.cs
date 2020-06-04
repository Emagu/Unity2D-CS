using System.Collections.Generic;

public enum CommandType
{
	Hold,
	Forward,
	Retreat
}

public class Constant
{
	public static Dictionary<CommandType, string> CommandTranslation = new Dictionary<CommandType, string>
	{
		{CommandType.Hold, "Hold_String"},
		{CommandType.Forward, "Forward_String"},
		{CommandType.Retreat, "Retreat_String"}
	};

	public const int ArmorRank = 5;//無視護甲係數
	
	public const int MaxArmorRank = 100;//最高無視護甲係數
	
	public const int MinArmorRank = 0;//最低無視護甲係數
	
	public const int ArrowAromrMitigate = 50;//弓箭對護甲降傷
	
	public const int BlockCoefficient = 40;//格擋係數
	
	public const int MaxCritRate = 100;//最高爆擊率
	
	public const int MinCritRate = 0;//最低爆擊率
	
	public const int MaxBlockRate = 100;//最高格擋率
}


