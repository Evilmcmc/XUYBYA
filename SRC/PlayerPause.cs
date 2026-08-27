using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.InputSystem;

[Token(Token = "0x2000044")]
public class PlayerPause : NetworkBehaviour
{
	[Token(Token = "0x40000DF")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private GameObject pauseParent;

	[Token(Token = "0x40000E0")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x100")]
	[SerializeField]
	private GameObject pauseMain;

	[Token(Token = "0x40000E1")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x108")]
	[SerializeField]
	private GameObject pauseOptions;

	[Token(Token = "0x40000E2")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x0")]
	public static bool paused;

	[Token(Token = "0x40000E3")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x110")]
	private bool NetworkInitialize___EarlyPlayerPauseAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40000E4")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x111")]
	private bool NetworkInitialize__LatePlayerPauseAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x600018A")]
	[Address(RVA = "0x475410", Offset = "0x473E10", VA = "0x180475410", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x600018B")]
	[Address(RVA = "0x4754A0", Offset = "0x473EA0", VA = "0x1804754A0")]
	public void InspectorTogglePause()
	{
	}

	[Token(Token = "0x600018C")]
	[Address(RVA = "0x4754C0", Offset = "0x473EC0", VA = "0x1804754C0")]
	public void TogglePause([Optional] InputAction.CallbackContext context)
	{
	}

	[Token(Token = "0x600018D")]
	[Address(RVA = "0x475830", Offset = "0x474230", VA = "0x180475830")]
	public void StartLeaveLobby()
	{
	}

	[Token(Token = "0x600018E")]
	[Address(RVA = "0x4758E0", Offset = "0x4742E0", VA = "0x1804758E0")]
	[IteratorStateMachine(typeof(_003CLeaveLobby_003Ed__8))]
	public IEnumerator LeaveLobby()
	{
		return null;
	}

	[Token(Token = "0x600018F")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public PlayerPause()
	{
	}

	[Token(Token = "0x6000190")]
	[Address(RVA = "0x459270", Offset = "0x457C70", VA = "0x180459270", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000191")]
	[Address(RVA = "0x459290", Offset = "0x457C90", VA = "0x180459290", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000192")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000193")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
