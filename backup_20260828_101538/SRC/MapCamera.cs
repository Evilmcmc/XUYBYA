using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000069")]
public class MapCamera : MonoBehaviour
{
	[Token(Token = "0x40001AE")]
	[FieldOffset(Offset = "0x0")]
	public static Camera cam;

	[Token(Token = "0x60002AE")]
	[Address(RVA = "0x48D160", Offset = "0x48BB60", VA = "0x18048D160")]
	private void Awake()
	{
	}

	[Token(Token = "0x60002AF")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public MapCamera()
	{
	}
}
