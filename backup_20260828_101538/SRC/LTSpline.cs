using System;
using Il2CppDummyDll;
using UnityEngine;

[Serializable]
[Token(Token = "0x2000125")]
public class LTSpline
{
	[Token(Token = "0x4000671")]
	[FieldOffset(Offset = "0x0")]
	public static int DISTANCE_COUNT;

	[Token(Token = "0x4000672")]
	[FieldOffset(Offset = "0x4")]
	public static int SUBLINE_COUNT;

	[Token(Token = "0x4000673")]
	[FieldOffset(Offset = "0x10")]
	public float distance;

	[Token(Token = "0x4000674")]
	[FieldOffset(Offset = "0x14")]
	public bool constantSpeed;

	[Token(Token = "0x4000675")]
	[FieldOffset(Offset = "0x18")]
	public Vector3[] pts;

	[NonSerialized]
	[Token(Token = "0x4000676")]
	[FieldOffset(Offset = "0x20")]
	public Vector3[] ptsAdj;

	[Token(Token = "0x4000677")]
	[FieldOffset(Offset = "0x28")]
	public int ptsAdjLength;

	[Token(Token = "0x4000678")]
	[FieldOffset(Offset = "0x2C")]
	public bool orientToPath;

	[Token(Token = "0x4000679")]
	[FieldOffset(Offset = "0x2D")]
	public bool orientToPath2d;

	[Token(Token = "0x400067A")]
	[FieldOffset(Offset = "0x30")]
	private int numSections;

	[Token(Token = "0x400067B")]
	[FieldOffset(Offset = "0x34")]
	private int currPt;

	[Token(Token = "0x6000951")]
	[Address(RVA = "0x51C0B0", Offset = "0x51AAB0", VA = "0x18051C0B0")]
	public LTSpline(Vector3[] pts)
	{
	}

	[Token(Token = "0x6000952")]
	[Address(RVA = "0x51C0C0", Offset = "0x51AAC0", VA = "0x18051C0C0")]
	public LTSpline(Vector3[] pts, bool constantSpeed)
	{
	}

	[Token(Token = "0x6000953")]
	[Address(RVA = "0x51C0D0", Offset = "0x51AAD0", VA = "0x18051C0D0")]
	private void init(Vector3[] pts, bool constantSpeed)
	{
	}

	[Token(Token = "0x6000954")]
	[Address(RVA = "0x51C770", Offset = "0x51B170", VA = "0x18051C770")]
	public Vector3 map(float u)
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000955")]
	[Address(RVA = "0x51C8E0", Offset = "0x51B2E0", VA = "0x18051C8E0")]
	public Vector3 interp(float t)
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000956")]
	[Address(RVA = "0x51CCC0", Offset = "0x51B6C0", VA = "0x18051CCC0")]
	public float ratioAtPoint(Vector3 pt)
	{
		return default(float);
	}

	[Token(Token = "0x6000957")]
	[Address(RVA = "0x51CE60", Offset = "0x51B860", VA = "0x18051CE60")]
	public Vector3 point(float ratio)
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000958")]
	[Address(RVA = "0x51CEB0", Offset = "0x51B8B0", VA = "0x18051CEB0")]
	public void place2d(Transform transform, float ratio)
	{
	}

	[Token(Token = "0x6000959")]
	[Address(RVA = "0x51D0F0", Offset = "0x51BAF0", VA = "0x18051D0F0")]
	public void placeLocal2d(Transform transform, float ratio)
	{
	}

	[Token(Token = "0x600095A")]
	[Address(RVA = "0x51D400", Offset = "0x51BE00", VA = "0x18051D400")]
	public void place(Transform transform, float ratio)
	{
	}

	[Token(Token = "0x600095B")]
	[Address(RVA = "0x51D490", Offset = "0x51BE90", VA = "0x18051D490")]
	public void place(Transform transform, float ratio, Vector3 worldUp)
	{
	}

	[Token(Token = "0x600095C")]
	[Address(RVA = "0x51D6A0", Offset = "0x51C0A0", VA = "0x18051D6A0")]
	public void placeLocal(Transform transform, float ratio)
	{
	}

	[Token(Token = "0x600095D")]
	[Address(RVA = "0x51D730", Offset = "0x51C130", VA = "0x18051D730")]
	public void placeLocal(Transform transform, float ratio, Vector3 worldUp)
	{
	}

	[Token(Token = "0x600095E")]
	[Address(RVA = "0x51DA00", Offset = "0x51C400", VA = "0x18051DA00")]
	public void gizmoDraw(float t = -1f)
	{
	}

	[Token(Token = "0x600095F")]
	[Address(RVA = "0x51DB10", Offset = "0x51C510", VA = "0x18051DB10")]
	public void drawGizmo(Color color)
	{
	}

	[Token(Token = "0x6000960")]
	[Address(RVA = "0x51DD30", Offset = "0x51C730", VA = "0x18051DD30")]
	public static void drawGizmo(Transform[] arr, Color color)
	{
	}

	[Token(Token = "0x6000961")]
	[Address(RVA = "0x51E0E0", Offset = "0x51CAE0", VA = "0x18051E0E0")]
	public static void drawLine(Transform[] arr, float width, Color color)
	{
	}

	[Token(Token = "0x6000962")]
	[Address(RVA = "0x51E100", Offset = "0x51CB00", VA = "0x18051E100")]
	public void drawLinesGLLines(Material outlineMaterial, Color color, float width)
	{
	}

	[Token(Token = "0x6000963")]
	[Address(RVA = "0x51E4B0", Offset = "0x51CEB0", VA = "0x18051E4B0")]
	public Vector3[] generateVectors()
	{
		return null;
	}
}
