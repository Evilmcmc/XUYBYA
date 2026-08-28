using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x20000C3")]
public class SyncRootPos : NetworkBehaviour
{
	[Token(Token = "0x400040A")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private Transform root;

	[Token(Token = "0x400040B")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private Transform spineBase;

	[Token(Token = "0x400040C")]
	[FieldOffset(Offset = "0x108")]
	private Vector3 difference;

	[Token(Token = "0x400040D")]
	[FieldOffset(Offset = "0x114")]
	private bool NetworkInitialize___EarlySyncRootPosAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x400040E")]
	[FieldOffset(Offset = "0x115")]
	private bool NetworkInitialize__LateSyncRootPosAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60005F9")]
	[Address(RVA = "0x4D4340", Offset = "0x4D2D40", VA = "0x1804D4340", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x60005FA")]
	[Address(RVA = "0x4D4520", Offset = "0x4D2F20", VA = "0x1804D4520")]
	[Client]
	private void Update()
	{
	}

	[Token(Token = "0x60005FB")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public SyncRootPos()
	{
	}

	[Token(Token = "0x60005FC")]
	[Address(RVA = "0x469050", Offset = "0x467A50", VA = "0x180469050", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60005FD")]
	[Address(RVA = "0x469070", Offset = "0x467A70", VA = "0x180469070", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60005FE")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60005FF")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
