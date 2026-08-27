using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x20000B0")]
public class PlayerSteamAchievements : NetworkBehaviour
{
	[Token(Token = "0x40003CF")]
	[FieldOffset(Offset = "0xF8")]
	public int minigunShotsInARow;

	[Token(Token = "0x40003D0")]
	[FieldOffset(Offset = "0x100")]
	public List<int> peopleHitWith1Burst;

	[Token(Token = "0x40003D1")]
	[FieldOffset(Offset = "0x108")]
	public int shotgunKillsInARow;

	[Token(Token = "0x40003D2")]
	[FieldOffset(Offset = "0x10C")]
	public int rpgKillsInARow;

	[Token(Token = "0x40003D3")]
	[FieldOffset(Offset = "0x110")]
	private List<WeaponScriptableObject> weaponsUsedToKill;

	[Token(Token = "0x40003D4")]
	[FieldOffset(Offset = "0x118")]
	private bool NetworkInitialize___EarlyPlayerSteamAchievementsAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40003D5")]
	[FieldOffset(Offset = "0x119")]
	private bool NetworkInitialize__LatePlayerSteamAchievementsAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000574")]
	[Address(RVA = "0x4CA7D0", Offset = "0x4C91D0", VA = "0x1804CA7D0")]
	[Client]
	public void HitAchievementCheck(int hitIndex)
	{
	}

	[Token(Token = "0x6000575")]
	[Address(RVA = "0x4CAC20", Offset = "0x4C9620", VA = "0x1804CAC20")]
	[Client]
	public void KillAchievementCheck(int killingIndex, int dyingIndex, int bounty)
	{
	}

	[Token(Token = "0x6000576")]
	[Address(RVA = "0x4CB1C0", Offset = "0x4C9BC0", VA = "0x1804CB1C0")]
	[Server]
	public void ServerExplodeTeammateAchievement()
	{
	}

	[Token(Token = "0x6000577")]
	[Address(RVA = "0x4CB390", Offset = "0x4C9D90", VA = "0x1804CB390")]
	[TargetRpc]
	private void ClientExplodeTeammateAchievement(NetworkConnection target)
	{
	}

	[Token(Token = "0x6000578")]
	[Address(RVA = "0x4CB500", Offset = "0x4C9F00", VA = "0x1804CB500")]
	private Vector3 GetPosition(int index)
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000579")]
	[Address(RVA = "0x4CBA10", Offset = "0x4CA410", VA = "0x1804CBA10")]
	[Client]
	public void TryUnlockCrossBowAchievement(int killingIndex, int dyingIndex)
	{
	}

	[Token(Token = "0x600057A")]
	[Address(RVA = "0x4CBD00", Offset = "0x4CA700", VA = "0x1804CBD00")]
	[Client]
	public void TryUnlockSniperAchievement(int killingIndex, int dyingIndex)
	{
	}

	[Token(Token = "0x600057B")]
	[Address(RVA = "0x4CBFF0", Offset = "0x4CA9F0", VA = "0x1804CBFF0")]
	[Client]
	public void TryUnlockBurstAchievement(int dyingIndex)
	{
	}

	[Token(Token = "0x600057C")]
	[Address(RVA = "0x4CC160", Offset = "0x4CAB60", VA = "0x1804CC160")]
	[Client]
	private void TryUnlockShotgunAchievement()
	{
	}

	[Token(Token = "0x600057D")]
	[Address(RVA = "0x4CC210", Offset = "0x4CAC10", VA = "0x1804CC210")]
	[Client]
	private void TryUnlockRPGAchievement(bool isSelf)
	{
	}

	[Token(Token = "0x600057E")]
	[Address(RVA = "0x4CC2D0", Offset = "0x4CACD0", VA = "0x1804CC2D0")]
	[Client]
	private void TryUnlockAllGunsAchievement(WeaponScriptableObject weapon)
	{
	}

	[Token(Token = "0x600057F")]
	[Address(RVA = "0x4CC500", Offset = "0x4CAF00", VA = "0x1804CC500")]
	[Client]
	private void TryUnlockMinigunAchievement()
	{
	}

	[Token(Token = "0x6000580")]
	[Address(RVA = "0x4CC620", Offset = "0x4CB020", VA = "0x1804CC620")]
	[Client]
	private void TryUnlock10KillStreakAchievement()
	{
	}

	[Token(Token = "0x6000581")]
	[Address(RVA = "0x4CC700", Offset = "0x4CB100", VA = "0x1804CC700")]
	[Client]
	public void TryClaimBountyAchievement(int bounty)
	{
	}

	[Token(Token = "0x6000582")]
	[Address(RVA = "0x4CC7B0", Offset = "0x4CB1B0", VA = "0x1804CC7B0")]
	[Client]
	public void WeaponGoneReset()
	{
	}

	[Token(Token = "0x6000583")]
	[Address(RVA = "0x4CC860", Offset = "0x4CB260", VA = "0x1804CC860")]
	[Client]
	public void UnlockAchievement(string achievement)
	{
	}

	[Token(Token = "0x6000584")]
	[Address(RVA = "0x4CC8F0", Offset = "0x4CB2F0", VA = "0x1804CC8F0")]
	[Client]
	public void IncreaseSteamStat(string stat)
	{
	}

	[Token(Token = "0x6000585")]
	[Address(RVA = "0x4CC9B0", Offset = "0x4CB3B0", VA = "0x1804CC9B0")]
	[Client]
	public void DeathAchievementReset()
	{
	}

	[Token(Token = "0x6000586")]
	[Address(RVA = "0x4CCA60", Offset = "0x4CB460", VA = "0x1804CCA60")]
	[Client]
	public void EndGameReset()
	{
	}

	[Token(Token = "0x6000587")]
	[Address(RVA = "0x4CCB50", Offset = "0x4CB550", VA = "0x1804CCB50")]
	public PlayerSteamAchievements()
	{
	}

	[Token(Token = "0x6000588")]
	[Address(RVA = "0x4CCCD0", Offset = "0x4CB6D0", VA = "0x1804CCCD0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000589")]
	[Address(RVA = "0x47D2C0", Offset = "0x47BCC0", VA = "0x18047D2C0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600058A")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x600058B")]
	[Address(RVA = "0x4CB390", Offset = "0x4C9D90", VA = "0x1804CB390")]
	private void RpcWriter___Target_ClientExplodeTeammateAchievement_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x600058C")]
	[Address(RVA = "0x4CCD60", Offset = "0x4CB760", VA = "0x1804CCD60")]
	private void RpcLogic___ClientExplodeTeammateAchievement_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x600058D")]
	[Address(RVA = "0x4CCDB0", Offset = "0x4CB7B0", VA = "0x1804CCDB0")]
	private void RpcReader___Target_ClientExplodeTeammateAchievement_328543758(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x600058E")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
