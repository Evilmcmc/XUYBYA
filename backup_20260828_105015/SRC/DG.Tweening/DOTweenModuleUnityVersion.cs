using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Il2CppDummyDll;
using UnityEngine;

namespace DG.Tweening;

[Token(Token = "0x20001A8")]
public static class DOTweenModuleUnityVersion
{
	[Token(Token = "0x6000DEA")]
	[Address(RVA = "0x573980", Offset = "0x572380", VA = "0x180573980")]
	public static Sequence DOGradientColor(this Material target, Gradient gradient, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000DEB")]
	[Address(RVA = "0x573BE0", Offset = "0x5725E0", VA = "0x180573BE0")]
	public static Sequence DOGradientColor(this Material target, Gradient gradient, string property, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000DEC")]
	[Address(RVA = "0x573E70", Offset = "0x572870", VA = "0x180573E70")]
	public static CustomYieldInstruction WaitForCompletion(this Tween t, bool returnCustomYieldInstruction)
	{
		return null;
	}

	[Token(Token = "0x6000DED")]
	[Address(RVA = "0x573F80", Offset = "0x572980", VA = "0x180573F80")]
	public static CustomYieldInstruction WaitForRewind(this Tween t, bool returnCustomYieldInstruction)
	{
		return null;
	}

	[Token(Token = "0x6000DEE")]
	[Address(RVA = "0x574090", Offset = "0x572A90", VA = "0x180574090")]
	public static CustomYieldInstruction WaitForKill(this Tween t, bool returnCustomYieldInstruction)
	{
		return null;
	}

	[Token(Token = "0x6000DEF")]
	[Address(RVA = "0x5741A0", Offset = "0x572BA0", VA = "0x1805741A0")]
	public static CustomYieldInstruction WaitForElapsedLoops(this Tween t, int elapsedLoops, bool returnCustomYieldInstruction)
	{
		return null;
	}

	[Token(Token = "0x6000DF0")]
	[Address(RVA = "0x5742D0", Offset = "0x572CD0", VA = "0x1805742D0")]
	public static CustomYieldInstruction WaitForPosition(this Tween t, float position, bool returnCustomYieldInstruction)
	{
		return null;
	}

	[Token(Token = "0x6000DF1")]
	[Address(RVA = "0x574400", Offset = "0x572E00", VA = "0x180574400")]
	public static CustomYieldInstruction WaitForStart(this Tween t, bool returnCustomYieldInstruction)
	{
		return null;
	}

	[Token(Token = "0x6000DF2")]
	[Address(RVA = "0x574510", Offset = "0x572F10", VA = "0x180574510")]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOOffset(this Material target, Vector2 endValue, int propertyID, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000DF3")]
	[Address(RVA = "0x574740", Offset = "0x573140", VA = "0x180574740")]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOTiling(this Material target, Vector2 endValue, int propertyID, float duration)
	{
		return null;
	}

	[Token(Token = "0x6000DF4")]
	[Address(RVA = "0x574970", Offset = "0x573370", VA = "0x180574970")]
	[AsyncStateMachine(typeof(_003CAsyncWaitForCompletion_003Ed__10))]
	public static Task AsyncWaitForCompletion(this Tween t)
	{
		return null;
	}

	[Token(Token = "0x6000DF5")]
	[Address(RVA = "0x574B20", Offset = "0x573520", VA = "0x180574B20")]
	[AsyncStateMachine(typeof(_003CAsyncWaitForRewind_003Ed__11))]
	public static Task AsyncWaitForRewind(this Tween t)
	{
		return null;
	}

	[Token(Token = "0x6000DF6")]
	[Address(RVA = "0x574CD0", Offset = "0x5736D0", VA = "0x180574CD0")]
	[AsyncStateMachine(typeof(_003CAsyncWaitForKill_003Ed__12))]
	public static Task AsyncWaitForKill(this Tween t)
	{
		return null;
	}

	[Token(Token = "0x6000DF7")]
	[Address(RVA = "0x574E80", Offset = "0x573880", VA = "0x180574E80")]
	[AsyncStateMachine(typeof(_003CAsyncWaitForElapsedLoops_003Ed__13))]
	public static Task AsyncWaitForElapsedLoops(this Tween t, int elapsedLoops)
	{
		return null;
	}

	[Token(Token = "0x6000DF8")]
	[Address(RVA = "0x575040", Offset = "0x573A40", VA = "0x180575040")]
	[AsyncStateMachine(typeof(_003CAsyncWaitForPosition_003Ed__14))]
	public static Task AsyncWaitForPosition(this Tween t, float position)
	{
		return null;
	}

	[Token(Token = "0x6000DF9")]
	[Address(RVA = "0x575210", Offset = "0x573C10", VA = "0x180575210")]
	[AsyncStateMachine(typeof(_003CAsyncWaitForStart_003Ed__15))]
	public static Task AsyncWaitForStart(this Tween t)
	{
		return null;
	}
}
