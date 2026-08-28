using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using FishNet.Connection;
using FishNet.Managing.Scened;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine.InputSystem;

[Token(Token = "0x20000A9")]
public class PlayerMainObjectInputManager : NetworkBehaviour
{
	[Token(Token = "0x40003B1")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xF8")]
	private bool NetworkInitialize___EarlyPlayerMainObjectInputManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40003B2")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xF9")]
	private bool NetworkInitialize__LatePlayerMainObjectInputManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000523")]
	[Address(RVA = "0x4C4CE0", Offset = "0x4C36E0", VA = "0x1804C4CE0", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x6000524")]
	[Address(RVA = "0x4C4DD0", Offset = "0x4C37D0", VA = "0x1804C4DD0", Slot = "16")]
	public override void OnStopClient()
	{
	}

	[Token(Token = "0x6000525")]
	[Address(RVA = "0x4C4EB0", Offset = "0x4C38B0", VA = "0x1804C4EB0", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x6000526")]
	[Address(RVA = "0x4C50A0", Offset = "0x4C3AA0", VA = "0x1804C50A0")]
	[TargetRpc]
	private void EnableLatePlayerInput(NetworkConnection connection)
	{
	}

	[Token(Token = "0x6000527")]
	[Address(RVA = "0x4C5210", Offset = "0x4C3C10", VA = "0x1804C5210")]
	[Client]
	private void EnableInput([Optional] SceneLoadEndEventArgs data)
	{
	}

	[Token(Token = "0x6000528")]
	[Address(RVA = "0x4C5AD0", Offset = "0x4C44D0", VA = "0x1804C5AD0")]
	[IteratorStateMachine(typeof(_003CEnableAndDisablePlayerInput_003Ed__5))]
	private IEnumerator EnableAndDisablePlayerInput(PlayerInput playerInput)
	{
		return null;
	}

	[Token(Token = "0x6000529")]
	[Address(RVA = "0x4C5B70", Offset = "0x4C4570", VA = "0x1804C5B70")]
	public void DisableInput()
	{
	}

	[Token(Token = "0x600052A")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public PlayerMainObjectInputManager()
	{
	}

	[Token(Token = "0x6000535")]
	[Address(RVA = "0x4C6800", Offset = "0x4C5200", VA = "0x1804C6800", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000536")]
	[Address(RVA = "0x46BB80", Offset = "0x46A580", VA = "0x18046BB80", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000537")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000538")]
	[Address(RVA = "0x4C50A0", Offset = "0x4C3AA0", VA = "0x1804C50A0")]
	private void RpcWriter___Target_EnableLatePlayerInput_328543758(NetworkConnection connection)
	{
	}

	[Token(Token = "0x6000539")]
	[Address(RVA = "0x4C6890", Offset = "0x4C5290", VA = "0x1804C6890")]
	private void RpcLogic___EnableLatePlayerInput_328543758(NetworkConnection connection)
	{
	}

	[Token(Token = "0x600053A")]
	[Address(RVA = "0x4C68C0", Offset = "0x4C52C0", VA = "0x1804C68C0")]
	private void RpcReader___Target_EnableLatePlayerInput_328543758(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x600053B")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
