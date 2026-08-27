using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using LeTai.Asset.TranslucentImage;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

[Token(Token = "0x20000E1")]
public class GameCountdown : NetworkBehaviour
{
	[Token(Token = "0x400049D")]
	[FieldOffset(Offset = "0xF8")]
	[Header("Countdown")]
	[SerializeField]
	private int duration;

	[Token(Token = "0x400049E")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private TMP_Text countdownText;

	[Token(Token = "0x400049F")]
	[FieldOffset(Offset = "0x108")]
	[SerializeField]
	private LocalizedString fightText;

	[Token(Token = "0x40004A0")]
	[FieldOffset(Offset = "0x110")]
	[Header("Effects")]
	[SerializeField]
	private AudioSource CDnumberAudio;

	[Token(Token = "0x40004A1")]
	[FieldOffset(Offset = "0x118")]
	[SerializeField]
	private TranslucentImage translucentImage;

	[Token(Token = "0x40004A2")]
	[FieldOffset(Offset = "0x120")]
	private bool NetworkInitialize___EarlyGameCountdownAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40004A3")]
	[FieldOffset(Offset = "0x121")]
	private bool NetworkInitialize__LateGameCountdownAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60006AD")]
	[Address(RVA = "0x4E27F0", Offset = "0x4E11F0", VA = "0x1804E27F0")]
	[IteratorStateMachine(typeof(_003CStartSpawn_003Ed__5))]
	[Server]
	public IEnumerator StartSpawn(NetworkConnection conn)
	{
		return null;
	}

	[Token(Token = "0x60006AE")]
	[Address(RVA = "0x4E2950", Offset = "0x4E1350", VA = "0x1804E2950")]
	[TargetRpc]
	private void SpawnCheckPointStart(NetworkConnection target)
	{
	}

	[Token(Token = "0x60006AF")]
	[Address(RVA = "0x4E2AC0", Offset = "0x4E14C0", VA = "0x1804E2AC0")]
	[TargetRpc]
	private void CountdownAnimation(NetworkConnection target, int number)
	{
	}

	[Token(Token = "0x60006B0")]
	[Address(RVA = "0x4E2C50", Offset = "0x4E1650", VA = "0x1804E2C50")]
	[TargetRpc]
	public void DisableCountdown(NetworkConnection target)
	{
	}

	[Token(Token = "0x60006B1")]
	[Address(RVA = "0x4E2DC0", Offset = "0x4E17C0", VA = "0x1804E2DC0")]
	public void DisableCountdown()
	{
	}

	[Token(Token = "0x60006B2")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public GameCountdown()
	{
	}

	[Token(Token = "0x60006B3")]
	[Address(RVA = "0x4E2ED0", Offset = "0x4E18D0", VA = "0x1804E2ED0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60006B4")]
	[Address(RVA = "0x47B5F0", Offset = "0x479FF0", VA = "0x18047B5F0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60006B5")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60006B6")]
	[Address(RVA = "0x4E2950", Offset = "0x4E1350", VA = "0x1804E2950")]
	private void RpcWriter___Target_SpawnCheckPointStart_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x60006B7")]
	[Address(RVA = "0x4E3000", Offset = "0x4E1A00", VA = "0x1804E3000")]
	private void RpcLogic___SpawnCheckPointStart_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x60006B8")]
	[Address(RVA = "0x4E3180", Offset = "0x4E1B80", VA = "0x1804E3180")]
	private void RpcReader___Target_SpawnCheckPointStart_328543758(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60006B9")]
	[Address(RVA = "0x4E2AC0", Offset = "0x4E14C0", VA = "0x1804E2AC0")]
	private void RpcWriter___Target_CountdownAnimation_2681120339(NetworkConnection target, int number)
	{
	}

	[Token(Token = "0x60006BA")]
	[Address(RVA = "0x4E3320", Offset = "0x4E1D20", VA = "0x1804E3320")]
	private void RpcLogic___CountdownAnimation_2681120339(NetworkConnection target, int number)
	{
	}

	[Token(Token = "0x60006BB")]
	[Address(RVA = "0x4E3750", Offset = "0x4E2150", VA = "0x1804E3750")]
	private void RpcReader___Target_CountdownAnimation_2681120339(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60006BC")]
	[Address(RVA = "0x4E2C50", Offset = "0x4E1650", VA = "0x1804E2C50")]
	private void RpcWriter___Target_DisableCountdown_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x60006BD")]
	[Address(RVA = "0x4E37D0", Offset = "0x4E21D0", VA = "0x1804E37D0")]
	public void RpcLogic___DisableCountdown_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x60006BE")]
	[Address(RVA = "0x4E37E0", Offset = "0x4E21E0", VA = "0x1804E37E0")]
	private void RpcReader___Target_DisableCountdown_328543758(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60006BF")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
