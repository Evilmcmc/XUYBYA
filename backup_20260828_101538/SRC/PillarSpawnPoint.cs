using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000076")]
public class PillarSpawnPoint : MonoBehaviour
{
	[Token(Token = "0x40001FF")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private PillarType type;

	[Token(Token = "0x4000200")]
	[FieldOffset(Offset = "0x24")]
	[SerializeField]
	private float frequency;

	[Token(Token = "0x4000201")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private float magnitude;

	[Token(Token = "0x4000202")]
	[FieldOffset(Offset = "0x2C")]
	[SerializeField]
	private float offset;

	[Token(Token = "0x60002F2")]
	[Address(RVA = "0x490B00", Offset = "0x48F500", VA = "0x180490B00")]
	private void Update()
	{
	}

	[Token(Token = "0x60002F3")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public PillarSpawnPoint()
	{
	}
}
