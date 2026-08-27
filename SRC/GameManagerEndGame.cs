using System;
using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Object;
using Il2CppDummyDll;

[Token(Token = "0x20000E3")]
public class GameManagerEndGame : NetworkBehaviour
{
	[Token(Token = "0x40004A9")]
	[FieldOffset(Offset = "0xF8")]
	public Action OnGameEnd;

	[Token(Token = "0x40004AA")]
	[FieldOffset(Offset = "0x100")]
	private bool NetworkInitialize___EarlyGameManagerEndGameAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40004AB")]
	[FieldOffset(Offset = "0x101")]
	private bool NetworkInitialize__LateGameManagerEndGameAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60006C6")]
	[Address(RVA = "0x4E3CA0", Offset = "0x4E26A0", VA = "0x1804E3CA0")]
	[Server]
	public void EndGame()
	{
	}

	[Token(Token = "0x60006C7")]
	[Address(RVA = "0x4E40E0", Offset = "0x4E2AE0", VA = "0x1804E40E0")]
	[IteratorStateMachine(typeof(_003CEndGameWait_003Ed__2))]
	[Server]
	private IEnumerator EndGameWait()
	{
		return null;
	}

	[Token(Token = "0x60006C8")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public GameManagerEndGame()
	{
	}

	[Token(Token = "0x60006C9")]
	[Address(RVA = "0x47FFB0", Offset = "0x47E9B0", VA = "0x18047FFB0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60006CA")]
	[Address(RVA = "0x47FFD0", Offset = "0x47E9D0", VA = "0x18047FFD0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60006CB")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60006CC")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
