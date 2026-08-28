using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200003B")]
public class Explosion
{
	[Token(Token = "0x6000133")]
	[Address(RVA = "0x46A880", Offset = "0x469280", VA = "0x18046A880")]
	[Server]
	public static void Explode(GameObject gameObject, float radius, int shootingPlayerIndex, bool shootingPlayerIsAwayTeam, int damage)
	{
	}

	[Token(Token = "0x6000134")]
	[Address(RVA = "0x46AEF0", Offset = "0x4698F0", VA = "0x18046AEF0")]
	[Server]
	public static void TryExplodePlayer(GameObject inRangeObject, Vector3 position, int shootingPlayerIndex, bool shootingPlayerIsAwayTeam, int damage)
	{
	}

	[Token(Token = "0x6000135")]
	[Address(RVA = "0x46B440", Offset = "0x469E40", VA = "0x18046B440")]
	public static void ExplodePlayer(NetworkBehaviour hitPlayer, Vector3 position, int shootingPlayerIndex, int damage)
	{
	}

	[Token(Token = "0x6000136")]
	[Address(RVA = "0x46B590", Offset = "0x469F90", VA = "0x18046B590")]
	[Server]
	public static void TryExplodeBarrel(GameObject inRangeObject, GameObject gameObject, int shootingPlayerIndex, bool shootingPlayerIsAwayTeam)
	{
	}

	[Token(Token = "0x6000137")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public Explosion()
	{
	}
}
