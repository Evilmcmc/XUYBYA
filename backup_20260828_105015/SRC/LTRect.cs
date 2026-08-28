using System;
using Il2CppDummyDll;
using UnityEngine;

[Serializable]
[Token(Token = "0x2000126")]
public class LTRect
{
	[Token(Token = "0x400067C")]
	[FieldOffset(Offset = "0x10")]
	public Rect _rect;

	[Token(Token = "0x400067D")]
	[FieldOffset(Offset = "0x20")]
	public float alpha;

	[Token(Token = "0x400067E")]
	[FieldOffset(Offset = "0x24")]
	public float rotation;

	[Token(Token = "0x400067F")]
	[FieldOffset(Offset = "0x28")]
	public Vector2 pivot;

	[Token(Token = "0x4000680")]
	[FieldOffset(Offset = "0x30")]
	public Vector2 margin;

	[Token(Token = "0x4000681")]
	[FieldOffset(Offset = "0x38")]
	public Rect relativeRect;

	[Token(Token = "0x4000682")]
	[FieldOffset(Offset = "0x48")]
	public bool rotateEnabled;

	[Token(Token = "0x4000683")]
	[FieldOffset(Offset = "0x49")]
	[HideInInspector]
	public bool rotateFinished;

	[Token(Token = "0x4000684")]
	[FieldOffset(Offset = "0x4A")]
	public bool alphaEnabled;

	[Token(Token = "0x4000685")]
	[FieldOffset(Offset = "0x50")]
	public string labelStr;

	[Token(Token = "0x4000686")]
	[FieldOffset(Offset = "0x58")]
	public LTGUI.Element_Type type;

	[Token(Token = "0x4000687")]
	[FieldOffset(Offset = "0x60")]
	public GUIStyle style;

	[Token(Token = "0x4000688")]
	[FieldOffset(Offset = "0x68")]
	public bool useColor;

	[Token(Token = "0x4000689")]
	[FieldOffset(Offset = "0x6C")]
	public Color color;

	[Token(Token = "0x400068A")]
	[FieldOffset(Offset = "0x7C")]
	public bool fontScaleToFit;

	[Token(Token = "0x400068B")]
	[FieldOffset(Offset = "0x7D")]
	public bool useSimpleScale;

	[Token(Token = "0x400068C")]
	[FieldOffset(Offset = "0x7E")]
	public bool sizeByHeight;

	[Token(Token = "0x400068D")]
	[FieldOffset(Offset = "0x80")]
	public Texture texture;

	[Token(Token = "0x400068E")]
	[FieldOffset(Offset = "0x88")]
	private int _id;

	[Token(Token = "0x400068F")]
	[FieldOffset(Offset = "0x8C")]
	[HideInInspector]
	public int counter;

	[Token(Token = "0x4000690")]
	[FieldOffset(Offset = "0x0")]
	public static bool colorTouched;

