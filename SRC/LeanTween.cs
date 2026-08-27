using System;
using System.Runtime.InteropServices;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.SceneManagement;

[Token(Token = "0x200011D")]
public class LeanTween : MonoBehaviour
{
	[Token(Token = "0x4000633")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x0")]
	public static bool throwErrors;

	[Token(Token = "0x4000634")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x4")]
	public static float tau;

	[Token(Token = "0x4000635")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x8")]
	public static float PI_DIV2;

	[Token(Token = "0x4000636")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x10")]
	private static LTSeq[] sequences;

	[Token(Token = "0x4000637")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x18")]
	private static LTDescr[] tweens;

	[Token(Token = "0x4000638")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x20")]
	private static int[] tweensFinished;

	[Token(Token = "0x4000639")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x28")]
	private static int[] tweensFinishedIds;

	[Token(Token = "0x400063A")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x30")]
	private static LTDescr tween;

	[Token(Token = "0x400063B")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x38")]
	private static int tweenMaxSearch;

	[Token(Token = "0x400063C")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x3C")]
	private static int maxTweens;

	[Token(Token = "0x400063D")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x40")]
	private static int maxSequences;

	[Token(Token = "0x400063E")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x44")]
	private static int frameRendered;

	[Token(Token = "0x400063F")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x48")]
	private static GameObject _tweenEmpty;

	[Token(Token = "0x4000640")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x50")]
	public static float dtEstimated;

	[Token(Token = "0x4000641")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x54")]
	public static float dtManual;

	[Token(Token = "0x4000642")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x58")]
	public static float dtActual;

	[Token(Token = "0x4000643")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x5C")]
	private static uint global_counter;

	[Token(Token = "0x4000644")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x60")]
	private static int i;

	[Token(Token = "0x4000645")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x64")]
	private static int j;

	[Token(Token = "0x4000646")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x68")]
	private static int finishedCnt;

	[Token(Token = "0x4000647")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x70")]
	public static AnimationCurve punch;

	[Token(Token = "0x4000648")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x78")]
	public static AnimationCurve shake;

	[Token(Token = "0x4000649")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x80")]
	private static int maxTweenReached;

	[Token(Token = "0x400064A")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x84")]
	public static int startSearch;

	[Token(Token = "0x400064B")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x88")]
	public static LTDescr d;

	[Token(Token = "0x400064C")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x90")]
	private static Action<LTEvent>[] eventListeners;

	[Token(Token = "0x400064D")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x98")]
	private static GameObject[] goListeners;

	[Token(Token = "0x400064E")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xA0")]
	private static int eventsMaxSearch;

	[Token(Token = "0x400064F")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xA4")]
	public static int EVENTS_MAX;

	[Token(Token = "0x4000650")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xA8")]
	public static int LISTENERS_MAX;

	[Token(Token = "0x4000651")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xAC")]
	private static int INIT_LISTENERS_MAX;

	[Token(Token = "0x170000AE")]
	public static int maxSearch
	{
		[Token(Token = "0x6000862")]
		[Address(RVA = "0x5006F0", Offset = "0x4FF0F0", VA = "0x1805006F0")]
		get
		{
			return default(int);
		}
	}

	[Token(Token = "0x170000AF")]
	public static int maxSimulataneousTweens
	{
		[Token(Token = "0x6000863")]
		[Address(RVA = "0x500750", Offset = "0x4FF150", VA = "0x180500750")]
		get
		{
			return default(int);
		}
	}

	[Token(Token = "0x170000B0")]
	public static int tweensRunning
	{
		[Token(Token = "0x6000864")]
		[Address(RVA = "0x5007B0", Offset = "0x4FF1B0", VA = "0x1805007B0")]
		get
		{
			return default(int);
		}
	}

	[Token(Token = "0x170000B1")]
	public static GameObject tweenEmpty
	{
		[Token(Token = "0x600088F")]
		[Address(RVA = "0x506270", Offset = "0x504C70", VA = "0x180506270")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x6000861")]
	[Address(RVA = "0x500640", Offset = "0x4FF040", VA = "0x180500640")]
	public static void init()
	{
	}

	[Token(Token = "0x6000865")]
	[Address(RVA = "0x500870", Offset = "0x4FF270", VA = "0x180500870")]
	public static void init(int maxSimultaneousTweens)
	{
	}

	[Token(Token = "0x6000866")]
	[Address(RVA = "0x5008E0", Offset = "0x4FF2E0", VA = "0x1805008E0")]
	public static void init(int maxSimultaneousTweens, int maxSimultaneousSequences)
	{
	}

	[Token(Token = "0x6000867")]
	[Address(RVA = "0x5011A0", Offset = "0x4FFBA0", VA = "0x1805011A0")]
	public static void reset()
	{
	}

	[Token(Token = "0x6000868")]
	[Address(RVA = "0x5013D0", Offset = "0x4FFDD0", VA = "0x1805013D0")]
	public void Update()
	{
	}

	[Token(Token = "0x6000869")]
	[Address(RVA = "0x501420", Offset = "0x4FFE20", VA = "0x180501420")]
	private static void onLevelWasLoaded54(Scene scene, LoadSceneMode mode)
	{
	}

	[Token(Token = "0x600086A")]
	[Address(RVA = "0x5014E0", Offset = "0x4FFEE0", VA = "0x1805014E0")]
	private static void internalOnLevelWasLoaded(int lvl)
	{
	}

	[Token(Token = "0x600086B")]
	[Address(RVA = "0x501530", Offset = "0x4FFF30", VA = "0x180501530")]
	public static void update()
	{
	}

	[Token(Token = "0x600086C")]
	[Address(RVA = "0x501CD0", Offset = "0x5006D0", VA = "0x180501CD0")]
	public static void removeTween(int i, int uniqueId)
	{
	}

	[Token(Token = "0x600086D")]
	[Address(RVA = "0x501D80", Offset = "0x500780", VA = "0x180501D80")]
	public static void removeTween(int i)
	{
	}

	[Token(Token = "0x600086E")]
	[Address(RVA = "0x502300", Offset = "0x500D00", VA = "0x180502300")]
	public static Vector3[] add(Vector3[] a, Vector3 b)
	{
		return null;
	}

	[Token(Token = "0x600086F")]
	[Address(RVA = "0x502480", Offset = "0x500E80", VA = "0x180502480")]
	public static float closestRot(float from, float to)
	{
		return default(float);
	}

	[Token(Token = "0x6000870")]
	[Address(RVA = "0x502540", Offset = "0x500F40", VA = "0x180502540")]
	public static void cancelAll()
	{
	}

	[Token(Token = "0x6000871")]
	[Address(RVA = "0x502590", Offset = "0x500F90", VA = "0x180502590")]
	public static void cancelAll(bool callComplete)
	{
	}

	[Token(Token = "0x6000872")]
	[Address(RVA = "0x502810", Offset = "0x501210", VA = "0x180502810")]
	public static void cancel(GameObject gameObject)
	{
	}

	[Token(Token = "0x6000873")]
	[Address(RVA = "0x502870", Offset = "0x501270", VA = "0x180502870")]
	public static void cancel(GameObject gameObject, bool callOnComplete)
	{
	}

	[Token(Token = "0x6000874")]
	[Address(RVA = "0x502AD0", Offset = "0x5014D0", VA = "0x180502AD0")]
	public static void cancel(RectTransform rect)
	{
	}

	[Token(Token = "0x6000875")]
	[Address(RVA = "0x502B40", Offset = "0x501540", VA = "0x180502B40")]
	public static void cancel(GameObject gameObject, int uniqueId, bool callOnComplete = false)
	{
	}

	[Token(Token = "0x6000876")]
	[Address(RVA = "0x502F20", Offset = "0x501920", VA = "0x180502F20")]
	public static void cancel(LTRect ltRect, int uniqueId)
	{
	}

	[Token(Token = "0x6000877")]
	[Address(RVA = "0x503030", Offset = "0x501A30", VA = "0x180503030")]
	public static void cancel(int uniqueId)
	{
	}

	[Token(Token = "0x6000878")]
	[Address(RVA = "0x503080", Offset = "0x501A80", VA = "0x180503080")]
	public static void cancel(int uniqueId, bool callOnComplete)
	{
	}

	[Token(Token = "0x6000879")]
	[Address(RVA = "0x503340", Offset = "0x501D40", VA = "0x180503340")]
	public static LTDescr descr(int uniqueId)
	{
		return null;
	}

	[Token(Token = "0x600087A")]
	[Address(RVA = "0x5035F0", Offset = "0x501FF0", VA = "0x1805035F0")]
	public static LTDescr description(int uniqueId)
	{
		return null;
	}

	[Token(Token = "0x600087B")]
	[Address(RVA = "0x503640", Offset = "0x502040", VA = "0x180503640")]
	public static LTDescr[] descriptions([Optional] GameObject gameObject)
	{
		return null;
	}

	[Token(Token = "0x600087C")]
	[Address(RVA = "0x5039C0", Offset = "0x5023C0", VA = "0x1805039C0")]
	[Obsolete("Use 'pause( id )' instead")]
	public static void pause(GameObject gameObject, int uniqueId)
	{
	}

	[Token(Token = "0x600087D")]
	[Address(RVA = "0x503AE0", Offset = "0x5024E0", VA = "0x180503AE0")]
	public static void pause(int uniqueId)
	{
	}

	[Token(Token = "0x600087E")]
	[Address(RVA = "0x503BD0", Offset = "0x5025D0", VA = "0x180503BD0")]
	public static void pause(GameObject gameObject)
	{
	}

	[Token(Token = "0x600087F")]
	[Address(RVA = "0x503E00", Offset = "0x502800", VA = "0x180503E00")]
	public static void pauseAll()
	{
	}

	[Token(Token = "0x6000880")]
	[Address(RVA = "0x503F00", Offset = "0x502900", VA = "0x180503F00")]
	public static void resumeAll()
	{
	}

	[Token(Token = "0x6000881")]
	[Address(RVA = "0x503FD0", Offset = "0x5029D0", VA = "0x180503FD0")]
	[Obsolete("Use 'resume( id )' instead")]
	public static void resume(GameObject gameObject, int uniqueId)
	{
	}

	[Token(Token = "0x6000882")]
	[Address(RVA = "0x5040E0", Offset = "0x502AE0", VA = "0x1805040E0")]
	public static void resume(int uniqueId)
	{
	}

	[Token(Token = "0x6000883")]
	[Address(RVA = "0x5041B0", Offset = "0x502BB0", VA = "0x1805041B0")]
	public static void resume(GameObject gameObject)
	{
	}

	[Token(Token = "0x6000884")]
	[Address(RVA = "0x5043C0", Offset = "0x502DC0", VA = "0x1805043C0")]
	public static bool isPaused([Optional] GameObject gameObject)
	{
		return default(bool);
	}

	[Token(Token = "0x6000885")]
	[Address(RVA = "0x5047D0", Offset = "0x5031D0", VA = "0x1805047D0")]
	public static bool isPaused(RectTransform rect)
	{
		return default(bool);
	}

	[Token(Token = "0x6000886")]
	[Address(RVA = "0x504840", Offset = "0x503240", VA = "0x180504840")]
	public static bool isPaused(int uniqueId)
	{
		return default(bool);
	}

	[Token(Token = "0x6000887")]
	[Address(RVA = "0x5049C0", Offset = "0x5033C0", VA = "0x1805049C0")]
	public static bool isTweening([Optional] GameObject gameObject)
	{
		return default(bool);
	}

	[Token(Token = "0x6000888")]
	[Address(RVA = "0x504CF0", Offset = "0x5036F0", VA = "0x180504CF0")]
	public static bool isTweening(RectTransform rect)
	{
		return default(bool);
	}

	[Token(Token = "0x6000889")]
	[Address(RVA = "0x504D60", Offset = "0x503760", VA = "0x180504D60")]
	public static bool isTweening(int uniqueId)
	{
		return default(bool);
	}

	[Token(Token = "0x600088A")]
	[Address(RVA = "0x504E60", Offset = "0x503860", VA = "0x180504E60")]
	public static bool isTweening(LTRect ltRect)
	{
		return default(bool);
	}

	[Token(Token = "0x600088B")]
	[Address(RVA = "0x504F90", Offset = "0x503990", VA = "0x180504F90")]
	public static void drawBezierPath(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float arrowSize = 0f, [Optional] Transform arrowTransform)
	{
	}

	[Token(Token = "0x600088C")]
	[Address(RVA = "0x505D00", Offset = "0x504700", VA = "0x180505D00")]
	public static object logError(string error)
	{
		return null;
	}

	[Token(Token = "0x600088D")]
	[Address(RVA = "0x505DB0", Offset = "0x5047B0", VA = "0x180505DB0")]
	public static LTDescr options(LTDescr seed)
	{
		return null;
	}

	[Token(Token = "0x600088E")]
	[Address(RVA = "0x505E10", Offset = "0x504810", VA = "0x180505E10")]
	public static LTDescr options()
	{
		return null;
	}

	[Token(Token = "0x6000890")]
	[Address(RVA = "0x506330", Offset = "0x504D30", VA = "0x180506330")]
	private static LTDescr pushNewTween(GameObject gameObject, Vector3 to, float time, LTDescr tween)
	{
		return null;
	}

	[Token(Token = "0x6000891")]
	[Address(RVA = "0x506540", Offset = "0x504F40", VA = "0x180506540")]
	public static LTDescr play(RectTransform rectTransform, Sprite[] sprites)
	{
		return null;
	}

	[Token(Token = "0x6000892")]
	[Address(RVA = "0x506840", Offset = "0x505240", VA = "0x180506840")]
	public static LTSeq sequence(bool initSequence = true)
	{
		return null;
	}

	[Token(Token = "0x6000893")]
	[Address(RVA = "0x506B70", Offset = "0x505570", VA = "0x180506B70")]
	public static LTDescr alpha(GameObject gameObject, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x6000894")]
	[Address(RVA = "0x506E30", Offset = "0x505830", VA = "0x180506E30")]
	public static LTDescr alpha(LTRect ltRect, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x6000895")]
	[Address(RVA = "0x5070A0", Offset = "0x505AA0", VA = "0x1805070A0")]
	public static LTDescr textAlpha(RectTransform rectTransform, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x6000896")]
	[Address(RVA = "0x507170", Offset = "0x505B70", VA = "0x180507170")]
	public static LTDescr alphaText(RectTransform rectTransform, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x6000897")]
	[Address(RVA = "0x507240", Offset = "0x505C40", VA = "0x180507240")]
	public static LTDescr alphaCanvas(CanvasGroup canvasGroup, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x6000898")]
	[Address(RVA = "0x507490", Offset = "0x505E90", VA = "0x180507490")]
	public static LTDescr alphaVertex(GameObject gameObject, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x6000899")]
	[Address(RVA = "0x5076C0", Offset = "0x5060C0", VA = "0x1805076C0")]
	public static LTDescr color(GameObject gameObject, Color to, float time)
	{
		return null;
	}

	[Token(Token = "0x600089A")]
	[Address(RVA = "0x5079B0", Offset = "0x5063B0", VA = "0x1805079B0")]
	public static LTDescr textColor(RectTransform rectTransform, Color to, float time)
	{
		return null;
	}

	[Token(Token = "0x600089B")]
	[Address(RVA = "0x507AD0", Offset = "0x5064D0", VA = "0x180507AD0")]
	public static LTDescr colorText(RectTransform rectTransform, Color to, float time)
	{
		return null;
	}

	[Token(Token = "0x600089C")]
	[Address(RVA = "0x507BF0", Offset = "0x5065F0", VA = "0x180507BF0")]
	public static LTDescr delayedCall(float delayTime, Action callback)
	{
		return null;
	}

	[Token(Token = "0x600089D")]
	[Address(RVA = "0x507D00", Offset = "0x506700", VA = "0x180507D00")]
	public static LTDescr delayedCall(float delayTime, Action<object> callback)
	{
		return null;
	}

	[Token(Token = "0x600089E")]
	[Address(RVA = "0x507E10", Offset = "0x506810", VA = "0x180507E10")]
	public static LTDescr delayedCall(GameObject gameObject, float delayTime, Action callback)
	{
		return null;
	}

	[Token(Token = "0x600089F")]
	[Address(RVA = "0x507F10", Offset = "0x506910", VA = "0x180507F10")]
	public static LTDescr delayedCall(GameObject gameObject, float delayTime, Action<object> callback)
	{
		return null;
	}

	[Token(Token = "0x60008A0")]
	[Address(RVA = "0x508010", Offset = "0x506A10", VA = "0x180508010")]
	public static LTDescr destroyAfter(LTRect rect, float delayTime)
	{
		return null;
	}

	[Token(Token = "0x60008A1")]
	[Address(RVA = "0x508120", Offset = "0x506B20", VA = "0x180508120")]
	public static LTDescr move(GameObject gameObject, Vector3 to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008A2")]
	[Address(RVA = "0x5081D0", Offset = "0x506BD0", VA = "0x1805081D0")]
	public static LTDescr move(GameObject gameObject, Vector2 to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008A3")]
	[Address(RVA = "0x508370", Offset = "0x506D70", VA = "0x180508370")]
	public static LTDescr move(GameObject gameObject, Vector3[] to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008A4")]
	[Address(RVA = "0x508650", Offset = "0x507050", VA = "0x180508650")]
	public static LTDescr move(GameObject gameObject, LTBezierPath to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008A5")]
	[Address(RVA = "0x508820", Offset = "0x507220", VA = "0x180508820")]
	public static LTDescr move(GameObject gameObject, LTSpline to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008A6")]
	[Address(RVA = "0x5089F0", Offset = "0x5073F0", VA = "0x1805089F0")]
	public static LTDescr moveSpline(GameObject gameObject, Vector3[] to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008A7")]
	[Address(RVA = "0x508C00", Offset = "0x507600", VA = "0x180508C00")]
	public static LTDescr moveSpline(GameObject gameObject, LTSpline to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008A8")]
	[Address(RVA = "0x508DD0", Offset = "0x5077D0", VA = "0x180508DD0")]
	public static LTDescr moveSplineLocal(GameObject gameObject, Vector3[] to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008A9")]
	[Address(RVA = "0x508FE0", Offset = "0x5079E0", VA = "0x180508FE0")]
	public static LTDescr move(LTRect ltRect, Vector2 to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008AA")]
	[Address(RVA = "0x509230", Offset = "0x507C30", VA = "0x180509230")]
	public static LTDescr moveMargin(LTRect ltRect, Vector2 to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008AB")]
	[Address(RVA = "0x509480", Offset = "0x507E80", VA = "0x180509480")]
	public static LTDescr moveX(GameObject gameObject, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008AC")]
	[Address(RVA = "0x5096B0", Offset = "0x5080B0", VA = "0x1805096B0")]
	public static LTDescr moveY(GameObject gameObject, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008AD")]
	[Address(RVA = "0x5098E0", Offset = "0x5082E0", VA = "0x1805098E0")]
	public static LTDescr moveZ(GameObject gameObject, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008AE")]
	[Address(RVA = "0x509B10", Offset = "0x508510", VA = "0x180509B10")]
	public static LTDescr moveLocal(GameObject gameObject, Vector3 to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008AF")]
	[Address(RVA = "0x509D20", Offset = "0x508720", VA = "0x180509D20")]
	public static LTDescr moveLocal(GameObject gameObject, Vector3[] to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008B0")]
	[Address(RVA = "0x50A000", Offset = "0x508A00", VA = "0x18050A000")]
	public static LTDescr moveLocalX(GameObject gameObject, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008B1")]
	[Address(RVA = "0x50A230", Offset = "0x508C30", VA = "0x18050A230")]
	public static LTDescr moveLocalY(GameObject gameObject, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008B2")]
	[Address(RVA = "0x50A460", Offset = "0x508E60", VA = "0x18050A460")]
	public static LTDescr moveLocalZ(GameObject gameObject, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008B3")]
	[Address(RVA = "0x50A690", Offset = "0x509090", VA = "0x18050A690")]
	public static LTDescr moveLocal(GameObject gameObject, LTBezierPath to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008B4")]
	[Address(RVA = "0x50A860", Offset = "0x509260", VA = "0x18050A860")]
	public static LTDescr moveLocal(GameObject gameObject, LTSpline to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008B5")]
	[Address(RVA = "0x50AA30", Offset = "0x509430", VA = "0x18050AA30")]
	public static LTDescr move(GameObject gameObject, Transform to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008B6")]
	[Address(RVA = "0x50ACE0", Offset = "0x5096E0", VA = "0x18050ACE0")]
	public static LTDescr rotate(GameObject gameObject, Vector3 to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008B7")]
	[Address(RVA = "0x50AEF0", Offset = "0x5098F0", VA = "0x18050AEF0")]
	public static LTDescr rotate(LTRect ltRect, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008B8")]
	[Address(RVA = "0x50B140", Offset = "0x509B40", VA = "0x18050B140")]
	public static LTDescr rotateLocal(GameObject gameObject, Vector3 to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008B9")]
	[Address(RVA = "0x50B350", Offset = "0x509D50", VA = "0x18050B350")]
	public static LTDescr rotateX(GameObject gameObject, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008BA")]
	[Address(RVA = "0x50B580", Offset = "0x509F80", VA = "0x18050B580")]
	public static LTDescr rotateY(GameObject gameObject, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008BB")]
	[Address(RVA = "0x50B7B0", Offset = "0x50A1B0", VA = "0x18050B7B0")]
	public static LTDescr rotateZ(GameObject gameObject, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008BC")]
	[Address(RVA = "0x50B9E0", Offset = "0x50A3E0", VA = "0x18050B9E0")]
	public static LTDescr rotateAround(GameObject gameObject, Vector3 axis, float add, float time)
	{
		return null;
	}

	[Token(Token = "0x60008BD")]
	[Address(RVA = "0x50BC30", Offset = "0x50A630", VA = "0x18050BC30")]
	public static LTDescr rotateAroundLocal(GameObject gameObject, Vector3 axis, float add, float time)
	{
		return null;
	}

	[Token(Token = "0x60008BE")]
	[Address(RVA = "0x50BE80", Offset = "0x50A880", VA = "0x18050BE80")]
	public static LTDescr scale(GameObject gameObject, Vector3 to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008BF")]
	[Address(RVA = "0x50C090", Offset = "0x50AA90", VA = "0x18050C090")]
	public static LTDescr scale(LTRect ltRect, Vector2 to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008C0")]
	[Address(RVA = "0x50C2E0", Offset = "0x50ACE0", VA = "0x18050C2E0")]
	public static LTDescr scaleX(GameObject gameObject, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008C1")]
	[Address(RVA = "0x50C510", Offset = "0x50AF10", VA = "0x18050C510")]
	public static LTDescr scaleY(GameObject gameObject, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008C2")]
	[Address(RVA = "0x50C740", Offset = "0x50B140", VA = "0x18050C740")]
	public static LTDescr scaleZ(GameObject gameObject, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008C3")]
	[Address(RVA = "0x50C970", Offset = "0x50B370", VA = "0x18050C970")]
	public static LTDescr value(GameObject gameObject, float from, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008C4")]
	[Address(RVA = "0x50CA70", Offset = "0x50B470", VA = "0x18050CA70")]
	public static LTDescr value(float from, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008C5")]
	[Address(RVA = "0x50CB70", Offset = "0x50B570", VA = "0x18050CB70")]
	public static LTDescr value(GameObject gameObject, Vector2 from, Vector2 to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008C6")]
	[Address(RVA = "0x50CCF0", Offset = "0x50B6F0", VA = "0x18050CCF0")]
	public static LTDescr value(GameObject gameObject, Vector3 from, Vector3 to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008C7")]
	[Address(RVA = "0x50CDD0", Offset = "0x50B7D0", VA = "0x18050CDD0")]
	public static LTDescr value(GameObject gameObject, Color from, Color to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008C8")]
	[Address(RVA = "0x50D000", Offset = "0x50BA00", VA = "0x18050D000")]
	public static LTDescr value(GameObject gameObject, Action<float> callOnUpdate, float from, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008C9")]
	[Address(RVA = "0x50D1F0", Offset = "0x50BBF0", VA = "0x18050D1F0")]
	public static LTDescr value(GameObject gameObject, Action<float, float> callOnUpdateRatio, float from, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008CA")]
	[Address(RVA = "0x50D3E0", Offset = "0x50BDE0", VA = "0x18050D3E0")]
	public static LTDescr value(GameObject gameObject, Action<Color> callOnUpdate, Color from, Color to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008CB")]
	[Address(RVA = "0x50D5D0", Offset = "0x50BFD0", VA = "0x18050D5D0")]
	public static LTDescr value(GameObject gameObject, Action<Color, object> callOnUpdate, Color from, Color to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008CC")]
	[Address(RVA = "0x50D7C0", Offset = "0x50C1C0", VA = "0x18050D7C0")]
	public static LTDescr value(GameObject gameObject, Action<Vector2> callOnUpdate, Vector2 from, Vector2 to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008CD")]
	[Address(RVA = "0x50D9E0", Offset = "0x50C3E0", VA = "0x18050D9E0")]
	public static LTDescr value(GameObject gameObject, Action<Vector3> callOnUpdate, Vector3 from, Vector3 to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008CE")]
	[Address(RVA = "0x50DBC0", Offset = "0x50C5C0", VA = "0x18050DBC0")]
	public static LTDescr value(GameObject gameObject, Action<float, object> callOnUpdate, float from, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008CF")]
	[Address(RVA = "0x50DE30", Offset = "0x50C830", VA = "0x18050DE30")]
	public static LTDescr delayedSound(AudioClip audio, Vector3 pos, float volume)
	{
		return null;
	}

	[Token(Token = "0x60008D0")]
	[Address(RVA = "0x50DFA0", Offset = "0x50C9A0", VA = "0x18050DFA0")]
	public static LTDescr delayedSound(GameObject gameObject, AudioClip audio, Vector3 pos, float volume)
	{
		return null;
	}

	[Token(Token = "0x60008D1")]
	[Address(RVA = "0x50E110", Offset = "0x50CB10", VA = "0x18050E110")]
	public static LTDescr move(RectTransform rectTrans, Vector3 to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008D2")]
	[Address(RVA = "0x50E3A0", Offset = "0x50CDA0", VA = "0x18050E3A0")]
	public static LTDescr moveX(RectTransform rectTrans, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008D3")]
	[Address(RVA = "0x50E660", Offset = "0x50D060", VA = "0x18050E660")]
	public static LTDescr moveY(RectTransform rectTrans, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008D4")]
	[Address(RVA = "0x50E920", Offset = "0x50D320", VA = "0x18050E920")]
	public static LTDescr moveZ(RectTransform rectTrans, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008D5")]
	[Address(RVA = "0x50EBE0", Offset = "0x50D5E0", VA = "0x18050EBE0")]
	public static LTDescr rotate(RectTransform rectTrans, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008D6")]
	[Address(RVA = "0x50ED80", Offset = "0x50D780", VA = "0x18050ED80")]
	public static LTDescr rotate(RectTransform rectTrans, Vector3 to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008D7")]
	[Address(RVA = "0x50EF00", Offset = "0x50D900", VA = "0x18050EF00")]
	public static LTDescr rotateAround(RectTransform rectTrans, Vector3 axis, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008D8")]
	[Address(RVA = "0x50F070", Offset = "0x50DA70", VA = "0x18050F070")]
	public static LTDescr rotateAroundLocal(RectTransform rectTrans, Vector3 axis, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008D9")]
	[Address(RVA = "0x50F350", Offset = "0x50DD50", VA = "0x18050F350")]
	public static LTDescr scale(RectTransform rectTrans, Vector3 to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008DA")]
	[Address(RVA = "0x50F5E0", Offset = "0x50DFE0", VA = "0x18050F5E0")]
	public static LTDescr size(RectTransform rectTrans, Vector2 to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008DB")]
	[Address(RVA = "0x50F8B0", Offset = "0x50E2B0", VA = "0x18050F8B0")]
	public static LTDescr alpha(RectTransform rectTrans, float to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008DC")]
	[Address(RVA = "0x50FB70", Offset = "0x50E570", VA = "0x18050FB70")]
	public static LTDescr color(RectTransform rectTrans, Color to, float time)
	{
		return null;
	}

	[Token(Token = "0x60008DD")]
	[Address(RVA = "0x50FE50", Offset = "0x50E850", VA = "0x18050FE50")]
	public static float tweenOnCurve(LTDescr tweenDescr, float ratioPassed)
	{
		return default(float);
	}

	[Token(Token = "0x60008DE")]
	[Address(RVA = "0x50FF10", Offset = "0x50E910", VA = "0x18050FF10")]
	public static Vector3 tweenOnCurveVector(LTDescr tweenDescr, float ratioPassed)
	{
		return default(Vector3);
	}

	[Token(Token = "0x60008DF")]
	[Address(RVA = "0x510160", Offset = "0x50EB60", VA = "0x180510160")]
	public static float easeOutQuadOpt(float start, float diff, float ratioPassed)
	{
		return default(float);
	}

	[Token(Token = "0x60008E0")]
	[Address(RVA = "0x510180", Offset = "0x50EB80", VA = "0x180510180")]
	public static float easeInQuadOpt(float start, float diff, float ratioPassed)
	{
		return default(float);
	}

	[Token(Token = "0x60008E1")]
	[Address(RVA = "0x510190", Offset = "0x50EB90", VA = "0x180510190")]
	public static float easeInOutQuadOpt(float start, float diff, float ratioPassed)
	{
		return default(float);
	}

	[Token(Token = "0x60008E2")]
	[Address(RVA = "0x5101F0", Offset = "0x50EBF0", VA = "0x1805101F0")]
	public static Vector3 easeInOutQuadOpt(Vector3 start, Vector3 diff, float ratioPassed)
	{
		return default(Vector3);
	}

	[Token(Token = "0x60008E3")]
	[Address(RVA = "0x478560", Offset = "0x476F60", VA = "0x180478560")]
	public static float linear(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008E4")]
	[Address(RVA = "0x510310", Offset = "0x50ED10", VA = "0x180510310")]
	public static float clerp(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008E5")]
	[Address(RVA = "0x5103C0", Offset = "0x50EDC0", VA = "0x1805103C0")]
	public static float spring(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008E6")]
	[Address(RVA = "0x5104B0", Offset = "0x50EEB0", VA = "0x1805104B0")]
	public static float easeInQuad(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008E7")]
	[Address(RVA = "0x5104D0", Offset = "0x50EED0", VA = "0x1805104D0")]
	public static float easeOutQuad(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008E8")]
	[Address(RVA = "0x510500", Offset = "0x50EF00", VA = "0x180510500")]
	public static float easeInOutQuad(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008E9")]
	[Address(RVA = "0x510570", Offset = "0x50EF70", VA = "0x180510570")]
	public static float easeInOutQuadOpt2(float start, float diffBy2, float val, float val2)
	{
		return default(float);
	}

	[Token(Token = "0x60008EA")]
	[Address(RVA = "0x5105B0", Offset = "0x50EFB0", VA = "0x1805105B0")]
	public static float easeInCubic(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008EB")]
	[Address(RVA = "0x5105D0", Offset = "0x50EFD0", VA = "0x1805105D0")]
	public static float easeOutCubic(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008EC")]
	[Address(RVA = "0x510600", Offset = "0x50F000", VA = "0x180510600")]
	public static float easeInOutCubic(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008ED")]
	[Address(RVA = "0x510660", Offset = "0x50F060", VA = "0x180510660")]
	public static float easeInQuart(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008EE")]
	[Address(RVA = "0x510680", Offset = "0x50F080", VA = "0x180510680")]
	public static float easeOutQuart(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008EF")]
	[Address(RVA = "0x5106C0", Offset = "0x50F0C0", VA = "0x1805106C0")]
	public static float easeInOutQuart(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008F0")]
	[Address(RVA = "0x510730", Offset = "0x50F130", VA = "0x180510730")]
	public static float easeInQuint(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008F1")]
	[Address(RVA = "0x510750", Offset = "0x50F150", VA = "0x180510750")]
	public static float easeOutQuint(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008F2")]
	[Address(RVA = "0x510790", Offset = "0x50F190", VA = "0x180510790")]
	public static float easeInOutQuint(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008F3")]
	[Address(RVA = "0x510800", Offset = "0x50F200", VA = "0x180510800")]
	public static float easeInSine(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008F4")]
	[Address(RVA = "0x510850", Offset = "0x50F250", VA = "0x180510850")]
	public static float easeOutSine(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008F5")]
	[Address(RVA = "0x510890", Offset = "0x50F290", VA = "0x180510890")]
	public static float easeInOutSine(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008F6")]
	[Address(RVA = "0x5108F0", Offset = "0x50F2F0", VA = "0x1805108F0")]
	public static float easeInExpo(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008F7")]
	[Address(RVA = "0x510940", Offset = "0x50F340", VA = "0x180510940")]
	public static float easeOutExpo(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008F8")]
	[Address(RVA = "0x5109A0", Offset = "0x50F3A0", VA = "0x1805109A0")]
	public static float easeInOutExpo(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008F9")]
	[Address(RVA = "0x510A30", Offset = "0x50F430", VA = "0x180510A30")]
	public static float easeInCirc(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008FA")]
	[Address(RVA = "0x510AA0", Offset = "0x50F4A0", VA = "0x180510AA0")]
	public static float easeOutCirc(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008FB")]
	[Address(RVA = "0x510B00", Offset = "0x50F500", VA = "0x180510B00")]
	public static float easeInOutCirc(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008FC")]
	[Address(RVA = "0x510BC0", Offset = "0x50F5C0", VA = "0x180510BC0")]
	public static float easeInBounce(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008FD")]
	[Address(RVA = "0x510C60", Offset = "0x50F660", VA = "0x180510C60")]
	public static float easeOutBounce(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008FE")]
	[Address(RVA = "0x510D30", Offset = "0x50F730", VA = "0x180510D30")]
	public static float easeInOutBounce(float start, float end, float val)
	{
		return default(float);
	}

	[Token(Token = "0x60008FF")]
	[Address(RVA = "0x510E20", Offset = "0x50F820", VA = "0x180510E20")]
	public static float easeInBack(float start, float end, float val, float overshoot = 1f)
	{
		return default(float);
	}

	[Token(Token = "0x6000900")]
	[Address(RVA = "0x510E60", Offset = "0x50F860", VA = "0x180510E60")]
	public static float easeOutBack(float start, float end, float val, float overshoot = 1f)
	{
		return default(float);
	}

	[Token(Token = "0x6000901")]
	[Address(RVA = "0x510EB0", Offset = "0x50F8B0", VA = "0x180510EB0")]
	public static float easeInOutBack(float start, float end, float val, float overshoot = 1f)
	{
		return default(float);
	}

	[Token(Token = "0x6000902")]
	[Address(RVA = "0x510F50", Offset = "0x50F950", VA = "0x180510F50")]
	public static float easeInElastic(float start, float end, float val, float overshoot = 1f, float period = 0.3f)
	{
		return default(float);
	}

	[Token(Token = "0x6000903")]
	[Address(RVA = "0x511070", Offset = "0x50FA70", VA = "0x180511070")]
	public static float easeOutElastic(float start, float end, float val, float overshoot = 1f, float period = 0.3f)
	{
		return default(float);
	}

	[Token(Token = "0x6000904")]
	[Address(RVA = "0x511190", Offset = "0x50FB90", VA = "0x180511190")]
	public static float easeInOutElastic(float start, float end, float val, float overshoot = 1f, float period = 0.3f)
	{
		return default(float);
	}

	[Token(Token = "0x6000905")]
	[Address(RVA = "0x511310", Offset = "0x50FD10", VA = "0x180511310")]
	public static LTDescr followDamp(Transform trans, Transform target, LeanProp prop, float smoothTime, float maxSpeed = -1f)
	{
		return null;
	}

	[Token(Token = "0x6000906")]
	[Address(RVA = "0x511780", Offset = "0x510180", VA = "0x180511780")]
	public static LTDescr followSpring(Transform trans, Transform target, LeanProp prop, float smoothTime, float maxSpeed = -1f, float friction = 2f, float accelRate = 0.5f)
	{
		return null;
	}

	[Token(Token = "0x6000907")]
	[Address(RVA = "0x511C00", Offset = "0x510600", VA = "0x180511C00")]
	public static LTDescr followBounceOut(Transform trans, Transform target, LeanProp prop, float smoothTime, float maxSpeed = -1f, float friction = 2f, float accelRate = 0.5f, float hitDamping = 0.9f)
	{
		return null;
	}

	[Token(Token = "0x6000908")]
	[Address(RVA = "0x512060", Offset = "0x510A60", VA = "0x180512060")]
	public static LTDescr followLinear(Transform trans, Transform target, LeanProp prop, float moveSpeed)
	{
		return null;
	}

	[Token(Token = "0x6000909")]
	[Address(RVA = "0x512490", Offset = "0x510E90", VA = "0x180512490")]
	public static void addListener(int eventId, Action<LTEvent> callback)
	{
	}

	[Token(Token = "0x600090A")]
	[Address(RVA = "0x512500", Offset = "0x510F00", VA = "0x180512500")]
	public static void addListener(GameObject caller, int eventId, Action<LTEvent> callback)
	{
	}

	[Token(Token = "0x600090B")]
	[Address(RVA = "0x512C40", Offset = "0x511640", VA = "0x180512C40")]
	public static bool removeListener(int eventId, Action<LTEvent> callback)
	{
		return default(bool);
	}

	[Token(Token = "0x600090C")]
	[Address(RVA = "0x512CB0", Offset = "0x5116B0", VA = "0x180512CB0")]
	public static bool removeListener(int eventId)
	{
		return default(bool);
	}

	[Token(Token = "0x600090D")]
	[Address(RVA = "0x512D50", Offset = "0x511750", VA = "0x180512D50")]
	public static bool removeListener(GameObject caller, int eventId, Action<LTEvent> callback)
	{
		return default(bool);
	}

	[Token(Token = "0x600090E")]
	[Address(RVA = "0x513090", Offset = "0x511A90", VA = "0x180513090")]
	public static void dispatchEvent(int eventId)
	{
	}

	[Token(Token = "0x600090F")]
	[Address(RVA = "0x5130E0", Offset = "0x511AE0", VA = "0x1805130E0")]
	public static void dispatchEvent(int eventId, object data)
	{
	}

	[Token(Token = "0x6000910")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public LeanTween()
	{
	}
}
