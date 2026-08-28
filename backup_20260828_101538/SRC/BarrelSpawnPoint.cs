using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000061")]
public class BarrelSpawnPoint : MonoBehaviour
{
	[Token(Token = "0x4000180")]
	[FieldOffset(Offset = "0x20")]
	[HideInInspector]
	public BarrelSpawnType barrelSpawnType;

	[Token(Token = "0x6000279")]
	[Address(RVA = "0x48A000", Offset = "0x488A00", VA = "0x18048A000")]
	private void Update()
	{
	}

	[Token(Token = "0x600027A")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public BarrelSpawnPoint()
	{
	}
}
