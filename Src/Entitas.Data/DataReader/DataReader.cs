//----------------------------------------------------------------------------
//！！！不要手动修改此文件，此文件由TableReaderGenerator按table.dsl生成！！！
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using Util;

namespace Entitas.Data
{
	public sealed partial class ActionConfig : IData2
	{
		[StructLayout(LayoutKind.Auto, Pack = 1, Size = 24)]
		private struct ActionConfigRecord
		{
			internal int ModelId;
			internal int Description;
			internal int Stand;
			internal int Run;
			internal int Dead;
			internal int Born;
		}

		public int ModelId;
		public string Description;
		public string Stand;
		public string Run;
		public string Dead;
		public string Born;

		public bool CollectDataFromDBC(DBC_Row node)
		{
			ModelId = DBCUtil.ExtractNumeric<int>(node, "ModelId", 0);
			Description = DBCUtil.ExtractString(node, "Description", "");
			Stand = DBCUtil.ExtractString(node, "Stand", "");
			Run = DBCUtil.ExtractString(node, "Run", "");
			Dead = DBCUtil.ExtractString(node, "Dead", "");
			Born = DBCUtil.ExtractString(node, "Born", "");
			return true;
		}

		public bool CollectDataFromBinary(BinaryTable table, int index)
		{
			ActionConfigRecord record = GetRecord(table,index);
			ModelId = DBCUtil.ExtractInt(table, record.ModelId, 0);
			Description = DBCUtil.ExtractString(table, record.Description, "");
			Stand = DBCUtil.ExtractString(table, record.Stand, "");
			Run = DBCUtil.ExtractString(table, record.Run, "");
			Dead = DBCUtil.ExtractString(table, record.Dead, "");
			Born = DBCUtil.ExtractString(table, record.Born, "");
			return true;
		}

		public void AddToBinary(BinaryTable table)
		{
			ActionConfigRecord record = new ActionConfigRecord();
			record.ModelId = DBCUtil.SetValue(table, ModelId, 0);
			record.Description = DBCUtil.SetValue(table, Description, "");
			record.Stand = DBCUtil.SetValue(table, Stand, "");
			record.Run = DBCUtil.SetValue(table, Run, "");
			record.Dead = DBCUtil.SetValue(table, Dead, "");
			record.Born = DBCUtil.SetValue(table, Born, "");
			byte[] bytes = GetRecordBytes(record);
			table.Records.Add(bytes);
		}

		public int GetId()
		{
			return ModelId;
		}

		private unsafe ActionConfigRecord GetRecord(BinaryTable table, int index)
		{
			ActionConfigRecord record;
			byte[] bytes = table.Records[index];
			fixed (byte* p = bytes) {
				record = *(ActionConfigRecord*)p;
			}
			return record;
		}
		private static unsafe byte[] GetRecordBytes(ActionConfigRecord record)
		{
			byte[] bytes = new byte[sizeof(ActionConfigRecord)];
			fixed (byte* p = bytes) {
				ActionConfigRecord* temp = (ActionConfigRecord*)p;
				*temp = record;
			}
			return bytes;
		}
	}

	public sealed partial class ActionConfigProvider
	{
		public void LoadForClient()
		{
			Load(FilePathDefine_Client.C_ActionConfig);
		}
		public void LoadForServer()
		{
			Load(FilePathDefine_Server.C_ActionConfig);
		}
		public void Load(string file)
		{
			if (BinaryTable.IsValid(HomePath.Instance.GetAbsolutePath(file))) {
				m_ActionConfigMgr.CollectDataFromBinary(file);
			} else {
				m_ActionConfigMgr.CollectDataFromDBC(file);
			}
		}
		public void Save(string file)
		{
		#if DEBUG
			m_ActionConfigMgr.SaveToBinary(file);
		#endif
		}
		public void Clear()
		{
			m_ActionConfigMgr.Clear();
		}

		public DataDictionaryMgr2<ActionConfig> ActionConfigMgr
		{
			get { return m_ActionConfigMgr; }
		}

		public int GetActionConfigCount()
		{
			return m_ActionConfigMgr.GetDataCount();
		}

		public ActionConfig GetActionConfig(int id)
		{
			return m_ActionConfigMgr.GetDataById(id);
		}

		private DataDictionaryMgr2<ActionConfig> m_ActionConfigMgr = new DataDictionaryMgr2<ActionConfig>();

		public static ActionConfigProvider Instance
		{
			get { return s_Instance; }
		}
		private static ActionConfigProvider s_Instance = new ActionConfigProvider();
	}
}

