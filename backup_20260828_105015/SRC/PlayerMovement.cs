using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[Token(Token = "0x200008C")]
public class PlayerMovement : NetworkBehaviour
{
	[Token(Token = "0x400029E")]
	[FieldOffset(Offset = "0xF8")]
	[Header("Player Input")]
	public GamePlayerInput playerInput;

	[Token(Token = "0x400029F")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private Transform orientation;

	[Token(Token = "0x40002A0")]
	[FieldOffset(Offset = "0x108")]
	[Header("Ground Movement")]
	[SerializeField]
	private float maxGroundSpeed;

	[Token(Token = "0x40002A1")]
	[FieldOffset(Offset = "0x10C")]
	[SerializeField]
	private float groundAcceleration;

	[Token(Token = "0x40002A2")]
	[FieldOffset(Offset = "0x110")]
	[SerializeField]
	private float maxGroundAccelForce;

	[Token(Token = "0x40002A3")]
	[FieldOffset(Offset = "0x114")]
	[Header("Air Movement")]
	[SerializeField]
	private float maxAirSpeed;

	[Token(Token = "0x40002A4")]
	[FieldOffset(Offset = "0x118")]
	[SerializeField]
	private float airAcceleration;

	[Token(Token = "0x40002A5")]
	[FieldOffset(Offset = "0x11C")]
	[SerializeField]
	private float maxAirAccelForce;

	[Token(Token = "0x40002A6")]
	[FieldOffset(Offset = "0x120")]
	[Range(0f, 1f)]
	[SerializeField]
	private float airBodyCtrl;

	[Token(Token = "0x40002A7")]
	[FieldOffset(Offset = "0x124")]
	[SerializeField]
	private float airVelocityLerpSpeed;

	[Token(Token = "0x40002A8")]
	[FieldOffset(Offset = "0x128")]
	[Header("General Movement")]
	[SerializeField]
	private AnimationCurve accelerationFactorFromDot;

	[Token(Token = "0x40002A9")]
	[FieldOffset(Offset = "0x130")]
	[SerializeField]
	private Vector3 forceScale;

	[Token(Token = "0x40002AA")]
	[FieldOffset(Offset = "0x13C")]
	[Header("Jumping")]
	[SerializeField]
	private float jumpForce;

	[Token(Token = "0x40002AB")]
	[FieldOffset(Offset = "0x140")]
	[Header("Drag")]
	public float groundDrag;

	[Token(Token = "0x40002AC")]
	[FieldOffset(Offset = "0x144")]
	public float airDrag;

	[Token(Token = "0x40002AD")]
	[FieldOffset(Offset = "0x148")]
	[HideInInspector]
	public bool isGrounded;

	[Token(Token = "0x40002AE")]
	[FieldOffset(Offset = "0x14C")]
	private Vector3 moveDirection;

	[Token(Token = "0x40002AF")]
	[FieldOffset(Offset = "0x158")]
	[Header("Networking")]
	public GameObject cameraParent;

	[Token(Token = "0x40002B0")]
	[FieldOffset(Offset = "0x160")]
	public GameObject canvas;

	[Token(Token = "0x40002B1")]
	[FieldOffset(Offset = "0x168")]
	public GameObject getGrappledPlayer;

	[Token(Token = "0x40002B2")]
	[FieldOffset(Offset = "0x170")]
	public int getGrappledForce;

	[Token(Token = "0x40002B3")]
	[FieldOffset(Offset = "0x178")]
	public GameObject root;

	[Token(Token = "0x40002B4")]
	[FieldOffset(Offset = "0x180")]
	public string playerMask;

	[Token(Token = "0x40002B5")]
	[FieldOffset(Offset = "0x188")]
	[Header("Jumping")]
	[SerializeField]
	private float jumpRayLength;

	[Token(Token = "0x40002B6")]
	[FieldOffset(Offset = "0x18C")]
	public LayerMask groundLayer;

	[Token(Token = "0x40002B7")]
	[FieldOffset(Offset = "0x190")]
	public LayerMask movingLayer;

	[Token(Token = "0x40002B8")]
	[FieldOffset(Offset = "0x194")]
	[SerializeField]
	private float cayoteTime;

	[Token(Token = "0x40002B9")]
	[FieldOffset(Offset = "0x198")]
	[SerializeField]
	private float jumpBufferTime;

	[Token(Token = "0x40002BA")]
	[FieldOffset(Offset = "0x1A0")]
	[SerializeField]
	private GameObject jumpParticle;

	[Token(Token = "0x40002BB")]
	[FieldOffset(Offset = "0x1A8")]
	[SerializeField]
	private float gravityForce;

	[Token(Token = "0x40002BC")]
	[FieldOffset(Offset = "0x1AC")]
	[SerializeField]
	private float yFallVelocity;

	[Token(Token = "0x40002BD")]
	[FieldOffset(Offset = "0x1B0")]
	[Header("Float")]
	public float rideHeight;

	[Token(Token = "0x40002BE")]
	[FieldOffset(Offset = "0x1B4")]
	[SerializeField]
	private float rideSpringStrength;

	[Token(Token = "0x40002BF")]
	[FieldOffset(Offset = "0x1B8")]
	[SerializeField]
	private float rideSpringDamper;

	[Token(Token = "0x40002C0")]
	[FieldOffset(Offset = "0x1BC")]
	[SerializeField]
	private float uprightSpringStrength;

	[Token(Token = "0x40002C1")]
	[FieldOffset(Offset = "0x1C0")]
	[SerializeField]
	private float uprightSpringDamper;

	[Token(Token = "0x40002C2")]
	[FieldOffset(Offset = "0x1C4")]
	[Header("HUD")]
	[HideInInspector]
	public bool awayTeam;

	[Token(Token = "0x40002C3")]
	[FieldOffset(Offset = "0x1C8")]
	public Renderer[] teamIndicators;

	[Token(Token = "0x40002C4")]
	[FieldOffset(Offset = "0x1D0")]
	public GameObject HUD;

	[Token(Token = "0x40002C5")]
	[FieldOffset(Offset = "0x1D8")]
	public TMP_Text HUDUsernamer;

	[Token(Token = "0x40002C6")]
	[FieldOffset(Offset = "0x1E0")]
	public TMP_Text playerUsername;

	[Token(Token = "0x40002C7")]
	[FieldOffset(Offset = "0x1E8")]
	public TMP_Text uiTeam;

	[Token(Token = "0x40002C8")]
	[FieldOffset(Offset = "0x1F0")]
	[SerializeField]
	private WeaponSpawnDirection attackChargeDir;

	[Token(Token = "0x40002C9")]
	[FieldOffset(Offset = "0x1F8")]
	[Header("Effects")]
	[SerializeField]
	private ParticleSystem trail;

	[Token(Token = "0x40002CA")]
	[FieldOffset(Offset = "0x200")]
	[SerializeField]
	private AudioManager audioManager;

	[Token(Token = "0x40002CB")]
	[FieldOffset(Offset = "0x208")]
	[SerializeField]
	private string[] jumpSounds;

	[Token(Token = "0x40002CC")]
	[FieldOffset(Offset = "0x210")]
	[Header("Refrences to other inputs")]
	[SerializeField]
	public GrapplingHook _LGrapple;

	[Token(Token = "0x40002CD")]
	[FieldOffset(Offset = "0x218")]
	[SerializeField]
	public GrapplingHook _RGrapple;

	[Token(Token = "0x40002CE")]
	[FieldOffset(Offset = "0x220")]
	[HideInInspector]
	public RagdollCameraController _cam;

	[Token(Token = "0x40002CF")]
	[FieldOffset(Offset = "0x228")]
	private Health health;

	[Token(Token = "0x40002D0")]
	[FieldOffset(Offset = "0x230")]
	private float gravityModifier;

	[Token(Token = "0x40002D1")]
	[FieldOffset(Offset = "0x234")]
	[SerializeField]
	private float gravityLerpSpeed;

	[Token(Token = "0x40002D2")]
	[FieldOffset(Offset = "0x238")]
	[SerializeField]
	private float Gravity;

	[Token(Token = "0x40002D3")]
	[FieldOffset(Offset = "0x23C")]
	[Header("Foot movement")]
	private float footMoveTimer;

	[Token(Token = "0x40002D4")]
	[FieldOffset(Offset = "0x240")]
	private bool kneeMove;

	[Token(Token = "0x40002D5")]
	[FieldOffset(Offset = "0x241")]
	private bool currentFootL;

	[Token(Token = "0x40002D6")]
	[FieldOffset(Offset = "0x244")]
	[SerializeField]
	private float footMoveTimerInterval;

	[Token(Token = "0x40002D7")]
	[FieldOffset(Offset = "0x248")]
	[Header("Walking")]
	[SerializeField]
	private float footForce;

	[Token(Token = "0x40002D8")]
	[FieldOffset(Offset = "0x24C")]
	[SerializeField]
	private float footDownForce;

	[Token(Token = "0x40002D9")]
	[FieldOffset(Offset = "0x250")]
	[SerializeField]
	private float footBackForce;

	[Token(Token = "0x40002DA")]
	[FieldOffset(Offset = "0x254")]
	[SerializeField]
	private float kneeForce;

	[Token(Token = "0x40002DB")]
	[FieldOffset(Offset = "0x258")]
	[SerializeField]
	private float handForce;

	[Token(Token = "0x40002DC")]
	[FieldOffset(Offset = "0x25C")]
	[SerializeField]
	private float chestForwardForce;

	[Token(Token = "0x40002DD")]
	[FieldOffset(Offset = "0x260")]
	[SerializeField]
	private float chestUpDownForce;

	[Token(Token = "0x40002DE")]
	[FieldOffset(Offset = "0x264")]
	[SerializeField]
	private float armOutForce;

	[Token(Token = "0x40002DF")]
	[FieldOffset(Offset = "0x268")]
	[Header("Idle")]
	[SerializeField]
	private float idleFootForce;

	[Token(Token = "0x40002E0")]
	[FieldOffset(Offset = "0x26C")]
	[SerializeField]
	private float breathingPace;

	[Token(Token = "0x40002E1")]
	[FieldOffset(Offset = "0x270")]
	[SerializeField]
	private float breathingStrength;

	[Token(Token = "0x40002E2")]
	[FieldOffset(Offset = "0x274")]
	public bool isMoving;

	[Token(Token = "0x40002E3")]
	[FieldOffset(Offset = "0x278")]
	[SerializeField]
	private float wallJumpForce;

	[Token(Token = "0x40002E4")]
	[FieldOffset(Offset = "0x280")]
	private List<Transform> grapplingPlayers;

	[Token(Token = "0x40002E5")]
	[FieldOffset(Offset = "0x288")]
	private float pulledByPlayerForce;

	[Token(Token = "0x40002E6")]
	[FieldOffset(Offset = "0x28C")]
	private float pulledByPlayerForceTwoHooks;

	[Token(Token = "0x40002E7")]
	[FieldOffset(Offset = "0x290")]
	private bool NetworkInitialize___EarlyPlayerMovementAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40002E8")]
	[FieldOffset(Offset = "0x291")]
	private bool NetworkInitialize__LatePlayerMovementAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60003C7")]
	[Address(RVA = "0x4A65B0", Offset = "0x4A4FB0", VA = "0x1804A65B0")]
	public void OnDestroy()
	{
	}

	[Token(Token = "0x60003C8")]
	[Address(RVA = "0x4A65E0", Offset = "0x4A4FE0", VA = "0x1804A65E0", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x60003C9")]
	[Address(RVA = "0x4A6A30", Offset = "0x4A5430", VA = "0x1804A6A30")]
	[Client]
	private void FixedUpdate()
	{
	}

	[Token(Token = "0x60003CA")]
	[Address(RVA = "0x4A6E50", Offset = "0x4A5850", VA = "0x1804A6E50")]
	[Client]
	private void Update()
	{
	}

	[Token(Token = "0x60003CB")]
	[Address(RVA = "0x4A73E0", Offset = "0x4A5DE0", VA = "0x1804A73E0")]
	[Client]
	public void SyncProfile(string username, int color, int hat)
	{
	}

	[Token(Token = "0x60003CC")]
	[Address(RVA = "0x4A7530", Offset = "0x4A5F30", VA = "0x1804A7530")]
	[Client]
	public void SyncTeam(bool pAwayTeam)
	{
	}

	[Token(Token = "0x60003CD")]
	[Address(RVA = "0x4A75F0", Offset = "0x4A5FF0", VA = "0x1804A75F0")]
	[Client]
	private void ColorTeamIndicators(Color pColor)
	{
	}

	[Token(Token = "0x60003CE")]
	[Address(RVA = "0x4A7780", Offset = "0x4A6180", VA = "0x1804A7780")]
	[Client]
	private void CheckIsGrounded()
	{
	}

	[Token(Token = "0x60003CF")]
	[Address(RVA = "0x4A7A00", Offset = "0x4A6400", VA = "0x1804A7A00")]
	[Client]
	private void Float()
	{
	}

	[Token(Token = "0x60003D0")]
	[Address(RVA = "0x4A80F0", Offset = "0x4A6AF0", VA = "0x1804A80F0")]
	[Client]
	private void UpdateUprightForce()
	{
	}

	[Token(Token = "0x60003D1")]
	[Address(RVA = "0x4A8710", Offset = "0x4A7110", VA = "0x1804A8710")]
	private void MyInput()
	{
	}

	[Token(Token = "0x60003D2")]
	[Address(RVA = "0x4AA210", Offset = "0x4A8C10", VA = "0x1804AA210")]
	[Client]
	public void StartJump(InputAction.CallbackContext context)
	{
	}

	[Token(Token = "0x60003D3")]
	[Address(RVA = "0x4AA6B0", Offset = "0x4A90B0", VA = "0x1804AA6B0")]
	[Client]
	private void Jump()
	{
	}

	[Token(Token = "0x60003D4")]
	[Address(RVA = "0x4AAA80", Offset = "0x4A9480", VA = "0x1804AAA80")]
	[Server]
	public void ServerKnockback(float strength, Vector3 source)
	{
	}

	[Token(Token = "0x60003D5")]
	[Address(RVA = "0x4AACB0", Offset = "0x4A96B0", VA = "0x1804AACB0")]
	[TargetRpc]
	public void RPCKnockback(NetworkConnection target, float strength, Vector3 source)
	{
	}

	[Token(Token = "0x60003D6")]
	[Address(RVA = "0x4AAE70", Offset = "0x4A9870", VA = "0x1804AAE70")]
	[Client]
	public void Knockback(float strength, Vector3 source)
	{
	}

	[Token(Token = "0x60003D7")]
	[Address(RVA = "0x4AB1C0", Offset = "0x4A9BC0", VA = "0x1804AB1C0")]
	[Server]
	public void AddGrapplingPlayer(int grapplingPlayerID)
	{
	}

	[Token(Token = "0x60003D8")]
	[Address(RVA = "0x4AB3C0", Offset = "0x4A9DC0", VA = "0x1804AB3C0")]
	[TargetRpc]
	private void RPCAddGrapplingPlayer(NetworkConnection target, int grapplingPlayerID)
	{
	}

	[Token(Token = "0x60003D9")]
	[Address(RVA = "0x4AB550", Offset = "0x4A9F50", VA = "0x1804AB550")]
	[Server]
	public void RemoveGrapplingPlayer(int grapplingPlayerID)
	{
	}

	[Token(Token = "0x60003DA")]
	[Address(RVA = "0x4AB750", Offset = "0x4AA150", VA = "0x1804AB750")]
	[TargetRpc]
	private void RPCRemoveGrapplingPlayer(NetworkConnection target, int grapplingPlayerID)
	{
	}

	[Token(Token = "0x60003DB")]
	[Address(RVA = "0x4AB8E0", Offset = "0x4AA2E0", VA = "0x1804AB8E0")]
	private void GetPulledByPlayers()
	{
	}

	[Token(Token = "0x60003DC")]
	[Address(RVA = "0x4AC060", Offset = "0x4AAA60", VA = "0x1804AC060")]
	public PlayerMovement()
	{
	}

	[Token(Token = "0x60003DD")]
	[Address(RVA = "0x4AC1E0", Offset = "0x4AABE0", VA = "0x1804AC1E0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60003DE")]
	[Address(RVA = "0x4AC310", Offset = "0x4AAD10", VA = "0x1804AC310", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60003DF")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60003E0")]
	[Address(RVA = "0x4AACB0", Offset = "0x4A96B0", VA = "0x1804AACB0")]
	private void RpcWriter___Target_RPCKnockback_2410615220(NetworkConnection target, float strength, Vector3 source)
	{
	}

	[Token(Token = "0x60003E1")]
	[Address(RVA = "0x4AC330", Offset = "0x4AAD30", VA = "0x1804AC330")]
	public void RpcLogic___RPCKnockback_2410615220(NetworkConnection target, float strength, Vector3 source)
	{
	}

	[Token(Token = "0x60003E2")]
	[Address(RVA = "0x4AC360", Offset = "0x4AAD60", VA = "0x1804AC360")]
	private void RpcReader___Target_RPCKnockback_2410615220(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60003E3")]
	[Address(RVA = "0x4AB3C0", Offset = "0x4A9DC0", VA = "0x1804AB3C0")]
	private void RpcWriter___Target_RPCAddGrapplingPlayer_2681120339(NetworkConnection target, int grapplingPlayerID)
	{
	}

	[Token(Token = "0x60003E4")]
	[Address(RVA = "0x4AC430", Offset = "0x4AAE30", VA = "0x1804AC430")]
	private void RpcLogic___RPCAddGrapplingPlayer_2681120339(NetworkConnection target, int grapplingPlayerID)
	{
	}

	[Token(Token = "0x60003E5")]
	[Address(RVA = "0x4AC580", Offset = "0x4AAF80", VA = "0x1804AC580")]
	private void RpcReader___Target_RPCAddGrapplingPlayer_2681120339(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60003E6")]
	[Address(RVA = "0x4AB750", Offset = "0x4AA150", VA = "0x1804AB750")]
	private void RpcWriter___Target_RPCRemoveGrapplingPlayer_2681120339(NetworkConnection target, int grapplingPlayerID)
	{
	}

	[Token(Token = "0x60003E7")]
	[Address(RVA = "0x4AC720", Offset = "0x4AB120", VA = "0x1804AC720")]
	private void RpcLogic___RPCRemoveGrapplingPlayer_2681120339(NetworkConnection target, int grapplingPlayerID)
	{
	}

	[Token(Token = "0x60003E8")]
	[Address(RVA = "0x4AC870", Offset = "0x4AB270", VA = "0x1804AC870")]
	private void RpcReader___Target_RPCRemoveGrapplingPlayer_2681120339(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60003E9")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
