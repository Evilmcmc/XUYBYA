using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x20000B3")]
public class RaceEndDetection : NetworkBehaviour
{
	[Token(Token = "0x40003DD")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private float serverDistanceThreshhold;

	[Token(Token = "0x40003DE")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private RaceEndCollisionChild childToEnable;

	[Token(Token = "0x40003DF")]
	[FieldOffset(Offset = "0x108")]
	private bool NetworkInitialize___EarlyRaceEndDetectionAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40003E0")]
	[FieldOffset(Offset = "0x109")]
	private bool NetworkInitialize__LateRaceEndDetectionAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60005A5")]
	[Address(RVA = "0x4CE730", Offset = "0x4CD130", VA = "0x1804CE730", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x60005A6")]
	[Address(RVA = "0x4CE790", Offset = "0x4CD190", VA = "0x1804CE790")]
	[Client]
	public void ClientTryWinRace()
	{
	}

	[Token(Token = "0x60005A7")]
	[Address(RVA = "0x4CE9B0", Offset = "0x4CD3B0", VA = "0x1804CE9B0")]
	[ServerRpc]
	private void ServerTryWinRace()
	{
	}

	[Token(Token = "0x60005A8")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public RaceEndDetection()
	{
	}

	[Token(Token = "0x60005A9")]
	[Address(RVA = "0x4CEB60", Offset = "0x4CD560", VA = "0x1804CEB60", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60005AA")]
	[Address(RVA = "0x4CEBF0", Offset = "0x4CD5F0", VA = "0x1804CEBF0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60005AB")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60005AC")]
	[Address(RVA = "0x4CE9B0", Offset = "0x4CD3B0", VA = "0x1804CE9B0")]
	private void RpcWriter___Server_ServerTryWinRace_2166136261()
	{
	}

	[Token(Token = "0x60005AD")]
	[Address(RVA = "0x4CEC10", Offset = "0x4CD610", VA = "0x1804CEC10")]
	private void RpcLogic___ServerTryWinRace_2166136261()
	{
	}

	[Token(Token = "0x60005AE")]
	[Address(RVA = "0x4CEEB0", Offset = "0x4CD8B0", VA = "0x1804CEEB0")]
	private void RpcReader___Server_ServerTryWinRace_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x60005AF")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
