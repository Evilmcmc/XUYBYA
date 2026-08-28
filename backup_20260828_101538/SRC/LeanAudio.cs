using System.Runtime.InteropServices;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000113")]
public class LeanAudio
{
	[Token(Token = "0x40005AF")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x0")]
	public static float MIN_FREQEUNCY_PERIOD;

	[Token(Token = "0x40005B0")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x4")]
	public static int PROCESSING_ITERATIONS_MAX;

	[Token(Token = "0x40005B1")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x8")]
	public static float[] generatedWaveDistances;

	[Token(Token = "0x40005B2")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x10")]
	public static int generatedWaveDistancesCount;

	[Token(Token = "0x40005B3")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x18")]
	private static float[] longList;

	[Token(Token = "0x6000828")]
	[Address(RVA = "0x4FC240", Offset = "0x4FAC40", VA = "0x1804FC240")]
	public static LeanAudioOptions options()
	{
		return null;
	}

	[Token(Token = "0x6000829")]
	[Address(RVA = "0x4FC420", Offset = "0x4FAE20", VA = "0x1804FC420")]
	public static LeanAudioStream createAudioStream(AnimationCurve volume, AnimationCurve frequency, [Optional] LeanAudioOptions options)
	{
		return null;
	}

	[Token(Token = "0x600082A")]
	[Address(RVA = "0x4FC4F0", Offset = "0x4FAEF0", VA = "0x1804FC4F0")]
	public static AudioClip createAudio(AnimationCurve volume, AnimationCurve frequency, [Optional] LeanAudioOptions options)
	{
		return null;
	}

	[Token(Token = "0x600082B")]
	[Address(RVA = "0x4FC5B0", Offset = "0x4FAFB0", VA = "0x1804FC5B0")]
	private static int createAudioWave(AnimationCurve volume, AnimationCurve frequency, LeanAudioOptions options)
	{
		return default(int);
	}

	[Token(Token = "0x600082C")]
	[Address(RVA = "0x4FCB80", Offset = "0x4FB580", VA = "0x1804FCB80")]
	private static AudioClip createAudioFromWave(int waveLength, LeanAudioOptions options)
	{
		return null;
	}

	[Token(Token = "0x600082D")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	private static void OnAudioSetPosition(int newPosition)
	{
	}

	[Token(Token = "0x600082E")]
	[Address(RVA = "0x4FD390", Offset = "0x4FBD90", VA = "0x1804FD390")]
	public static AudioClip generateAudioFromCurve(AnimationCurve curve, int frequencyRate = 44100)
	{
		return null;
	}

	[Token(Token = "0x600082F")]
	[Address(RVA = "0x4FD630", Offset = "0x4FC030", VA = "0x1804FD630")]
	public static AudioSource play(AudioClip audio, float volume)
	{
		return null;
	}

	[Token(Token = "0x6000830")]
	[Address(RVA = "0x4FD710", Offset = "0x4FC110", VA = "0x1804FD710")]
	public static AudioSource play(AudioClip audio)
	{
		return null;
	}

	[Token(Token = "0x6000831")]
	[Address(RVA = "0x4FD7C0", Offset = "0x4FC1C0", VA = "0x1804FD7C0")]
	public static AudioSource play(AudioClip audio, Vector3 pos)
	{
		return null;
	}

	[Token(Token = "0x6000832")]
	[Address(RVA = "0x4FD840", Offset = "0x4FC240", VA = "0x1804FD840")]
	public static AudioSource play(AudioClip audio, Vector3 pos, float volume)
	{
		return null;
	}

	[Token(Token = "0x6000833")]
	[Address(RVA = "0x4FD900", Offset = "0x4FC300", VA = "0x1804FD900")]
	public static AudioSource playClipAt(AudioClip clip, Vector3 pos)
	{
		return null;
	}

	[Token(Token = "0x6000834")]
	[Address(RVA = "0x4FDB70", Offset = "0x4FC570", VA = "0x1804FDB70")]
	public static void printOutAudioClip(AudioClip audioClip, ref AnimationCurve curve, float scaleX = 1f)
	{
	}

	[Token(Token = "0x6000835")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public LeanAudio()
	{
	}
}
