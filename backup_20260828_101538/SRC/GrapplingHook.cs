using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.InputSystem;

[Token(Token = "0x2000084")]
public class GrapplingHook : NetworkBehaviour
{
	[Token(Token = "0x4000230")]
	[FieldOffset(Offset = "0xF8")]
	[Header("Grappling")]
	public readonly SyncVar<Vector3> grapplePoint;

	[Token(Token = "0x4000231")]
	[FieldOffset(Offset = "0x100")]
	public LayerMask whatIsGrappleable;

	[Token(Token = "0x4000232")]
	[FieldOffset(Offset = "0x108")]
	public Transform gunTip;

	[Token(Token = "0x4000233")]
	[FieldOffset(Offset = "0x110")]
	public Transform _camera;

	[Token(Token = "0x4000234")]
	[FieldOffset(Offset = "0x118")]
	public GameObject player;

	[Token(Token = "0x4000235")]
	[FieldOffset(Offset = "0x120")]
	public float maxDistance;

	[Token(Token = "0x4000236")]
	[FieldOffset(Offset = "0x128")]
	private SpringJoint joint;

	[Token(Token = "0x4000237")]
	[FieldOffset(Offset = "0x130")]
	public int mouseButton;

	[Token(Token = "0x4000238")]
	[FieldOffset(Offset = "0x138")]
	public PlayerMovement playerMovement;

	[Token(Token = "0x4000239")]
	[FieldOffset(Offset = "0x140")]
	public Rigidbody handrb;

	[Token(Token = "0x400023A")]
	[FieldOffset(Offset = "0x148")]
	private Rigidbody rb;

	[Token(Token = "0x400023B")]
	[FieldOffset(Offset = "0x150")]
	public int oneHookRetractForce;

	[Token(Token = "0x400023C")]
	[FieldOffset(Offset = "0x154")]
	public int twoHookRetractForce;

	[Token(Token = "0x400023D")]
	[FieldOffset(Offset = "0x158")]
	public GrapplingHook otherHook;

	[Token(Token = "0x400023E")]
	[FieldOffset(Offset = "0x160")]
	public float playerAimAssistSize;

	[Token(Token = "0x400023F")]
	[FieldOffset(Offset = "0x164")]
	public LayerMask enemyLayer;

	[Token(Token = "0x4000240")]
	[FieldOffset(Offset = "0x168")]
	public LayerMask movingLayers;

	[Token(Token = "0x4000241")]
	[FieldOffset(Offset = "0x16C")]
	public LayerMask grapplableLayers;

	[Token(Token = "0x4000242")]
	[FieldOffset(Offset = "0x170")]
	[Header("Networking")]
	[HideInInspector]
	public GameObject grappledPlayer;

	[Token(Token = "0x4000243")]
	[FieldOffset(Offset = "0x178")]
	[HideInInspector]
	public MovingObject grappledMovingObject;

	[Token(Token = "0x4000244")]
	[FieldOffset(Offset = "0x180")]
	private GameObject grappledObject;

	[Token(Token = "0x4000245")]
	[FieldOffset(Offset = "0x188")]
	private Vector3 grappledObjectPosAtGrapple;

	[Token(Token = "0x4000246")]
	[FieldOffset(Offset = "0x198")]
	[SerializeField]
	private Transform grapplingRaycastStart;

	[Token(Token = "0x4000247")]
	[FieldOffset(Offset = "0x1A0")]
	public float grappleRate;

	[Token(Token = "0x4000248")]
	[FieldOffset(Offset = "0x1A4")]
	[HideInInspector]
	public float nextTimeToFire;

	[Token(Token = "0x4000249")]
	[FieldOffset(Offset = "0x1A8")]
	[SerializeField]
	private float grappleBoostCooldown;

	[Token(Token = "0x400024A")]
	[FieldOffset(Offset = "0x1AC")]
	private float currentGrappleBoostCooldown;

	[Token(Token = "0x400024B")]
	[FieldOffset(Offset = "0x1B0")]
	private bool CanBoost;

	[Token(Token = "0x400024C")]
	[FieldOffset(Offset = "0x1B4")]
	[SerializeField]
	private float dampingSpeed;

	[Token(Token = "0x400024D")]
	[FieldOffset(Offset = "0x1B8")]
	[SerializeField]
	private float handForce;

