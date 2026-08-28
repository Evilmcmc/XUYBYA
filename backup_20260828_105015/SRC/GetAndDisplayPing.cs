using FishNet.Object;
using Il2CppDummyDll;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

[Token(Token = "0x2000082")]
public class GetAndDisplayPing : NetworkBehaviour
{
	[Token(Token = "0x4000228")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private TMP_Text pingText;

	[Token(Token = "0x4000229")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private LocalizedString msText;

	[Token(Token = "0x400022A")]
	[FieldOffset(Offset = "0x108")]
	private float nextActionTime;

	[Token(Token = "0x400022B")]
	[FieldOffset(Offset = "0x10C")]
	private float period;

	[Token(Token = "0x400022C")]
	[FieldOffset(Offset = "0x110")]
	private bool NetworkInitialize___EarlyGetAndDisplayPingAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x400022D")]
	[FieldOffset(Offset = "0x111")]
	private bool NetworkInitialize__LateGetAndDisplayPingAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000327")]
	[Address(RVA = "0x4835D0", Offset = "0x481FD0", VA = "0x1804835D0", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x6000328")]
	[Address(RVA = "0x4962C0", Offset = "0x494CC0", VA = "0x1804962C0")]
	private void Update()
	{
	}

	[Token(Token = "0x6000329")]
	[Address(RVA = "0x496410", Offset = "0x494E10", VA = "0x180496410")]
	public GetAndDisplayPing()
	{
	}

	[Token(Token = "0x600032A")]
	[Address(RVA = "0x459270", Offset = "0x457C70", VA = "0x180459270", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x600032B")]
	[Address(RVA = "0x459290", Offset = "0x457C90", VA = "0x180459290", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600032C")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x600032D")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