namespace Entitas.Data
{
	public sealed partial class AttributeConfig : IData2
	{
		[StructLayout(LayoutKind.Auto, Pack = 1, Size = 44)]
		private struct AttributeConfigRecord
		{
			internal int Id;
			internal int Describe;
			internal int AddStrength;
			internal int AddStrengthRate;
			internal int AddIntelligence;
			internal int AddIntelligenceRate;
			internal int AddCharm;
			internal int AddCharmRate;
			internal int AddAction;
			internal int AddActionMax;
			internal int AddGold;
		}

		public int Id;
		public string Describe;
		public int AddStrength;
		public int AddStrengthRate;
		public int AddIntelligence;
		public int AddIntelligenceRate;
		public int AddCharm;
		public int AddCharmRate;
		public int AddAction;
		public int AddActionMax;
		public int AddGold;

		public bool CollectDataFromDBC(DBC_Row node)
		{
			Id = DBCUtil.ExtractNumeric<int>(node, "Id", 0);
			Describe = DBCUtil.ExtractString(node, "Describe", "");
			AddStrength = DBCUtil.ExtractNumeric<int>(node, "AddStrength", 0);
			AddStrengthRate = DBCUtil.ExtractNumeric<int>(node, "AddStrengthRate", 0);
			AddIntelligence = DBCUtil.ExtractNumeric<int>(node, "AddIntelligence", 0);
			AddIntelligenceRate = DBCUtil.ExtractNumeric<int>(node, "AddIntelligenceRate", 0);
			AddCharm = DBCUtil.ExtractNumeric<int>(node, "AddCharm", 0);
			AddCharmRate = DBCUtil.ExtractNumeric<int>(node, "AddCharmRate", 0);
			AddAction = DBCUtil.ExtractNumeric<int>(node, "AddAction", 0);
			AddActionMax = DBCUtil.ExtractNumeric<int>(node, "AddActionMax", 0);
			AddGold = DBCUtil.ExtractNumeric<int>(node, "AddGold", 0);
			AfterCollectData();
			return true;
		}

		public bool CollectDataFromBinary(BinaryTable table, int index)
		{
			AttributeConfigRecord record = GetRecord(table,index);
			Id = DBCUtil.ExtractInt(table, record.Id, 0);
			Describe = DBCUtil.ExtractString(table, record.Describe, "");
			AddStrength = DBCUtil.ExtractInt(table, record.AddStrength, 0);
			AddStrengthRate = DBCUtil.ExtractInt(table, record.AddStrengthRate, 0);
			AddIntelligence = DBCUtil.ExtractInt(table, record.AddIntelligence, 0);
			AddIntelligenceRate = DBCUtil.ExtractInt(table, record.AddIntelligenceRate, 0);
			AddCharm = DBCUtil.ExtractInt(table, record.AddCharm, 0);
			AddCharmRate = DBCUtil.ExtractInt(table, record.AddCharmRate, 0);
			AddAction = DBCUtil.ExtractInt(table, record.AddAction, 0);
			AddActionMax = DBCUtil.ExtractInt(table, record.AddActionMax, 0);
			AddGold = DBCUtil.ExtractInt(table, record.AddGold, 0);
			AfterCollectData();
			return true;
		}

		public void AddToBinary(BinaryTable table)
		{
			AttributeConfigRecord record = new AttributeConfigRecord();
			record.Id = DBCUtil.SetValue(table, Id, 0);
			record.Describe = DBCUtil.SetValue(table, Describe, "");
			record.AddStrength = DBCUtil.SetValue(table, AddStrength, 0);
			record.AddStrengthRate = DBCUtil.SetValue(table, AddStrengthRate, 0);
			record.AddIntelligence = DBCUtil.SetValue(table, AddIntelligence, 0);
			record.AddIntelligenceRate = DBCUtil.SetValue(table, AddIntelligenceRate, 0);
			record.AddCharm = DBCUtil.SetValue(table, AddCharm, 0);
			record.AddCharmRate = DBCUtil.SetValue(table, AddCharmRate, 0);
			record.AddAction = DBCUtil.SetValue(table, AddAction, 0);
			record.AddActionMax = DBCUtil.SetValue(table, AddActionMax, 0);
			record.AddGold = DBCUtil.SetValue(table, AddGold, 0);
			byte[] bytes = GetRecordBytes(record);
			table.Records.Add(bytes);
		}

		public int GetId()
		{
			return Id;
		}

		private unsafe AttributeConfigRecord GetRecord(BinaryTable table, int index)
		{
			AttributeConfigRecord record;
			byte[] bytes = table.Records[index];
			fixed (byte* p = bytes) {
				record = *(AttributeConfigRecord*)p;
			}
			return record;
		}
		private static unsafe byte[] GetRecordBytes(AttributeConfigRecord record)
		{
			byte[] bytes = new byte[sizeof(AttributeConfigRecord)];
			fixed (byte* p = bytes) {
				AttributeConfigRecord* temp = (AttributeConfigRecord*)p;
				*temp = record;
			}
			return bytes;
		}
	}

