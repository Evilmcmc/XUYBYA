using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

[Token(Token = "0x2000031")]
public class DeathManager : NetworkBehaviour
{
	[Token(Token = "0x400008F")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private GameObject deathScreen;

	[Token(Token = "0x4000090")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private TMP_Text killedByText;

	[Token(Token = "0x4000091")]
	[FieldOffset(Offset = "0x108")]
	[SerializeField]
	private LocalizedString killedbyString;

	[Token(Token = "0x4000092")]
	[FieldOffset(Offset = "0x110")]
	private bool NetworkInitialize___EarlyDeathManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000093")]
	[FieldOffset(Offset = "0x111")]
	private bool NetworkInitialize__LateDeathManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60000EA")]
	[Address(RVA = "0x465BD0", Offset = "0x4645D0", VA = "0x180465BD0")]
	[IteratorStateMachine(typeof(_003CDeath_003Ed__3))]
	[Server]
	public IEnumerator Death(int damage, Vector3 source, string usernameOfKiller)
	{
		return null;
	}

	[Token(Token = "0x60000EB")]
	[Address(RVA = "0x465D60", Offset = "0x464760", VA = "0x180465D60")]
	[TargetRpc]
	private void StartDeathEffects(NetworkConnection target, int damage, Vector3 source, string usernameOfKiller)
	{
	}

	[Token(Token = "0x60000EC")]
	[Address(RVA = "0x465DA0", Offset = "0x4647A0", VA = "0x180465DA0")]
	[TargetRpc]
	private void RemoveDeathText(NetworkConnection target)
	{
	}

	[Token(Token = "0x60000ED")]
	[Address(RVA = "0x465F10", Offset = "0x464910", VA = "0x180465F10")]
	[Client]
	private void EnableDeathScreen()
	{
	}

	[Token(Token = "0x60000EE")]
	[Address(RVA = "0x466570", Offset = "0x464F70", VA = "0x180466570")]
	[Client]
	private void FadeInDeathScreen()
	{
	}

	[Token(Token = "0x60000EF")]
	[Address(RVA = "0x466720", Offset = "0x465120", VA = "0x180466720")]
	[Client]
	private void ScaleText(Vector3 startScale, Vector3 endScale)
	{
	}

	[Token(Token = "0x60000F0")]
	[Address(RVA = "0x466DD0", Offset = "0x4657D0", VA = "0x180466DD0")]
	[Client]
	private void SetKilledByText(string usernameOfKiller)
	{
	}

	[Token(Token = "0x60000F1")]
	[Address(RVA = "0x466FC0", Offset = "0x4659C0", VA = "0x180466FC0")]
	[Client]
	private void DisableControls()
	{
	}

	[Token(Token = "0x60000F2")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public DeathManager()
	{
	}

	[Token(Token = "0x60000F3")]
	[Address(RVA = "0x4672D0", Offset = "0x465CD0", VA = "0x1804672D0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60000F4")]
	[Address(RVA = "0x459290", Offset = "0x457C90", VA = "0x180459290", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60000F5")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60000F6")]
	[Address(RVA = "0x4673B0", Offset = "0x465DB0", VA = "0x1804673B0")]
	private void RpcWriter___Target_StartDeathEffects_2463727990(NetworkConnection target, int damage, Vector3 source, string usernameOfKiller)
	{
	}

	[Token(Token = "0x60000F7")]
	[Address(RVA = "0x4675A0", Offset = "0x465FA0", VA = "0x1804675A0")]
	private void RpcLogic___StartDeathEffects_2463727990(NetworkConnection target, int damage, Vector3 source, string usernameOfKiller)
	{
	}

	[Token(Token = "0x60000F8")]
	[Address(RVA = "0x4678E0", Offset = "0x4662E0", VA = "0x1804678E0")]
	private void RpcReader___Target_StartDeathEffects_2463727990(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60000F9")]
	[Address(RVA = "0x465DA0", Offset = "0x4647A0", VA = "0x180465DA0")]
	private void RpcWriter___Target_RemoveDeathText_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x60000FA")]
	[Address(RVA = "0x467A00", Offset = "0x466400", VA = "0x180467A00")]
	private void RpcLogic___RemoveDeathText_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x60000FB")]
	[Address(RVA = "0x467AC0", Offset = "0x4664C0", VA = "0x180467AC0")]
	private void RpcReader___Target_RemoveDeathText_328543758(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60000FC")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
