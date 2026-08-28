using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000057")]
public class HealthDamageManager : NetworkBehaviour
{
	[Token(Token = "0x4000157")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private AudioManager audioManager;

	[Token(Token = "0x4000158")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private ParticleSystem splatterEffect;

	[Token(Token = "0x4000159")]
	[FieldOffset(Offset = "0x108")]
	[SerializeField]
	private Image damagePanel;

	[Token(Token = "0x400015A")]
	[FieldOffset(Offset = "0x110")]
	[SerializeField]
	private float lerpSpeed;

	[Token(Token = "0x400015B")]
	[FieldOffset(Offset = "0x114")]
	private bool damageEffectIsRunning;

	[Token(Token = "0x400015C")]
	[FieldOffset(Offset = "0x115")]
	private bool NetworkInitialize___EarlyHealthDamageManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x400015D")]
	[FieldOffset(Offset = "0x116")]
	private bool NetworkInitialize__LateHealthDamageManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x600022E")]
	[Address(RVA = "0x484BC0", Offset = "0x4835C0", VA = "0x180484BC0")]
	[Server]
	public void Damage(Vector3 source, int damage, int shootingPlayerIndex = -1)
	{
	}

	[Token(Token = "0x600022F")]
	[Address(RVA = "0x485CD0", Offset = "0x4846D0", VA = "0x180485CD0")]
	[ObserversRpc]
	private void NetworkDamageEffects()
	{
	}

	[Token(Token = "0x6000230")]
	[Address(RVA = "0x485E30", Offset = "0x484830", VA = "0x180485E30")]
	[IteratorStateMachine(typeof(_003CDamageEffects_003Ed__7))]
	private IEnumerator DamageEffects()
	{
		return null;
	}

	[Token(Token = "0x6000231")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public HealthDamageManager()
	{
	}

	[Token(Token = "0x6000232")]
	[Address(RVA = "0x485ED0", Offset = "0x4848D0", VA = "0x180485ED0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000233")]
	[Address(RVA = "0x485F60", Offset = "0x484960", VA = "0x180485F60", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000234")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000235")]
	[Address(RVA = "0x485CD0", Offset = "0x4846D0", VA = "0x180485CD0")]
	private void RpcWriter___Observers_NetworkDamageEffects_2166136261()
	{
	}

	[Token(Token = "0x6000236")]
	[Address(RVA = "0x485F80", Offset = "0x484980", VA = "0x180485F80")]
	private void RpcLogic___NetworkDamageEffects_2166136261()
	{
	}

	[Token(Token = "0x6000237")]
	[Address(RVA = "0x486160", Offset = "0x484B60", VA = "0x180486160")]
	private void RpcReader___Observers_NetworkDamageEffects_2166136261(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000238")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