	public sealed partial class AttributeConfigProvider
	{
		public void LoadForClient()
		{
			Load(FilePathDefine_Client.C_AttributeConfig);
		}
		public void LoadForServer()
		{
			Load(FilePathDefine_Server.C_AttributeConfig);
		}
		public void Load(string file)
		{
			if (BinaryTable.IsValid(HomePath.Instance.GetAbsolutePath(file))) {
				m_AttributeConfigMgr.CollectDataFromBinary(file);
			} else {
				m_AttributeConfigMgr.CollectDataFromDBC(file);
			}
		}
		public void Save(string file)
		{
		#if DEBUG
			m_AttributeConfigMgr.SaveToBinary(file);
		#endif
		}
		public void Clear()
		{
			m_AttributeConfigMgr.Clear();
		}

		public DataDictionaryMgr2<AttributeConfig> AttributeConfigMgr
		{
			get { return m_AttributeConfigMgr; }
		}

		public int GetAttributeConfigCount()
		{
			return m_AttributeConfigMgr.GetDataCount();
		}

		public AttributeConfig GetAttributeConfig(int id)
		{
			return m_AttributeConfigMgr.GetDataById(id);
		}

		private DataDictionaryMgr2<AttributeConfig> m_AttributeConfigMgr = new DataDictionaryMgr2<AttributeConfig>();

		public static AttributeConfigProvider Instance
		{
			get { return s_Instance; }
		}
		private static AttributeConfigProvider s_Instance = new AttributeConfigProvider();
	}
}

namespace Entitas.Data
{
	public sealed partial class BuffConfig : IData2
	{
		[StructLayout(LayoutKind.Auto, Pack = 1, Size = 20)]
		private struct BuffConfigRecord
		{
			internal int Id;
			internal int Description;
			internal int Script;
			internal int AttrId;
			internal int MaxCount;
		}

		public int Id;
		public string Description;
		public string Script;
		public int AttrId;
		public int MaxCount;

		public bool CollectDataFromDBC(DBC_Row node)
		{
			Id = DBCUtil.ExtractNumeric<int>(node, "Id", 0);
			Description = DBCUtil.ExtractString(node, "Description", "");
			Script = DBCUtil.ExtractString(node, "Script", "");
			AttrId = DBCUtil.ExtractNumeric<int>(node, "AttrId", 0);
			MaxCount = DBCUtil.ExtractNumeric<int>(node, "MaxCount", 0);
			return true;
		}

		public bool CollectDataFromBinary(BinaryTable table, int index)
		{
			BuffConfigRecord record = GetRecord(table,index);
			Id = DBCUtil.ExtractInt(table, record.Id, 0);
			Description = DBCUtil.ExtractString(table, record.Description, "");
			Script = DBCUtil.ExtractString(table, record.Script, "");
			AttrId = DBCUtil.ExtractInt(table, record.AttrId, 0);
			MaxCount = DBCUtil.ExtractInt(table, record.MaxCount, 0);
			return true;
		}

		public void AddToBinary(BinaryTable table)
		{
			BuffConfigRecord record = new BuffConfigRecord();
			record.Id = DBCUtil.SetValue(table, Id, 0);
			record.Description = DBCUtil.SetValue(table, Description, "");
			record.Script = DBCUtil.SetValue(table, Script, "");
			record.AttrId = DBCUtil.SetValue(table, AttrId, 0);
			record.MaxCount = DBCUtil.SetValue(table, MaxCount, 0);
			byte[] bytes = GetRecordBytes(record);
			table.Records.Add(bytes);
		}

		public int GetId()
		{
			return Id;
		}

		private unsafe BuffConfigRecord GetRecord(BinaryTable table, int index)
		{
			BuffConfigRecord record;
			byte[] bytes = table.Records[index];
			fixed (byte* p = bytes) {
				record = *(BuffConfigRecord*)p;
			}
			return record;
		}
		private static unsafe byte[] GetRecordBytes(BuffConfigRecord record)
		{
			byte[] bytes = new byte[sizeof(BuffConfigRecord)];
			fixed (byte* p = bytes) {
				BuffConfigRecord* temp = (BuffConfigRecord*)p;
				*temp = record;
			}
			return bytes;
		}
	}

