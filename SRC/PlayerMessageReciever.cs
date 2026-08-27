using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x20000AB")]
public class PlayerMessageReciever : NetworkBehaviour
{
	[Token(Token = "0x40003B6")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private Text chatText;

	[Token(Token = "0x40003B8")]
	[FieldOffset(Offset = "0x8")]
	public static List<string> mutedPlayers;

	[Token(Token = "0x40003B9")]
	[FieldOffset(Offset = "0x10")]
	public static bool muteAll;

	[Token(Token = "0x40003BA")]
	[FieldOffset(Offset = "0x100")]
	private bool NetworkInitialize___EarlyPlayerMessageRecieverAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40003BB")]
	[FieldOffset(Offset = "0x101")]
	private bool NetworkInitialize__LatePlayerMessageRecieverAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x14000002")]
	private static event Action<string> OnMessage
	{
		[Token(Token = "0x6000542")]
		[Address(RVA = "0x4C6AD0", Offset = "0x4C54D0", VA = "0x1804C6AD0")]
		[CompilerGenerated]
		add
		{
		}
		[Token(Token = "0x6000543")]
		[Address(RVA = "0x4C6C30", Offset = "0x4C5630", VA = "0x1804C6C30")]
		[CompilerGenerated]
		remove
		{
		}
	}

	[Token(Token = "0x6000544")]
	[Address(RVA = "0x4C6D90", Offset = "0x4C5790", VA = "0x1804C6D90", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x6000545")]
	[Address(RVA = "0x4C6FD0", Offset = "0x4C59D0", VA = "0x1804C6FD0", Slot = "16")]
	public override void OnStopClient()
	{
	}

	[Token(Token = "0x6000546")]
	[Address(RVA = "0x4C7200", Offset = "0x4C5C00", VA = "0x1804C7200")]
	[ObserversRpc]
	public void RpcHandleMessage(string message)
	{
	}

	[Token(Token = "0x6000547")]
	[Address(RVA = "0x4C7380", Offset = "0x4C5D80", VA = "0x1804C7380")]
	private void HandleNewMessage(string message)
	{
	}

	[Token(Token = "0x6000548")]
	[Address(RVA = "0x4C75A0", Offset = "0x4C5FA0", VA = "0x1804C75A0")]
	public void HandleMessage(string message)
	{
	}

	[Token(Token = "0x6000549")]
	[Address(RVA = "0x4C76D0", Offset = "0x4C60D0", VA = "0x1804C76D0")]
	public void HandleCommandMessage()
	{
	}

	[Token(Token = "0x600054A")]
	[Address(RVA = "0x4C7820", Offset = "0x4C6220", VA = "0x1804C7820")]
	private void Update()
	{
	}

	[Token(Token = "0x600054B")]
	[Address(RVA = "0x4C79A0", Offset = "0x4C63A0", VA = "0x1804C79A0")]
	private bool MessageIsMuted(string message)
	{
		return default(bool);
	}

	[Token(Token = "0x600054C")]
	[Address(RVA = "0x4C7B50", Offset = "0x4C6550", VA = "0x1804C7B50")]
	[IteratorStateMachine(typeof(_003CFadeText_003Ed__14))]
	private IEnumerator FadeText()
	{
		return null;
	}

	[Token(Token = "0x600054D")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public PlayerMessageReciever()
	{
	}

	[Token(Token = "0x600054F")]
	[Address(RVA = "0x4C7CE0", Offset = "0x4C66E0", VA = "0x1804C7CE0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000550")]
	[Address(RVA = "0x47FFD0", Offset = "0x47E9D0", VA = "0x18047FFD0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000551")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000552")]
	[Address(RVA = "0x4C7200", Offset = "0x4C5C00", VA = "0x1804C7200")]
	private void RpcWriter___Observers_RpcHandleMessage_3615296227(string message)
	{
	}

	[Token(Token = "0x6000553")]
	[Address(RVA = "0x4C7D70", Offset = "0x4C6770", VA = "0x1804C7D70")]
	public void RpcLogic___RpcHandleMessage_3615296227(string message)
	{
	}

	[Token(Token = "0x6000554")]
	[Address(RVA = "0x4C7E10", Offset = "0x4C6810", VA = "0x1804C7E10")]
	private void RpcReader___Observers_RpcHandleMessage_3615296227(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000555")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
