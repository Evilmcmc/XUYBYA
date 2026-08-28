using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x200005D")]
public class HealthHealingManager : NetworkBehaviour
{
	[Token(Token = "0x4000172")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private AudioManager audioManager;

	[Token(Token = "0x4000173")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private ParticleSystem splatterEffect;

	[Token(Token = "0x4000174")]
	[FieldOffset(Offset = "0x108")]
	[SerializeField]
	private Image damagePanel;

	[Token(Token = "0x4000175")]
	[FieldOffset(Offset = "0x110")]
	[SerializeField]
	private Image healPanel;

	[Token(Token = "0x4000176")]
	[FieldOffset(Offset = "0x118")]
	[SerializeField]
	private float lerpSpeed;

	[Token(Token = "0x4000177")]
	[FieldOffset(Offset = "0x11C")]
	private bool healEffectIsRunning;

	[Token(Token = "0x4000178")]
	[FieldOffset(Offset = "0x11D")]
	private bool NetworkInitialize___EarlyHealthHealingManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000179")]
	[FieldOffset(Offset = "0x11E")]
	private bool NetworkInitialize__LateHealthHealingManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000264")]
	[Address(RVA = "0x4880B0", Offset = "0x486AB0", VA = "0x1804880B0")]
	[Server]
	public void Heal(int amount)
	{
	}

	[Token(Token = "0x6000265")]
	[Address(RVA = "0x488390", Offset = "0x486D90", VA = "0x180488390")]
	[ObserversRpc]
	private void NetworkHealEffects()
	{
	}

	[Token(Token = "0x6000266")]
	[Address(RVA = "0x4884F0", Offset = "0x486EF0", VA = "0x1804884F0")]
	[IteratorStateMachine(typeof(_003CHealEffects_003Ed__8))]
	private IEnumerator HealEffects()
	{
		return null;
	}

	[Token(Token = "0x6000267")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public HealthHealingManager()
	{
	}

	[Token(Token = "0x6000268")]
	[Address(RVA = "0x488590", Offset = "0x486F90", VA = "0x180488590", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000269")]
	[Address(RVA = "0x488620", Offset = "0x487020", VA = "0x180488620", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600026A")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x600026B")]
	[Address(RVA = "0x488390", Offset = "0x486D90", VA = "0x180488390")]
	private void RpcWriter___Observers_NetworkHealEffects_2166136261()
	{
	}

	[Token(Token = "0x600026C")]
	[Address(RVA = "0x488640", Offset = "0x487040", VA = "0x180488640")]
	private void RpcLogic___NetworkHealEffects_2166136261()
	{
	}

	[Token(Token = "0x600026D")]
	[Address(RVA = "0x488820", Offset = "0x487220", VA = "0x180488820")]
	private void RpcReader___Observers_NetworkHealEffects_2166136261(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x600026E")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
