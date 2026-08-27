using EZCameraShake;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000104")]
public class WeaponSpawnCollisionParent : NetworkBehaviour
{
	[Token(Token = "0x400055E")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private CameraShaker cameraShaker;

	[Token(Token = "0x400055F")]
	[FieldOffset(Offset = "0x100")]
	private WeaponManager weaponManager;

	[Token(Token = "0x4000560")]
	[FieldOffset(Offset = "0x108")]
	[HideInInspector]
	public bool movingWeaponSpawn;

	[Token(Token = "0x4000561")]
	[FieldOffset(Offset = "0x109")]
	private bool NetworkInitialize___EarlyWeaponSpawnCollisionParentAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000562")]
	[FieldOffset(Offset = "0x10A")]
	private bool NetworkInitialize__LateWeaponSpawnCollisionParentAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60007E4")]
	[Address(RVA = "0x4F6360", Offset = "0x4F4D60", VA = "0x1804F6360", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x60007E5")]
	[Address(RVA = "0x4F6400", Offset = "0x4F4E00", VA = "0x1804F6400", Slot = "17")]
	public override void OnOwnershipClient(NetworkConnection prevOwner)
	{
	}

	[Token(Token = "0x60007E6")]
	[Address(RVA = "0x4F6540", Offset = "0x4F4F40", VA = "0x1804F6540")]
	public void MoveAttackCharge(int index)
	{
	}

	[Token(Token = "0x60007E7")]
	[Address(RVA = "0x4F65B0", Offset = "0x4F4FB0", VA = "0x1804F65B0")]
	[ServerRpc]
	private void CMDMoveAttackCharge(int index)
	{
	}

	[Token(Token = "0x60007E8")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public WeaponSpawnCollisionParent()
	{
	}

	[Token(Token = "0x60007E9")]
	[Address(RVA = "0x4F65C0", Offset = "0x4F4FC0", VA = "0x1804F65C0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60007EA")]
	[Address(RVA = "0x4C4740", Offset = "0x4C3140", VA = "0x1804C4740", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60007EB")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60007EC")]
	[Address(RVA = "0x4F6650", Offset = "0x4F5050", VA = "0x1804F6650")]
	private void RpcWriter___Server_CMDMoveAttackCharge_3316948804(int index)
	{
	}

	[Token(Token = "0x60007ED")]
	[Address(RVA = "0x4F6820", Offset = "0x4F5220", VA = "0x1804F6820")]
	private void RpcLogic___CMDMoveAttackCharge_3316948804(int index)
	{
	}

	[Token(Token = "0x60007EE")]
	[Address(RVA = "0x4F69E0", Offset = "0x4F53E0", VA = "0x1804F69E0")]
	private void RpcReader___Server_CMDMoveAttackCharge_3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x60007EF")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
