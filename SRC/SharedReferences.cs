using FishNet.Object;
using FishNet.Object.Synchronizing;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200008E")]
public class SharedReferences : NetworkBehaviour
{
	[Token(Token = "0x40002FD")]
	[FieldOffset(Offset = "0xF8")]
	public Camera playerCamera;

	[Token(Token = "0x40002FE")]
	[FieldOffset(Offset = "0x100")]
	public AudioManager audioManager;

	[Token(Token = "0x40002FF")]
	[FieldOffset(Offset = "0x108")]
	public readonly SyncVar<bool> awayTeam;

	[Token(Token = "0x4000300")]
	[FieldOffset(Offset = "0x110")]
	private bool NetworkInitialize___EarlySharedReferencesAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000301")]
	[FieldOffset(Offset = "0x111")]
	private bool NetworkInitialize__LateSharedReferencesAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60003F4")]
	[Address(RVA = "0x4ADAF0", Offset = "0x4AC4F0", VA = "0x1804ADAF0", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x60003F5")]
	[Address(RVA = "0x4ADBC0", Offset = "0x4AC5C0", VA = "0x1804ADBC0")]
	public SharedReferences()
	{
	}

	[Token(Token = "0x60003F6")]
	[Address(RVA = "0x4ADCB0", Offset = "0x4AC6B0", VA = "0x1804ADCB0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60003F7")]
	[Address(RVA = "0x4ADD00", Offset = "0x4AC700", VA = "0x1804ADD00", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60003F8")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60003F9")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
