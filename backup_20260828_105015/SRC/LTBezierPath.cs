using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000124")]
public class LTBezierPath
{
	[Token(Token = "0x4000669")]
	[FieldOffset(Offset = "0x10")]
	public Vector3[] pts;

	[Token(Token = "0x400066A")]
	[FieldOffset(Offset = "0x18")]
	public float length;

	[Token(Token = "0x400066B")]
	[FieldOffset(Offset = "0x1C")]
	public bool orientToPath;

	[Token(Token = "0x400066C")]
	[FieldOffset(Offset = "0x1D")]
	public bool orientToPath2d;

	[Token(Token = "0x400066D")]
	[FieldOffset(Offset = "0x20")]
	private LTBezier[] beziers;

	[Token(Token = "0x400066E")]
	[FieldOffset(Offset = "0x28")]
	private float[] lengthRatio;

	[Token(Token = "0x400066F")]
	[FieldOffset(Offset = "0x30")]
	private int currentBezier;

	[Token(Token = "0x4000670")]
	[FieldOffset(Offset = "0x34")]
	private int previousBezier;

	[Token(Token = "0x170000B2")]
	public float distance
	{
		[Token(Token = "0x6000947")]
		[Address(RVA = "0x51B090", Offset = "0x519A90", VA = "0x18051B090")]
		get
		{
			return default(float);
		}
	}

	[Token(Token = "0x6000944")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public LTBezierPath()
	{
	}

	[Token(Token = "0x6000945")]
	[Address(RVA = "0x51AAF0", Offset = "0x5194F0", VA = "0x18051AAF0")]
	public LTBezierPath(Vector3[] pts_)
	{
	}

	[Token(Token = "0x6000946")]
	[Address(RVA = "0x51AB00", Offset = "0x519500", VA = "0x18051AB00")]
	public void setPoints(Vector3[] pts_)
	{
	}

	[Token(Token = "0x6000948")]
	[Address(RVA = "0x51B0A0", Offset = "0x519AA0", VA = "0x18051B0A0")]
	public Vector3 point(float ratio)
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000949")]
	[Address(RVA = "0x51B1A0", Offset = "0x519BA0", VA = "0x18051B1A0")]
	public void place2d(Transform transform, float ratio)
	{
	}

	[Token(Token = "0x600094A")]
	[Address(RVA = "0x51B3A0", Offset = "0x519DA0", VA = "0x18051B3A0")]
	public void placeLocal2d(Transform transform, float ratio)
	{
	}

	[Token(Token = "0x600094B")]
	[Address(RVA = "0x51B5A0", Offset = "0x519FA0", VA = "0x18051B5A0")]
	public void place(Transform transform, float ratio)
	{
	}

	[Token(Token = "0x600094C")]
	[Address(RVA = "0x51B7B0", Offset = "0x51A1B0", VA = "0x18051B7B0")]
	public void place(Transform transform, float ratio, Vector3 worldUp)
	{
	}

	[Token(Token = "0x600094D")]
	[Address(RVA = "0x51B980", Offset = "0x51A380", VA = "0x18051B980")]
	public void placeLocal(Transform transform, float ratio)
	{
	}

	[Token(Token = "0x600094E")]
	[Address(RVA = "0x51BA10", Offset = "0x51A410", VA = "0x18051BA10")]
	public void placeLocal(Transform transform, float ratio, Vector3 worldUp)
	{
	}

	[Token(Token = "0x600094F")]
	[Address(RVA = "0x51BCF0", Offset = "0x51A6F0", VA = "0x18051BCF0")]
	public void gizmoDraw(float t = -1f)
	{
	}

	[Token(Token = "0x6000950")]
	[Address(RVA = "0x51BEA0", Offset = "0x51A8A0", VA = "0x18051BEA0")]
	public float ratioAtPoint(Vector3 pt, float precision = 0.01f)
	{
		return default(float);
	}
}
