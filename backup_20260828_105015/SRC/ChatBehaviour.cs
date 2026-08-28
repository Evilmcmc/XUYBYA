using FishNet.Object;
using Il2CppDummyDll;

[Token(Token = "0x200003C")]
public class ChatBehaviour : NetworkBehaviour
{
	[Token(Token = "0x40000BC")]
	[FieldOffset(Offset = "0xF8")]
	private bool NetworkInitialize___EarlyChatBehaviourAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40000BD")]
	[FieldOffset(Offset = "0xF9")]
	private bool NetworkInitialize__LateChatBehaviourAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000138")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public ChatBehaviour()
	{
	}

	[Token(Token = "0x6000139")]
	[Address(RVA = "0x46BB60", Offset = "0x46A560", VA = "0x18046BB60", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x600013A")]
	[Address(RVA = "0x46BB80", Offset = "0x46A580", VA = "0x18046BB80", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600013B")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x600013C")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
