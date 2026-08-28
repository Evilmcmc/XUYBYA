using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.InputSystem;

[Token(Token = "0x200010B")]
public class MenuRigidbodyMover : MonoBehaviour
{
	[Token(Token = "0x400058E")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private float sphereRadius;

	[Token(Token = "0x400058F")]
	[FieldOffset(Offset = "0x24")]
	[SerializeField]
	private float maxDistance;

	[Token(Token = "0x4000590")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private float maxTravelDistance;

	[Token(Token = "0x4000591")]
	[FieldOffset(Offset = "0x2C")]
	[SerializeField]
	private LayerMask targetLayer;

	[Token(Token = "0x4000592")]
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	private float dragSpeed;

	[Token(Token = "0x4000593")]
	[FieldOffset(Offset = "0x34")]
	[SerializeField]
	private float rotationSpeed;

	[Token(Token = "0x4000594")]
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	private GameObject mainMenu;

	[Token(Token = "0x4000595")]
	[FieldOffset(Offset = "0x40")]
	[HideInInspector]
	public Rigidbody heldRigidBody;

	[Token(Token = "0x4000596")]
	[FieldOffset(Offset = "0x48")]
	private Plane dragPlane;

	[Token(Token = "0x4000597")]
	[FieldOffset(Offset = "0x58")]
	private Vector3 offset;

	[Token(Token = "0x4000598")]
	[FieldOffset(Offset = "0x64")]
	private Vector3 grabPoint;

	[Token(Token = "0x4000599")]
	[FieldOffset(Offset = "0x70")]
	private Vector2 prevMousePosition;

	[Token(Token = "0x400059A")]
	[FieldOffset(Offset = "0x78")]
	[SerializeField]
	private InputAction leftClickAction;

	[Token(Token = "0x400059B")]
	[FieldOffset(Offset = "0x80")]
	[SerializeField]
	private InputAction mousePositionAction;

	[Token(Token = "0x400059C")]
	[FieldOffset(Offset = "0x88")]
	[SerializeField]
	private float forwardsOffset;

	[Token(Token = "0x400059D")]
	[FieldOffset(Offset = "0x8C")]
	[SerializeField]
	private float maxRigidbodyDistance;

	[Token(Token = "0x600080B")]
	[Address(RVA = "0x4F9B90", Offset = "0x4F8590", VA = "0x1804F9B90")]
	private void OnEnable()
	{
	}

	[Token(Token = "0x600080C")]
	[Address(RVA = "0x4F9CF0", Offset = "0x4F86F0", VA = "0x1804F9CF0")]
	private void OnDisable()
	{
	}

	[Token(Token = "0x600080D")]
	[Address(RVA = "0x4F9E50", Offset = "0x4F8850", VA = "0x1804F9E50")]
	private void OnMouseClick(InputAction.CallbackContext context)
	{
	}

	[Token(Token = "0x600080E")]
	[Address(RVA = "0x4FA450", Offset = "0x4F8E50", VA = "0x1804FA450")]
	private void OnMouseRelease(InputAction.CallbackContext context)
	{
	}

	[Token(Token = "0x600080F")]
	[Address(RVA = "0x4FA570", Offset = "0x4F8F70", VA = "0x1804FA570")]
	private void Update()
	{
	}

	[Token(Token = "0x6000810")]
	[Address(RVA = "0x4FA650", Offset = "0x4F9050", VA = "0x1804FA650")]
	private void DragSelectedObject()
	{
	}

	[Token(Token = "0x6000811")]
	[Address(RVA = "0x4FABE0", Offset = "0x4F95E0", VA = "0x1804FABE0")]
	public MenuRigidbodyMover()
	{
	}
}
