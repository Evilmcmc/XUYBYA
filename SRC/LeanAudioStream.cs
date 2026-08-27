using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000112")]
public class LeanAudioStream
{
	[Token(Token = "0x40005AC")]
	[FieldOffset(Offset = "0x10")]
	public int position;

	[Token(Token = "0x40005AD")]
	[FieldOffset(Offset = "0x18")]
	public AudioClip audioClip;

	[Token(Token = "0x40005AE")]
	[FieldOffset(Offset = "0x20")]
	public float[] audioArr;

	[Token(Token = "0x6000825")]
	[Address(RVA = "0x4FC180", Offset = "0x4FAB80", VA = "0x1804FC180")]
	public LeanAudioStream(float[] audioArr)
	{
	}

	[Token(Token = "0x6000826")]
	[Address(RVA = "0x4FC1E0", Offset = "0x4FABE0", VA = "0x1804FC1E0")]
	public void OnAudioRead(float[] data)
	{
	}

	[Token(Token = "0x6000827")]
	[Address(RVA = "0x457970", Offset = "0x456370", VA = "0x180457970")]
	public void OnAudioSetPosition(int newPosition)
	{
	}
}
