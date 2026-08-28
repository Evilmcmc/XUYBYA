using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200002E")]
public class CrusherSpawnPoint : MonoBehaviour
{
	[Token(Token = "0x400008A")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private float frequency;

	[Token(Token = "0x400008B")]
	[FieldOffset(Offset = "0x24")]
	[SerializeField]
	private float magnitude;

	[Token(Token = "0x60000E1")]
	[Address(RVA = "0x465400", Offset = "0x463E00", VA = "0x180465400")]
	private void Update()
	{
	}

	[Token(Token = "0x60000E2")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public CrusherSpawnPoint()
	{
	}
}
