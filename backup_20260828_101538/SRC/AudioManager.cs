using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.Audio;

[Token(Token = "0x2000077")]
public class AudioManager : MonoBehaviour
{
	[Token(Token = "0x4000203")]
	[FieldOffset(Offset = "0x20")]
	public Sound[] sounds;

	[Token(Token = "0x4000204")]
	[FieldOffset(Offset = "0x28")]
	public AudioMixerGroup audioMixerGroup;

	[Token(Token = "0x60002F4")]
	[Address(RVA = "0x490E20", Offset = "0x48F820", VA = "0x180490E20")]
	private void Awake()
	{
	}

	[Token(Token = "0x60002F5")]
	[Address(RVA = "0x4915D0", Offset = "0x48FFD0", VA = "0x1804915D0")]
	public void Play(string name)
	{
	}

	[Token(Token = "0x60002F6")]
	[Address(RVA = "0x491850", Offset = "0x490250", VA = "0x180491850")]
	public void Stop(string name)
	{
	}

	[Token(Token = "0x60002F7")]
	[Address(RVA = "0x491AD0", Offset = "0x4904D0", VA = "0x180491AD0")]
	public bool IsPlaying(string name)
	{
		return default(bool);
	}

	[Token(Token = "0x60002F8")]
	[Address(RVA = "0x491D50", Offset = "0x490750", VA = "0x180491D50")]
	public AudioSource GetAudioSource(string name)
	{
		return null;
	}

	[Token(Token = "0x60002F9")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public AudioManager()
	{
	}
}
