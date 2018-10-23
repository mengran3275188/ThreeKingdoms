//----------------------------------------------------------------------------
//！！！不要手动修改此文件，此文件由LogicDataGenerator按AttributeConfig.txt生成！！！
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Util;

namespace Entitas.Data
{
	public sealed partial class AttributeConfig : IData2
	{
	private enum ValueType : int
		{
			AbsoluteValue = 0,
			PercentValue,
			LevelRateValue,
		}
		public const int c_MaxAbsoluteValue = 1000000000;
		public const int c_MaxPercentValue = 2000000000;
		public const float c_Rate = 100.0f;

		private float m_AddStrength = 0;
		private int m_StrengthType = 0;
		private float m_AddStrengthRate = 0;
		private int m_StrengthRateType = 0;
		private float m_AddIntelligence = 0;
		private int m_IntelligenceType = 0;
		private float m_AddIntelligenceRate = 0;
		private int m_IntelligenceRateType = 0;
		private float m_AddCharm = 0;
		private int m_CharmType = 0;
		private float m_AddCharmRate = 0;
		private int m_CharmRateType = 0;
		private float m_AddAction = 0;
		private int m_ActionType = 0;
		private float m_AddActionMax = 0;
		private int m_ActionMaxType = 0;
		private float m_AddGold = 0;
		private int m_GoldType = 0;

		private void AfterCollectData()
		{
			m_AddStrength = CalcRealValue(AddStrength, out m_StrengthType);
			m_AddStrengthRate = CalcRealValue(AddStrengthRate, out m_StrengthRateType);
			m_AddIntelligence = CalcRealValue(AddIntelligence, out m_IntelligenceType);
			m_AddIntelligenceRate = CalcRealValue(AddIntelligenceRate, out m_IntelligenceRateType);
			m_AddCharm = CalcRealValue(AddCharm, out m_CharmType);
			m_AddCharmRate = CalcRealValue(AddCharmRate, out m_CharmRateType);
			m_AddAction = CalcRealValue(AddAction, out m_ActionType);
			m_AddActionMax = CalcRealValue(AddActionMax, out m_ActionMaxType);
			m_AddGold = CalcRealValue(AddGold, out m_GoldType);
		}

		public float GetStrength(float refVal, int refLevel)
		{
			return CalcAddedAttrValue(refVal, refLevel, m_AddStrength, m_StrengthType);
		}
		public float GetStrengthRate(float refVal, int refLevel)
		{
			return CalcAddedAttrValue(refVal, refLevel, m_AddStrengthRate, m_StrengthRateType);
		}
		public float GetIntelligence(float refVal, int refLevel)
		{
			return CalcAddedAttrValue(refVal, refLevel, m_AddIntelligence, m_IntelligenceType);
		}
		public float GetIntelligenceRate(float refVal, int refLevel)
		{
			return CalcAddedAttrValue(refVal, refLevel, m_AddIntelligenceRate, m_IntelligenceRateType);
		}
		public float GetCharm(float refVal, int refLevel)
		{
			return CalcAddedAttrValue(refVal, refLevel, m_AddCharm, m_CharmType);
		}
		public float GetCharmRate(float refVal, int refLevel)
		{
			return CalcAddedAttrValue(refVal, refLevel, m_AddCharmRate, m_CharmRateType);
		}
		public float GetAction(float refVal, int refLevel)
		{
			return CalcAddedAttrValue(refVal, refLevel, m_AddAction, m_ActionType);
		}
		public float GetActionMax(float refVal, int refLevel)
		{
			return CalcAddedAttrValue(refVal, refLevel, m_AddActionMax, m_ActionMaxType);
		}
		public float GetGold(float refVal, int refLevel)
		{
			return CalcAddedAttrValue(refVal, refLevel, m_AddGold, m_GoldType);
		}

		private float CalcRealValue(int tableValue, out int type)
		{
			float retVal = 0;
			int val = tableValue;
			bool isNegative = false;
			if(tableValue < 0){;
				isNegative =true;
				val = -val;
			};
			if(val < c_MaxAbsoluteValue) {
				retVal = val / c_Rate;
				type = (int)ValueType.AbsoluteValue;
			}else if(val < c_MaxPercentValue) {
				retVal = (val - c_MaxAbsoluteValue) / c_Rate / 100;
				type = (int)ValueType.PercentValue;
			}else{
				retVal = (val - c_MaxPercentValue) / c_Rate / 100;
				type = (int)ValueType.LevelRateValue;
			}
			if(isNegative)
				retVal = -retVal;
			return retVal;
		}

		private float CalcAddedAttrValue(float refVal, int refLevel, float addVal, int type)
		{
			float retVal = 0;
			switch(type){
				case (int)ValueType.AbsoluteValue:
					retVal = addVal;
					break;
				case (int)ValueType.PercentValue:
					retVal = refVal * addVal;
					break;
				case (int)ValueType.LevelRateValue:
					retVal = refLevel * addVal;
					break;
			}
			return retVal;
		}
	}
}

