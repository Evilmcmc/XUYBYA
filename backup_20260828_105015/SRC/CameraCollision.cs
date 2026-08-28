using EZCameraShake;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200007D")]
public class CameraCollision : MonoBehaviour
{
	[Token(Token = "0x400020E")]
	[FieldOffset(Offset = "0x20")]
	public float minDistance;

	[Token(Token = "0x400020F")]
	[FieldOffset(Offset = "0x24")]
	public float maxDistance;

	[Token(Token = "0x4000210")]
	[FieldOffset(Offset = "0x28")]
	public float smooth;

	[Token(Token = "0x4000211")]
	[FieldOffset(Offset = "0x2C")]
	public float camDistMultiplier;

	[Token(Token = "0x4000212")]
	[FieldOffset(Offset = "0x30")]
	private Vector3 dollyDir;

	[Token(Token = "0x4000213")]
	[FieldOffset(Offset = "0x3C")]
	public Vector3 dollyDirAdjusted;

	[Token(Token = "0x4000214")]
	[FieldOffset(Offset = "0x48")]
	public float distance;

	[Token(Token = "0x4000215")]
	[FieldOffset(Offset = "0x50")]
	public CameraShaker camShaker;

	[Token(Token = "0x4000216")]
	[FieldOffset(Offset = "0x58")]
	public LayerMask rayHitMask;

	[Token(Token = "0x4000217")]
	[FieldOffset(Offset = "0x5C")]
	public float bonus;

	[Token(Token = "0x6000306")]
	[Address(RVA = "0x492F60", Offset = "0x491960", VA = "0x180492F60")]
	private void Awake()
	{
	}

	[Token(Token = "0x6000307")]
	[Address(RVA = "0x492F90", Offset = "0x491990", VA = "0x180492F90")]
	private void LateUpdate()
	{
	}

	[Token(Token = "0x6000308")]
	[Address(RVA = "0x4932F0", Offset = "0x491CF0", VA = "0x1804932F0")]
	public CameraCollision()
	{
	}
}
