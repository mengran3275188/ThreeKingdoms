//----------------------------------------------------------------------------
//！！！不要手动修改此文件，此文件由LogicDataGenerator按AttributeConfig.txt生成！！！
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Entitas.Data
{
	public sealed class AttributeData
	{
		//----------------------------------------------------------------------------
		//基础属性以及读写接口
		//----------------------------------------------------------------------------
		public void SetStrength(Operate_Type opType, float tVal)
		{
			m_Strength = UpdateAttr(m_Strength, m_Strength, opType, tVal);
		}
		public float Strength
		{
			get { return m_Strength / s_Key; }
		}
		private float m_Strength;

		public void SetStrengthRate(Operate_Type opType, float tVal)
		{
			m_StrengthRate = UpdateAttr(m_StrengthRate, m_StrengthRate, opType, tVal);
		}
		public float StrengthRate
		{
			get { return m_StrengthRate / s_Key; }
		}
		private float m_StrengthRate;

		public void SetIntelligence(Operate_Type opType, float tVal)
		{
			m_Intelligence = UpdateAttr(m_Intelligence, m_Intelligence, opType, tVal);
		}
		public float Intelligence
		{
			get { return m_Intelligence / s_Key; }
		}
		private float m_Intelligence;

		public void SetIntelligenceRate(Operate_Type opType, float tVal)
		{
			m_IntelligenceRate = UpdateAttr(m_IntelligenceRate, m_IntelligenceRate, opType, tVal);
		}
		public float IntelligenceRate
		{
			get { return m_IntelligenceRate / s_Key; }
		}
		private float m_IntelligenceRate;

		public void SetCharm(Operate_Type opType, float tVal)
		{
			m_Charm = UpdateAttr(m_Charm, m_Charm, opType, tVal);
		}
		public float Charm
		{
			get { return m_Charm / s_Key; }
		}
		private float m_Charm;

		public void SetCharmRate(Operate_Type opType, float tVal)
		{
			m_CharmRate = UpdateAttr(m_CharmRate, m_CharmRate, opType, tVal);
		}
		public float CharmRate
		{
			get { return m_CharmRate / s_Key; }
		}
		private float m_CharmRate;

		public void SetAction(Operate_Type opType, float tVal)
		{
			m_Action = UpdateAttr(m_Action, m_Action, opType, tVal);
		}
		public float Action
		{
			get { return m_Action / s_Key; }
		}
		private float m_Action;

		public void SetActionMax(Operate_Type opType, float tVal)
		{
			m_ActionMax = UpdateAttr(m_ActionMax, m_ActionMax, opType, tVal);
		}
		public float ActionMax
		{
			get { return m_ActionMax / s_Key; }
		}
		private float m_ActionMax;

		public void SetGold(Operate_Type opType, float tVal)
		{
			m_Gold = UpdateAttr(m_Gold, m_Gold, opType, tVal);
		}
		public float Gold
		{
			get { return m_Gold / s_Key; }
		}
		private float m_Gold;

		//------------------------------------------------------------------------
		//指定属性枚举获取属性值，全部转化为float类型,返回值需要自行转换类型
		//------------------------------------------------------------------------
		public float GetAttributeByType(AttrbuteEnum attrType)
		{
			float attValue = 0;
			switch (attrType) {
				case AttrbuteEnum.Actual_Strength:
					attValue = Strength;
					break;
				case AttrbuteEnum.Actual_StrengthRate:
					attValue = StrengthRate;
					break;
				case AttrbuteEnum.Actual_Intelligence:
					attValue = Intelligence;
					break;
				case AttrbuteEnum.Actual_IntelligenceRate:
					attValue = IntelligenceRate;
					break;
				case AttrbuteEnum.Actual_Charm:
					attValue = Charm;
					break;
				case AttrbuteEnum.Actual_CharmRate:
					attValue = CharmRate;
					break;
				case AttrbuteEnum.Actual_Action:
					attValue = Action;
					break;
				case AttrbuteEnum.Actual_ActionMax:
					attValue = ActionMax;
					break;
				case AttrbuteEnum.Actual_Gold:
					attValue = Gold;
					break;
				default:
					attValue = -1;
					break;
			}
			return attValue;
		}
		//------------------------------------------------------------------------
		//指定属性枚举值设置属性值,属性值参数为float类型，内部根据属性类型自行转换
		//------------------------------------------------------------------------
		public void SetAttributeByType(AttrbuteEnum attrType, Operate_Type opType, float tVal)
		{
			switch (attrType) {
				case AttrbuteEnum.Actual_Strength:
					SetStrength(opType, (int)tVal);
					break;
				case AttrbuteEnum.Actual_StrengthRate:
					SetStrengthRate(opType, (int)tVal);
					break;
				case AttrbuteEnum.Actual_Intelligence:
					SetIntelligence(opType, (int)tVal);
					break;
				case AttrbuteEnum.Actual_IntelligenceRate:
					SetIntelligenceRate(opType, (int)tVal);
					break;
				case AttrbuteEnum.Actual_Charm:
					SetCharm(opType, (int)tVal);
					break;
				case AttrbuteEnum.Actual_CharmRate:
					SetCharmRate(opType, (int)tVal);
					break;
				case AttrbuteEnum.Actual_Action:
					SetAction(opType, (int)tVal);
					break;
				case AttrbuteEnum.Actual_ActionMax:
					SetActionMax(opType, (int)tVal);
					break;
				case AttrbuteEnum.Actual_Gold:
					SetGold(opType, (int)tVal);
					break;
			default:
				break;
			}
		}
		//------------------------------------------------------------------------
		//属性修改接口
		//------------------------------------------------------------------------
		public static float UpdateAttr(float val, float maxVal, Operate_Type opType, float tVal)
		{
			float ret = val;
			if (opType == Operate_Type.OT_PercentMax) {
				float t = maxVal * (tVal / 100.0f);
				ret = t;
			} else {
				ret = UpdateAttr(val, opType, tVal);
			}
			return ret;
		}

		public static float UpdateAttr(float val, Operate_Type opType, float tVal)
		{
			float ret = val;
			if (opType == Operate_Type.OT_Absolute) {
				ret = tVal * s_Key;
			} else if (opType == Operate_Type.OT_Relative) {
				float t = (ret + tVal * s_Key);
				if (t < 0) {
					t = 0;
				}
				ret = t;
			} else if (opType == Operate_Type.OT_PercentCurrent) {
				float t = (ret * (tVal / 100.0f));
				ret = t;
			}
			return ret;
		}
		//------------------------------------------------------------------------
		// 属性初始化接口
		//------------------------------------------------------------------------
		public void SetAbsoluteByConfig(AttributeConfig attr)
		{
			float aStrength = attr.GetStrength(0, 0);
			float aStrengthRate = attr.GetStrengthRate(0, 0);
			float aIntelligence = attr.GetIntelligence(0, 0);
			float aIntelligenceRate = attr.GetIntelligenceRate(0, 0);
			float aCharm = attr.GetCharm(0, 0);
			float aCharmRate = attr.GetCharmRate(0, 0);
			float aAction = attr.GetAction(0, 0);
			float aActionMax = attr.GetActionMax(0, 0);
			float aGold = attr.GetGold(0, 0);
			SetStrength(Operate_Type.OT_Absolute, aStrength);
			SetStrengthRate(Operate_Type.OT_Absolute, aStrengthRate);
			SetIntelligence(Operate_Type.OT_Absolute, aIntelligence);
			SetIntelligenceRate(Operate_Type.OT_Absolute, aIntelligenceRate);
			SetCharm(Operate_Type.OT_Absolute, aCharm);
			SetCharmRate(Operate_Type.OT_Absolute, aCharmRate);
			SetAction(Operate_Type.OT_Absolute, aAction);
			SetActionMax(Operate_Type.OT_Absolute, aActionMax);
			SetGold(Operate_Type.OT_Absolute, aGold);
		}
		public void SetRelativeByConfig(AttributeConfig attr)
		{
			SetStrength(Operate_Type.OT_Relative, attr.GetStrength(Strength, 0));
			SetStrengthRate(Operate_Type.OT_Relative, attr.GetStrengthRate(StrengthRate, 0));
			SetIntelligence(Operate_Type.OT_Relative, attr.GetIntelligence(Intelligence, 0));
			SetIntelligenceRate(Operate_Type.OT_Relative, attr.GetIntelligenceRate(IntelligenceRate, 0));
			SetCharm(Operate_Type.OT_Relative, attr.GetCharm(Charm, 0));
			SetCharmRate(Operate_Type.OT_Relative, attr.GetCharmRate(CharmRate, 0));
			SetAction(Operate_Type.OT_Relative, attr.GetAction(Action, 0));
			SetActionMax(Operate_Type.OT_Relative, attr.GetActionMax(ActionMax, 0));
			SetGold(Operate_Type.OT_Relative, attr.GetGold(Gold, 0));
		}
		//------------------------------------------------------------------------
		//注意：Key的修改应该在所有对象创建前执行，否则属性会乱！！！
		//------------------------------------------------------------------------
		public static int Key
		{
			get { return s_Key; }
			set { s_Key = value; }
		}
		private static int s_Key = 1;

	}
}