	public sealed partial class BuffConfigProvider
	{
		public void LoadForClient()
		{
			Load(FilePathDefine_Client.C_BuffConfig);
		}
		public void LoadForServer()
		{
			Load(FilePathDefine_Server.C_BuffConfig);
		}
		public void Load(string file)
		{
			if (BinaryTable.IsValid(HomePath.Instance.GetAbsolutePath(file))) {
				m_BuffConfigMgr.CollectDataFromBinary(file);
			} else {
				m_BuffConfigMgr.CollectDataFromDBC(file);
			}
		}
		public void Save(string file)
		{
		#if DEBUG
			m_BuffConfigMgr.SaveToBinary(file);
		#endif
		}
		public void Clear()
		{
			m_BuffConfigMgr.Clear();
		}

		public DataDictionaryMgr2<BuffConfig> BuffConfigMgr
		{
			get { return m_BuffConfigMgr; }
		}

		public int GetBuffConfigCount()
		{
			return m_BuffConfigMgr.GetDataCount();
		}

		public BuffConfig GetBuffConfig(int id)
		{
			return m_BuffConfigMgr.GetDataById(id);
		}

		private DataDictionaryMgr2<BuffConfig> m_BuffConfigMgr = new DataDictionaryMgr2<BuffConfig>();

		public static BuffConfigProvider Instance
		{
			get { return s_Instance; }
		}
		private static BuffConfigProvider s_Instance = new BuffConfigProvider();
	}
}

namespace Entitas.Data
{
	public sealed partial class CameraConfig : IData2
	{
		[StructLayout(LayoutKind.Auto, Pack = 1, Size = 20)]
		private struct CameraConfigRecord
		{
			internal int Id;
			internal int Description;
			internal float Pitch;
			internal float Yaw;
			internal float Distance;
		}

		public int Id;
		public string Description;
		public float Pitch;
		public float Yaw;
		public float Distance;

		public bool CollectDataFromDBC(DBC_Row node)
		{
			Id = DBCUtil.ExtractNumeric<int>(node, "Id", 0);
			Description = DBCUtil.ExtractString(node, "Description", "");
			Pitch = DBCUtil.ExtractNumeric<float>(node, "Pitch", 0);
			Yaw = DBCUtil.ExtractNumeric<float>(node, "Yaw", 0);
			Distance = DBCUtil.ExtractNumeric<float>(node, "Distance", 0);
			return true;
		}

		public bool CollectDataFromBinary(BinaryTable table, int index)
		{
			CameraConfigRecord record = GetRecord(table,index);
			Id = DBCUtil.ExtractInt(table, record.Id, 0);
			Description = DBCUtil.ExtractString(table, record.Description, "");
			Pitch = DBCUtil.ExtractFloat(table, record.Pitch, 0);
			Yaw = DBCUtil.ExtractFloat(table, record.Yaw, 0);
			Distance = DBCUtil.ExtractFloat(table, record.Distance, 0);
			return true;
		}

		public void AddToBinary(BinaryTable table)
		{
			CameraConfigRecord record = new CameraConfigRecord();
			record.Id = DBCUtil.SetValue(table, Id, 0);
			record.Description = DBCUtil.SetValue(table, Description, "");
			record.Pitch = DBCUtil.SetValue(table, Pitch, 0);
			record.Yaw = DBCUtil.SetValue(table, Yaw, 0);
			record.Distance = DBCUtil.SetValue(table, Distance, 0);
			byte[] bytes = GetRecordBytes(record);
			table.Records.Add(bytes);
		}

		public int GetId()
		{
			return Id;
		}

		private unsafe CameraConfigRecord GetRecord(BinaryTable table, int index)
		{
			CameraConfigRecord record;
			byte[] bytes = table.Records[index];
			fixed (byte* p = bytes) {
				record = *(CameraConfigRecord*)p;
			}
			return record;
		}
		private static unsafe byte[] GetRecordBytes(CameraConfigRecord record)
		{
			byte[] bytes = new byte[sizeof(CameraConfigRecord)];
			fixed (byte* p = bytes) {
				CameraConfigRecord* temp = (CameraConfigRecord*)p;
				*temp = record;
			}
			return bytes;
		}
	}

	public sealed partial class CameraConfigProvider
	{
		public void LoadForClient()
		{
			Load(FilePathDefine_Client.C_CameraConfig);
		}
		public void LoadForServer()
		{
			Load(FilePathDefine_Server.C_CameraConfig);
		}
		public void Load(string file)
		{
			if (BinaryTable.IsValid(HomePath.Instance.GetAbsolutePath(file))) {
				m_CameraConfigMgr.CollectDataFromBinary(file);
			} else {
				m_CameraConfigMgr.CollectDataFromDBC(file);
			}
		}
		public void Save(string file)
		{
		#if DEBUG
			m_CameraConfigMgr.SaveToBinary(file);
		#endif
		}
		public void Clear()
		{
			m_CameraConfigMgr.Clear();
		}

