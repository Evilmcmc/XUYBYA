using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000085")]
public class MovingObjectRopePos
{
	[Token(Token = "0x4000251")]
	[FieldOffset(Offset = "0x10")]
	public int posIndex;

	[Token(Token = "0x4000252")]
	[FieldOffset(Offset = "0x18")]
	public GameObject attachedObject;

	[Token(Token = "0x4000253")]
	[FieldOffset(Offset = "0x20")]
	public Vector3 posOnObject;

	[Token(Token = "0x6000366")]
	[Address(RVA = "0x49DED0", Offset = "0x49C8D0", VA = "0x18049DED0")]
	public void SetMovingObjectRopePos(int _posIndex, GameObject _attachedObject, Vector3 _posOnObject)
	{
	}

	[Token(Token = "0x6000367")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public MovingObjectRopePos()
	{
	}
}
