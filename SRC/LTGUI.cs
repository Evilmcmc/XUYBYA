using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000128")]
public class LTGUI
{
	[Token(Token = "0x2000129")]
	public enum Element_Type
	{
		[Token(Token = "0x40006A0")]
		Texture,
		[Token(Token = "0x40006A1")]
		Label
	}

	[Token(Token = "0x4000693")]
	[FieldOffset(Offset = "0x0")]
	public static int RECT_LEVELS;

	[Token(Token = "0x4000694")]
	[FieldOffset(Offset = "0x4")]
	public static int RECTS_PER_LEVEL;

	[Token(Token = "0x4000695")]
	[FieldOffset(Offset = "0x8")]
	public static int BUTTONS_MAX;

	[Token(Token = "0x4000696")]
	[FieldOffset(Offset = "0x10")]
	private static LTRect[] levels;

	[Token(Token = "0x4000697")]
	[FieldOffset(Offset = "0x18")]
	private static int[] levelDepths;

	[Token(Token = "0x4000698")]
	[FieldOffset(Offset = "0x20")]
	private static Rect[] buttons;

	[Token(Token = "0x4000699")]
	[FieldOffset(Offset = "0x28")]
	private static int[] buttonLevels;

	[Token(Token = "0x400069A")]
	[FieldOffset(Offset = "0x30")]
	private static int[] buttonLastFrame;

	[Token(Token = "0x400069B")]
	[FieldOffset(Offset = "0x38")]
	private static LTRect r;

	[Token(Token = "0x400069C")]
	[FieldOffset(Offset = "0x40")]
	private static Color color;

	[Token(Token = "0x400069D")]
	[FieldOffset(Offset = "0x50")]
	private static bool isGUIEnabled;

	[Token(Token = "0x400069E")]
	[FieldOffset(Offset = "0x54")]
	private static int global_counter;

	[Token(Token = "0x6000983")]
	[Address(RVA = "0x51F940", Offset = "0x51E340", VA = "0x18051F940")]
	public static void init()
	{
	}

	[Token(Token = "0x6000984")]
	[Address(RVA = "0x51FB00", Offset = "0x51E500", VA = "0x18051FB00")]
	public static void initRectCheck()
	{
	}

	[Token(Token = "0x6000985")]
	[Address(RVA = "0x51FDC0", Offset = "0x51E7C0", VA = "0x18051FDC0")]
	public static void reset()
	{
	}

	[Token(Token = "0x6000986")]
	[Address(RVA = "0x51FFB0", Offset = "0x51E9B0", VA = "0x18051FFB0")]
	public static void update(int updateLevel)
	{
	}

	[Token(Token = "0x6000987")]
	[Address(RVA = "0x520D80", Offset = "0x51F780", VA = "0x180520D80")]
	public static bool checkOnScreen(Rect rect)
	{
		return default(bool);
	}

	[Token(Token = "0x6000988")]
	[Address(RVA = "0x520EA0", Offset = "0x51F8A0", VA = "0x180520EA0")]
	public static void destroy(int id)
	{
	}

	[Token(Token = "0x6000989")]
	[Address(RVA = "0x521000", Offset = "0x51FA00", VA = "0x180521000")]
	public static void destroyAll(int depth)
	{
	}

	[Token(Token = "0x600098A")]
	[Address(RVA = "0x521160", Offset = "0x51FB60", VA = "0x180521160")]
	public static LTRect label(Rect rect, string label, int depth)
	{
		return null;
	}

	[Token(Token = "0x600098B")]
	[Address(RVA = "0x5212C0", Offset = "0x51FCC0", VA = "0x1805212C0")]
	public static LTRect label(LTRect rect, string label, int depth)
	{
		return null;
	}

	[Token(Token = "0x600098C")]
	[Address(RVA = "0x521390", Offset = "0x51FD90", VA = "0x180521390")]
	public static LTRect texture(Rect rect, Texture texture, int depth)
	{
		return null;
	}

	[Token(Token = "0x600098D")]
	[Address(RVA = "0x521500", Offset = "0x51FF00", VA = "0x180521500")]
	public static LTRect texture(LTRect rect, Texture texture, int depth)
	{
		return null;
	}

	[Token(Token = "0x600098E")]
	[Address(RVA = "0x5215E0", Offset = "0x51FFE0", VA = "0x1805215E0")]
	public static LTRect element(LTRect rect, int depth)
	{
		return null;
	}

	[Token(Token = "0x600098F")]
	[Address(RVA = "0x521B40", Offset = "0x520540", VA = "0x180521B40")]
	public static bool hasNoOverlap(Rect rect, int depth)
	{
		return default(bool);
	}

	[Token(Token = "0x6000990")]
	[Address(RVA = "0x521E90", Offset = "0x520890", VA = "0x180521E90")]
	public static bool pressedWithinRect(Rect rect)
	{
		return default(bool);
	}

	[Token(Token = "0x6000991")]
	[Address(RVA = "0x521F80", Offset = "0x520980", VA = "0x180521F80")]
	public static bool checkWithinRect(Vector2 vec2, Rect rect)
	{
		return default(bool);
	}

	[Token(Token = "0x6000992")]
	[Address(RVA = "0x522020", Offset = "0x520A20", VA = "0x180522020")]
	public static Vector2 firstTouch()
	{
		return default(Vector2);
	}

	[Token(Token = "0x6000993")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public LTGUI()
	{
	}
}
