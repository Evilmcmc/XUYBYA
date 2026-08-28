using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200008D")]
public class RagdollCameraController : NetworkBehaviour
{
	[Token(Token = "0x40002E9")]
	[FieldOffset(Offset = "0xF8")]
	[Header("Player Input")]
	public GamePlayerInput playerInput;

	[Token(Token = "0x40002EA")]
	[FieldOffset(Offset = "0x0")]
	public static float sensitivity;

	[Token(Token = "0x40002EB")]
	[FieldOffset(Offset = "0x100")]
	public Transform CamTarget;

	[Token(Token = "0x40002EC")]
	[FieldOffset(Offset = "0x108")]
	public Transform root;

	[Token(Token = "0x40002ED")]
	[FieldOffset(Offset = "0x110")]
	public Transform OrientationTarget;

	[Token(Token = "0x40002EE")]
	[FieldOffset(Offset = "0x118")]
	public float positionLerpSpeed;

	[Token(Token = "0x40002EF")]
	[FieldOffset(Offset = "0x11C")]
	private float mouseX;

	[Token(Token = "0x40002F0")]
	[FieldOffset(Offset = "0x120")]
	private float mouseY;

	[Token(Token = "0x40002F1")]
	[FieldOffset(Offset = "0x124")]
	public float stomchOffset;

	[Token(Token = "0x40002F2")]
	[FieldOffset(Offset = "0x128")]
	public float MinY;

	[Token(Token = "0x40002F3")]
	[FieldOffset(Offset = "0x12C")]
	public float MaxY;

	[Token(Token = "0x40002F4")]
	[FieldOffset(Offset = "0x130")]
	public ConfigurableJoint stomachJoint;

	[Token(Token = "0x40002F5")]
	[FieldOffset(Offset = "0x138")]
	public ConfigurableJoint hipjoint;

	[Token(Token = "0x40002F6")]
	[FieldOffset(Offset = "0x140")]
	public Camera cam;

	[Token(Token = "0x40002F7")]
	[FieldOffset(Offset = "0x148")]
	public float detectRange;

	[Token(Token = "0x40002F8")]
	[FieldOffset(Offset = "0x14C")]
	public float camLag;

	[Token(Token = "0x40002F9")]
	[FieldOffset(Offset = "0x150")]
	public Transform ItemHolder;

	[Token(Token = "0x40002FA")]
	[FieldOffset(Offset = "0x158")]
	public LayerMask itemMask;

	[Token(Token = "0x40002FB")]
	[FieldOffset(Offset = "0x15C")]
	private bool NetworkInitialize___EarlyRagdollCameraControllerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40002FC")]
	[FieldOffset(Offset = "0x15D")]
	private bool NetworkInitialize__LateRagdollCameraControllerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60003EA")]
	[Address(RVA = "0x4ACA10", Offset = "0x4AB410", VA = "0x1804ACA10", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x60003EB")]
	[Address(RVA = "0x4ACE30", Offset = "0x4AB830", VA = "0x1804ACE30")]
	[Client]
	private void Update()
	{
	}

	[Token(Token = "0x60003EC")]
	[Address(RVA = "0x4ACEE0", Offset = "0x4AB8E0", VA = "0x1804ACEE0")]
	public void CamControl()
	{
	}

	[Token(Token = "0x60003ED")]
	[Address(RVA = "0x4AD490", Offset = "0x4ABE90", VA = "0x1804AD490")]
	[Client]
	public void LateUpdate()
	{
	}

	[Token(Token = "0x60003EE")]
	[Address(RVA = "0x4ADA50", Offset = "0x4AC450", VA = "0x1804ADA50")]
	public RagdollCameraController()
	{
	}

	[Token(Token = "0x60003F0")]
	[Address(RVA = "0x4ADAB0", Offset = "0x4AC4B0", VA = "0x1804ADAB0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60003F1")]
	[Address(RVA = "0x4ADAD0", Offset = "0x4AC4D0", VA = "0x1804ADAD0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60003F2")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60003F3")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