		public DataDictionaryMgr2<CameraConfig> CameraConfigMgr
		{
			get { return m_CameraConfigMgr; }
		}

		public int GetCameraConfigCount()
		{
			return m_CameraConfigMgr.GetDataCount();
		}

		public CameraConfig GetCameraConfig(int id)
		{
			return m_CameraConfigMgr.GetDataById(id);
		}

		private DataDictionaryMgr2<CameraConfig> m_CameraConfigMgr = new DataDictionaryMgr2<CameraConfig>();

		public static CameraConfigProvider Instance
		{
			get { return s_Instance; }
		}
		private static CameraConfigProvider s_Instance = new CameraConfigProvider();
	}
}

namespace Entitas.Data
{
	public sealed partial class CharacterConfig : IData2
	{
		[StructLayout(LayoutKind.Auto, Pack = 1, Size = 36)]
		private struct CharacterConfigRecord
		{
			internal int Id;
			internal int Description;
			internal int Model;
			internal float Scale;
			internal int ActionId;
			internal int ActionPrefix;
			internal int AIScript;
			internal int AttrId;
			internal int Skills;
		}

		public int Id;
		public string Description;
		public string Model;
		public float Scale;
		public int ActionId;
		public string ActionPrefix;
		public string AIScript;
		public int AttrId;
		public int[] Skills;

		public bool CollectDataFromDBC(DBC_Row node)
		{
			Id = DBCUtil.ExtractNumeric<int>(node, "Id", 0);
			Description = DBCUtil.ExtractString(node, "Description", "");
			Model = DBCUtil.ExtractString(node, "Model", "");
			Scale = DBCUtil.ExtractNumeric<float>(node, "Scale", 0);
			ActionId = DBCUtil.ExtractNumeric<int>(node, "ActionId", 0);
			ActionPrefix = DBCUtil.ExtractString(node, "ActionPrefix", "");
			AIScript = DBCUtil.ExtractString(node, "AIScript", "");
			AttrId = DBCUtil.ExtractNumeric<int>(node, "AttrId", 0);
			Skills = DBCUtil.ExtractNumericArray<int>(node, "Skills", null);
			return true;
		}

		public bool CollectDataFromBinary(BinaryTable table, int index)
		{
			CharacterConfigRecord record = GetRecord(table,index);
			Id = DBCUtil.ExtractInt(table, record.Id, 0);
			Description = DBCUtil.ExtractString(table, record.Description, "");
			Model = DBCUtil.ExtractString(table, record.Model, "");
			Scale = DBCUtil.ExtractFloat(table, record.Scale, 0);
			ActionId = DBCUtil.ExtractInt(table, record.ActionId, 0);
			ActionPrefix = DBCUtil.ExtractString(table, record.ActionPrefix, "");
			AIScript = DBCUtil.ExtractString(table, record.AIScript, "");
			AttrId = DBCUtil.ExtractInt(table, record.AttrId, 0);
			Skills = DBCUtil.ExtractIntArray(table, record.Skills, null);
			return true;
		}

		public void AddToBinary(BinaryTable table)
		{
			CharacterConfigRecord record = new CharacterConfigRecord();
			record.Id = DBCUtil.SetValue(table, Id, 0);
			record.Description = DBCUtil.SetValue(table, Description, "");
			record.Model = DBCUtil.SetValue(table, Model, "");
			record.Scale = DBCUtil.SetValue(table, Scale, 0);
			record.ActionId = DBCUtil.SetValue(table, ActionId, 0);
			record.ActionPrefix = DBCUtil.SetValue(table, ActionPrefix, "");
			record.AIScript = DBCUtil.SetValue(table, AIScript, "");
			record.AttrId = DBCUtil.SetValue(table, AttrId, 0);
			record.Skills = DBCUtil.SetValue(table, Skills, null);
			byte[] bytes = GetRecordBytes(record);
			table.Records.Add(bytes);
		}

		public int GetId()
		{
			return Id;
		}

		private unsafe CharacterConfigRecord GetRecord(BinaryTable table, int index)
		{
			CharacterConfigRecord record;
			byte[] bytes = table.Records[index];
			fixed (byte* p = bytes) {
				record = *(CharacterConfigRecord*)p;
			}
			return record;
		}
		private static unsafe byte[] GetRecordBytes(CharacterConfigRecord record)
		{
			byte[] bytes = new byte[sizeof(CharacterConfigRecord)];
			fixed (byte* p = bytes) {
				CharacterConfigRecord* temp = (CharacterConfigRecord*)p;
				*temp = record;
			}
			return bytes;
		}
	}

