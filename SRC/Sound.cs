using System;
using Il2CppDummyDll;
using UnityEngine;

[Serializable]
[Token(Token = "0x2000016")]
public class Sound
{
	[Token(Token = "0x4000048")]
	[FieldOffset(Offset = "0x10")]
	public string name;

	[Token(Token = "0x4000049")]
	[FieldOffset(Offset = "0x18")]
	public AudioClip clip;

	[Token(Token = "0x400004A")]
	[FieldOffset(Offset = "0x20")]
	[Range(0f, 1f)]
	public float volume;

	[Token(Token = "0x400004B")]
	[FieldOffset(Offset = "0x24")]
	[Range(0.1f, 3f)]
	public float pitch;

	[Token(Token = "0x400004C")]
	[FieldOffset(Offset = "0x28")]
	public bool Loop;

	[Token(Token = "0x400004D")]
	[FieldOffset(Offset = "0x30")]
	[HideInInspector]
	public AudioSource source;

	[Token(Token = "0x6000076")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public Sound()
	{
	}
}
