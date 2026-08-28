using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000036")]
public class DroneMovement : NetworkBehaviour
{
	[Token(Token = "0x400009F")]
	[FieldOffset(Offset = "0xF8")]
	public float radius;

	[Token(Token = "0x40000A0")]
	[FieldOffset(Offset = "0xFC")]
	public float orbitSpeed;

	[Token(Token = "0x40000A1")]
	[FieldOffset(Offset = "0x100")]
	public float floatMagnitude;

	[Token(Token = "0x40000A2")]
	[FieldOffset(Offset = "0x104")]
	public float floatFrequency;

	[Token(Token = "0x40000A3")]
	[FieldOffset(Offset = "0x108")]
	private Vector3 startPosition;

	[Token(Token = "0x40000A4")]
	[FieldOffset(Offset = "0x114")]
	private bool NetworkInitialize___EarlyDroneMovementAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40000A5")]
	[FieldOffset(Offset = "0x115")]
	private bool NetworkInitialize__LateDroneMovementAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x600010D")]
	[Address(RVA = "0x468830", Offset = "0x467230", VA = "0x180468830", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x600010E")]
	[Address(RVA = "0x468910", Offset = "0x467310", VA = "0x180468910")]
	private void Update()
	{
	}

	[Token(Token = "0x600010F")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public DroneMovement()
	{
	}

	[Token(Token = "0x6000110")]
	[Address(RVA = "0x469050", Offset = "0x467A50", VA = "0x180469050", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000111")]
	[Address(RVA = "0x469070", Offset = "0x467A70", VA = "0x180469070", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000112")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000113")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