	public sealed partial class CharacterConfigProvider
	{
		public void LoadForClient()
		{
			Load(FilePathDefine_Client.C_CharacterConfig);
		}
		public void LoadForServer()
		{
			Load(FilePathDefine_Server.C_CharacterConfig);
		}
		public void Load(string file)
		{
			if (BinaryTable.IsValid(HomePath.Instance.GetAbsolutePath(file))) {
				m_CharacterConfigMgr.CollectDataFromBinary(file);
			} else {
				m_CharacterConfigMgr.CollectDataFromDBC(file);
			}
		}
		public void Save(string file)
		{
		#if DEBUG
			m_CharacterConfigMgr.SaveToBinary(file);
		#endif
		}
		public void Clear()
		{
			m_CharacterConfigMgr.Clear();
		}

		public DataDictionaryMgr2<CharacterConfig> CharacterConfigMgr
		{
			get { return m_CharacterConfigMgr; }
		}

		public int GetCharacterConfigCount()
		{
			return m_CharacterConfigMgr.GetDataCount();
		}

		public CharacterConfig GetCharacterConfig(int id)
		{
			return m_CharacterConfigMgr.GetDataById(id);
		}

		private DataDictionaryMgr2<CharacterConfig> m_CharacterConfigMgr = new DataDictionaryMgr2<CharacterConfig>();

		public static CharacterConfigProvider Instance
		{
			get { return s_Instance; }
		}
		private static CharacterConfigProvider s_Instance = new CharacterConfigProvider();
	}
}

namespace Entitas.Data
{
	public sealed partial class SceneConfig : IData2
	{
		[StructLayout(LayoutKind.Auto, Pack = 1, Size = 20)]
		private struct SceneConfigRecord
		{
			internal int Id;
			internal int Description;
			internal int Name;
			internal int Script;
			internal int Navmesh;
		}

		public int Id;
		public string Description;
		public string Name;
		public string Script;
		public string Navmesh;

		public bool CollectDataFromDBC(DBC_Row node)
		{
			Id = DBCUtil.ExtractNumeric<int>(node, "Id", 0);
			Description = DBCUtil.ExtractString(node, "Description", "");
			Name = DBCUtil.ExtractString(node, "Name", "");
			Script = DBCUtil.ExtractString(node, "Script", "");
			Navmesh = DBCUtil.ExtractString(node, "Navmesh", "");
			return true;
		}

		public bool CollectDataFromBinary(BinaryTable table, int index)
		{
			SceneConfigRecord record = GetRecord(table,index);
			Id = DBCUtil.ExtractInt(table, record.Id, 0);
			Description = DBCUtil.ExtractString(table, record.Description, "");
			Name = DBCUtil.ExtractString(table, record.Name, "");
			Script = DBCUtil.ExtractString(table, record.Script, "");
			Navmesh = DBCUtil.ExtractString(table, record.Navmesh, "");
			return true;
		}

		public void AddToBinary(BinaryTable table)
		{
			SceneConfigRecord record = new SceneConfigRecord();
			record.Id = DBCUtil.SetValue(table, Id, 0);
			record.Description = DBCUtil.SetValue(table, Description, "");
			record.Name = DBCUtil.SetValue(table, Name, "");
			record.Script = DBCUtil.SetValue(table, Script, "");
			record.Navmesh = DBCUtil.SetValue(table, Navmesh, "");
			byte[] bytes = GetRecordBytes(record);
			table.Records.Add(bytes);
		}

		public int GetId()
		{
			return Id;
		}

		private unsafe SceneConfigRecord GetRecord(BinaryTable table, int index)
		{
			SceneConfigRecord record;
			byte[] bytes = table.Records[index];
			fixed (byte* p = bytes) {
				record = *(SceneConfigRecord*)p;
			}
			return record;
		}
		private static unsafe byte[] GetRecordBytes(SceneConfigRecord record)
		{
			byte[] bytes = new byte[sizeof(SceneConfigRecord)];
			fixed (byte* p = bytes) {
				SceneConfigRecord* temp = (SceneConfigRecord*)p;
				*temp = record;
			}
			return bytes;
		}
	}

	public sealed partial class SceneConfigProvider
	{
		public void LoadForClient()
		{
			Load(FilePathDefine_Client.C_SceneConfig);
		}
		public void LoadForServer()
		{
			Load(FilePathDefine_Server.C_SceneConfig);
		}
		public void Load(string file)
		{
			if (BinaryTable.IsValid(HomePath.Instance.GetAbsolutePath(file))) {
				m_SceneConfigMgr.CollectDataFromBinary(file);
			} else {
				m_SceneConfigMgr.CollectDataFromDBC(file);
			}
		}
		public void Save(string file)
		{
		#if DEBUG
			m_SceneConfigMgr.SaveToBinary(file);
		#endif
		}
		public void Clear()
		{
			m_SceneConfigMgr.Clear();
		}

