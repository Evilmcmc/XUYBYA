using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200007E")]
public class CheckIfOutOfBounds : NetworkBehaviour
{
	[Token(Token = "0x4000218")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private Transform player;

	[Token(Token = "0x4000219")]
	[FieldOffset(Offset = "0x100")]
	[Header("Boundries")]
	[SerializeField]
	private float Min_Y;

	[Token(Token = "0x400021A")]
	[FieldOffset(Offset = "0x104")]
	private bool NetworkInitialize___EarlyCheckIfOutOfBoundsAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x400021B")]
	[FieldOffset(Offset = "0x105")]
	private bool NetworkInitialize__LateCheckIfOutOfBoundsAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000309")]
	[Address(RVA = "0x4835D0", Offset = "0x481FD0", VA = "0x1804835D0", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x600030A")]
	[Address(RVA = "0x493350", Offset = "0x491D50", VA = "0x180493350")]
	private void Update()
	{
	}

	[Token(Token = "0x600030B")]
	[Address(RVA = "0x4935F0", Offset = "0x491FF0", VA = "0x1804935F0")]
	[ServerRpc]
	private void CMDAlertOutOfBounds()
	{
	}

	[Token(Token = "0x600030C")]
	[Address(RVA = "0x4937A0", Offset = "0x4921A0", VA = "0x1804937A0")]
	private bool IsOutOfBoudries()
	{
		return default(bool);
	}

	[Token(Token = "0x600030D")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public CheckIfOutOfBounds()
	{
	}

	[Token(Token = "0x600030E")]
	[Address(RVA = "0x493870", Offset = "0x492270", VA = "0x180493870", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x600030F")]
	[Address(RVA = "0x493900", Offset = "0x492300", VA = "0x180493900", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000310")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000311")]
	[Address(RVA = "0x4935F0", Offset = "0x491FF0", VA = "0x1804935F0")]
	private void RpcWriter___Server_CMDAlertOutOfBounds_2166136261()
	{
	}

	[Token(Token = "0x6000312")]
	[Address(RVA = "0x493920", Offset = "0x492320", VA = "0x180493920")]
	private void RpcLogic___CMDAlertOutOfBounds_2166136261()
	{
	}

	[Token(Token = "0x6000313")]
	[Address(RVA = "0x493A50", Offset = "0x492450", VA = "0x180493A50")]
	private void RpcReader___Server_CMDAlertOutOfBounds_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x6000314")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
