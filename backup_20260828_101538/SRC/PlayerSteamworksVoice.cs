using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.InputSystem;

[Token(Token = "0x20000B1")]
public class PlayerSteamworksVoice : NetworkBehaviour
{
	[Token(Token = "0x40003D6")]
	[FieldOffset(Offset = "0xF8")]
	private AudioSource audioSource;

	[Token(Token = "0x40003D7")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	public GameObject voiceHUD;

	[Token(Token = "0x40003D8")]
	[FieldOffset(Offset = "0x108")]
	private bool record;

	[Token(Token = "0x40003D9")]
	[FieldOffset(Offset = "0x109")]
	private bool NetworkInitialize___EarlyPlayerSteamworksVoiceAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40003DA")]
	[FieldOffset(Offset = "0x10A")]
	private bool NetworkInitialize__LatePlayerSteamworksVoiceAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x600058F")]
	[Address(RVA = "0x4CCE20", Offset = "0x4CB820", VA = "0x1804CCE20", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x6000590")]
	[Address(RVA = "0x4CCEC0", Offset = "0x4CB8C0", VA = "0x1804CCEC0", Slot = "17")]
	public override void OnOwnershipClient(NetworkConnection prevOwner)
	{
	}

	[Token(Token = "0x6000591")]
	[Address(RVA = "0x4CCF80", Offset = "0x4CB980", VA = "0x1804CCF80")]
	public void OnDisable()
	{
	}

	[Token(Token = "0x6000592")]
	[Address(RVA = "0x4CD030", Offset = "0x4CBA30", VA = "0x1804CD030")]
	public void StartRecord(InputAction.CallbackContext context)
	{
	}

	[Token(Token = "0x6000593")]
	[Address(RVA = "0x4CD120", Offset = "0x4CBB20", VA = "0x1804CD120")]
	public void StopRecord(InputAction.CallbackContext context)
	{
	}

	[Token(Token = "0x6000594")]
	[Address(RVA = "0x4CD210", Offset = "0x4CBC10", VA = "0x1804CD210")]
	private void Update()
	{
	}

	[Token(Token = "0x6000595")]
	[Address(RVA = "0x4CD740", Offset = "0x4CC140", VA = "0x1804CD740")]
	[ServerRpc(RequireOwnership = true)]
	private void SendVoiceData(byte[] byteBuffer, uint byteCount, Channel channel = Channel.Unreliable)
	{
	}

	[Token(Token = "0x6000596")]
	[Address(RVA = "0x4CD750", Offset = "0x4CC150", VA = "0x1804CD750")]
	[ObserversRpc(ExcludeOwner = true)]
	private void ClientPlaySound(byte[] byteBuffer, uint byteCount, Channel channel = Channel.Unreliable)
	{
	}

	[Token(Token = "0x6000597")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public PlayerSteamworksVoice()
	{
	}

	[Token(Token = "0x6000598")]
	[Address(RVA = "0x4CD760", Offset = "0x4CC160", VA = "0x1804CD760", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000599")]
	[Address(RVA = "0x4C4740", Offset = "0x4C3140", VA = "0x1804C4740", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600059A")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x600059B")]
	[Address(RVA = "0x4CD850", Offset = "0x4CC250", VA = "0x1804CD850")]
	private void RpcWriter___Server_SendVoiceData_3210327127(byte[] byteBuffer, uint byteCount, Channel channel = Channel.Unreliable)
	{
	}

	[Token(Token = "0x600059C")]
	[Address(RVA = "0x4CDAA0", Offset = "0x4CC4A0", VA = "0x1804CDAA0")]
	private void RpcLogic___SendVoiceData_3210327127(byte[] byteBuffer, uint byteCount, Channel channel = Channel.Unreliable)
	{
	}

	[Token(Token = "0x600059D")]
	[Address(RVA = "0x4CDAC0", Offset = "0x4CC4C0", VA = "0x1804CDAC0")]
	private void RpcReader___Server_SendVoiceData_3210327127(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x600059E")]
	[Address(RVA = "0x4CDC00", Offset = "0x4CC600", VA = "0x1804CDC00")]
	private void RpcWriter___Observers_ClientPlaySound_3210327127(byte[] byteBuffer, uint byteCount, Channel channel = Channel.Unreliable)
	{
	}

	[Token(Token = "0x600059F")]
	[Address(RVA = "0x4CDE10", Offset = "0x4CC810", VA = "0x1804CDE10")]
	private void RpcLogic___ClientPlaySound_3210327127(byte[] byteBuffer, uint byteCount, Channel channel = Channel.Unreliable)
	{
	}

	[Token(Token = "0x60005A0")]
	[Address(RVA = "0x4CE3E0", Offset = "0x4CCDE0", VA = "0x1804CE3E0")]
	private void RpcReader___Observers_ClientPlaySound_3210327127(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60005A1")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
