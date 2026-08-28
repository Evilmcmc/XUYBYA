using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.InputSystem;

[Token(Token = "0x2000081")]
public class GamePlayerInput : NetworkBehaviour
{
	[Token(Token = "0x4000221")]
	[FieldOffset(Offset = "0xF8")]
	[HideInInspector]
	public PlayerInput playerInput;

	[Token(Token = "0x4000222")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private PlayerMovement playerMovement;

	[Token(Token = "0x4000223")]
	[FieldOffset(Offset = "0x108")]
	public GameObject playerObject;

	[Token(Token = "0x4000224")]
	[FieldOffset(Offset = "0x110")]
	public GameObject playerHUD;

	[Token(Token = "0x4000225")]
	[FieldOffset(Offset = "0x118")]
	private Weapon[] weapons;

	[Token(Token = "0x4000226")]
	[FieldOffset(Offset = "0x120")]
	private bool NetworkInitialize___EarlyGamePlayerInputAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000227")]
	[FieldOffset(Offset = "0x121")]
	private bool NetworkInitialize__LateGamePlayerInputAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x600031E")]
	[Address(RVA = "0x494370", Offset = "0x492D70", VA = "0x180494370", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x600031F")]
	[Address(RVA = "0x494C10", Offset = "0x493610", VA = "0x180494C10")]
	private void OnEnable()
	{
	}

	[Token(Token = "0x6000320")]
	[Address(RVA = "0x4954C0", Offset = "0x493EC0", VA = "0x1804954C0")]
	private void OnDisable()
	{
	}

	[Token(Token = "0x6000321")]
	[Address(RVA = "0x495BC0", Offset = "0x4945C0", VA = "0x180495BC0")]
	public void PlayerMovementOnDestroy()
	{
	}

	[Token(Token = "0x6000322")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public GamePlayerInput()
	{
	}

	[Token(Token = "0x6000323")]
	[Address(RVA = "0x47F7D0", Offset = "0x47E1D0", VA = "0x18047F7D0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000324")]
	[Address(RVA = "0x47B5F0", Offset = "0x479FF0", VA = "0x18047B5F0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000325")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000326")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
