using System.Collections.Generic;
using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x20000A4")]
public class PlayerCollisionRollback : NetworkBehaviour
{
	[Token(Token = "0x400039C")]
	[FieldOffset(Offset = "0x0")]
	public static Dictionary<int, PlayerCollisionRollback> Players;

	[Token(Token = "0x400039D")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private CapsuleCollider _capsuleCollider;

	[Token(Token = "0x400039E")]
	[FieldOffset(Offset = "0x100")]
	private float _capsuleRadius;

	[Token(Token = "0x400039F")]
	[FieldOffset(Offset = "0x104")]
	private float _capsuleHeight;

	[Token(Token = "0x40003A0")]
	[FieldOffset(Offset = "0x108")]
	private Dictionary<uint, Vector3> _pastPositions;

	[Token(Token = "0x40003A1")]
	[FieldOffset(Offset = "0x110")]
	private Vector3 endPoint;

	[Token(Token = "0x40003A2")]
	[FieldOffset(Offset = "0x11C")]
	private bool NetworkInitialize___EarlyPlayerCollisionRollbackAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40003A3")]
	[FieldOffset(Offset = "0x11D")]
	private bool NetworkInitialize__LatePlayerCollisionRollbackAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60004EF")]
	[Address(RVA = "0x4C1D60", Offset = "0x4C0760", VA = "0x1804C1D60", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x60004F0")]
	[Address(RVA = "0x4C20D0", Offset = "0x4C0AD0", VA = "0x1804C20D0", Slot = "11")]
	public override void OnStopServer()
	{
	}

	[Token(Token = "0x60004F1")]
	[Address(RVA = "0x4C21F0", Offset = "0x4C0BF0", VA = "0x1804C21F0")]
	private void OnTick()
	{
	}

	[Token(Token = "0x60004F2")]
	[Address(RVA = "0x4C24E0", Offset = "0x4C0EE0", VA = "0x1804C24E0")]
	public bool CheckPastCollisions(Rocket rocket, float collisionRadius)
	{
		return default(bool);
	}

	[Token(Token = "0x60004F3")]
	[Address(RVA = "0x4C2770", Offset = "0x4C1170", VA = "0x1804C2770")]
	public bool CheckPastCollisions(Vector3 rayOrigin, Vector3 rayDirection, float aimAssistRadius, float range, out Vector3 hitPosition, uint tick)
	{
		return default(bool);
	}

	[Token(Token = "0x60004F4")]
	[Address(RVA = "0x4C2B00", Offset = "0x4C1500", VA = "0x1804C2B00")]
	private Vector3 ClosestPointOnLineSegment(Vector3 a, Vector3 b, Vector3 target)
	{
		return default(Vector3);
	}

	[Token(Token = "0x60004F5")]
	[Address(RVA = "0x4C2C00", Offset = "0x4C1600", VA = "0x1804C2C00")]
	private void OnDrawGizmos()
	{
	}

	[Token(Token = "0x60004F6")]
	[Address(RVA = "0x4C31C0", Offset = "0x4C1BC0", VA = "0x1804C31C0")]
	private void DrawWireSphere(Vector3 position, float radius)
	{
	}

	[Token(Token = "0x60004F7")]
	[Address(RVA = "0x4C3290", Offset = "0x4C1C90", VA = "0x1804C3290")]
	private void DrawWireCylinder(Vector3 position, float height, float radius)
	{
	}

	[Token(Token = "0x60004F8")]
	[Address(RVA = "0x4C3640", Offset = "0x4C2040", VA = "0x1804C3640")]
	public PlayerCollisionRollback()
	{
	}

	[Token(Token = "0x60004FA")]
	[Address(RVA = "0x4C3820", Offset = "0x4C2220", VA = "0x1804C3820", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60004FB")]
	[Address(RVA = "0x4C3840", Offset = "0x4C2240", VA = "0x1804C3840", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60004FC")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60004FD")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