		public DataDictionaryMgr2<SceneConfig> SceneConfigMgr
		{
			get { return m_SceneConfigMgr; }
		}

		public int GetSceneConfigCount()
		{
			return m_SceneConfigMgr.GetDataCount();
		}

		public SceneConfig GetSceneConfig(int id)
		{
			return m_SceneConfigMgr.GetDataById(id);
		}

		private DataDictionaryMgr2<SceneConfig> m_SceneConfigMgr = new DataDictionaryMgr2<SceneConfig>();

		public static SceneConfigProvider Instance
		{
			get { return s_Instance; }
		}
		private static SceneConfigProvider s_Instance = new SceneConfigProvider();
	}
}

namespace Entitas.Data
{
	public sealed partial class SkillConfig : IData2
	{
		[StructLayout(LayoutKind.Auto, Pack = 1, Size = 20)]
		private struct SkillConfigRecord
		{
			internal int Id;
			internal int Description;
			internal int Script;
			internal int BreakType;
			internal int NextId;
		}

		public int Id;
		public string Description;
		public string Script;
		public int BreakType;
		public int NextId;

		public bool CollectDataFromDBC(DBC_Row node)
		{
			Id = DBCUtil.ExtractNumeric<int>(node, "Id", 0);
			Description = DBCUtil.ExtractString(node, "Description", "");
			Script = DBCUtil.ExtractString(node, "Script", "");
			BreakType = DBCUtil.ExtractNumeric<int>(node, "BreakType", 0);
			NextId = DBCUtil.ExtractNumeric<int>(node, "NextId", 0);
			return true;
		}

		public bool CollectDataFromBinary(BinaryTable table, int index)
		{
			SkillConfigRecord record = GetRecord(table,index);
			Id = DBCUtil.ExtractInt(table, record.Id, 0);
			Description = DBCUtil.ExtractString(table, record.Description, "");
			Script = DBCUtil.ExtractString(table, record.Script, "");
			BreakType = DBCUtil.ExtractInt(table, record.BreakType, 0);
			NextId = DBCUtil.ExtractInt(table, record.NextId, 0);
			return true;
		}

		public void AddToBinary(BinaryTable table)
		{
			SkillConfigRecord record = new SkillConfigRecord();
			record.Id = DBCUtil.SetValue(table, Id, 0);
			record.Description = DBCUtil.SetValue(table, Description, "");
			record.Script = DBCUtil.SetValue(table, Script, "");
			record.BreakType = DBCUtil.SetValue(table, BreakType, 0);
			record.NextId = DBCUtil.SetValue(table, NextId, 0);
			byte[] bytes = GetRecordBytes(record);
			table.Records.Add(bytes);
		}

		public int GetId()
		{
			return Id;
		}

		private unsafe SkillConfigRecord GetRecord(BinaryTable table, int index)
		{
			SkillConfigRecord record;
			byte[] bytes = table.Records[index];
			fixed (byte* p = bytes) {
				record = *(SkillConfigRecord*)p;
			}
			return record;
		}
		private static unsafe byte[] GetRecordBytes(SkillConfigRecord record)
		{
			byte[] bytes = new byte[sizeof(SkillConfigRecord)];
			fixed (byte* p = bytes) {
				SkillConfigRecord* temp = (SkillConfigRecord*)p;
				*temp = record;
			}
			return bytes;
		}
	}

	public sealed partial class SkillConfigProvider
	{
		public void LoadForClient()
		{
			Load(FilePathDefine_Client.C_SkillConfig);
		}
		public void LoadForServer()
		{
			Load(FilePathDefine_Server.C_SkillConfig);
		}
		public void Load(string file)
		{
			if (BinaryTable.IsValid(HomePath.Instance.GetAbsolutePath(file))) {
				m_SkillConfigMgr.CollectDataFromBinary(file);
			} else {
				m_SkillConfigMgr.CollectDataFromDBC(file);
			}
		}
		public void Save(string file)
		{
		#if DEBUG
			m_SkillConfigMgr.SaveToBinary(file);
		#endif
		}
		public void Clear()
		{
			m_SkillConfigMgr.Clear();
		}

		public DataDictionaryMgr2<SkillConfig> SkillConfigMgr
		{
			get { return m_SkillConfigMgr; }
		}

		public int GetSkillConfigCount()
		{
			return m_SkillConfigMgr.GetDataCount();
		}

		public SkillConfig GetSkillConfig(int id)
		{
			return m_SkillConfigMgr.GetDataById(id);
		}

