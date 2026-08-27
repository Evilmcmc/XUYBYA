using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000075")]
public class PillarObstacle : NetworkBehaviour
{
	[Token(Token = "0x40001F7")]
	[FieldOffset(Offset = "0xF8")]
	[HideInInspector]
	public PillarType type;

	[Token(Token = "0x40001F8")]
	[FieldOffset(Offset = "0xFC")]
	[HideInInspector]
	public float frequency;

	[Token(Token = "0x40001F9")]
	[FieldOffset(Offset = "0x100")]
	[HideInInspector]
	public float magnitude;

	[Token(Token = "0x40001FA")]
	[FieldOffset(Offset = "0x104")]
	[HideInInspector]
	public float offset;

	[Token(Token = "0x40001FB")]
	[FieldOffset(Offset = "0x108")]
	private Vector3 startPosition;

	[Token(Token = "0x40001FC")]
	[FieldOffset(Offset = "0x114")]
	private Vector3 startRotation;

	[Token(Token = "0x40001FD")]
	[FieldOffset(Offset = "0x120")]
	private bool NetworkInitialize___EarlyPillarObstacleAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40001FE")]
	[FieldOffset(Offset = "0x121")]
	private bool NetworkInitialize__LatePillarObstacleAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60002E6")]
	[Address(RVA = "0x48FFF0", Offset = "0x48E9F0", VA = "0x18048FFF0", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x60002E7")]
	[Address(RVA = "0x4901A0", Offset = "0x48EBA0", VA = "0x1804901A0")]
	private void Update()
	{
	}

	[Token(Token = "0x60002E8")]
	[Address(RVA = "0x490520", Offset = "0x48EF20", VA = "0x180490520")]
	private float GetModifier()
	{
		return default(float);
	}

	[Token(Token = "0x60002E9")]
	[Address(RVA = "0x4905B0", Offset = "0x48EFB0", VA = "0x1804905B0")]
	private void XMovement()
	{
	}

	[Token(Token = "0x60002EA")]
	[Address(RVA = "0x4906C0", Offset = "0x48F0C0", VA = "0x1804906C0")]
	private void YMovement()
	{
	}

	[Token(Token = "0x60002EB")]
	[Address(RVA = "0x4907D0", Offset = "0x48F1D0", VA = "0x1804907D0")]
	private void ZMovement()
	{
	}

	[Token(Token = "0x60002EC")]
	[Address(RVA = "0x490930", Offset = "0x48F330", VA = "0x180490930")]
	private void Rotate()
	{
	}

	[Token(Token = "0x60002ED")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public PillarObstacle()
	{
	}

	[Token(Token = "0x60002EE")]
	[Address(RVA = "0x47F7D0", Offset = "0x47E1D0", VA = "0x18047F7D0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60002EF")]
	[Address(RVA = "0x47B5F0", Offset = "0x479FF0", VA = "0x18047B5F0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60002F0")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60002F1")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
