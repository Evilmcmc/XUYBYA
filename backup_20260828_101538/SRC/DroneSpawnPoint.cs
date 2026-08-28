using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000037")]
public class DroneSpawnPoint : MonoBehaviour
{
	[Token(Token = "0x40000A6")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private float radius;

	[Token(Token = "0x40000A7")]
	[FieldOffset(Offset = "0x24")]
	[SerializeField]
	private float orbitSpeed;

	[Token(Token = "0x40000A8")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private float floatFrequency;

	[Token(Token = "0x40000A9")]
	[FieldOffset(Offset = "0x2C")]
	[SerializeField]
	private float floatMagnitude;

	[Token(Token = "0x6000114")]
	[Address(RVA = "0x469090", Offset = "0x467A90", VA = "0x180469090")]
	private void Update()
	{
	}

	[Token(Token = "0x6000115")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public DroneSpawnPoint()
	{
	}
}
