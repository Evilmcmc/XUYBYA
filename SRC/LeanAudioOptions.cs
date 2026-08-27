using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000114")]
public class LeanAudioOptions
{
	[Token(Token = "0x2000115")]
	public enum LeanAudioWaveStyle
	{
		[Token(Token = "0x40005BD")]
		Sine,
		[Token(Token = "0x40005BE")]
		Square,
		[Token(Token = "0x40005BF")]
		Sawtooth,
		[Token(Token = "0x40005C0")]
		Noise
	}

	[Token(Token = "0x40005B4")]
	[FieldOffset(Offset = "0x10")]
	public LeanAudioWaveStyle waveStyle;

	[Token(Token = "0x40005B5")]
	[FieldOffset(Offset = "0x18")]
	public Vector3[] vibrato;

	[Token(Token = "0x40005B6")]
	[FieldOffset(Offset = "0x20")]
	public Vector3[] modulation;

	[Token(Token = "0x40005B7")]
	[FieldOffset(Offset = "0x28")]
	public int frequencyRate;

	[Token(Token = "0x40005B8")]
	[FieldOffset(Offset = "0x2C")]
	public float waveNoiseScale;

	[Token(Token = "0x40005B9")]
	[FieldOffset(Offset = "0x30")]
	public float waveNoiseInfluence;

	[Token(Token = "0x40005BA")]
	[FieldOffset(Offset = "0x34")]
	public bool useSetData;

	[Token(Token = "0x40005BB")]
	[FieldOffset(Offset = "0x38")]
	public LeanAudioStream stream;

	[Token(Token = "0x6000837")]
	[Address(RVA = "0x4FDEA0", Offset = "0x4FC8A0", VA = "0x1804FDEA0")]
	public LeanAudioOptions()
	{
	}

	[Token(Token = "0x6000838")]
	[Address(RVA = "0x4FDEC0", Offset = "0x4FC8C0", VA = "0x1804FDEC0")]
	public LeanAudioOptions setFrequency(int frequencyRate)
	{
		return null;
	}

	[Token(Token = "0x6000839")]
	[Address(RVA = "0x4FDED0", Offset = "0x4FC8D0", VA = "0x1804FDED0")]
	public LeanAudioOptions setVibrato(Vector3[] vibrato)
	{
		return null;
	}

	[Token(Token = "0x600083A")]
	[Address(RVA = "0x4FDF30", Offset = "0x4FC930", VA = "0x1804FDF30")]
	public LeanAudioOptions setWaveSine()
	{
		return null;
	}

	[Token(Token = "0x600083B")]
	[Address(RVA = "0x4FDF40", Offset = "0x4FC940", VA = "0x1804FDF40")]
	public LeanAudioOptions setWaveSquare()
	{
		return null;
	}

	[Token(Token = "0x600083C")]
	[Address(RVA = "0x4FDF50", Offset = "0x4FC950", VA = "0x1804FDF50")]
	public LeanAudioOptions setWaveSawtooth()
	{
		return null;
	}

	[Token(Token = "0x600083D")]
	[Address(RVA = "0x4FDF60", Offset = "0x4FC960", VA = "0x1804FDF60")]
	public LeanAudioOptions setWaveNoise()
	{
		return null;
	}

	[Token(Token = "0x600083E")]
	[Address(RVA = "0x4FDF70", Offset = "0x4FC970", VA = "0x1804FDF70")]
	public LeanAudioOptions setWaveStyle(LeanAudioWaveStyle style)
	{
		return null;
	}

	[Token(Token = "0x600083F")]
	[Address(RVA = "0x4FDF80", Offset = "0x4FC980", VA = "0x1804FDF80")]
	public LeanAudioOptions setWaveNoiseScale(float waveScale)
	{
		return null;
	}

	[Token(Token = "0x6000840")]
	[Address(RVA = "0x4FDF90", Offset = "0x4FC990", VA = "0x1804FDF90")]
	public LeanAudioOptions setWaveNoiseInfluence(float influence)
	{
		return null;
	}
}
