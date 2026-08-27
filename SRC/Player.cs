using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000089")]
public class Player : NetworkBehaviour
{
	[Token(Token = "0x4000281")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private Rigidbody[] rigidBodies;

	[Token(Token = "0x4000282")]
	[FieldOffset(Offset = "0x100")]
	public Rigidbody spineRb;

	[Token(Token = "0x4000283")]
	[FieldOffset(Offset = "0x108")]
	public Rigidbody rootRb;

	[Token(Token = "0x4000284")]
	[FieldOffset(Offset = "0x110")]
	public Rigidbody LFootRb;

	[Token(Token = "0x4000285")]
	[FieldOffset(Offset = "0x118")]
	public Rigidbody RFootRb;

	[Token(Token = "0x4000286")]
	[FieldOffset(Offset = "0x120")]
	public Rigidbody LKneeRb;

	[Token(Token = "0x4000287")]
	[FieldOffset(Offset = "0x128")]
	public Rigidbody RKneeRb;

	[Token(Token = "0x4000288")]
	[FieldOffset(Offset = "0x130")]
	public Rigidbody LHandRb;

	[Token(Token = "0x4000289")]
	[FieldOffset(Offset = "0x138")]
	public Rigidbody RHandRb;

	[Token(Token = "0x400028A")]
	[FieldOffset(Offset = "0x140")]
	public Rigidbody LElbowRb;

	[Token(Token = "0x400028B")]
	[FieldOffset(Offset = "0x148")]
	public Rigidbody RElbowRb;

	[Token(Token = "0x400028C")]
	[FieldOffset(Offset = "0x150")]
	public Rigidbody LUpperArmRb;

	[Token(Token = "0x400028D")]
	[FieldOffset(Offset = "0x158")]
	public Rigidbody RUpperArmRb;

	[Token(Token = "0x400028E")]
	[FieldOffset(Offset = "0x160")]
	public Rigidbody LShoulderRb;

	[Token(Token = "0x400028F")]
	[FieldOffset(Offset = "0x168")]
	public Rigidbody RShoulderRb;

	[Token(Token = "0x4000290")]
	[FieldOffset(Offset = "0x170")]
	public Rigidbody chestRb;

	[Token(Token = "0x4000291")]
	[FieldOffset(Offset = "0x178")]
	private bool NetworkInitialize___EarlyPlayerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000292")]
	[FieldOffset(Offset = "0x179")]
	private bool NetworkInitialize__LatePlayerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60003A1")]
	[Address(RVA = "0x4A3AC0", Offset = "0x4A24C0", VA = "0x1804A3AC0", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x60003A2")]
	[Address(RVA = "0x4A4440", Offset = "0x4A2E40", VA = "0x1804A4440")]
	private void Update()
	{
	}

	[Token(Token = "0x60003A3")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public Player()
	{
	}

	[Token(Token = "0x60003A4")]
	[Address(RVA = "0x4A4550", Offset = "0x4A2F50", VA = "0x1804A4550", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60003A5")]
	[Address(RVA = "0x4A4570", Offset = "0x4A2F70", VA = "0x1804A4570", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60003A6")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60003A7")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
