using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.Scripting;

namespace DG.Tweening;

[Token(Token = "0x20001B8")]
public static class DOTweenModuleUtils
{
	[Token(Token = "0x20001B9")]
	public static class Physics
	{
		[Token(Token = "0x6000E1A")]
		[Address(RVA = "0x576D50", Offset = "0x575750", VA = "0x180576D50")]
		public static void SetOrientationOnPath(PathOptions options, Tween t, Quaternion newRot, Transform trans)
		{
		}

		[Token(Token = "0x6000E1B")]
		[Address(RVA = "0x576F60", Offset = "0x575960", VA = "0x180576F60")]
		public static bool HasRigidbody2D(Component target)
		{
			return default(bool);
		}

		[Token(Token = "0x6000E1C")]
		[Address(RVA = "0x577060", Offset = "0x575A60", VA = "0x180577060")]
		[Preserve]
		public static bool HasRigidbody(Component target)
		{
			return default(bool);
		}

		[Token(Token = "0x6000E1D")]
		[Address(RVA = "0x577160", Offset = "0x575B60", VA = "0x180577160")]
		[Preserve]
		public static TweenerCore<Vector3, Path, PathOptions> CreateDOTweenPathTween(MonoBehaviour target, bool tweenRigidbody, bool isLocal, Path path, float duration, PathMode pathMode)
		{
			return null;
		}
	}

	[Token(Token = "0x40008F8")]
	[FieldOffset(Offset = "0x0")]
	private static bool _initialized;

	[Token(Token = "0x6000E18")]
	[Address(RVA = "0x576980", Offset = "0x575380", VA = "0x180576980")]
	[Preserve]
	public static void Init()
	{
	}

	[Token(Token = "0x6000E19")]
	[Address(RVA = "0x576BF0", Offset = "0x5755F0", VA = "0x180576BF0")]
	[Preserve]
	private static void Preserver()
	{
	}
}