	[Token(Token = "0x400024E")]
	[FieldOffset(Offset = "0x1BC")]
	private float minRetractDistance;

	[Token(Token = "0x400024F")]
	[FieldOffset(Offset = "0x1C0")]
	private bool NetworkInitialize___EarlyGrapplingHookAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000250")]
	[FieldOffset(Offset = "0x1C1")]
	private bool NetworkInitialize__LateGrapplingHookAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x600032F")]
	[Address(RVA = "0x4964A0", Offset = "0x494EA0", VA = "0x1804964A0", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x6000330")]
	[Address(RVA = "0x4965A0", Offset = "0x494FA0", VA = "0x1804965A0")]
	[Client]
	private void LateUpdate()
	{
	}

	[Token(Token = "0x6000331")]
	[Address(RVA = "0x496990", Offset = "0x495390", VA = "0x180496990")]
	[ServerRpc]
	private void CMDStartGrapplePlayer(int grapplingPlayerNetID, int grappledPlayerNetID)
	{
	}

	[Token(Token = "0x6000332")]
	[Address(RVA = "0x4969A0", Offset = "0x4953A0", VA = "0x1804969A0")]
	[ServerRpc]
	private void CMDStopGrapplePlayer(int grapplingPlayerNetID, int grappledPlayerNetID)
	{
	}

	[Token(Token = "0x6000333")]
	[Address(RVA = "0x4969B0", Offset = "0x4953B0", VA = "0x1804969B0")]
	[ServerRpc]
	private void CMDGetGrappledPlayerObject(int grappledPlayerID)
	{
	}

	[Token(Token = "0x6000334")]
	[Address(RVA = "0x4969C0", Offset = "0x4953C0", VA = "0x1804969C0")]
	[ObserversRpc]
	public void RPCGetGrappledPlayerObject(int grappledPlayerID)
	{
	}

	[Token(Token = "0x6000335")]
	[Address(RVA = "0x496B50", Offset = "0x495550", VA = "0x180496B50")]
	[ServerRpc]
	private void CMDGetGrappledMovingObject(int grappledObjectID, Vector3 hitInversePoint)
	{
	}

	[Token(Token = "0x6000336")]
	[Address(RVA = "0x496B80", Offset = "0x495580", VA = "0x180496B80")]
	[ObserversRpc]
	public void RPCGetGrappledMovingObject(int grappledPlayerID, Vector3 hitInversePoint)
	{
	}

	[Token(Token = "0x6000337")]
	[Address(RVA = "0x496BB0", Offset = "0x4955B0", VA = "0x180496BB0")]
	[Client]
	public void GrappleStopInput(InputAction.CallbackContext context)
	{
	}

	[Token(Token = "0x6000338")]
	[Address(RVA = "0x496C30", Offset = "0x495630", VA = "0x180496C30")]
	[Client]
	public void GrappleInput(InputAction.CallbackContext context)
	{
	}

	[Token(Token = "0x6000339")]
	[Address(RVA = "0x4980D0", Offset = "0x496AD0", VA = "0x1804980D0")]
	[Client]
	public void StartLocalGrapple(RaycastHit hit)
	{
	}

	[Token(Token = "0x600033A")]
	[Address(RVA = "0x498EA0", Offset = "0x4978A0", VA = "0x180498EA0")]
	[ServerRpc]
	private void CMDStartGrapple(short[] grapplePointData)
	{
	}

	[Token(Token = "0x600033B")]
	[Address(RVA = "0x498EB0", Offset = "0x4978B0", VA = "0x180498EB0")]
	[ObserversRpc]
	public void StartPublicGrapple(short[] grapplePointData)
	{
	}

	[Token(Token = "0x600033C")]
	[Address(RVA = "0x498EC0", Offset = "0x4978C0", VA = "0x180498EC0")]
	[Client]
	public void StopLocalGrapple()
	{
	}

	[Token(Token = "0x600033D")]
	[Address(RVA = "0x4993B0", Offset = "0x497DB0", VA = "0x1804993B0")]
	[ServerRpc]
	private void CMDStopGrapple()
	{
	}

	[Token(Token = "0x600033E")]
	[Address(RVA = "0x499560", Offset = "0x497F60", VA = "0x180499560")]
	[ObserversRpc]
	public void StopPublicGrapple()
	{
	}

	[Token(Token = "0x600033F")]
	[Address(RVA = "0x4996C0", Offset = "0x4980C0", VA = "0x1804996C0")]
	[Client]
	public Vector3 GetGrapplePoint()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000340")]
	[Address(RVA = "0x499A10", Offset = "0x498410", VA = "0x180499A10")]
	private void OnDrawGizmos()
	{
	}

	[Token(Token = "0x6000341")]
	[Address(RVA = "0x499BE0", Offset = "0x4985E0", VA = "0x180499BE0")]
	[Client]
	private void RetractGrapple()
	{
	}

	[Token(Token = "0x6000342")]
	[Address(RVA = "0x49A870", Offset = "0x499270", VA = "0x18049A870")]
	[Client]
	private void OnApplicationFocus(bool focus)
	{
	}

	[Token(Token = "0x6000343")]
	[Address(RVA = "0x49A900", Offset = "0x499300", VA = "0x18049A900")]
	public GrapplingHook()
	{
	}

	[Token(Token = "0x6000344")]
	[Address(RVA = "0x49AA50", Offset = "0x499450", VA = "0x18049AA50", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000345")]
	[Address(RVA = "0x49ADB0", Offset = "0x4997B0", VA = "0x18049ADB0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000346")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000347")]
	[Address(RVA = "0x49ADF0", Offset = "0x4997F0", VA = "0x18049ADF0")]
	private void RpcWriter___Server_CMDStartGrapplePlayer_1692629761(int grapplingPlayerNetID, int grappledPlayerNetID)
	{
	}

	[Token(Token = "0x6000348")]
	[Address(RVA = "0x49AFE0", Offset = "0x4999E0", VA = "0x18049AFE0")]
	private void RpcLogic___CMDStartGrapplePlayer_1692629761(int grapplingPlayerNetID, int grappledPlayerNetID)
	{
	}

	[Token(Token = "0x6000349")]
	[Address(RVA = "0x49B120", Offset = "0x499B20", VA = "0x18049B120")]
	private void RpcReader___Server_CMDStartGrapplePlayer_1692629761(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x600034A")]
	[Address(RVA = "0x49B350", Offset = "0x499D50", VA = "0x18049B350")]
	private void RpcWriter___Server_CMDStopGrapplePlayer_1692629761(int grapplingPlayerNetID, int grappledPlayerNetID)
	{
	}

	[Token(Token = "0x600034B")]
	[Address(RVA = "0x49B540", Offset = "0x499F40", VA = "0x18049B540")]
	private void RpcLogic___CMDStopGrapplePlayer_1692629761(int grapplingPlayerNetID, int grappledPlayerNetID)
	{
	}

	[Token(Token = "0x600034C")]
	[Address(RVA = "0x49B670", Offset = "0x49A070", VA = "0x18049B670")]
	private void RpcReader___Server_CMDStopGrapplePlayer_1692629761(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x600034D")]
	[Address(RVA = "0x49B890", Offset = "0x49A290", VA = "0x18049B890")]
	private void RpcWriter___Server_CMDGetGrappledPlayerObject_3316948804(int grappledPlayerID)
	{
	}

	[Token(Token = "0x600034E")]
	[Address(RVA = "0x4969C0", Offset = "0x4953C0", VA = "0x1804969C0")]
	private void RpcLogic___CMDGetGrappledPlayerObject_3316948804(int grappledPlayerID)
	{
	}

	[Token(Token = "0x600034F")]
	[Address(RVA = "0x49BA60", Offset = "0x49A460", VA = "0x18049BA60")]
	private void RpcReader___Server_CMDGetGrappledPlayerObject_3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x6000350")]
	[Address(RVA = "0x4969C0", Offset = "0x4953C0", VA = "0x1804969C0")]
	private void RpcWriter___Observers_RPCGetGrappledPlayerObject_3316948804(int grappledPlayerID)
	{
	}

	[Token(Token = "0x6000351")]
	[Address(RVA = "0x49BCB0", Offset = "0x49A6B0", VA = "0x18049BCB0")]
	public void RpcLogic___RPCGetGrappledPlayerObject_3316948804(int grappledPlayerID)
	{
	}

	[Token(Token = "0x6000352")]
	[Address(RVA = "0x49BEB0", Offset = "0x49A8B0", VA = "0x18049BEB0")]
	private void RpcReader___Observers_RPCGetGrappledPlayerObject_3316948804(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000353")]
	[Address(RVA = "0x49BF10", Offset = "0x49A910", VA = "0x18049BF10")]
	private void RpcWriter___Server_CMDGetGrappledMovingObject_215135683(int grappledObjectID, Vector3 hitInversePoint)
	{
	}

	[Token(Token = "0x6000354")]
	[Address(RVA = "0x496B80", Offset = "0x495580", VA = "0x180496B80")]
	private void RpcLogic___CMDGetGrappledMovingObject_215135683(int grappledObjectID, Vector3 hitInversePoint)
	{
	}

	[Token(Token = "0x6000355")]
	[Address(RVA = "0x49C120", Offset = "0x49AB20", VA = "0x18049C120")]
	private void RpcReader___Server_CMDGetGrappledMovingObject_215135683(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x6000356")]
	[Address(RVA = "0x49C270", Offset = "0x49AC70", VA = "0x18049C270")]
	private void RpcWriter___Observers_RPCGetGrappledMovingObject_215135683(int grappledPlayerID, Vector3 hitInversePoint)
	{
	}

	[Token(Token = "0x6000357")]
	[Address(RVA = "0x49C440", Offset = "0x49AE40", VA = "0x18049C440")]
	public void RpcLogic___RPCGetGrappledMovingObject_215135683(int grappledPlayerID, Vector3 hitInversePoint)
	{
	}

	[Token(Token = "0x6000358")]
	[Address(RVA = "0x49C6E0", Offset = "0x49B0E0", VA = "0x18049C6E0")]
	private void RpcReader___Observers_RPCGetGrappledMovingObject_215135683(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000359")]
	[Address(RVA = "0x49C7B0", Offset = "0x49B1B0", VA = "0x18049C7B0")]
	private void RpcWriter___Server_CMDStartGrapple_3949533238(short[] grapplePointData)
	{
	}

	[Token(Token = "0x600035A")]
	[Address(RVA = "0x49C9F0", Offset = "0x49B3F0", VA = "0x18049C9F0")]
	private void RpcLogic___CMDStartGrapple_3949533238(short[] grapplePointData)
	{
	}

	[Token(Token = "0x600035B")]
	[Address(RVA = "0x49CAD0", Offset = "0x49B4D0", VA = "0x18049CAD0")]
	private void RpcReader___Server_CMDStartGrapple_3949533238(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x600035C")]
	[Address(RVA = "0x49CCC0", Offset = "0x49B6C0", VA = "0x18049CCC0")]
	private void RpcWriter___Observers_StartPublicGrapple_3949533238(short[] grapplePointData)
	{
	}

	[Token(Token = "0x600035D")]
	[Address(RVA = "0x49CEC0", Offset = "0x49B8C0", VA = "0x18049CEC0")]
	public void RpcLogic___StartPublicGrapple_3949533238(short[] grapplePointData)
	{
	}

	[Token(Token = "0x600035E")]
	[Address(RVA = "0x49D080", Offset = "0x49BA80", VA = "0x18049D080")]
	private void RpcReader___Observers_StartPublicGrapple_3949533238(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x600035F")]
	[Address(RVA = "0x4993B0", Offset = "0x497DB0", VA = "0x1804993B0")]
	private void RpcWriter___Server_CMDStopGrapple_2166136261()
	{
	}

	[Token(Token = "0x6000360")]
	[Address(RVA = "0x499560", Offset = "0x497F60", VA = "0x180499560")]
	private void RpcLogic___CMDStopGrapple_2166136261()
	{
	}

	[Token(Token = "0x6000361")]
	[Address(RVA = "0x49D130", Offset = "0x49BB30", VA = "0x18049D130")]
	private void RpcReader___Server_CMDStopGrapple_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x6000362")]
	[Address(RVA = "0x499560", Offset = "0x497F60", VA = "0x180499560")]
	private void RpcWriter___Observers_StopPublicGrapple_2166136261()
	{
	}

	[Token(Token = "0x6000363")]
	[Address(RVA = "0x49D340", Offset = "0x49BD40", VA = "0x18049D340")]
	public void RpcLogic___StopPublicGrapple_2166136261()
	{
	}

	[Token(Token = "0x6000364")]
	[Address(RVA = "0x49D620", Offset = "0x49C020", VA = "0x18049D620")]
	private void RpcReader___Observers_StopPublicGrapple_2166136261(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000365")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
