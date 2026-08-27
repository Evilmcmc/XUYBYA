using System.Collections;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000014")]
public class Music : MonoBehaviour
{
	[Token(Token = "0x400003E")]
	[FieldOffset(Offset = "0x0")]
	[HideInInspector]
	public static Music instance;

	[Token(Token = "0x400003F")]
	[FieldOffset(Offset = "0x20")]
	private AudioSource musicSource;

	[Token(Token = "0x4000040")]
	[FieldOffset(Offset = "0x28")]
	private float fadeTime;

	[Token(Token = "0x4000041")]
	[FieldOffset(Offset = "0x2C")]
	private float maxVolume;

	[Token(Token = "0x600006C")]
	[Address(RVA = "0x4594C0", Offset = "0x457EC0", VA = "0x1804594C0")]
	private void Awake()
	{
	}

	[Token(Token = "0x600006D")]
	[Address(RVA = "0x459950", Offset = "0x458350", VA = "0x180459950")]
	public void ChangeCutOffFrequency(float targetFrequency)
	{
	}

	[Token(Token = "0x600006E")]
	[Address(RVA = "0x459A80", Offset = "0x458480", VA = "0x180459A80")]
	[IteratorStateMachine(typeof(_003CFade_003Ed__6))]
	public IEnumerator Fade(float targetVolume)
	{
		return null;
	}

	[Token(Token = "0x600006F")]
	[Address(RVA = "0x459B40", Offset = "0x458540", VA = "0x180459B40")]
	public Music()
	{
	}
}
