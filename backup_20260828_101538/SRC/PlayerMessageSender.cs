using Crosstales.BWF.Model.Enum;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[Token(Token = "0x20000AD")]
public class PlayerMessageSender : NetworkBehaviour
{
	[Token(Token = "0x40003BF")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	public TMP_InputField inputField;

	[Token(Token = "0x40003C0")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private ManagerMask textMask;

	[Token(Token = "0x40003C1")]
	[FieldOffset(Offset = "0x108")]
	[SerializeField]
	private string[] sources;

	[Token(Token = "0x40003C2")]
	[FieldOffset(Offset = "0x110")]
	[SerializeField]
	private AudioSource sendSoundEffect;

	[Token(Token = "0x40003C3")]
	[FieldOffset(Offset = "0x118")]
	[SerializeField]
	private GameObject healthUISlot;

	[Token(Token = "0x40003C4")]
	[FieldOffset(Offset = "0x0")]
	public static bool isChatting;

	[Token(Token = "0x40003C5")]
	[FieldOffset(Offset = "0x120")]
	private bool NetworkInitialize___EarlyPlayerMessageSenderAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40003C6")]
	[FieldOffset(Offset = "0x121")]
	private bool NetworkInitialize__LatePlayerMessageSenderAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x600055C")]
	[Address(RVA = "0x4C80C0", Offset = "0x4C6AC0", VA = "0x1804C80C0")]
	private string ProfanityCheck(string message)
	{
		return null;
	}

	[Token(Token = "0x600055D")]
	[Address(RVA = "0x4C81B0", Offset = "0x4C6BB0", VA = "0x1804C81B0", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x600055E")]
	[Address(RVA = "0x4C8280", Offset = "0x4C6C80", VA = "0x1804C8280")]
	private void Update()
	{
	}

	[Token(Token = "0x600055F")]
	[Address(RVA = "0x4C8570", Offset = "0x4C6F70", VA = "0x1804C8570")]
	public void EnterInput(InputAction.CallbackContext context)
	{
	}

	[Token(Token = "0x6000560")]
	[Address(RVA = "0x4C8870", Offset = "0x4C7270", VA = "0x1804C8870")]
	public void CancelChat()
	{
	}

	[Token(Token = "0x6000561")]
	[Address(RVA = "0x4C8920", Offset = "0x4C7320", VA = "0x1804C8920")]
	[Client]
	public void Send(string message)
	{
	}

	[Token(Token = "0x6000562")]
	[Address(RVA = "0x4C8BE0", Offset = "0x4C75E0", VA = "0x1804C8BE0")]
	[ServerRpc]
	private void CmdSendMessage(string message)
	{
	}

	[Token(Token = "0x6000563")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public PlayerMessageSender()
	{
	}

	[Token(Token = "0x6000564")]
	[Address(RVA = "0x4C8DA0", Offset = "0x4C77A0", VA = "0x1804C8DA0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000565")]
	[Address(RVA = "0x47B5F0", Offset = "0x479FF0", VA = "0x18047B5F0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000566")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000567")]
	[Address(RVA = "0x4C8BE0", Offset = "0x4C75E0", VA = "0x1804C8BE0")]
	private void RpcWriter___Server_CmdSendMessage_3615296227(string message)
	{
	}

	[Token(Token = "0x6000568")]
	[Address(RVA = "0x4C8E30", Offset = "0x4C7830", VA = "0x1804C8E30")]
	private void RpcLogic___CmdSendMessage_3615296227(string message)
	{
	}

	[Token(Token = "0x6000569")]
	[Address(RVA = "0x4C9960", Offset = "0x4C8360", VA = "0x1804C9960")]
	private void RpcReader___Server_CmdSendMessage_3615296227(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x600056A")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
