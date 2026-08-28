using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.Audio;

namespace DG.Tweening;

[Token(Token = "0x200015F")]
public static class DOTweenModuleAudio
{
	[Token(Token = "0x6000CD0")]
	[Address(RVA = "0x565820", Offset = "0x564220", VA = "0x180565820")]
	public static TweenerCore<float, float, FloatOptions> DOFade(this AudioSource target, float endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000CD1")]
	[Address(RVA = "0x5659F0", Offset = "0x5643F0", VA = "0x1805659F0")]
	public static TweenerCore<float, float, FloatOptions> DOPitch(this AudioSource target, float endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000CD2")]
	[Address(RVA = "0x565BB0", Offset = "0x5645B0", VA = "0x180565BB0")]
	public static TweenerCore<float, float, FloatOptions> DOSetFloat(this AudioMixer target, string floatName, float endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000CD3")]
	[Address(RVA = "0x565DD0", Offset = "0x5647D0", VA = "0x180565DD0")]
	public static int DOComplete(this AudioMixer target, bool withCallbacks = false)
	{
		return default(int);
	}

	[Token(Token = "0x6000CD4")]
	[Address(RVA = "0x565EA0", Offset = "0x5648A0", VA = "0x180565EA0")]
	public static int DOKill(this AudioMixer target, bool complete = false)
	{
		return default(int);
	}

	[Token(Token = "0x6000CD5")]
	[Address(RVA = "0x566010", Offset = "0x564A10", VA = "0x180566010")]
	public static int DOFlip(this AudioMixer target)
	{
		return default(int);
	}

	[Token(Token = "0x6000CD6")]
	[Address(RVA = "0x5660D0", Offset = "0x564AD0", VA = "0x1805660D0")]
	public static int DOGoto(this AudioMixer target, float to, bool andPlay = false)
	{
		return default(int);
	}

	[Token(Token = "0x6000CD7")]
	[Address(RVA = "0x5661B0", Offset = "0x564BB0", VA = "0x1805661B0")]
	public static int DOPause(this AudioMixer target)
	{
		return default(int);
	}

	[Token(Token = "0x6000CD8")]
	[Address(RVA = "0x566270", Offset = "0x564C70", VA = "0x180566270")]
	public static int DOPlay(this AudioMixer target)
	{
		return default(int);
	}

	[Token(Token = "0x6000CD9")]
	[Address(RVA = "0x566330", Offset = "0x564D30", VA = "0x180566330")]
	public static int DOPlayBackwards(this AudioMixer target)
	{
		return default(int);
	}

	[Token(Token = "0x6000CDA")]
	[Address(RVA = "0x5663F0", Offset = "0x564DF0", VA = "0x1805663F0")]
	public static int DOPlayForward(this AudioMixer target)
	{
		return default(int);
	}

	[Token(Token = "0x6000CDB")]
	[Address(RVA = "0x5664B0", Offset = "0x564EB0", VA = "0x1805664B0")]
	public static int DORestart(this AudioMixer target)
	{
		return default(int);
	}

	[Token(Token = "0x6000CDC")]
	[Address(RVA = "0x566570", Offset = "0x564F70", VA = "0x180566570")]
	public static int DORewind(this AudioMixer target)
	{
		return default(int);
	}

	[Token(Token = "0x6000CDD")]
	[Address(RVA = "0x566630", Offset = "0x565030", VA = "0x180566630")]
	public static int DOSmoothRewind(this AudioMixer target)
	{
		return default(int);
	}

	[Token(Token = "0x6000CDE")]
	[Address(RVA = "0x5666F0", Offset = "0x5650F0", VA = "0x1805666F0")]
	public static int DOTogglePause(this AudioMixer target)
	{
		return default(int);
	}
}
