using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200005F")]
public class InitializeCustomMap : MonoBehaviour
{
	[Token(Token = "0x400017D")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private GameObject spawnPoint;

	[Token(Token = "0x400017E")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private GameObject weaponSpawn;

	[Token(Token = "0x6000275")]
	[Address(RVA = "0x488F10", Offset = "0x487910", VA = "0x180488F10")]
	private void Start()
	{
	}

	[Token(Token = "0x6000276")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public InitializeCustomMap()
	{
	}
}
