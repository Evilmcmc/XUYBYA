using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000083")]
public class MovingObject
{
	[Token(Token = "0x400022E")]
	[FieldOffset(Offset = "0x10")]
	public GameObject attachedObject;

	[Token(Token = "0x400022F")]
	[FieldOffset(Offset = "0x18")]
	public Vector3 posOnObject;

	[Token(Token = "0x600032E")]
	[Address(RVA = "0x496430", Offset = "0x494E30", VA = "0x180496430")]
	public MovingObject(GameObject _attachedObject, Vector3 _posOnObject)
	{
	}
}
