using EZCameraShake;
using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000053")]
public class GrapplingHookVisuals : NetworkBehaviour
{
	[Token(Token = "0x4000146")]
	[FieldOffset(Offset = "0xF8")]
	[Header("Audio")]
	public AudioManager audioManager;

	[Token(Token = "0x4000147")]
	[FieldOffset(Offset = "0x100")]
	public string[] grappleLaunchSFX;

	[Token(Token = "0x4000148")]
	[FieldOffset(Offset = "0x108")]
	[Header("FOV")]
	[SerializeField]
	private Camera cam;

	[Token(Token = "0x4000149")]
	[FieldOffset(Offset = "0x110")]
	[SerializeField]
	public float restingFOV;

	[Token(Token = "0x400014A")]
	[FieldOffset(Offset = "0x114")]
	[SerializeField]
	public float grapplingFOV;

	[Token(Token = "0x400014B")]
	[FieldOffset(Offset = "0x118")]
	[SerializeField]
	public float fovChangeSpeed;

	[Token(Token = "0x400014C")]
	[FieldOffset(Offset = "0x120")]
	[Header("Visual Effects")]
	public GameObject grapplingHitEffect;

	[Token(Token = "0x400014D")]
	[FieldOffset(Offset = "0x128")]
	public CameraShaker camShake;

	[Token(Token = "0x400014E")]
	[FieldOffset(Offset = "0x130")]
	[SerializeField]
	private GrapplingRope leftGrappleRope;

	[Token(Token = "0x400014F")]
	[FieldOffset(Offset = "0x138")]
	[SerializeField]
	private GrapplingRope rightGrappleRope;

	[Token(Token = "0x4000150")]
	[FieldOffset(Offset = "0x140")]
	private bool NetworkInitialize___EarlyGrapplingHookVisualsAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000151")]
	[FieldOffset(Offset = "0x141")]
	private bool NetworkInitialize__LateGrapplingHookVisualsAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000214")]
	[Address(RVA = "0x4835D0", Offset = "0x481FD0", VA = "0x1804835D0", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x6000215")]
	[Address(RVA = "0x483630", Offset = "0x482030", VA = "0x180483630")]
	private void LateUpdate()
	{
	}

	[Token(Token = "0x6000216")]
	[Address(RVA = "0x483640", Offset = "0x482040", VA = "0x180483640")]
	[Client]
	private void FOVControl()
	{
	}

	[Token(Token = "0x6000217")]
	[Address(RVA = "0x4839D0", Offset = "0x4823D0", VA = "0x1804839D0")]
	public void GrappleStartEffects(Vector3 grapplePoint, int hand)
	{
	}

	[Token(Token = "0x6000218")]
	[Address(RVA = "0x483C00", Offset = "0x482600", VA = "0x180483C00")]
	public Vector3 GetRopeBend(int hand)
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000219")]
	[Address(RVA = "0x483D00", Offset = "0x482700", VA = "0x180483D00")]
	public void GrappleFailEffects()
	{
	}

	[Token(Token = "0x600021A")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public GrapplingHookVisuals()
	{
	}

	[Token(Token = "0x600021B")]
	[Address(RVA = "0x483D80", Offset = "0x482780", VA = "0x180483D80", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x600021C")]
	[Address(RVA = "0x483DA0", Offset = "0x4827A0", VA = "0x180483DA0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600021D")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x600021E")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
