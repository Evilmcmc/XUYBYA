using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Il2CppDummyDll;
using UnityEngine;

namespace DG.Tweening;

[Token(Token = "0x2000179")]
public static class DOTweenModuleSprite
{
	[Token(Token = "0x6000D33")]
	[Address(RVA = "0x56B760", Offset = "0x56A160", VA = "0x18056B760")]
	public static TweenerCore<Color, Color, ColorOptions> DOColor(this SpriteRenderer target, Color endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D34")]
	[Address(RVA = "0x56B960", Offset = "0x56A360", VA = "0x18056B960")]
	public static TweenerCore<Color, Color, ColorOptions> DOFade(this SpriteRenderer target, float endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D35")]
	[Address(RVA = "0x56BB20", Offset = "0x56A520", VA = "0x18056BB20")]
	public static Sequence DOGradientColor(this SpriteRenderer target, Gradient gradient, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D36")]
	[Address(RVA = "0x56BE00", Offset = "0x56A800", VA = "0x18056BE00")]
	public static Tweener DOBlendableColor(this SpriteRenderer target, Color endValue, float duration)
	{
		return null;
	}
}
