using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000123")]
public class LTBezier
{
	[Token(Token = "0x4000662")]
	[FieldOffset(Offset = "0x10")]
	public float length;

	[Token(Token = "0x4000663")]
	[FieldOffset(Offset = "0x14")]
	private Vector3 a;

	[Token(Token = "0x4000664")]
	[FieldOffset(Offset = "0x20")]
	private Vector3 aa;

	[Token(Token = "0x4000665")]
	[FieldOffset(Offset = "0x2C")]
	private Vector3 bb;

	[Token(Token = "0x4000666")]
	[FieldOffset(Offset = "0x38")]
	private Vector3 cc;

	[Token(Token = "0x4000667")]
	[FieldOffset(Offset = "0x44")]
	private float len;

	[Token(Token = "0x4000668")]
	[FieldOffset(Offset = "0x48")]
	private float[] arcLengths;

	[Token(Token = "0x6000940")]
	[Address(RVA = "0x51A390", Offset = "0x518D90", VA = "0x18051A390")]
	public LTBezier(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float precision)
	{
	}

	[Token(Token = "0x6000941")]
	[Address(RVA = "0x51A850", Offset = "0x519250", VA = "0x18051A850")]
	private float map(float u)
	{
		return default(float);
	}

	[Token(Token = "0x6000942")]
	[Address(RVA = "0x51A970", Offset = "0x519370", VA = "0x18051A970")]
	private Vector3 bezierPoint(float t)
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000943")]
	[Address(RVA = "0x51AA20", Offset = "0x519420", VA = "0x18051AA20")]
	public Vector3 point(float t)
	{
		return default(Vector3);
	}
}
