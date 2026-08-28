using Il2CppDummyDll;
using UnityEngine;

namespace GPUInstancer;

[Token(Token = "0x200014F")]
public class MouseLook
{
	[Token(Token = "0x4000807")]
	[FieldOffset(Offset = "0x10")]
	public float XSensitivity;

	[Token(Token = "0x4000808")]
	[FieldOffset(Offset = "0x14")]
	public float YSensitivity;

	[Token(Token = "0x4000809")]
	[FieldOffset(Offset = "0x18")]
	public bool clampVerticalRotation;

	[Token(Token = "0x400080A")]
	[FieldOffset(Offset = "0x1C")]
	public float MinimumX;

	[Token(Token = "0x400080B")]
	[FieldOffset(Offset = "0x20")]
	public float MaximumX;

	[Token(Token = "0x400080C")]
	[FieldOffset(Offset = "0x24")]
	public bool smooth;

	[Token(Token = "0x400080D")]
	[FieldOffset(Offset = "0x28")]
	public float smoothTime;

	[Token(Token = "0x400080E")]
	[FieldOffset(Offset = "0x2C")]
	public bool lockCursor;

	[Token(Token = "0x400080F")]
	[FieldOffset(Offset = "0x30")]
	private Quaternion m_CharacterTargetRot;

	[Token(Token = "0x4000810")]
	[FieldOffset(Offset = "0x40")]
	private Quaternion m_CameraTargetRot;

	[Token(Token = "0x4000811")]
	[FieldOffset(Offset = "0x50")]
	private bool m_cursorIsLocked;

	[Token(Token = "0x6000C33")]
	[Address(RVA = "0x558BB0", Offset = "0x5575B0", VA = "0x180558BB0")]
	public void Init(Transform character, Transform camera)
	{
	}

	[Token(Token = "0x6000C34")]
	[Address(RVA = "0x558D20", Offset = "0x557720", VA = "0x180558D20")]
	public void LookRotation(Transform character, Transform camera)
	{
	}

	[Token(Token = "0x6000C35")]
	[Address(RVA = "0x559700", Offset = "0x558100", VA = "0x180559700")]
	public void SetCursorLock(bool value)
	{
	}

	[Token(Token = "0x6000C36")]
	[Address(RVA = "0x5597A0", Offset = "0x5581A0", VA = "0x1805597A0")]
	public void UpdateCursorLock()
	{
	}

	[Token(Token = "0x6000C37")]
	[Address(RVA = "0x5597B0", Offset = "0x5581B0", VA = "0x1805597B0")]
	private void InternalLockUpdate()
	{
	}

	[Token(Token = "0x6000C38")]
	[Address(RVA = "0x559970", Offset = "0x558370", VA = "0x180559970")]
	private Quaternion ClampRotationAroundXAxis(Quaternion q)
	{
		return default(Quaternion);
	}

	[Token(Token = "0x6000C39")]
	[Address(RVA = "0x559A30", Offset = "0x558430", VA = "0x180559A30")]
	public MouseLook()
	{
	}
}
