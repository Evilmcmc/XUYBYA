using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200002C")]
public class CrainSpawnPoint : MonoBehaviour
{
	[Token(Token = "0x4000083")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private float rotationSpeed;

	[Token(Token = "0x4000084")]
	[FieldOffset(Offset = "0x24")]
	[SerializeField]
	private bool taxi;

	[Token(Token = "0x60000D5")]
	[Address(RVA = "0x464E60", Offset = "0x463860", VA = "0x180464E60")]
	private void Update()
	{
	}

	[Token(Token = "0x60000D6")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public CrainSpawnPoint()
	{
	}
}
