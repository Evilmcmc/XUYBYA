using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000103")]
public class WeaponSpawnCollisionChild : MonoBehaviour
{
	[Token(Token = "0x400055A")]
	[FieldOffset(Offset = "0x20")]
	public WeaponSpawnCollisionParent parent;

	[Token(Token = "0x400055B")]
	[FieldOffset(Offset = "0x28")]
	private string attackChargeTag;

	[Token(Token = "0x400055C")]
	[FieldOffset(Offset = "0x30")]
	private float rideHeight;

	[Token(Token = "0x400055D")]
	[FieldOffset(Offset = "0x34")]
	private LayerMask groundLayer;

	[Token(Token = "0x60007DF")]
	[Address(RVA = "0x4F5CB0", Offset = "0x4F46B0", VA = "0x1804F5CB0")]
	private void OnEnable()
	{
	}

	[Token(Token = "0x60007E0")]
	[Address(RVA = "0x4F5D30", Offset = "0x4F4730", VA = "0x1804F5D30")]
	private void Update()
	{
	}

	[Token(Token = "0x60007E1")]
	[Address(RVA = "0x4F6030", Offset = "0x4F4A30", VA = "0x1804F6030")]
	private void PickupCooldownTimer()
	{
	}

	[Token(Token = "0x60007E2")]
	[Address(RVA = "0x4F6190", Offset = "0x4F4B90", VA = "0x1804F6190")]
	private void OnTriggerEnter(Collider other)
	{
	}

	[Token(Token = "0x60007E3")]
	[Address(RVA = "0x4F6290", Offset = "0x4F4C90", VA = "0x1804F6290")]
	public WeaponSpawnCollisionChild()
	{
	}
}
