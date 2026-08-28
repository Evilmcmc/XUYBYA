using System.Globalization;
using System.Runtime.InteropServices;
using DG.Tweening.Core;
using DG.Tweening.Plugins;
using DG.Tweening.Plugins.Options;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.UI;

namespace DG.Tweening;

[Token(Token = "0x200017D")]
public static class DOTweenModuleUI
{
	[Token(Token = "0x200017E")]
	public static class Utils
	{
		[Token(Token = "0x6000D6A")]
		[Address(RVA = "0x572580", Offset = "0x570F80", VA = "0x180572580")]
		public static Vector2 SwitchToRectTransform(RectTransform from, RectTransform to)
		{
			return default(Vector2);
		}
	}

	[Token(Token = "0x6000D40")]
	[Address(RVA = "0x56C4A0", Offset = "0x56AEA0", VA = "0x18056C4A0")]
	public static TweenerCore<float, float, FloatOptions> DOFade(this CanvasGroup target, float endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D41")]
	[Address(RVA = "0x56C660", Offset = "0x56B060", VA = "0x18056C660")]
	public static TweenerCore<Color, Color, ColorOptions> DOColor(this Graphic target, Color endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D42")]
	[Address(RVA = "0x56C860", Offset = "0x56B260", VA = "0x18056C860")]
	public static TweenerCore<Color, Color, ColorOptions> DOFade(this Graphic target, float endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D43")]
	[Address(RVA = "0x56CA20", Offset = "0x56B420", VA = "0x18056CA20")]
	public static TweenerCore<Color, Color, ColorOptions> DOColor(this Image target, Color endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D44")]
	[Address(RVA = "0x56CC20", Offset = "0x56B620", VA = "0x18056CC20")]
	public static TweenerCore<Color, Color, ColorOptions> DOFade(this Image target, float endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D45")]
	[Address(RVA = "0x56CDE0", Offset = "0x56B7E0", VA = "0x18056CDE0")]
	public static TweenerCore<float, float, FloatOptions> DOFillAmount(this Image target, float endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D46")]
	[Address(RVA = "0x56CFB0", Offset = "0x56B9B0", VA = "0x18056CFB0")]
	public static Sequence DOGradientColor(this Image target, Gradient gradient, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D47")]
	[Address(RVA = "0x56D220", Offset = "0x56BC20", VA = "0x18056D220")]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOFlexibleSize(this LayoutElement target, Vector2 endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D48")]
	[Address(RVA = "0x56D400", Offset = "0x56BE00", VA = "0x18056D400")]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOMinSize(this LayoutElement target, Vector2 endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D49")]
	[Address(RVA = "0x56D5E0", Offset = "0x56BFE0", VA = "0x18056D5E0")]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOPreferredSize(this LayoutElement target, Vector2 endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D4A")]
	[Address(RVA = "0x56D7C0", Offset = "0x56C1C0", VA = "0x18056D7C0")]
	public static TweenerCore<Color, Color, ColorOptions> DOColor(this Outline target, Color endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D4B")]
	[Address(RVA = "0x56D9C0", Offset = "0x56C3C0", VA = "0x18056D9C0")]
	public static TweenerCore<Color, Color, ColorOptions> DOFade(this Outline target, float endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D4C")]
	[Address(RVA = "0x56DB80", Offset = "0x56C580", VA = "0x18056DB80")]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOScale(this Outline target, Vector2 endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D4D")]
	[Address(RVA = "0x56DD40", Offset = "0x56C740", VA = "0x18056DD40")]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOAnchorPos(this RectTransform target, Vector2 endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D4E")]
	[Address(RVA = "0x56DF20", Offset = "0x56C920", VA = "0x18056DF20")]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOAnchorPosX(this RectTransform target, float endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D4F")]
	[Address(RVA = "0x56E120", Offset = "0x56CB20", VA = "0x18056E120")]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOAnchorPosY(this RectTransform target, float endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D50")]
	[Address(RVA = "0x56E310", Offset = "0x56CD10", VA = "0x18056E310")]
	public static TweenerCore<Vector3, Vector3, VectorOptions> DOAnchorPos3D(this RectTransform target, Vector3 endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D51")]
	[Address(RVA = "0x56E4F0", Offset = "0x56CEF0", VA = "0x18056E4F0")]
	public static TweenerCore<Vector3, Vector3, VectorOptions> DOAnchorPos3DX(this RectTransform target, float endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D52")]
	[Address(RVA = "0x56E710", Offset = "0x56D110", VA = "0x18056E710")]
	public static TweenerCore<Vector3, Vector3, VectorOptions> DOAnchorPos3DY(this RectTransform target, float endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D53")]
	[Address(RVA = "0x56E930", Offset = "0x56D330", VA = "0x18056E930")]
	public static TweenerCore<Vector3, Vector3, VectorOptions> DOAnchorPos3DZ(this RectTransform target, float endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D54")]
	[Address(RVA = "0x56EB50", Offset = "0x56D550", VA = "0x18056EB50")]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOAnchorMax(this RectTransform target, Vector2 endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D55")]
	[Address(RVA = "0x56ED30", Offset = "0x56D730", VA = "0x18056ED30")]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOAnchorMin(this RectTransform target, Vector2 endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D56")]
	[Address(RVA = "0x56EF10", Offset = "0x56D910", VA = "0x18056EF10")]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOPivot(this RectTransform target, Vector2 endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D57")]
	[Address(RVA = "0x56F0D0", Offset = "0x56DAD0", VA = "0x18056F0D0")]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOPivotX(this RectTransform target, float endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D58")]
	[Address(RVA = "0x56F2D0", Offset = "0x56DCD0", VA = "0x18056F2D0")]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOPivotY(this RectTransform target, float endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D59")]
	[Address(RVA = "0x56F4B0", Offset = "0x56DEB0", VA = "0x18056F4B0")]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOSizeDelta(this RectTransform target, Vector2 endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D5A")]
	[Address(RVA = "0x56F690", Offset = "0x56E090", VA = "0x18056F690")]
	public static Tweener DOPunchAnchorPos(this RectTransform target, Vector2 punch, float duration, int vibrato = 10, float elasticity = 1f, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D5B")]
	[Address(RVA = "0x56F8C0", Offset = "0x56E2C0", VA = "0x18056F8C0")]
	public static Tweener DOShakeAnchorPos(this RectTransform target, float duration, float strength = 100f, int vibrato = 10, float randomness = 90f, bool snapping = false, bool fadeOut = true)
	{
		return null;
	}

	[Token(Token = "0x6000D5C")]
	[Address(RVA = "0x56FB40", Offset = "0x56E540", VA = "0x18056FB40")]
	public static Tweener DOShakeAnchorPos(this RectTransform target, float duration, Vector2 strength, int vibrato = 10, float randomness = 90f, bool snapping = false, bool fadeOut = true)
	{
		return null;
	}

	[Token(Token = "0x6000D5D")]
	[Address(RVA = "0x56FDD0", Offset = "0x56E7D0", VA = "0x18056FDD0")]
	public static Sequence DOJumpAnchorPos(this RectTransform target, Vector2 endValue, float jumpPower, int numJumps, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D5E")]
	[Address(RVA = "0x570590", Offset = "0x56EF90", VA = "0x180570590")]
	public static Tweener DONormalizedPos(this ScrollRect target, Vector2 endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D5F")]
	[Address(RVA = "0x570770", Offset = "0x56F170", VA = "0x180570770")]
	public static Tweener DOHorizontalNormalizedPos(this ScrollRect target, float endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D60")]
	[Address(RVA = "0x570940", Offset = "0x56F340", VA = "0x180570940")]
	public static Tweener DOVerticalNormalizedPos(this ScrollRect target, float endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D61")]
	[Address(RVA = "0x570B10", Offset = "0x56F510", VA = "0x180570B10")]
	public static TweenerCore<float, float, FloatOptions> DOValue(this Slider target, float endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D62")]
	[Address(RVA = "0x570CF0", Offset = "0x56F6F0", VA = "0x180570CF0")]
	public static TweenerCore<Color, Color, ColorOptions> DOColor(this Text target, Color endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D63")]
	[Address(RVA = "0x570EF0", Offset = "0x56F8F0", VA = "0x180570EF0")]
	public static TweenerCore<int, int, NoOptions> DOCounter(this Text target, int fromValue, int endValue, float duration, bool addThousandsSeparator = true, [Optional] CultureInfo culture)
	{
		return null;
	}

	[Token(Token = "0x6000D64")]
	[Address(RVA = "0x5713A0", Offset = "0x56FDA0", VA = "0x1805713A0")]
	public static TweenerCore<Color, Color, ColorOptions> DOFade(this Text target, float endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D65")]
	[Address(RVA = "0x571560", Offset = "0x56FF60", VA = "0x180571560")]
	public static TweenerCore<string, string, StringOptions> DOText(this Text target, string endValue, float duration, bool richTextEnabled = true, ScrambleMode scrambleMode = ScrambleMode.None, [Optional] string scrambleChars)
	{
		return null;
	}

	[Token(Token = "0x6000D66")]
	[Address(RVA = "0x571A00", Offset = "0x570400", VA = "0x180571A00")]
	public static Tweener DOBlendableColor(this Graphic target, Color endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D67")]
	[Address(RVA = "0x571CB0", Offset = "0x5706B0", VA = "0x180571CB0")]
	public static Tweener DOBlendableColor(this Image target, Color endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D68")]
	[Address(RVA = "0x571F60", Offset = "0x570960", VA = "0x180571F60")]
	public static Tweener DOBlendableColor(this Text target, Color endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D69")]
	[Address(RVA = "0x572210", Offset = "0x570C10", VA = "0x180572210")]
	public static TweenerCore<Vector2, Vector2, CircleOptions> DOShapeCircle(this RectTransform target, Vector2 center, float endValueDegrees, float duration, bool relativeCenter = false, bool snapping = false)
	{
		return null;
	}
}