		private DataDictionaryMgr2<SkillConfig> m_SkillConfigMgr = new DataDictionaryMgr2<SkillConfig>();

		public static SkillConfigProvider Instance
		{
			get { return s_Instance; }
		}
		private static SkillConfigProvider s_Instance = new SkillConfigProvider();
	}
}

namespace Entitas.Data
{
	public sealed partial class WorksConfig : IData2
	{
		[StructLayout(LayoutKind.Auto, Pack = 1, Size = 20)]
		private struct WorksConfigRecord
		{
			internal int Id;
			internal int Description;
			internal int CostAction;
			internal int AddAttrType;
			internal int AddAttrValue;
		}

		public int Id;
		public string Description;
		public int CostAction;
		public int AddAttrType;
		public int AddAttrValue;

		public bool CollectDataFromDBC(DBC_Row node)
		{
			Id = DBCUtil.ExtractNumeric<int>(node, "Id", 0);
			Description = DBCUtil.ExtractString(node, "Description", "");
			CostAction = DBCUtil.ExtractNumeric<int>(node, "CostAction", 0);
			AddAttrType = DBCUtil.ExtractNumeric<int>(node, "AddAttrType", 0);
			AddAttrValue = DBCUtil.ExtractNumeric<int>(node, "AddAttrValue", 0);
			return true;
		}

		public bool CollectDataFromBinary(BinaryTable table, int index)
		{
			WorksConfigRecord record = GetRecord(table,index);
			Id = DBCUtil.ExtractInt(table, record.Id, 0);
			Description = DBCUtil.ExtractString(table, record.Description, "");
			CostAction = DBCUtil.ExtractInt(table, record.CostAction, 0);
			AddAttrType = DBCUtil.ExtractInt(table, record.AddAttrType, 0);
			AddAttrValue = DBCUtil.ExtractInt(table, record.AddAttrValue, 0);
			return true;
		}

		public void AddToBinary(BinaryTable table)
		{
			WorksConfigRecord record = new WorksConfigRecord();
			record.Id = DBCUtil.SetValue(table, Id, 0);
			record.Description = DBCUtil.SetValue(table, Description, "");
			record.CostAction = DBCUtil.SetValue(table, CostAction, 0);
			record.AddAttrType = DBCUtil.SetValue(table, AddAttrType, 0);
			record.AddAttrValue = DBCUtil.SetValue(table, AddAttrValue, 0);
			byte[] bytes = GetRecordBytes(record);
			table.Records.Add(bytes);
		}

		public int GetId()
		{
			return Id;
		}

		private unsafe WorksConfigRecord GetRecord(BinaryTable table, int index)
		{
			WorksConfigRecord record;
			byte[] bytes = table.Records[index];
			fixed (byte* p = bytes) {
				record = *(WorksConfigRecord*)p;
			}
			return record;
		}
		private static unsafe byte[] GetRecordBytes(WorksConfigRecord record)
		{
			byte[] bytes = new byte[sizeof(WorksConfigRecord)];
			fixed (byte* p = bytes) {
				WorksConfigRecord* temp = (WorksConfigRecord*)p;
				*temp = record;
			}
			return bytes;
		}
	}

	public sealed partial class WorksConfigProvider
	{
		public void LoadForClient()
		{
			Load(FilePathDefine_Client.C_WorksConfig);
		}
		public void LoadForServer()
		{
			Load(FilePathDefine_Server.C_WorksConfig);
		}
		public void Load(string file)
		{
			if (BinaryTable.IsValid(HomePath.Instance.GetAbsolutePath(file))) {
				m_WorksConfigMgr.CollectDataFromBinary(file);
			} else {
				m_WorksConfigMgr.CollectDataFromDBC(file);
			}
		}
		public void Save(string file)
		{
		#if DEBUG
			m_WorksConfigMgr.SaveToBinary(file);
		#endif
		}
		public void Clear()
		{
			m_WorksConfigMgr.Clear();
		}

		public DataDictionaryMgr2<WorksConfig> WorksConfigMgr
		{
			get { return m_WorksConfigMgr; }
		}

		public int GetWorksConfigCount()
		{
			return m_WorksConfigMgr.GetDataCount();
		}

		public WorksConfig GetWorksConfig(int id)
		{
			return m_WorksConfigMgr.GetDataById(id);
		}

		private DataDictionaryMgr2<WorksConfig> m_WorksConfigMgr = new DataDictionaryMgr2<WorksConfig>();

		public static WorksConfigProvider Instance
		{
			get { return s_Instance; }
		}
		private static WorksConfigProvider s_Instance = new WorksConfigProvider();
	}
}
