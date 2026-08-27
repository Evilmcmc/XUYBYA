using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200006D")]
public class MatchSettings : NetworkBehaviour
{
	[Token(Token = "0x40001BC")]
	[FieldOffset(Offset = "0x8")]
	[HideInInspector]
	public static GameMode mode;

	[Token(Token = "0x40001BD")]
	[FieldOffset(Offset = "0xC")]
	[HideInInspector]
	public static int length;

	[Token(Token = "0x40001BE")]
	[FieldOffset(Offset = "0x10")]
	[HideInInspector]
	public static BarrelSpawnType barrels;

	[Token(Token = "0x40001BF")]
	[FieldOffset(Offset = "0x18")]
	[HideInInspector]
	public static List<int> weapons;

	[Token(Token = "0x40001C0")]
	[FieldOffset(Offset = "0x20")]
	[HideInInspector]
	public static List<string> maps;

	[Token(Token = "0x40001C1")]
	[FieldOffset(Offset = "0xF8")]
	private bool NetworkInitialize___EarlyMatchSettingsAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40001C2")]
	[FieldOffset(Offset = "0xF9")]
	private bool NetworkInitialize__LateMatchSettingsAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x17000050")]
	public static MatchSettings Instance
	{
		[Token(Token = "0x60002B2")]
		[Address(RVA = "0x48D350", Offset = "0x48BD50", VA = "0x18048D350")]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[Token(Token = "0x60002B3")]
		[Address(RVA = "0x48D3B0", Offset = "0x48BDB0", VA = "0x18048D3B0")]
		[CompilerGenerated]
		private set
		{
		}
	}

	[Token(Token = "0x60002B4")]
	[Address(RVA = "0x48D460", Offset = "0x48BE60", VA = "0x18048D460", Slot = "27")]
	public override void Awake()
	{
	}

	[Token(Token = "0x60002B5")]
	[Address(RVA = "0x48D4A0", Offset = "0x48BEA0", VA = "0x18048D4A0", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x60002B6")]
	[Address(RVA = "0x48D6D0", Offset = "0x48C0D0", VA = "0x18048D6D0")]
	[ObserversRpc]
	public void SetClientMatchSettings()
	{
	}

	[Token(Token = "0x60002B7")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public MatchSettings()
	{
	}

	[Token(Token = "0x60002B9")]
	[Address(RVA = "0x48D9D0", Offset = "0x48C3D0", VA = "0x18048D9D0", Slot = "28")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60002BA")]
	[Address(RVA = "0x46BB80", Offset = "0x46A580", VA = "0x18046BB80", Slot = "29")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60002BB")]
	[Address(RVA = "0x469C90", Offset = "0x468690", VA = "0x180469C90", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60002BC")]
	[Address(RVA = "0x48D6D0", Offset = "0x48C0D0", VA = "0x18048D6D0")]
	private void RpcWriter___Observers_SetClientMatchSettings_2166136261()
	{
	}

	[Token(Token = "0x60002BD")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public void RpcLogic___SetClientMatchSettings_2166136261()
	{
	}

	[Token(Token = "0x60002BE")]
	[Address(RVA = "0x48DA60", Offset = "0x48C460", VA = "0x18048DA60")]
	private void RpcReader___Observers_SetClientMatchSettings_2166136261(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60002BF")]
	[Address(RVA = "0x48DA80", Offset = "0x48C480", VA = "0x18048DA80")]
	private void Awake_UserLogic_MatchSettings_Assembly_002DCSharp_002Edll()
	{
	}
}
