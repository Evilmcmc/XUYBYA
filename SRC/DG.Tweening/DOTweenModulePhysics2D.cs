using System.Runtime.InteropServices;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using Il2CppDummyDll;
using UnityEngine;

namespace DG.Tweening;

[Token(Token = "0x200016F")]
public static class DOTweenModulePhysics2D
{
	[Token(Token = "0x6000D0F")]
	[Address(RVA = "0x5694F0", Offset = "0x567EF0", VA = "0x1805694F0")]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOMove(this Rigidbody2D target, Vector2 endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D10")]
	[Address(RVA = "0x5696D0", Offset = "0x5680D0", VA = "0x1805696D0")]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOMoveX(this Rigidbody2D target, float endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D11")]
	[Address(RVA = "0x5698E0", Offset = "0x5682E0", VA = "0x1805698E0")]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOMoveY(this Rigidbody2D target, float endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D12")]
	[Address(RVA = "0x569AD0", Offset = "0x5684D0", VA = "0x180569AD0")]
	public static TweenerCore<float, float, FloatOptions> DORotate(this Rigidbody2D target, float endValue, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000D13")]
	[Address(RVA = "0x569CA0", Offset = "0x5686A0", VA = "0x180569CA0")]
	public static Sequence DOJump(this Rigidbody2D target, Vector2 endValue, float jumpPower, int numJumps, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000D14")]
	[Address(RVA = "0x56A4C0", Offset = "0x568EC0", VA = "0x18056A4C0")]
	public static TweenerCore<Vector3, Path, PathOptions> DOPath(this Rigidbody2D target, Vector2[] path, float duration, PathType pathType = PathType.Linear, PathMode pathMode = PathMode.Full3D, int resolution = 10, [Optional] Color? gizmoColor)
	{
		return null;
	}

	[Token(Token = "0x6000D15")]
	[Address(RVA = "0x56A800", Offset = "0x569200", VA = "0x18056A800")]
	public static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(this Rigidbody2D target, Vector2[] path, float duration, PathType pathType = PathType.Linear, PathMode pathMode = PathMode.Full3D, int resolution = 10, [Optional] Color? gizmoColor)
	{
		return null;
	}

	[Token(Token = "0x6000D16")]
	[Address(RVA = "0x56AC50", Offset = "0x569650", VA = "0x18056AC50")]
	internal static TweenerCore<Vector3, Path, PathOptions> DOPath(this Rigidbody2D target, Path path, float duration, PathMode pathMode = PathMode.Full3D)
	{
		return null;
	}

	[Token(Token = "0x6000D17")]
	[Address(RVA = "0x56AE60", Offset = "0x569860", VA = "0x18056AE60")]
	internal static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(this Rigidbody2D target, Path path, float duration, PathMode pathMode = PathMode.Full3D)
	{
		return null;
	}
}
