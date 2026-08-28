using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GPUInstancer;

[Token(Token = "0x2000145")]
public class SpaceshipMobileJoystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
{
	[Token(Token = "0x40007B8")]
	[FieldOffset(Offset = "0x20")]
	[HideInInspector]
	public Vector3 inputDirection;

	[Token(Token = "0x40007B9")]
	[FieldOffset(Offset = "0x30")]
	private Image joystickBase;

	[Token(Token = "0x40007BA")]
	[FieldOffset(Offset = "0x38")]
	private Image joystick;

	[Token(Token = "0x40007BB")]
	[FieldOffset(Offset = "0x40")]
	private Vector2 dragPosition;

	[Token(Token = "0x6000BEC")]
	[Address(RVA = "0x551670", Offset = "0x550070", VA = "0x180551670")]
	private void Start()
	{
	}

	[Token(Token = "0x6000BED")]
	[Address(RVA = "0x5517F0", Offset = "0x5501F0", VA = "0x1805517F0", Slot = "7")]
	public virtual void OnDrag(PointerEventData data)
	{
	}

	[Token(Token = "0x6000BEE")]
	[Address(RVA = "0x551B40", Offset = "0x550540", VA = "0x180551B40", Slot = "8")]
	public virtual void OnPointerDown(PointerEventData data)
	{
	}

	[Token(Token = "0x6000BEF")]
	[Address(RVA = "0x551B60", Offset = "0x550560", VA = "0x180551B60", Slot = "9")]
	public virtual void OnPointerUp(PointerEventData data)
	{
	}

	[Token(Token = "0x6000BF0")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public SpaceshipMobileJoystick()
	{
	}
}
