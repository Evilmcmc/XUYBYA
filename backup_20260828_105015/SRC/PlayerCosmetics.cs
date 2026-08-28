using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000065")]
public class PlayerCosmetics : NetworkBehaviour
{
	[Token(Token = "0x400018D")]
	[FieldOffset(Offset = "0xF8")]
	[HideInInspector]
	public readonly SyncVar<string> hat;

	[Token(Token = "0x400018E")]
	[FieldOffset(Offset = "0x100")]
	[HideInInspector]
	public readonly SyncVar<string> body;

	[Token(Token = "0x400018F")]
	[FieldOffset(Offset = "0x108")]
	[HideInInspector]
	public readonly SyncVar<int> color;

	[Token(Token = "0x4000190")]
	[FieldOffset(Offset = "0x110")]
	private bool NetworkInitialize___EarlyPlayerCosmeticsAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000191")]
	[FieldOffset(Offset = "0x111")]
	private bool NetworkInitialize__LatePlayerCosmeticsAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x600028B")]
	[Address(RVA = "0x48B660", Offset = "0x48A060", VA = "0x18048B660", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x600028C")]
	[Address(RVA = "0x48B750", Offset = "0x48A150", VA = "0x18048B750")]
	[IteratorStateMachine(typeof(_003CInitializeCosmetics_003Ed__4))]
	private IEnumerator InitializeCosmetics()
	{
		return null;
	}

	[Token(Token = "0x600028D")]
	[Address(RVA = "0x48B7F0", Offset = "0x48A1F0", VA = "0x18048B7F0")]
	[ServerRpc]
	public void CMDUpdatePlayerColor(int newValue)
	{
	}

	[Token(Token = "0x600028E")]
	[Address(RVA = "0x48B800", Offset = "0x48A200", VA = "0x18048B800")]
	[ServerRpc]
	public void CMDUpdatePlayerHat(string newValue)
	{
	}

	[Token(Token = "0x600028F")]
	[Address(RVA = "0x48B9C0", Offset = "0x48A3C0", VA = "0x18048B9C0")]
	[ServerRpc]
	public void CMDUpdatePlayerBody(string newValue)
	{
	}

	[Token(Token = "0x6000290")]
	[Address(RVA = "0x48BB80", Offset = "0x48A580", VA = "0x18048BB80")]
	public PlayerCosmetics()
	{
	}

	[Token(Token = "0x6000291")]
	[Address(RVA = "0x48BE00", Offset = "0x48A800", VA = "0x18048BE00", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000292")]
	[Address(RVA = "0x48BFA0", Offset = "0x48A9A0", VA = "0x18048BFA0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000293")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000294")]
	[Address(RVA = "0x48C020", Offset = "0x48AA20", VA = "0x18048C020")]
	private void RpcWriter___Server_CMDUpdatePlayerColor_3316948804(int newValue)
	{
	}

	[Token(Token = "0x6000295")]
	[Address(RVA = "0x48C1F0", Offset = "0x48ABF0", VA = "0x18048C1F0")]
	public void RpcLogic___CMDUpdatePlayerColor_3316948804(int newValue)
	{
	}

	[Token(Token = "0x6000296")]
	[Address(RVA = "0x48C270", Offset = "0x48AC70", VA = "0x18048C270")]
	private void RpcReader___Server_CMDUpdatePlayerColor_3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x6000297")]
	[Address(RVA = "0x48B800", Offset = "0x48A200", VA = "0x18048B800")]
	private void RpcWriter___Server_CMDUpdatePlayerHat_3615296227(string newValue)
	{
	}

	[Token(Token = "0x6000298")]
	[Address(RVA = "0x48C3C0", Offset = "0x48ADC0", VA = "0x18048C3C0")]
	public void RpcLogic___CMDUpdatePlayerHat_3615296227(string newValue)
	{
	}

	[Token(Token = "0x6000299")]
	[Address(RVA = "0x48C440", Offset = "0x48AE40", VA = "0x18048C440")]
	private void RpcReader___Server_CMDUpdatePlayerHat_3615296227(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x600029A")]
	[Address(RVA = "0x48B9C0", Offset = "0x48A3C0", VA = "0x18048B9C0")]
	private void RpcWriter___Server_CMDUpdatePlayerBody_3615296227(string newValue)
	{
	}

	[Token(Token = "0x600029B")]
	[Address(RVA = "0x48C580", Offset = "0x48AF80", VA = "0x18048C580")]
	public void RpcLogic___CMDUpdatePlayerBody_3615296227(string newValue)
	{
	}

	[Token(Token = "0x600029C")]
	[Address(RVA = "0x48C600", Offset = "0x48B000", VA = "0x18048C600")]
	private void RpcReader___Server_CMDUpdatePlayerBody_3615296227(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x600029D")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
