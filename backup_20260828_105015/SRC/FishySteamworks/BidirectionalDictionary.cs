using System.Collections;
using System.Collections.Generic;
using Il2CppDummyDll;

namespace FishySteamworks;

[Token(Token = "0x2000156")]
public class BidirectionalDictionary<T1, T2> : IEnumerable
{
	[Token(Token = "0x4000838")]
	[FieldOffset(Offset = "0x0")]
	private Dictionary<T1, T2> t1ToT2Dict;

	[Token(Token = "0x4000839")]
	[FieldOffset(Offset = "0x0")]
	private Dictionary<T2, T1> t2ToT1Dict;

	[Token(Token = "0x170000ED")]
	public IEnumerable<T1> FirstTypes
	{
		[Token(Token = "0x6000C55")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x170000EE")]
	public IEnumerable<T2> SecondTypes
	{
		[Token(Token = "0x6000C56")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x170000EF")]
	public int Count
	{
		[Token(Token = "0x6000C58")]
		get
		{
			return default(int);
		}
	}

	[Token(Token = "0x170000F0")]
	public Dictionary<T1, T2> First
	{
		[Token(Token = "0x6000C59")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x170000F1")]
	public Dictionary<T2, T1> Second
	{
		[Token(Token = "0x6000C5A")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x170000F2")]
	public T1 this[T2 key]
	{
		[Token(Token = "0x6000C65")]
		get
		{
			return (T1)null;
		}
		[Token(Token = "0x6000C66")]
		set
		{
		}
	}

	[Token(Token = "0x170000F3")]
	public T2 this[T1 key]
	{
		[Token(Token = "0x6000C67")]
		get
		{
			return (T2)null;
		}
		[Token(Token = "0x6000C68")]
		set
		{
		}
	}

	[Token(Token = "0x6000C57")]
	public IEnumerator GetEnumerator()
	{
		return null;
	}

	[Token(Token = "0x6000C5B")]
	public void Add(T1 key, T2 value)
	{
	}

	[Token(Token = "0x6000C5C")]
	public void Add(T2 key, T1 value)
	{
	}

	[Token(Token = "0x6000C5D")]
	public T2 Get(T1 key)
	{
		return (T2)null;
	}

	[Token(Token = "0x6000C5E")]
	public T1 Get(T2 key)
	{
		return (T1)null;
	}

	[Token(Token = "0x6000C5F")]
	public bool TryGetValue(T1 key, out T2 value)
	{
		return default(bool);
	}

	[Token(Token = "0x6000C60")]
	public bool TryGetValue(T2 key, out T1 value)
	{
		return default(bool);
	}

	[Token(Token = "0x6000C61")]
	public bool Contains(T1 key)
	{
		return default(bool);
	}

	[Token(Token = "0x6000C62")]
	public bool Contains(T2 key)
	{
		return default(bool);
	}

	[Token(Token = "0x6000C63")]
	public void Remove(T1 key)
	{
	}

	[Token(Token = "0x6000C64")]
	public void Remove(T2 key)
	{
	}

	[Token(Token = "0x6000C69")]
	public BidirectionalDictionary()
	{
	}
}
