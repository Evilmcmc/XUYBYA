using System.Runtime.InteropServices;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using Il2CppDummyDll;
using UnityEngine;

namespace DG.Tweening;

[Token(Token = "0x2000163")]
public static class DOTweenModulePhysics
{
	[Token(Token = "0x6000CE8")]
	[Address(RVA = "0x5669C0", Offset = "0x5653C0", VA = "0x1805669C0")]
	public static TweenerCore<Vector3, Vector3, VectorOptions> DOMove(this Rigidbody target, Vector3 endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000CE9")]
	[Address(RVA = "0x566BC0", Offset = "0x5655C0", VA = "0x180566BC0")]
	public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveX(this Rigidbody target, float endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000CEA")]
	[Address(RVA = "0x566DE0", Offset = "0x5657E0", VA = "0x180566DE0")]
	public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveY(this Rigidbody target, float endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000CEB")]
	[Address(RVA = "0x567000", Offset = "0x565A00", VA = "0x180567000")]
	public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveZ(this Rigidbody target, float endValue, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000CEC")]
	[Address(RVA = "0x567220", Offset = "0x565C20", VA = "0x180567220")]
	public static TweenerCore<Quaternion, Vector3, QuaternionOptions> DORotate(this Rigidbody target, Vector3 endValue, float duration, RotateMode mode = RotateMode.Fast)
	{
		return null;
	}

	[Token(Token = "0x6000CED")]
	[Address(RVA = "0x567410", Offset = "0x565E10", VA = "0x180567410")]
	public static TweenerCore<Quaternion, Vector3, QuaternionOptions> DOLookAt(this Rigidbody target, Vector3 towards, float duration, AxisConstraint axisConstraint = AxisConstraint.None, [Optional] Vector3? up)
	{
		return null;
	}

	[Token(Token = "0x6000CEE")]
	[Address(RVA = "0x5676A0", Offset = "0x5660A0", VA = "0x1805676A0")]
	public static Sequence DOJump(this Rigidbody target, Vector3 endValue, float jumpPower, int numJumps, float duration, bool snapping = false)
	{
		return null;
	}

	[Token(Token = "0x6000CEF")]
	[Address(RVA = "0x568010", Offset = "0x566A10", VA = "0x180568010")]
	public static TweenerCore<Vector3, Path, PathOptions> DOPath(this Rigidbody target, Vector3[] path, float duration, PathType pathType = PathType.Linear, PathMode pathMode = PathMode.Full3D, int resolution = 10, [Optional] Color? gizmoColor)
	{
		return null;
	}

	[Token(Token = "0x6000CF0")]
	[Address(RVA = "0x5682D0", Offset = "0x566CD0", VA = "0x1805682D0")]
	public static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(this Rigidbody target, Vector3[] path, float duration, PathType pathType = PathType.Linear, PathMode pathMode = PathMode.Full3D, int resolution = 10, [Optional] Color? gizmoColor)
	{
		return null;
	}

	[Token(Token = "0x6000CF1")]
	[Address(RVA = "0x568600", Offset = "0x567000", VA = "0x180568600")]
	internal static TweenerCore<Vector3, Path, PathOptions> DOPath(this Rigidbody target, Path path, float duration, PathMode pathMode = PathMode.Full3D)
	{
		return null;
	}

	[Token(Token = "0x6000CF2")]
	[Address(RVA = "0x568820", Offset = "0x567220", VA = "0x180568820")]
	internal static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(this Rigidbody target, Path path, float duration, PathMode pathMode = PathMode.Full3D)
	{
		return null;
	}
}
