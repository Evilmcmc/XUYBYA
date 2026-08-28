using Il2CppDummyDll;
using UnityEngine;

namespace Crosstales.Common.Util;

[Token(Token = "0x20001DA")]
[DisallowMultipleComponent]
public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
	[Token(Token = "0x40009C3")]
	[FieldOffset(Offset = "0x0")]
	[Tooltip("Don't destroy gameobject during scene switches (default: false).")]
	[SerializeField]
	private bool dontDestroy;

	[Token(Token = "0x40009C4")]
	[FieldOffset(Offset = "0x0")]
	public static string PrefabPath;

	[Token(Token = "0x40009C5")]
	[FieldOffset(Offset = "0x0")]
	public static string GameObjectName;

	[Token(Token = "0x40009C6")]
	[FieldOffset(Offset = "0x0")]
	protected static T instance;

	[Token(Token = "0x40009C7")]
	[FieldOffset(Offset = "0x0")]
	private static readonly object LOCK_OBJ;

	[Token(Token = "0x1700013F")]
	public static T Instance
	{
		[Token(Token = "0x6000FA8")]
		get
		{
			return null;
		}
		[Token(Token = "0x6000FA9")]
		protected set
		{
		}
	}

	[Token(Token = "0x17000140")]
	public bool DontDestroy
	{
		[Token(Token = "0x6000FAA")]
		get
		{
			return default(bool);
		}
		[Token(Token = "0x6000FAB")]
		set
		{
		}
	}

	[Token(Token = "0x6000FAC")]
	protected virtual void Awake()
	{
	}

	[Token(Token = "0x6000FAD")]
	protected virtual void OnDestroy()
	{
	}

	[Token(Token = "0x6000FAE")]
	protected virtual void OnApplicationQuit()
	{
	}

	[Token(Token = "0x6000FAF")]
	public static void CreateInstance(bool searchExistingGameObject = true, bool deleteExistingInstance = false)
	{
	}

	[Token(Token = "0x6000FB0")]
	public static void DeleteInstance()
	{
	}

	[Token(Token = "0x6000FB1")]
	protected Singleton()
	{
	}
}
