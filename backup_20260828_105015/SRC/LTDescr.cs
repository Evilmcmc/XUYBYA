using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x200012B")]
public class LTDescr
{
	[Token(Token = "0x200012C")]
	public delegate Vector3 EaseTypeDelegate();

	[Token(Token = "0x200012D")]
	public delegate void ActionMethodDelegate();

	[Token(Token = "0x40006A2")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x10")]
	public bool toggle;

	[Token(Token = "0x40006A3")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x11")]
	public bool useEstimatedTime;

	[Token(Token = "0x40006A4")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x12")]
	public bool useFrames;

	[Token(Token = "0x40006A5")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x13")]
	public bool useManualTime;

	[Token(Token = "0x40006A6")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x14")]
	public bool usesNormalDt;

	[Token(Token = "0x40006A7")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x15")]
	public bool hasInitiliazed;

	[Token(Token = "0x40006A8")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x16")]
	public bool hasExtraOnCompletes;

	[Token(Token = "0x40006A9")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x17")]
	public bool hasPhysics;

	[Token(Token = "0x40006AA")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x18")]
	public bool onCompleteOnRepeat;

	[Token(Token = "0x40006AB")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x19")]
	public bool onCompleteOnStart;

	[Token(Token = "0x40006AC")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x1A")]
	public bool useRecursion;

	[Token(Token = "0x40006AD")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x1C")]
	public float ratioPassed;

	[Token(Token = "0x40006AE")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x20")]
	public float passed;

	[Token(Token = "0x40006AF")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x24")]
	public float delay;

	[Token(Token = "0x40006B0")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x28")]
	public float time;

	[Token(Token = "0x40006B1")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x2C")]
	public float speed;

	[Token(Token = "0x40006B2")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x30")]
	public float lastVal;

	[Token(Token = "0x40006B3")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x34")]
	private uint _id;

	[Token(Token = "0x40006B4")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x38")]
	public int loopCount;

	[Token(Token = "0x40006B5")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x3C")]
	public uint counter;

	[Token(Token = "0x40006B6")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x40")]
	public float direction;

	[Token(Token = "0x40006B7")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x44")]
	public float directionLast;

	[Token(Token = "0x40006B8")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x48")]
	public float overshoot;

	[Token(Token = "0x40006B9")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x4C")]
	public float period;

	[Token(Token = "0x40006BA")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x50")]
	public float scale;

	[Token(Token = "0x40006BB")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x54")]
	public bool destroyOnComplete;

	[Token(Token = "0x40006BC")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x58")]
	public Transform trans;

	[Token(Token = "0x40006BD")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x60")]
	internal Vector3 fromInternal;

	[Token(Token = "0x40006BE")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x6C")]
	internal Vector3 toInternal;

	[Token(Token = "0x40006BF")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x78")]
	internal Vector3 diff;

	[Token(Token = "0x40006C0")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x84")]
	internal Vector3 diffDiv2;

	[Token(Token = "0x40006C1")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x90")]
	public TweenAction type;

	[Token(Token = "0x40006C2")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x94")]
	private LeanTweenType easeType;

	[Token(Token = "0x40006C3")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x98")]
	public LeanTweenType loopType;

	[Token(Token = "0x40006C4")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x9C")]
	public bool hasUpdateCallback;

	[Token(Token = "0x40006C5")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xA0")]
	public EaseTypeDelegate easeMethod;

	[Token(Token = "0x40006C8")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xB8")]
	public SpriteRenderer spriteRen;

	[Token(Token = "0x40006C9")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xC0")]
	public RectTransform rectTransform;

	[Token(Token = "0x40006CA")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xC8")]
	public Text uiText;

	[Token(Token = "0x40006CB")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xD0")]
	public Image uiImage;

	[Token(Token = "0x40006CC")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xD8")]
	public RawImage rawImage;

	[Token(Token = "0x40006CD")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xE0")]
	public Sprite[] sprites;

	[Token(Token = "0x40006CE")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xE8")]
	public LTDescrOptional _optional;

	[Token(Token = "0x40006CF")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x0")]
	public static float val;

	[Token(Token = "0x40006D0")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x4")]
	public static float dt;

	[Token(Token = "0x40006D1")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x8")]
	public static Vector3 newVect;

	[Token(Token = "0x170000BA")]
	public Vector3 from
	{
		[Token(Token = "0x60009F8")]
		[Address(RVA = "0x527090", Offset = "0x525A90", VA = "0x180527090")]
		get
		{
			return default(Vector3);
		}
		[Token(Token = "0x60009F9")]
		[Address(RVA = "0x5270B0", Offset = "0x525AB0", VA = "0x1805270B0")]
		set
		{
		}
	}

	[Token(Token = "0x170000BB")]
	public Vector3 to
	{
		[Token(Token = "0x60009FA")]
		[Address(RVA = "0x5270C0", Offset = "0x525AC0", VA = "0x1805270C0")]
		get
		{
			return default(Vector3);
		}
		[Token(Token = "0x60009FB")]
		[Address(RVA = "0x5270E0", Offset = "0x525AE0", VA = "0x1805270E0")]
		set
		{
		}
	}

	[Token(Token = "0x170000BC")]
	public ActionMethodDelegate easeInternal
	{
		[Token(Token = "0x60009FC")]
		[Address(RVA = "0x5270F0", Offset = "0x525AF0", VA = "0x1805270F0")]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[Token(Token = "0x60009FD")]
		[Address(RVA = "0x513D20", Offset = "0x512720", VA = "0x180513D20")]
		[CompilerGenerated]
		set
		{
		}
	}

	[Token(Token = "0x170000BD")]
	public ActionMethodDelegate initInternal
	{
		[Token(Token = "0x60009FE")]
		[Address(RVA = "0x527100", Offset = "0x525B00", VA = "0x180527100")]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[Token(Token = "0x60009FF")]
		[Address(RVA = "0x527110", Offset = "0x525B10", VA = "0x180527110")]
		[CompilerGenerated]
		set
		{
		}
	}

	[Token(Token = "0x170000BE")]
	public Transform toTrans
	{
		[Token(Token = "0x6000A00")]
		[Address(RVA = "0x527170", Offset = "0x525B70", VA = "0x180527170")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x170000BF")]
	public int uniqueId
	{
		[Token(Token = "0x6000A04")]
		[Address(RVA = "0x527AE0", Offset = "0x5264E0", VA = "0x180527AE0")]
		get
		{
			return default(int);
		}
	}

	[Token(Token = "0x170000C0")]
	public int id
	{
		[Token(Token = "0x6000A05")]
		[Address(RVA = "0x527AE0", Offset = "0x5264E0", VA = "0x180527AE0")]
		get
		{
			return default(int);
		}
	}

	[Token(Token = "0x170000C1")]
	public LTDescrOptional optional
	{
		[Token(Token = "0x6000A06")]
		[Address(RVA = "0x527AF0", Offset = "0x5264F0", VA = "0x180527AF0")]
		get
		{
			return null;
		}
		[Token(Token = "0x6000A07")]
		[Address(RVA = "0x478600", Offset = "0x477000", VA = "0x180478600")]
		set
		{
		}
	}

	[Token(Token = "0x6000A01")]
	[Address(RVA = "0x527190", Offset = "0x525B90", VA = "0x180527190", Slot = "3")]
	public override string ToString()
	{
		return null;
	}

	[Token(Token = "0x6000A02")]
	[Address(RVA = "0x527840", Offset = "0x526240", VA = "0x180527840")]
	public LTDescr()
	{
	}

	[Token(Token = "0x6000A03")]
	[Address(RVA = "0x5278E0", Offset = "0x5262E0", VA = "0x1805278E0")]
	[Obsolete("Use 'LeanTween.cancel( id )' instead")]
	public LTDescr cancel(GameObject gameObject)
	{
		return null;
	}

	[Token(Token = "0x6000A08")]
	[Address(RVA = "0x527B00", Offset = "0x526500", VA = "0x180527B00")]
	public void reset()
	{
	}

	[Token(Token = "0x6000A09")]
	[Address(RVA = "0x527D50", Offset = "0x526750", VA = "0x180527D50")]
	public LTDescr setFollow()
	{
		return null;
	}

	[Token(Token = "0x6000A0A")]
	[Address(RVA = "0x527D60", Offset = "0x526760", VA = "0x180527D60")]
	public LTDescr setMoveX()
	{
		return null;
	}

	[Token(Token = "0x6000A0B")]
	[Address(RVA = "0x527ED0", Offset = "0x5268D0", VA = "0x180527ED0")]
	public LTDescr setMoveY()
	{
		return null;
	}

	[Token(Token = "0x6000A0C")]
	[Address(RVA = "0x528040", Offset = "0x526A40", VA = "0x180528040")]
	public LTDescr setMoveZ()
	{
		return null;
	}

	[Token(Token = "0x6000A0D")]
	[Address(RVA = "0x5281B0", Offset = "0x526BB0", VA = "0x1805281B0")]
	public LTDescr setMoveLocalX()
	{
		return null;
	}

	[Token(Token = "0x6000A0E")]
	[Address(RVA = "0x528320", Offset = "0x526D20", VA = "0x180528320")]
	public LTDescr setMoveLocalY()
	{
		return null;
	}

	[Token(Token = "0x6000A0F")]
	[Address(RVA = "0x528490", Offset = "0x526E90", VA = "0x180528490")]
	public LTDescr setMoveLocalZ()
	{
		return null;
	}

	[Token(Token = "0x6000A10")]
	[Address(RVA = "0x528600", Offset = "0x527000", VA = "0x180528600")]
	private void initFromInternal()
	{
	}

	[Token(Token = "0x6000A11")]
	[Address(RVA = "0x528610", Offset = "0x527010", VA = "0x180528610")]
	public LTDescr setOffset(Vector3 offset)
	{
		return null;
	}

	[Token(Token = "0x6000A12")]
	[Address(RVA = "0x528630", Offset = "0x527030", VA = "0x180528630")]
	public LTDescr setMoveCurved()
	{
		return null;
	}

	[Token(Token = "0x6000A13")]
	[Address(RVA = "0x5287A0", Offset = "0x5271A0", VA = "0x1805287A0")]
	public LTDescr setMoveCurvedLocal()
	{
		return null;
	}

	[Token(Token = "0x6000A14")]
	[Address(RVA = "0x528910", Offset = "0x527310", VA = "0x180528910")]
	public LTDescr setMoveSpline()
	{
		return null;
	}

	[Token(Token = "0x6000A15")]
	[Address(RVA = "0x528A80", Offset = "0x527480", VA = "0x180528A80")]
	public LTDescr setMoveSplineLocal()
	{
		return null;
	}

	[Token(Token = "0x6000A16")]
	[Address(RVA = "0x528BF0", Offset = "0x5275F0", VA = "0x180528BF0")]
	public LTDescr setScaleX()
	{
		return null;
	}

	[Token(Token = "0x6000A17")]
	[Address(RVA = "0x528D60", Offset = "0x527760", VA = "0x180528D60")]
	public LTDescr setScaleY()
	{
		return null;
	}

	[Token(Token = "0x6000A18")]
	[Address(RVA = "0x528ED0", Offset = "0x5278D0", VA = "0x180528ED0")]
	public LTDescr setScaleZ()
	{
		return null;
	}

	[Token(Token = "0x6000A19")]
	[Address(RVA = "0x529040", Offset = "0x527A40", VA = "0x180529040")]
	public LTDescr setRotateX()
	{
		return null;
	}

	[Token(Token = "0x6000A1A")]
	[Address(RVA = "0x5291B0", Offset = "0x527BB0", VA = "0x1805291B0")]
	public LTDescr setRotateY()
	{
		return null;
	}

	[Token(Token = "0x6000A1B")]
	[Address(RVA = "0x529320", Offset = "0x527D20", VA = "0x180529320")]
	public LTDescr setRotateZ()
	{
		return null;
	}

	[Token(Token = "0x6000A1C")]
	[Address(RVA = "0x529490", Offset = "0x527E90", VA = "0x180529490")]
	public LTDescr setRotateAround()
	{
		return null;
	}

	[Token(Token = "0x6000A1D")]
	[Address(RVA = "0x529600", Offset = "0x528000", VA = "0x180529600")]
	public LTDescr setRotateAroundLocal()
	{
		return null;
	}

	[Token(Token = "0x6000A1E")]
	[Address(RVA = "0x529770", Offset = "0x528170", VA = "0x180529770")]
	public LTDescr setAlpha()
	{
		return null;
	}

	[Token(Token = "0x6000A1F")]
	[Address(RVA = "0x5298E0", Offset = "0x5282E0", VA = "0x1805298E0")]
	public LTDescr setTextAlpha()
	{
		return null;
	}

	[Token(Token = "0x6000A20")]
	[Address(RVA = "0x529A50", Offset = "0x528450", VA = "0x180529A50")]
	public LTDescr setAlphaVertex()
	{
		return null;
	}

	[Token(Token = "0x6000A21")]
	[Address(RVA = "0x529BC0", Offset = "0x5285C0", VA = "0x180529BC0")]
	public LTDescr setColor()
	{
		return null;
	}

	[Token(Token = "0x6000A22")]
	[Address(RVA = "0x529D30", Offset = "0x528730", VA = "0x180529D30")]
	public LTDescr setCallbackColor()
	{
		return null;
	}

	[Token(Token = "0x6000A23")]
	[Address(RVA = "0x529EA0", Offset = "0x5288A0", VA = "0x180529EA0")]
	public LTDescr setTextColor()
	{
		return null;
	}

	[Token(Token = "0x6000A24")]
	[Address(RVA = "0x52A010", Offset = "0x528A10", VA = "0x18052A010")]
	public LTDescr setCanvasAlpha()
	{
		return null;
	}

	[Token(Token = "0x6000A25")]
	[Address(RVA = "0x52A180", Offset = "0x528B80", VA = "0x18052A180")]
	public LTDescr setCanvasGroupAlpha()
	{
		return null;
	}

	[Token(Token = "0x6000A26")]
	[Address(RVA = "0x52A2F0", Offset = "0x528CF0", VA = "0x18052A2F0")]
	public LTDescr setCanvasColor()
	{
		return null;
	}

	[Token(Token = "0x6000A27")]
	[Address(RVA = "0x52A460", Offset = "0x528E60", VA = "0x18052A460")]
	public LTDescr setCanvasMoveX()
	{
		return null;
	}

	[Token(Token = "0x6000A28")]
	[Address(RVA = "0x52A5D0", Offset = "0x528FD0", VA = "0x18052A5D0")]
	public LTDescr setCanvasMoveY()
	{
		return null;
	}

	[Token(Token = "0x6000A29")]
	[Address(RVA = "0x52A740", Offset = "0x529140", VA = "0x18052A740")]
	public LTDescr setCanvasMoveZ()
	{
		return null;
	}

	[Token(Token = "0x6000A2A")]
	[Address(RVA = "0x52A8B0", Offset = "0x5292B0", VA = "0x18052A8B0")]
	private void initCanvasRotateAround()
	{
	}

	[Token(Token = "0x6000A2B")]
	[Address(RVA = "0x52A980", Offset = "0x529380", VA = "0x18052A980")]
	public LTDescr setCanvasRotateAround()
	{
		return null;
	}

	[Token(Token = "0x6000A2C")]
	[Address(RVA = "0x52AAF0", Offset = "0x5294F0", VA = "0x18052AAF0")]
	public LTDescr setCanvasRotateAroundLocal()
	{
		return null;
	}

	[Token(Token = "0x6000A2D")]
	[Address(RVA = "0x52AC60", Offset = "0x529660", VA = "0x18052AC60")]
	public LTDescr setCanvasPlaySprite()
	{
		return null;
	}

	[Token(Token = "0x6000A2E")]
	[Address(RVA = "0x52ADD0", Offset = "0x5297D0", VA = "0x18052ADD0")]
	public LTDescr setCanvasMove()
	{
		return null;
	}

	[Token(Token = "0x6000A2F")]
	[Address(RVA = "0x52AF40", Offset = "0x529940", VA = "0x18052AF40")]
	public LTDescr setCanvasScale()
	{
		return null;
	}

	[Token(Token = "0x6000A30")]
	[Address(RVA = "0x52B0B0", Offset = "0x529AB0", VA = "0x18052B0B0")]
	public LTDescr setCanvasSizeDelta()
	{
		return null;
	}

	[Token(Token = "0x6000A31")]
	[Address(RVA = "0x52B220", Offset = "0x529C20", VA = "0x18052B220")]
	private void callback()
	{
	}

	[Token(Token = "0x6000A32")]
	[Address(RVA = "0x52B2B0", Offset = "0x529CB0", VA = "0x18052B2B0")]
	public LTDescr setCallback()
	{
		return null;
	}

	[Token(Token = "0x6000A33")]
	[Address(RVA = "0x52B520", Offset = "0x529F20", VA = "0x18052B520")]
	public LTDescr setValue3()
	{
		return null;
	}

	[Token(Token = "0x6000A34")]
	[Address(RVA = "0x52B790", Offset = "0x52A190", VA = "0x18052B790")]
	public LTDescr setMove()
	{
		return null;
	}

	[Token(Token = "0x6000A35")]
	[Address(RVA = "0x52B900", Offset = "0x52A300", VA = "0x18052B900")]
	public LTDescr setMoveLocal()
	{
		return null;
	}

	[Token(Token = "0x6000A36")]
	[Address(RVA = "0x52BA70", Offset = "0x52A470", VA = "0x18052BA70")]
	public LTDescr setMoveToTransform()
	{
		return null;
	}

	[Token(Token = "0x6000A37")]
	[Address(RVA = "0x52BBE0", Offset = "0x52A5E0", VA = "0x18052BBE0")]
	public LTDescr setRotate()
	{
		return null;
	}

	[Token(Token = "0x6000A38")]
	[Address(RVA = "0x52BD50", Offset = "0x52A750", VA = "0x18052BD50")]
	public LTDescr setRotateLocal()
	{
		return null;
	}

	[Token(Token = "0x6000A39")]
	[Address(RVA = "0x52BEC0", Offset = "0x52A8C0", VA = "0x18052BEC0")]
	public LTDescr setScale()
	{
		return null;
	}

	[Token(Token = "0x6000A3A")]
	[Address(RVA = "0x52C030", Offset = "0x52AA30", VA = "0x18052C030")]
	public LTDescr setGUIMove()
	{
		return null;
	}

	[Token(Token = "0x6000A3B")]
	[Address(RVA = "0x52C1A0", Offset = "0x52ABA0", VA = "0x18052C1A0")]
	public LTDescr setGUIMoveMargin()
	{
		return null;
	}

	[Token(Token = "0x6000A3C")]
	[Address(RVA = "0x52C310", Offset = "0x52AD10", VA = "0x18052C310")]
	public LTDescr setGUIScale()
	{
		return null;
	}

	[Token(Token = "0x6000A3D")]
	[Address(RVA = "0x52C480", Offset = "0x52AE80", VA = "0x18052C480")]
	public LTDescr setGUIAlpha()
	{
		return null;
	}

	[Token(Token = "0x6000A3E")]
	[Address(RVA = "0x52C5F0", Offset = "0x52AFF0", VA = "0x18052C5F0")]
	public LTDescr setGUIRotate()
	{
		return null;
	}

	[Token(Token = "0x6000A3F")]
	[Address(RVA = "0x52C760", Offset = "0x52B160", VA = "0x18052C760")]
	public LTDescr setDelayedSound()
	{
		return null;
	}

	[Token(Token = "0x6000A40")]
	[Address(RVA = "0x52C8D0", Offset = "0x52B2D0", VA = "0x18052C8D0")]
	public LTDescr setTarget(Transform trans)
	{
		return null;
	}

	[Token(Token = "0x6000A41")]
	[Address(RVA = "0x52C940", Offset = "0x52B340", VA = "0x18052C940")]
	private void init()
	{
	}

	[Token(Token = "0x6000A42")]
	[Address(RVA = "0x52CAF0", Offset = "0x52B4F0", VA = "0x18052CAF0")]
	private void initSpeed()
	{
	}

	[Token(Token = "0x6000A43")]
	[Address(RVA = "0x52CBF0", Offset = "0x52B5F0", VA = "0x18052CBF0")]
	public LTDescr updateNow()
	{
		return null;
	}

	[Token(Token = "0x6000A44")]
	[Address(RVA = "0x52CC10", Offset = "0x52B610", VA = "0x18052CC10")]
	public bool updateInternal()
	{
		return default(bool);
	}

	[Token(Token = "0x6000A45")]
	[Address(RVA = "0x52D180", Offset = "0x52BB80", VA = "0x18052D180")]
	public void callOnCompletes()
	{
	}

	[Token(Token = "0x6000A46")]
	[Address(RVA = "0x52D2B0", Offset = "0x52BCB0", VA = "0x18052D2B0")]
	public LTDescr setFromColor(Color col)
	{
		return null;
	}

	[Token(Token = "0x6000A47")]
	[Address(RVA = "0x52D320", Offset = "0x52BD20", VA = "0x18052D320")]
	private static void alphaRecursive(Transform transform, float val, bool useRecursion = true)
	{
	}

	[Token(Token = "0x6000A48")]
	[Address(RVA = "0x52D8E0", Offset = "0x52C2E0", VA = "0x18052D8E0")]
	private static void colorRecursive(Transform transform, Color toColor, bool useRecursion = true)
	{
	}

	[Token(Token = "0x6000A49")]
	[Address(RVA = "0x52DD00", Offset = "0x52C700", VA = "0x18052DD00")]
	private static void alphaRecursive(RectTransform rectTransform, float val, int recursiveLevel = 0)
	{
	}

	[Token(Token = "0x6000A4A")]
	[Address(RVA = "0x52E220", Offset = "0x52CC20", VA = "0x18052E220")]
	private static void alphaRecursiveSprite(Transform transform, float val)
	{
	}

	[Token(Token = "0x6000A4B")]
	[Address(RVA = "0x52E6A0", Offset = "0x52D0A0", VA = "0x18052E6A0")]
	private static void colorRecursiveSprite(Transform transform, Color toColor)
	{
	}

	[Token(Token = "0x6000A4C")]
	[Address(RVA = "0x52EB20", Offset = "0x52D520", VA = "0x18052EB20")]
	private static void colorRecursive(RectTransform rectTransform, Color toColor)
	{
	}

	[Token(Token = "0x6000A4D")]
	[Address(RVA = "0x52EF80", Offset = "0x52D980", VA = "0x18052EF80")]
	private static void textAlphaChildrenRecursive(Transform trans, float val, bool useRecursion = true)
	{
	}

	[Token(Token = "0x6000A4E")]
	[Address(RVA = "0x52F310", Offset = "0x52DD10", VA = "0x18052F310")]
	private static void textAlphaRecursive(Transform trans, float val, bool useRecursion = true)
	{
	}

	[Token(Token = "0x6000A4F")]
	[Address(RVA = "0x52F6B0", Offset = "0x52E0B0", VA = "0x18052F6B0")]
	private static void textColorRecursive(Transform trans, Color toColor)
	{
	}

	[Token(Token = "0x6000A50")]
	[Address(RVA = "0x52FA60", Offset = "0x52E460", VA = "0x18052FA60")]
	private static Color tweenColor(LTDescr tween, float val)
	{
		return default(Color);
	}

	[Token(Token = "0x6000A51")]
	[Address(RVA = "0x52FB30", Offset = "0x52E530", VA = "0x18052FB30")]
	public LTDescr pause()
	{
		return null;
	}

	[Token(Token = "0x6000A52")]
	[Address(RVA = "0x52FB50", Offset = "0x52E550", VA = "0x18052FB50")]
	public LTDescr resume()
	{
		return null;
	}

	[Token(Token = "0x6000A53")]
	[Address(RVA = "0x52FB60", Offset = "0x52E560", VA = "0x18052FB60")]
	public LTDescr setAxis(Vector3 axis)
	{
		return null;
	}

	[Token(Token = "0x6000A54")]
	[Address(RVA = "0x52FB90", Offset = "0x52E590", VA = "0x18052FB90")]
	public LTDescr setDelay(float delay)
	{
		return null;
	}

	[Token(Token = "0x6000A55")]
	[Address(RVA = "0x52FBA0", Offset = "0x52E5A0", VA = "0x18052FBA0")]
	public LTDescr setEase(LeanTweenType easeType)
	{
		return null;
	}

	[Token(Token = "0x6000A56")]
	[Address(RVA = "0x5317C0", Offset = "0x5301C0", VA = "0x1805317C0")]
	public LTDescr setEaseLinear()
	{
		return null;
	}

	[Token(Token = "0x6000A57")]
	[Address(RVA = "0x531890", Offset = "0x530290", VA = "0x180531890")]
	public LTDescr setEaseSpring()
	{
		return null;
	}

	[Token(Token = "0x6000A58")]
	[Address(RVA = "0x531960", Offset = "0x530360", VA = "0x180531960")]
	public LTDescr setEaseInQuad()
	{
		return null;
	}

	[Token(Token = "0x6000A59")]
	[Address(RVA = "0x531A30", Offset = "0x530430", VA = "0x180531A30")]
	public LTDescr setEaseOutQuad()
	{
		return null;
	}

	[Token(Token = "0x6000A5A")]
	[Address(RVA = "0x531B00", Offset = "0x530500", VA = "0x180531B00")]
	public LTDescr setEaseInOutQuad()
	{
		return null;
	}

	[Token(Token = "0x6000A5B")]
	[Address(RVA = "0x531BD0", Offset = "0x5305D0", VA = "0x180531BD0")]
	public LTDescr setEaseInCubic()
	{
		return null;
	}

	[Token(Token = "0x6000A5C")]
	[Address(RVA = "0x531CA0", Offset = "0x5306A0", VA = "0x180531CA0")]
	public LTDescr setEaseOutCubic()
	{
		return null;
	}

	[Token(Token = "0x6000A5D")]
	[Address(RVA = "0x531D70", Offset = "0x530770", VA = "0x180531D70")]
	public LTDescr setEaseInOutCubic()
	{
		return null;
	}

	[Token(Token = "0x6000A5E")]
	[Address(RVA = "0x531E40", Offset = "0x530840", VA = "0x180531E40")]
	public LTDescr setEaseInQuart()
	{
		return null;
	}

	[Token(Token = "0x6000A5F")]
	[Address(RVA = "0x531F10", Offset = "0x530910", VA = "0x180531F10")]
	public LTDescr setEaseOutQuart()
	{
		return null;
	}

	[Token(Token = "0x6000A60")]
	[Address(RVA = "0x531FE0", Offset = "0x5309E0", VA = "0x180531FE0")]
	public LTDescr setEaseInOutQuart()
	{
		return null;
	}

	[Token(Token = "0x6000A61")]
	[Address(RVA = "0x5320B0", Offset = "0x530AB0", VA = "0x1805320B0")]
	public LTDescr setEaseInQuint()
	{
		return null;
	}

	[Token(Token = "0x6000A62")]
	[Address(RVA = "0x532180", Offset = "0x530B80", VA = "0x180532180")]
	public LTDescr setEaseOutQuint()
	{
		return null;
	}

	[Token(Token = "0x6000A63")]
	[Address(RVA = "0x532250", Offset = "0x530C50", VA = "0x180532250")]
	public LTDescr setEaseInOutQuint()
	{
		return null;
	}

	[Token(Token = "0x6000A64")]
	[Address(RVA = "0x532320", Offset = "0x530D20", VA = "0x180532320")]
	public LTDescr setEaseInSine()
	{
		return null;
	}

	[Token(Token = "0x6000A65")]
	[Address(RVA = "0x5323F0", Offset = "0x530DF0", VA = "0x1805323F0")]
	public LTDescr setEaseOutSine()
	{
		return null;
	}

	[Token(Token = "0x6000A66")]
	[Address(RVA = "0x5324C0", Offset = "0x530EC0", VA = "0x1805324C0")]
	public LTDescr setEaseInOutSine()
	{
		return null;
	}

	[Token(Token = "0x6000A67")]
	[Address(RVA = "0x532590", Offset = "0x530F90", VA = "0x180532590")]
	public LTDescr setEaseInExpo()
	{
		return null;
	}

	[Token(Token = "0x6000A68")]
	[Address(RVA = "0x532660", Offset = "0x531060", VA = "0x180532660")]
	public LTDescr setEaseOutExpo()
	{
		return null;
	}

	[Token(Token = "0x6000A69")]
	[Address(RVA = "0x532730", Offset = "0x531130", VA = "0x180532730")]
	public LTDescr setEaseInOutExpo()
	{
		return null;
	}

	[Token(Token = "0x6000A6A")]
	[Address(RVA = "0x532800", Offset = "0x531200", VA = "0x180532800")]
	public LTDescr setEaseInCirc()
	{
		return null;
	}

	[Token(Token = "0x6000A6B")]
	[Address(RVA = "0x5328D0", Offset = "0x5312D0", VA = "0x1805328D0")]
	public LTDescr setEaseOutCirc()
	{
		return null;
	}

	[Token(Token = "0x6000A6C")]
	[Address(RVA = "0x5329A0", Offset = "0x5313A0", VA = "0x1805329A0")]
	public LTDescr setEaseInOutCirc()
	{
		return null;
	}

	[Token(Token = "0x6000A6D")]
	[Address(RVA = "0x532A70", Offset = "0x531470", VA = "0x180532A70")]
	public LTDescr setEaseInBounce()
	{
		return null;
	}

	[Token(Token = "0x6000A6E")]
	[Address(RVA = "0x532B40", Offset = "0x531540", VA = "0x180532B40")]
	public LTDescr setEaseOutBounce()
	{
		return null;
	}

	[Token(Token = "0x6000A6F")]
	[Address(RVA = "0x532C10", Offset = "0x531610", VA = "0x180532C10")]
	public LTDescr setEaseInOutBounce()
	{
		return null;
	}

	[Token(Token = "0x6000A70")]
	[Address(RVA = "0x532CE0", Offset = "0x5316E0", VA = "0x180532CE0")]
	public LTDescr setEaseInBack()
	{
		return null;
	}

	[Token(Token = "0x6000A71")]
	[Address(RVA = "0x532DB0", Offset = "0x5317B0", VA = "0x180532DB0")]
	public LTDescr setEaseOutBack()
	{
		return null;
	}

	[Token(Token = "0x6000A72")]
	[Address(RVA = "0x532E80", Offset = "0x531880", VA = "0x180532E80")]
	public LTDescr setEaseInOutBack()
	{
		return null;
	}

	[Token(Token = "0x6000A73")]
	[Address(RVA = "0x532F50", Offset = "0x531950", VA = "0x180532F50")]
	public LTDescr setEaseInElastic()
	{
		return null;
	}

	[Token(Token = "0x6000A74")]
	[Address(RVA = "0x533020", Offset = "0x531A20", VA = "0x180533020")]
	public LTDescr setEaseOutElastic()
	{
		return null;
	}

	[Token(Token = "0x6000A75")]
	[Address(RVA = "0x5330F0", Offset = "0x531AF0", VA = "0x1805330F0")]
	public LTDescr setEaseInOutElastic()
	{
		return null;
	}

	[Token(Token = "0x6000A76")]
	[Address(RVA = "0x5331C0", Offset = "0x531BC0", VA = "0x1805331C0")]
	public LTDescr setEasePunch()
	{
		return null;
	}

	[Token(Token = "0x6000A77")]
	[Address(RVA = "0x533360", Offset = "0x531D60", VA = "0x180533360")]
	public LTDescr setEaseShake()
	{
		return null;
	}

	[Token(Token = "0x6000A78")]
	[Address(RVA = "0x533500", Offset = "0x531F00", VA = "0x180533500")]
	private Vector3 tweenOnCurve()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A79")]
	[Address(RVA = "0x533770", Offset = "0x532170", VA = "0x180533770")]
	private Vector3 easeInOutQuad()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A7A")]
	[Address(RVA = "0x533890", Offset = "0x532290", VA = "0x180533890")]
	private Vector3 easeInQuad()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A7B")]
	[Address(RVA = "0x533940", Offset = "0x532340", VA = "0x180533940")]
	private Vector3 easeOutQuad()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A7C")]
	[Address(RVA = "0x533A20", Offset = "0x532420", VA = "0x180533A20")]
	private Vector3 easeLinear()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A7D")]
	[Address(RVA = "0x533AD0", Offset = "0x5324D0", VA = "0x180533AD0")]
	private Vector3 easeSpring()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A7E")]
	[Address(RVA = "0x533C40", Offset = "0x532640", VA = "0x180533C40")]
	private Vector3 easeInCubic()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A7F")]
	[Address(RVA = "0x533D00", Offset = "0x532700", VA = "0x180533D00")]
	private Vector3 easeOutCubic()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A80")]
	[Address(RVA = "0x533DE0", Offset = "0x5327E0", VA = "0x180533DE0")]
	private Vector3 easeInOutCubic()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A81")]
	[Address(RVA = "0x533F00", Offset = "0x532900", VA = "0x180533F00")]
	private Vector3 easeInQuart()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A82")]
	[Address(RVA = "0x533FC0", Offset = "0x5329C0", VA = "0x180533FC0")]
	private Vector3 easeOutQuart()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A83")]
	[Address(RVA = "0x5340B0", Offset = "0x532AB0", VA = "0x1805340B0")]
	private Vector3 easeInOutQuart()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A84")]
	[Address(RVA = "0x534250", Offset = "0x532C50", VA = "0x180534250")]
	private Vector3 easeInQuint()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A85")]
	[Address(RVA = "0x534320", Offset = "0x532D20", VA = "0x180534320")]
	private Vector3 easeOutQuint()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A86")]
	[Address(RVA = "0x534410", Offset = "0x532E10", VA = "0x180534410")]
	private Vector3 easeInOutQuint()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A87")]
	[Address(RVA = "0x534540", Offset = "0x532F40", VA = "0x180534540")]
	private Vector3 easeInSine()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A88")]
	[Address(RVA = "0x534660", Offset = "0x533060", VA = "0x180534660")]
	private Vector3 easeOutSine()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A89")]
	[Address(RVA = "0x534760", Offset = "0x533160", VA = "0x180534760")]
	private Vector3 easeInOutSine()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A8A")]
	[Address(RVA = "0x534830", Offset = "0x533230", VA = "0x180534830")]
	private Vector3 easeInExpo()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A8B")]
	[Address(RVA = "0x534900", Offset = "0x533300", VA = "0x180534900")]
	private Vector3 easeOutExpo()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A8C")]
	[Address(RVA = "0x5349D0", Offset = "0x5333D0", VA = "0x1805349D0")]
	private Vector3 easeInOutExpo()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A8D")]
	[Address(RVA = "0x534B30", Offset = "0x533530", VA = "0x180534B30")]
	private Vector3 easeInCirc()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A8E")]
	[Address(RVA = "0x534C20", Offset = "0x533620", VA = "0x180534C20")]
	private Vector3 easeOutCirc()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A8F")]
	[Address(RVA = "0x534D20", Offset = "0x533720", VA = "0x180534D20")]
	private Vector3 easeInOutCirc()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A90")]
	[Address(RVA = "0x534E90", Offset = "0x533890", VA = "0x180534E90")]
	private Vector3 easeInBounce()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A91")]
	[Address(RVA = "0x535020", Offset = "0x533A20", VA = "0x180535020")]
	private Vector3 easeOutBounce()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A92")]
	[Address(RVA = "0x535260", Offset = "0x533C60", VA = "0x180535260")]
	private Vector3 easeInOutBounce()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A93")]
	[Address(RVA = "0x5354D0", Offset = "0x533ED0", VA = "0x1805354D0")]
	private Vector3 easeInBack()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A94")]
	[Address(RVA = "0x5355C0", Offset = "0x533FC0", VA = "0x1805355C0")]
	private Vector3 easeOutBack()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A95")]
	[Address(RVA = "0x5356C0", Offset = "0x5340C0", VA = "0x1805356C0")]
	private Vector3 easeInOutBack()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A96")]
	[Address(RVA = "0x535880", Offset = "0x534280", VA = "0x180535880")]
	private Vector3 easeInElastic()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A97")]
	[Address(RVA = "0x5359D0", Offset = "0x5343D0", VA = "0x1805359D0")]
	private Vector3 easeOutElastic()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A98")]
	[Address(RVA = "0x535B20", Offset = "0x534520", VA = "0x180535B20")]
	private Vector3 easeInOutElastic()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000A99")]
	[Address(RVA = "0x535C70", Offset = "0x534670", VA = "0x180535C70")]
	public LTDescr setOvershoot(float overshoot)
	{
		return null;
	}

	[Token(Token = "0x6000A9A")]
	[Address(RVA = "0x535C80", Offset = "0x534680", VA = "0x180535C80")]
	public LTDescr setPeriod(float period)
	{
		return null;
	}

	[Token(Token = "0x6000A9B")]
	[Address(RVA = "0x535C90", Offset = "0x534690", VA = "0x180535C90")]
	public LTDescr setScale(float scale)
	{
		return null;
	}

	[Token(Token = "0x6000A9C")]
	[Address(RVA = "0x535CA0", Offset = "0x5346A0", VA = "0x180535CA0")]
	public LTDescr setEase(AnimationCurve easeCurve)
	{
		return null;
	}

	[Token(Token = "0x6000A9D")]
	[Address(RVA = "0x535DF0", Offset = "0x5347F0", VA = "0x180535DF0")]
	public LTDescr setTo(Vector3 to)
	{
		return null;
	}

	[Token(Token = "0x6000A9E")]
	[Address(RVA = "0x52C8D0", Offset = "0x52B2D0", VA = "0x18052C8D0")]
	public LTDescr setTo(Transform to)
	{
		return null;
	}

	[Token(Token = "0x6000A9F")]
	[Address(RVA = "0x535E50", Offset = "0x534850", VA = "0x180535E50")]
	public LTDescr setFrom(Vector3 from)
	{
		return null;
	}

	[Token(Token = "0x6000AA0")]
	[Address(RVA = "0x535FA0", Offset = "0x5349A0", VA = "0x180535FA0")]
	public LTDescr setFrom(float from)
	{
		return null;
	}

	[Token(Token = "0x6000AA1")]
	[Address(RVA = "0x535FD0", Offset = "0x5349D0", VA = "0x180535FD0")]
	public LTDescr setDiff(Vector3 diff)
	{
		return null;
	}

	[Token(Token = "0x6000AA2")]
	[Address(RVA = "0x535FF0", Offset = "0x5349F0", VA = "0x180535FF0")]
	public LTDescr setHasInitialized(bool has)
	{
		return null;
	}

	[Token(Token = "0x6000AA3")]
	[Address(RVA = "0x536000", Offset = "0x534A00", VA = "0x180536000")]
	public LTDescr setId(uint id, uint global_counter)
	{
		return null;
	}

	[Token(Token = "0x6000AA4")]
	[Address(RVA = "0x51F4D0", Offset = "0x51DED0", VA = "0x18051F4D0")]
	public LTDescr setPassed(float passed)
	{
		return null;
	}

	[Token(Token = "0x6000AA5")]
	[Address(RVA = "0x536010", Offset = "0x534A10", VA = "0x180536010")]
	public LTDescr setTime(float time)
	{
		return null;
	}

	[Token(Token = "0x6000AA6")]
	[Address(RVA = "0x536030", Offset = "0x534A30", VA = "0x180536030")]
	public LTDescr setSpeed(float speed)
	{
		return null;
	}

	[Token(Token = "0x6000AA7")]
	[Address(RVA = "0x536060", Offset = "0x534A60", VA = "0x180536060")]
	public LTDescr setRepeat(int repeat)
	{
		return null;
	}

	[Token(Token = "0x6000AA8")]
	[Address(RVA = "0x5360B0", Offset = "0x534AB0", VA = "0x1805360B0")]
	public LTDescr setLoopType(LeanTweenType loopType)
	{
		return null;
	}

	[Token(Token = "0x6000AA9")]
	[Address(RVA = "0x5360C0", Offset = "0x534AC0", VA = "0x1805360C0")]
	public LTDescr setUseEstimatedTime(bool useEstimatedTime)
	{
		return null;
	}

	[Token(Token = "0x6000AAA")]
	[Address(RVA = "0x5360C0", Offset = "0x534AC0", VA = "0x1805360C0")]
	public LTDescr setIgnoreTimeScale(bool useUnScaledTime)
	{
		return null;
	}

	[Token(Token = "0x6000AAB")]
	[Address(RVA = "0x5360D0", Offset = "0x534AD0", VA = "0x1805360D0")]
	public LTDescr setUseFrames(bool useFrames)
	{
		return null;
	}

	[Token(Token = "0x6000AAC")]
	[Address(RVA = "0x5360E0", Offset = "0x534AE0", VA = "0x1805360E0")]
	public LTDescr setUseManualTime(bool useManualTime)
	{
		return null;
	}

	[Token(Token = "0x6000AAD")]
	[Address(RVA = "0x5360F0", Offset = "0x534AF0", VA = "0x1805360F0")]
	public LTDescr setLoopCount(int loopCount)
	{
		return null;
	}

	[Token(Token = "0x6000AAE")]
	[Address(RVA = "0x536110", Offset = "0x534B10", VA = "0x180536110")]
	public LTDescr setLoopOnce()
	{
		return null;
	}

	[Token(Token = "0x6000AAF")]
	[Address(RVA = "0x536120", Offset = "0x534B20", VA = "0x180536120")]
	public LTDescr setLoopClamp()
	{
		return null;
	}

	[Token(Token = "0x6000AB0")]
	[Address(RVA = "0x536140", Offset = "0x534B40", VA = "0x180536140")]
	public LTDescr setLoopClamp(int loops)
	{
		return null;
	}

	[Token(Token = "0x6000AB1")]
	[Address(RVA = "0x536150", Offset = "0x534B50", VA = "0x180536150")]
	public LTDescr setLoopPingPong()
	{
		return null;
	}

	[Token(Token = "0x6000AB2")]
	[Address(RVA = "0x536170", Offset = "0x534B70", VA = "0x180536170")]
	public LTDescr setLoopPingPong(int loops)
	{
		return null;
	}

	[Token(Token = "0x6000AB3")]
	[Address(RVA = "0x536190", Offset = "0x534B90", VA = "0x180536190")]
	public LTDescr setOnComplete(Action onComplete)
	{
		return null;
	}

	[Token(Token = "0x6000AB4")]
	[Address(RVA = "0x536210", Offset = "0x534C10", VA = "0x180536210")]
	public LTDescr setOnComplete(Action<object> onComplete)
	{
		return null;
	}

	[Token(Token = "0x6000AB5")]
	[Address(RVA = "0x536290", Offset = "0x534C90", VA = "0x180536290")]
	public LTDescr setOnComplete(Action<object> onComplete, object onCompleteParam)
	{
		return null;
	}

	[Token(Token = "0x6000AB6")]
	[Address(RVA = "0x536390", Offset = "0x534D90", VA = "0x180536390")]
	public LTDescr setOnCompleteParam(object onCompleteParam)
	{
		return null;
	}

	[Token(Token = "0x6000AB7")]
	[Address(RVA = "0x536410", Offset = "0x534E10", VA = "0x180536410")]
	public LTDescr setOnUpdate(Action<float> onUpdate)
	{
		return null;
	}

	[Token(Token = "0x6000AB8")]
	[Address(RVA = "0x536490", Offset = "0x534E90", VA = "0x180536490")]
	public LTDescr setOnUpdateRatio(Action<float, float> onUpdate)
	{
		return null;
	}

	[Token(Token = "0x6000AB9")]
	[Address(RVA = "0x536510", Offset = "0x534F10", VA = "0x180536510")]
	public LTDescr setOnUpdateObject(Action<float, object> onUpdate)
	{
		return null;
	}

	[Token(Token = "0x6000ABA")]
	[Address(RVA = "0x536590", Offset = "0x534F90", VA = "0x180536590")]
	public LTDescr setOnUpdateVector2(Action<Vector2> onUpdate)
	{
		return null;
	}

	[Token(Token = "0x6000ABB")]
	[Address(RVA = "0x536610", Offset = "0x535010", VA = "0x180536610")]
	public LTDescr setOnUpdateVector3(Action<Vector3> onUpdate)
	{
		return null;
	}

	[Token(Token = "0x6000ABC")]
	[Address(RVA = "0x536690", Offset = "0x535090", VA = "0x180536690")]
	public LTDescr setOnUpdateColor(Action<Color> onUpdate)
	{
		return null;
	}

	[Token(Token = "0x6000ABD")]
	[Address(RVA = "0x536710", Offset = "0x535110", VA = "0x180536710")]
	public LTDescr setOnUpdateColor(Action<Color, object> onUpdate)
	{
		return null;
	}

	[Token(Token = "0x6000ABE")]
	[Address(RVA = "0x536690", Offset = "0x535090", VA = "0x180536690")]
	public LTDescr setOnUpdate(Action<Color> onUpdate)
	{
		return null;
	}

	[Token(Token = "0x6000ABF")]
	[Address(RVA = "0x536710", Offset = "0x535110", VA = "0x180536710")]
	public LTDescr setOnUpdate(Action<Color, object> onUpdate)
	{
		return null;
	}

	[Token(Token = "0x6000AC0")]
	[Address(RVA = "0x536790", Offset = "0x535190", VA = "0x180536790")]
	public LTDescr setOnUpdate(Action<float, object> onUpdate, [Optional] object onUpdateParam)
	{
		return null;
	}

	[Token(Token = "0x6000AC1")]
	[Address(RVA = "0x536890", Offset = "0x535290", VA = "0x180536890")]
	public LTDescr setOnUpdate(Action<Vector3, object> onUpdate, [Optional] object onUpdateParam)
	{
		return null;
	}

	[Token(Token = "0x6000AC2")]
	[Address(RVA = "0x536990", Offset = "0x535390", VA = "0x180536990")]
	public LTDescr setOnUpdate(Action<Vector2> onUpdate, [Optional] object onUpdateParam)
	{
		return null;
	}

	[Token(Token = "0x6000AC3")]
	[Address(RVA = "0x536A90", Offset = "0x535490", VA = "0x180536A90")]
	public LTDescr setOnUpdate(Action<Vector3> onUpdate, [Optional] object onUpdateParam)
	{
		return null;
	}

	[Token(Token = "0x6000AC4")]
	[Address(RVA = "0x536B90", Offset = "0x535590", VA = "0x180536B90")]
	public LTDescr setOnUpdateParam(object onUpdateParam)
	{
		return null;
	}

	[Token(Token = "0x6000AC5")]
	[Address(RVA = "0x536C00", Offset = "0x535600", VA = "0x180536C00")]
	public LTDescr setOrientToPath(bool doesOrient)
	{
		return null;
	}

	[Token(Token = "0x6000AC6")]
	[Address(RVA = "0x536CD0", Offset = "0x5356D0", VA = "0x180536CD0")]
	public LTDescr setOrientToPath2d(bool doesOrient2d)
	{
		return null;
	}

	[Token(Token = "0x6000AC7")]
	[Address(RVA = "0x536DF0", Offset = "0x5357F0", VA = "0x180536DF0")]
	public LTDescr setRect(LTRect rect)
	{
		return null;
	}

	[Token(Token = "0x6000AC8")]
	[Address(RVA = "0x536E60", Offset = "0x535860", VA = "0x180536E60")]
	public LTDescr setRect(Rect rect)
	{
		return null;
	}

	[Token(Token = "0x6000AC9")]
	[Address(RVA = "0x536F70", Offset = "0x535970", VA = "0x180536F70")]
	public LTDescr setPath(LTBezierPath path)
	{
		return null;
	}

	[Token(Token = "0x6000ACA")]
	[Address(RVA = "0x536FE0", Offset = "0x5359E0", VA = "0x180536FE0")]
	public LTDescr setPoint(Vector3 point)
	{
		return null;
	}

	[Token(Token = "0x6000ACB")]
	[Address(RVA = "0x537010", Offset = "0x535A10", VA = "0x180537010")]
	public LTDescr setDestroyOnComplete(bool doesDestroy)
	{
		return null;
	}

	[Token(Token = "0x6000ACC")]
	[Address(RVA = "0x537020", Offset = "0x535A20", VA = "0x180537020")]
	public LTDescr setAudio(object audio)
	{
		return null;
	}

	[Token(Token = "0x6000ACD")]
	[Address(RVA = "0x537090", Offset = "0x535A90", VA = "0x180537090")]
	public LTDescr setOnCompleteOnRepeat(bool isOn)
	{
		return null;
	}

	[Token(Token = "0x6000ACE")]
	[Address(RVA = "0x5370A0", Offset = "0x535AA0", VA = "0x1805370A0")]
	public LTDescr setOnCompleteOnStart(bool isOn)
	{
		return null;
	}

	[Token(Token = "0x6000ACF")]
	[Address(RVA = "0x5370B0", Offset = "0x535AB0", VA = "0x1805370B0")]
	public LTDescr setRect(RectTransform rect)
	{
		return null;
	}

	[Token(Token = "0x6000AD0")]
	[Address(RVA = "0x537110", Offset = "0x535B10", VA = "0x180537110")]
	public LTDescr setSprites(Sprite[] sprites)
	{
		return null;
	}

	[Token(Token = "0x6000AD1")]
	[Address(RVA = "0x537170", Offset = "0x535B70", VA = "0x180537170")]
	public LTDescr setFrameRate(float frameRate)
	{
		return null;
	}

	[Token(Token = "0x6000AD2")]
	[Address(RVA = "0x5371A0", Offset = "0x535BA0", VA = "0x1805371A0")]
	public LTDescr setOnStart(Action onStart)
	{
		return null;
	}

	[Token(Token = "0x6000AD3")]
	[Address(RVA = "0x537210", Offset = "0x535C10", VA = "0x180537210")]
	public LTDescr setDirection(float direction)
	{
		return null;
	}

	[Token(Token = "0x6000AD4")]
	[Address(RVA = "0x537450", Offset = "0x535E50", VA = "0x180537450")]
	public LTDescr setRecursive(bool useRecursion)
	{
		return null;
	}
}
