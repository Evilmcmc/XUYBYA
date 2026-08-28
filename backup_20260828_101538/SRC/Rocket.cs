using System.Collections.Generic;
using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200009A")]
public class Rocket : MonoBehaviour
{
	[Token(Token = "0x4000349")]
	[FieldOffset(Offset = "0x0")]
	public static Dictionary<int, Rocket> Rockets;

	[Token(Token = "0x400034A")]
	[FieldOffset(Offset = "0x8")]
	public static int nextProjectileId;

	[Token(Token = "0x400034B")]
	[FieldOffset(Offset = "0x20")]
	public int damage;

	[Token(Token = "0x400034C")]
	[FieldOffset(Offset = "0x24")]
	public int shootingPlayerIndex;

	[Token(Token = "0x400034D")]
	[FieldOffset(Offset = "0x28")]
	public bool shootingPlayerIsAwayTeam;

	[Token(Token = "0x400034E")]
	[FieldOffset(Offset = "0x30")]
	[HideInInspector]
	public Dictionary<uint, Vector3> pastPositions;

	[Token(Token = "0x400034F")]
	[FieldOffset(Offset = "0x38")]
	[HideInInspector]
	public float aimAssist;

	[Token(Token = "0x4000350")]
	[FieldOffset(Offset = "0x3C")]
	[HideInInspector]
	public float speed;

	[Token(Token = "0x4000351")]
	[FieldOffset(Offset = "0x40")]
	[HideInInspector]
	public RocketLauncher source;

	[Token(Token = "0x4000352")]
	[FieldOffset(Offset = "0x48")]
	[SerializeField]
	private float lifeTime;

	[Token(Token = "0x4000353")]
	[FieldOffset(Offset = "0x4C")]
	[SerializeField]
	private float explosionRadius;

	[Token(Token = "0x4000354")]
	[FieldOffset(Offset = "0x50")]
	[SerializeField]
	private GameObject explosionEffect;

	[Token(Token = "0x4000355")]
	[FieldOffset(Offset = "0x58")]
	private float currentTime;

	[Token(Token = "0x4000356")]
	[FieldOffset(Offset = "0x5C")]
	private bool hasExploded;

	[Token(Token = "0x6000486")]
	[Address(RVA = "0x4B83E0", Offset = "0x4B6DE0", VA = "0x1804B83E0")]
	private void OnEnable()
	{
	}

	[Token(Token = "0x6000487")]
	[Address(RVA = "0x4B8520", Offset = "0x4B6F20", VA = "0x1804B8520")]
	private void OnDisable()
	{
	}

	[Token(Token = "0x6000488")]
	[Address(RVA = "0x4B85D0", Offset = "0x4B6FD0", VA = "0x1804B85D0")]
	private void OnTick()
	{
	}

	[Token(Token = "0x6000489")]
	[Address(RVA = "0x4B8D30", Offset = "0x4B7730", VA = "0x1804B8D30")]
	private void Update()
	{
	}

	[Token(Token = "0x600048A")]
	[Address(RVA = "0x4B9050", Offset = "0x4B7A50", VA = "0x1804B9050")]
	private void OnTriggerEnter(Collider other)
	{
	}

	[Token(Token = "0x600048B")]
	[Address(RVA = "0x4B9240", Offset = "0x4B7C40", VA = "0x1804B9240")]
	[Server]
	public void RPGExplode()
	{
	}

	[Token(Token = "0x600048C")]
	[Address(RVA = "0x4B9620", Offset = "0x4B8020", VA = "0x1804B9620")]
	public Rocket()
	{
	}
}
