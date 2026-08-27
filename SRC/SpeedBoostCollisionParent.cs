using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x20000BF")]
public class SpeedBoostCollisionParent : NetworkBehaviour
{
	[Token(Token = "0x4000404")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private float boostForce;

	[Token(Token = "0x4000405")]
	[FieldOffset(Offset = "0xFC")]
	[SerializeField]
	private float maxDistance;

	[Token(Token = "0x4000406")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private string soundEffect;

	[Token(Token = "0x4000407")]
	[FieldOffset(Offset = "0x108")]
	private bool NetworkInitialize___EarlySpeedBoostCollisionParentAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000408")]
	[FieldOffset(Offset = "0x109")]
	private bool NetworkInitialize__LateSpeedBoostCollisionParentAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60005E5")]
	[Address(RVA = "0x4D2D30", Offset = "0x4D1730", VA = "0x1804D2D30")]
	[Client]
	public void ClientTrySpeedBoost(int speedBoostIndex)
	{
	}

	[Token(Token = "0x60005E6")]
	[Address(RVA = "0x4D2E00", Offset = "0x4D1800", VA = "0x1804D2E00")]
	[ServerRpc]
	private void ServerTrySpeedBoost(int speedBoostIndex)
	{
	}

	[Token(Token = "0x60005E7")]
	[Address(RVA = "0x4D2E10", Offset = "0x4D1810", VA = "0x1804D2E10")]
	[ObserversRpc]
	private void ClientSpeedBoost(NetworkConnection target)
	{
	}

	[Token(Token = "0x60005E8")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public SpeedBoostCollisionParent()
	{
	}

	[Token(Token = "0x60005E9")]
	[Address(RVA = "0x4D2E20", Offset = "0x4D1820", VA = "0x1804D2E20", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60005EA")]
	[Address(RVA = "0x4CEBF0", Offset = "0x4CD5F0", VA = "0x1804CEBF0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60005EB")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60005EC")]
	[Address(RVA = "0x4D2F10", Offset = "0x4D1910", VA = "0x1804D2F10")]
	private void RpcWriter___Server_ServerTrySpeedBoost_3316948804(int speedBoostIndex)
	{
	}

	[Token(Token = "0x60005ED")]
	[Address(RVA = "0x4D30E0", Offset = "0x4D1AE0", VA = "0x1804D30E0")]
	private void RpcLogic___ServerTrySpeedBoost_3316948804(int speedBoostIndex)
	{
	}

	[Token(Token = "0x60005EE")]
	[Address(RVA = "0x4D3830", Offset = "0x4D2230", VA = "0x1804D3830")]
	private void RpcReader___Server_ServerTrySpeedBoost_3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x60005EF")]
	[Address(RVA = "0x4D3930", Offset = "0x4D2330", VA = "0x1804D3930")]
	private void RpcWriter___Observers_ClientSpeedBoost_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x60005F0")]
	[Address(RVA = "0x4D3AE0", Offset = "0x4D24E0", VA = "0x1804D3AE0")]
	private void RpcLogic___ClientSpeedBoost_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x60005F1")]
	[Address(RVA = "0x4D3D80", Offset = "0x4D2780", VA = "0x1804D3D80")]
	private void RpcReader___Observers_ClientSpeedBoost_328543758(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60005F2")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
