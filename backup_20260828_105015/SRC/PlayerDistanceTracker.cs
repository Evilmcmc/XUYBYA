using FishNet.Managing.Scened;
using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x20000A5")]
public class PlayerDistanceTracker : NetworkBehaviour
{
	[Token(Token = "0x40003A4")]
	[FieldOffset(Offset = "0xF8")]
	[HideInInspector]
	public short maxDistance;

	[Token(Token = "0x40003A5")]
	[FieldOffset(Offset = "0xFA")]
	private bool NetworkInitialize___EarlyPlayerDistanceTrackerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40003A6")]
	[FieldOffset(Offset = "0xFB")]
	private bool NetworkInitialize__LatePlayerDistanceTrackerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60004FE")]
	[Address(RVA = "0x4C3860", Offset = "0x4C2260", VA = "0x1804C3860", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x60004FF")]
	[Address(RVA = "0x4C3910", Offset = "0x4C2310", VA = "0x1804C3910")]
	private void Update()
	{
	}

	[Token(Token = "0x6000500")]
	[Address(RVA = "0x4C3960", Offset = "0x4C2360", VA = "0x1804C3960")]
	[Server]
	private short GetDistance()
	{
		return default(short);
	}

	[Token(Token = "0x6000501")]
	[Address(RVA = "0x4C3D10", Offset = "0x4C2710", VA = "0x1804C3D10")]
	private void ResetStats(SceneLoadEndEventArgs obj)
	{
	}

	[Token(Token = "0x6000502")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public PlayerDistanceTracker()
	{
	}

	[Token(Token = "0x6000503")]
	[Address(RVA = "0x4C3D20", Offset = "0x4C2720", VA = "0x1804C3D20", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000504")]
	[Address(RVA = "0x4C3D40", Offset = "0x4C2740", VA = "0x1804C3D40", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000505")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000506")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
