using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200002B")]
public class CrainMovement : NetworkBehaviour
{
	[Token(Token = "0x400007F")]
	[FieldOffset(Offset = "0xF8")]
	[HideInInspector]
	public float rotationSpeed;

	[Token(Token = "0x4000080")]
	[FieldOffset(Offset = "0xFC")]
	private Quaternion startRotation;

	[Token(Token = "0x4000081")]
	[FieldOffset(Offset = "0x10C")]
	private bool NetworkInitialize___EarlyCrainMovementAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000082")]
	[FieldOffset(Offset = "0x10D")]
	private bool NetworkInitialize__LateCrainMovementAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60000CE")]
	[Address(RVA = "0x464A20", Offset = "0x463420", VA = "0x180464A20", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x60000CF")]
	[Address(RVA = "0x464AF0", Offset = "0x4634F0", VA = "0x180464AF0")]
	private void Update()
	{
	}

	[Token(Token = "0x60000D0")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public CrainMovement()
	{
	}

	[Token(Token = "0x60000D1")]
	[Address(RVA = "0x464E20", Offset = "0x463820", VA = "0x180464E20", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60000D2")]
	[Address(RVA = "0x464E40", Offset = "0x463840", VA = "0x180464E40", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60000D3")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60000D4")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
