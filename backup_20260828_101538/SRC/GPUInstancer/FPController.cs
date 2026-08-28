using Il2CppDummyDll;
using UnityEngine;

namespace GPUInstancer;

[Token(Token = "0x200014E")]
[RequireComponent(typeof(CharacterController))]
public class FPController : MonoBehaviour
{
	[Token(Token = "0x40007F7")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	public float m_WalkSpeed;

	[Token(Token = "0x40007F8")]
	[FieldOffset(Offset = "0x24")]
	[SerializeField]
	public float m_RunSpeed;

	[Token(Token = "0x40007F9")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	public float m_JumpSpeed;

	[Token(Token = "0x40007FA")]
	[FieldOffset(Offset = "0x2C")]
	private bool m_IsWalking;

	[Token(Token = "0x40007FB")]
	[FieldOffset(Offset = "0x30")]
	private MouseLook m_MouseLook;

	[Token(Token = "0x40007FC")]
	[FieldOffset(Offset = "0x38")]
	private Camera m_Camera;

	[Token(Token = "0x40007FD")]
	[FieldOffset(Offset = "0x40")]
	private bool m_Jump;

	[Token(Token = "0x40007FE")]
	[FieldOffset(Offset = "0x44")]
	private float m_YRotation;

	[Token(Token = "0x40007FF")]
	[FieldOffset(Offset = "0x48")]
	private Vector2 m_Input;

	[Token(Token = "0x4000800")]
	[FieldOffset(Offset = "0x50")]
	private Vector3 m_MoveDir;

	[Token(Token = "0x4000801")]
	[FieldOffset(Offset = "0x60")]
	private CharacterController m_CharacterController;

	[Token(Token = "0x4000802")]
	[FieldOffset(Offset = "0x68")]
	private CollisionFlags m_CollisionFlags;

	[Token(Token = "0x4000803")]
	[FieldOffset(Offset = "0x6C")]
	private bool m_PreviouslyGrounded;

	[Token(Token = "0x4000804")]
	[FieldOffset(Offset = "0x6D")]
	private bool m_Jumping;

	[Token(Token = "0x4000805")]
	[FieldOffset(Offset = "0x70")]
	private float m_StickToGroundForce;

	[Token(Token = "0x4000806")]
	[FieldOffset(Offset = "0x74")]
	private float m_GravityMultiplier;

	[Token(Token = "0x6000C2C")]
	[Address(RVA = "0x557850", Offset = "0x556250", VA = "0x180557850")]
	private void Start()
	{
	}

	[Token(Token = "0x6000C2D")]
	[Address(RVA = "0x557B60", Offset = "0x556560", VA = "0x180557B60")]
	private void Update()
	{
	}

	[Token(Token = "0x6000C2E")]
	[Address(RVA = "0x557DA0", Offset = "0x5567A0", VA = "0x180557DA0")]
	private void FixedUpdate()
	{
	}

	[Token(Token = "0x6000C2F")]
	[Address(RVA = "0x558710", Offset = "0x557110", VA = "0x180558710")]
	private void GetInput(out float speed)
	{
	}

	[Token(Token = "0x6000C30")]
	[Address(RVA = "0x558820", Offset = "0x557220", VA = "0x180558820")]
	private void RotateView()
	{
	}

	[Token(Token = "0x6000C31")]
	[Address(RVA = "0x558880", Offset = "0x557280", VA = "0x180558880")]
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
	}

	[Token(Token = "0x6000C32")]
	[Address(RVA = "0x558B10", Offset = "0x557510", VA = "0x180558B10")]
	public FPController()
	{
	}
}
