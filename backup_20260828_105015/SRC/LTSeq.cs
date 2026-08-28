using System;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000130")]
public class LTSeq
{
	[Token(Token = "0x40006ED")]
	[FieldOffset(Offset = "0x10")]
	public LTSeq previous;

	[Token(Token = "0x40006EE")]
	[FieldOffset(Offset = "0x18")]
	public LTSeq current;

	[Token(Token = "0x40006EF")]
	[FieldOffset(Offset = "0x20")]
	public LTDescr tween;

	[Token(Token = "0x40006F0")]
	[FieldOffset(Offset = "0x28")]
	public float totalDelay;

	[Token(Token = "0x40006F1")]
	[FieldOffset(Offset = "0x2C")]
	public float timeScale;

	[Token(Token = "0x40006F2")]
	[FieldOffset(Offset = "0x30")]
	private int debugIter;

	[Token(Token = "0x40006F3")]
	[FieldOffset(Offset = "0x34")]
	public uint counter;

	[Token(Token = "0x40006F4")]
	[FieldOffset(Offset = "0x38")]
	public bool toggle;

	[Token(Token = "0x40006F5")]
	[FieldOffset(Offset = "0x3C")]
	private uint _id;

	[Token(Token = "0x170000D7")]
	public int id
	{
		[Token(Token = "0x6000B68")]
		[Address(RVA = "0x541FC0", Offset = "0x5409C0", VA = "0x180541FC0")]
		get
		{
			return default(int);
		}
	}

	[Token(Token = "0x6000B69")]
	[Address(RVA = "0x541FD0", Offset = "0x5409D0", VA = "0x180541FD0")]
	public void reset()
	{
	}

	[Token(Token = "0x6000B6A")]
	[Address(RVA = "0x542080", Offset = "0x540A80", VA = "0x180542080")]
	public void init(uint id, uint global_counter)
	{
	}

	[Token(Token = "0x6000B6B")]
	[Address(RVA = "0x542110", Offset = "0x540B10", VA = "0x180542110")]
	private LTSeq addOn()
	{
		return null;
	}

	[Token(Token = "0x6000B6C")]
	[Address(RVA = "0x542260", Offset = "0x540C60", VA = "0x180542260")]
	private float addPreviousDelays()
	{
		return default(float);
	}

	[Token(Token = "0x6000B6D")]
	[Address(RVA = "0x5422B0", Offset = "0x540CB0", VA = "0x1805422B0")]
	public LTSeq append(float delay)
	{
		return null;
	}

	[Token(Token = "0x6000B6E")]
	[Address(RVA = "0x5422E0", Offset = "0x540CE0", VA = "0x1805422E0")]
	public LTSeq append(Action callback)
	{
		return null;
	}

	[Token(Token = "0x6000B6F")]
	[Address(RVA = "0x542430", Offset = "0x540E30", VA = "0x180542430")]
	public LTSeq append(Action<object> callback, object obj)
	{
		return null;
	}

	[Token(Token = "0x6000B70")]
	[Address(RVA = "0x5425B0", Offset = "0x540FB0", VA = "0x1805425B0")]
	public LTSeq append(GameObject gameObject, Action callback)
	{
		return null;
	}

	[Token(Token = "0x6000B71")]
	[Address(RVA = "0x542640", Offset = "0x541040", VA = "0x180542640")]
	public LTSeq append(GameObject gameObject, Action<object> callback, object obj)
	{
		return null;
	}

	[Token(Token = "0x6000B72")]
	[Address(RVA = "0x5426F0", Offset = "0x5410F0", VA = "0x1805426F0")]
	public LTSeq append(LTDescr tween)
	{
		return null;
	}

	[Token(Token = "0x6000B73")]
	[Address(RVA = "0x5427B0", Offset = "0x5411B0", VA = "0x1805427B0")]
	public LTSeq insert(LTDescr tween)
	{
		return null;
	}

	[Token(Token = "0x6000B74")]
	[Address(RVA = "0x542870", Offset = "0x541270", VA = "0x180542870")]
	public LTSeq setScale(float timeScale)
	{
		return null;
	}

	[Token(Token = "0x6000B75")]
	[Address(RVA = "0x542920", Offset = "0x541320", VA = "0x180542920")]
	private void setScaleRecursive(LTSeq seq, float timeScale, int count)
	{
	}

	[Token(Token = "0x6000B76")]
	[Address(RVA = "0x5429B0", Offset = "0x5413B0", VA = "0x1805429B0")]
	public LTSeq reverse()
	{
		return null;
	}

	[Token(Token = "0x6000B77")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public LTSeq()
	{
	}
}
