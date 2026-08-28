using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000054")]
public class GrapplingStateManager : MonoBehaviour
{
	[Token(Token = "0x4000152")]
	[FieldOffset(Offset = "0x20")]
	public bool leftHandGrappling;

	[Token(Token = "0x4000153")]
	[FieldOffset(Offset = "0x21")]
	public bool rightHandGrappling;

	[Token(Token = "0x600021F")]
	[Address(RVA = "0x483DC0", Offset = "0x4827C0", VA = "0x180483DC0")]
	public bool IsGrappling()
	{
		return default(bool);
	}

	[Token(Token = "0x6000220")]
	[Address(RVA = "0x483DD0", Offset = "0x4827D0", VA = "0x180483DD0")]
	public bool IsHookGrappling(int hand)
	{
		return default(bool);
	}

	[Token(Token = "0x6000221")]
	[Address(RVA = "0x483DE0", Offset = "0x4827E0", VA = "0x180483DE0")]
	public bool IsOtherHookGrappling(int hand)
	{
		return default(bool);
	}

	[Token(Token = "0x6000222")]
	[Address(RVA = "0x483DF0", Offset = "0x4827F0", VA = "0x180483DF0")]
	public void SetGrapplingState(int hand, bool value)
	{
	}

	[Token(Token = "0x6000223")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public GrapplingStateManager()
	{
	}
}
