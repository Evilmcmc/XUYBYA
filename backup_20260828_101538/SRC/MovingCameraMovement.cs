using FishNet.Object;
using Il2CppDummyDll;

[Token(Token = "0x200006F")]
public class MovingCameraMovement : NetworkBehaviour
{
	[Token(Token = "0x40001D3")]
	[FieldOffset(Offset = "0xF8")]
	private bool NetworkInitialize___EarlyMovingCameraMovementAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40001D4")]
	[FieldOffset(Offset = "0xF9")]
	private bool NetworkInitialize__LateMovingCameraMovementAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60002C7")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	private void Start()
	{
	}

	[Token(Token = "0x60002C8")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	private void Update()
	{
	}

	[Token(Token = "0x60002C9")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public MovingCameraMovement()
	{
	}

	[Token(Token = "0x60002CA")]
	[Address(RVA = "0x46BB60", Offset = "0x46A560", VA = "0x18046BB60", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60002CB")]
	[Address(RVA = "0x46BB80", Offset = "0x46A580", VA = "0x18046BB80", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60002CC")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60002CD")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