	[Token(Token = "0x170000B3")]
	public bool hasInitiliazed
	{
		[Token(Token = "0x600096A")]
		[Address(RVA = "0x51EA00", Offset = "0x51D400", VA = "0x18051EA00")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x170000B4")]
	public int id
	{
		[Token(Token = "0x600096B")]
		[Address(RVA = "0x51EA10", Offset = "0x51D410", VA = "0x18051EA10")]
		get
		{
			return default(int);
		}
	}

	[Token(Token = "0x170000B5")]
	public float x
	{
		[Token(Token = "0x600096F")]
		[Address(RVA = "0x51EDD0", Offset = "0x51D7D0", VA = "0x18051EDD0")]
		get
		{
			return default(float);
		}
		[Token(Token = "0x6000970")]
		[Address(RVA = "0x4ADDF0", Offset = "0x4AC7F0", VA = "0x1804ADDF0")]
		set
		{
		}
	}

	[Token(Token = "0x170000B6")]
	public float y
	{
		[Token(Token = "0x6000971")]
		[Address(RVA = "0x51EDE0", Offset = "0x51D7E0", VA = "0x18051EDE0")]
		get
		{
			return default(float);
		}
		[Token(Token = "0x6000972")]
		[Address(RVA = "0x4ADDE0", Offset = "0x4AC7E0", VA = "0x1804ADDE0")]
		set
		{
		}
	}

	[Token(Token = "0x170000B7")]
	public float width
	{
		[Token(Token = "0x6000973")]
		[Address(RVA = "0x51EDF0", Offset = "0x51D7F0", VA = "0x18051EDF0")]
		get
		{
			return default(float);
		}
		[Token(Token = "0x6000974")]
		[Address(RVA = "0x4ADDD0", Offset = "0x4AC7D0", VA = "0x1804ADDD0")]
		set
		{
		}
	}

	[Token(Token = "0x170000B8")]
	public float height
	{
		[Token(Token = "0x6000975")]
		[Address(RVA = "0x51EE00", Offset = "0x51D800", VA = "0x18051EE00")]
		get
		{
			return default(float);
		}
		[Token(Token = "0x6000976")]
		[Address(RVA = "0x4ADE00", Offset = "0x4AC800", VA = "0x1804ADE00")]
		set
		{
		}
	}

	[Token(Token = "0x170000B9")]
	public Rect rect
	{
		[Token(Token = "0x6000977")]
		[Address(RVA = "0x51EE10", Offset = "0x51D810", VA = "0x18051EE10")]
		get
		{
			return default(Rect);
		}
		[Token(Token = "0x6000978")]
		[Address(RVA = "0x51F440", Offset = "0x51DE40", VA = "0x18051F440")]
		set
		{
		}
	}

	[Token(Token = "0x6000965")]
	[Address(RVA = "0x51E7F0", Offset = "0x51D1F0", VA = "0x18051E7F0")]
	public LTRect()
	{
	}

	[Token(Token = "0x6000966")]
	[Address(RVA = "0x51E850", Offset = "0x51D250", VA = "0x18051E850")]
	public LTRect(Rect rect)
	{
	}

	[Token(Token = "0x6000967")]
	[Address(RVA = "0x51E890", Offset = "0x51D290", VA = "0x18051E890")]
	public LTRect(float x, float y, float width, float height)
	{
	}

	[Token(Token = "0x6000968")]
	[Address(RVA = "0x51E900", Offset = "0x51D300", VA = "0x18051E900")]
	public LTRect(float x, float y, float width, float height, float alpha)
	{
	}

	[Token(Token = "0x6000969")]
	[Address(RVA = "0x51E970", Offset = "0x51D370", VA = "0x18051E970")]
	public LTRect(float x, float y, float width, float height, float alpha, float rotation)
	{
	}

	[Token(Token = "0x600096C")]
	[Address(RVA = "0x51EA20", Offset = "0x51D420", VA = "0x18051EA20")]
	public void setId(int id, int counter)
	{
	}

	[Token(Token = "0x600096D")]
	[Address(RVA = "0x51EA30", Offset = "0x51D430", VA = "0x18051EA30")]
	public void reset()
	{
	}

	[Token(Token = "0x600096E")]
	[Address(RVA = "0x51EAA0", Offset = "0x51D4A0", VA = "0x18051EAA0")]
	public void resetForRotation()
	{
	}

	[Token(Token = "0x6000979")]
	[Address(RVA = "0x51F450", Offset = "0x51DE50", VA = "0x18051F450")]
	public LTRect setStyle(GUIStyle style)
	{
		return null;
	}

	[Token(Token = "0x600097A")]
	[Address(RVA = "0x51F4B0", Offset = "0x51DEB0", VA = "0x18051F4B0")]
	public LTRect setFontScaleToFit(bool fontScaleToFit)
	{
		return null;
	}

	[Token(Token = "0x600097B")]
	[Address(RVA = "0x51F4C0", Offset = "0x51DEC0", VA = "0x18051F4C0")]
	public LTRect setColor(Color color)
	{
		return null;
	}

	[Token(Token = "0x600097C")]
	[Address(RVA = "0x51F4D0", Offset = "0x51DED0", VA = "0x18051F4D0")]
	public LTRect setAlpha(float alpha)
	{
		return null;
	}

	[Token(Token = "0x600097D")]
	[Address(RVA = "0x51F4E0", Offset = "0x51DEE0", VA = "0x18051F4E0")]
	public LTRect setLabel(string str)
	{
		return null;
	}

	[Token(Token = "0x600097E")]
	[Address(RVA = "0x51F540", Offset = "0x51DF40", VA = "0x18051F540")]
	public LTRect setUseSimpleScale(bool useSimpleScale, Rect relativeRect)
	{
		return null;
	}

	[Token(Token = "0x600097F")]
	[Address(RVA = "0x51F550", Offset = "0x51DF50", VA = "0x18051F550")]
	public LTRect setUseSimpleScale(bool useSimpleScale)
	{
		return null;
	}

	[Token(Token = "0x6000980")]
	[Address(RVA = "0x51F630", Offset = "0x51E030", VA = "0x18051F630")]
	public LTRect setSizeByHeight(bool sizeByHeight)
	{
		return null;
	}

	[Token(Token = "0x6000981")]
	[Address(RVA = "0x51F640", Offset = "0x51E040", VA = "0x18051F640", Slot = "3")]
	public override string ToString()
	{
		return null;
	}
}
