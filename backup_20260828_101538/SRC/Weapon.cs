using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.InputSystem;

[Token(Token = "0x200009F")]
public class Weapon : NetworkBehaviour
{
	[Token(Token = "0x4000371")]
	[FieldOffset(Offset = "0xF8")]
	public GameObject gunGameObject;

	[Token(Token = "0x4000372")]
	[FieldOffset(Offset = "0x100")]
	public WeaponScriptableObject weaponData;

	[Token(Token = "0x4000373")]
	[FieldOffset(Offset = "0x108")]
	[HideInInspector]
	public InputAction shoot;

	[Token(Token = "0x4000374")]
	[FieldOffset(Offset = "0x110")]
	[HideInInspector]
	public float nextTimeToFire;

	[Token(Token = "0x4000375")]
	[FieldOffset(Offset = "0x114")]
	[HideInInspector]
	public int currentAmmo;

	[Token(Token = "0x4000376")]
	[FieldOffset(Offset = "0x118")]
	[HideInInspector]
	public WeaponManager weaponManger;

	[Token(Token = "0x4000377")]
	[FieldOffset(Offset = "0x120")]
	private bool canShoot;

	[Token(Token = "0x4000378")]
	private const string explosiveLayer = "Explosives";

	[Token(Token = "0x4000379")]
	[FieldOffset(Offset = "0x121")]
	private bool NetworkInitialize___EarlyWeaponAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x400037A")]
	[FieldOffset(Offset = "0x122")]
	private bool NetworkInitialize__LateWeaponAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60004B8")]
	[Address(RVA = "0x4BCD70", Offset = "0x4BB770", VA = "0x1804BCD70", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x60004B9")]
	[Address(RVA = "0x4BCE40", Offset = "0x4BB840", VA = "0x1804BCE40")]
	private void OnEnable()
	{
	}

	[Token(Token = "0x60004BA")]
	[Address(RVA = "0x4BCF30", Offset = "0x4BB930", VA = "0x1804BCF30", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x60004BB")]
	[Address(RVA = "0x4BCFD0", Offset = "0x4BB9D0", VA = "0x1804BCFD0")]
	private void Update()
	{
	}

	[Token(Token = "0x60004BC")]
	[Address(RVA = "0x4BD0E0", Offset = "0x4BBAE0", VA = "0x1804BD0E0")]
	public bool FireKeyIsHeld()
	{
		return default(bool);
	}

	[Token(Token = "0x60004BD")]
	[Address(RVA = "0x4BD140", Offset = "0x4BBB40", VA = "0x1804BD140")]
	[IteratorStateMachine(typeof(_003CDisableTutorialPopUp_003Ed__13))]
	public IEnumerator DisableTutorialPopUp()
	{
		return null;
	}

	[Token(Token = "0x60004BE")]
	[Address(RVA = "0x4BD1E0", Offset = "0x4BBBE0", VA = "0x1804BD1E0", Slot = "27")]
	[Client]
	public virtual void ClientTryShoot()
	{
	}

	[Token(Token = "0x60004BF")]
	[Address(RVA = "0x4BD500", Offset = "0x4BBF00", VA = "0x1804BD500", Slot = "28")]
	[ServerRpc]
	public virtual void CMDShoot(short[] _cameraPosition, short[] _cameraForward, uint tick)
	{
	}

	[Token(Token = "0x60004C0")]
	[Address(RVA = "0x4BD510", Offset = "0x4BBF10", VA = "0x1804BD510")]
	[Server]
	public bool AppleDamage(GameObject hitObject)
	{
		return default(bool);
	}

	[Token(Token = "0x60004C1")]
	[Address(RVA = "0x4BD720", Offset = "0x4BC120", VA = "0x1804BD720", Slot = "29")]
	[Server]
	public virtual int GetDamage(Vector3 hitPoint)
	{
		return default(int);
	}

	[Token(Token = "0x60004C2")]
	[Address(RVA = "0x4BD7F0", Offset = "0x4BC1F0", VA = "0x1804BD7F0")]
	[Server]
	public void UpdateGunVariables()
	{
	}

	[Token(Token = "0x60004C3")]
	[Address(RVA = "0x4BD890", Offset = "0x4BC290", VA = "0x1804BD890")]
	[TargetRpc]
	private void RPCUpdateGunVariables(NetworkConnection target, short currentAmmo)
	{
	}

	[Token(Token = "0x60004C4")]
	[Address(RVA = "0x4BDA10", Offset = "0x4BC410", VA = "0x1804BDA10")]
	public float DistanceSqToLine(Ray ray, Vector3 point)
	{
		return default(float);
	}

	[Token(Token = "0x60004C5")]
	[Address(RVA = "0x4BDAE0", Offset = "0x4BC4E0", VA = "0x1804BDAE0", Slot = "30")]
	[Server]
	public virtual void HandleRaycasts(Vector3 cameraPosition, Vector3 cameraForward, uint tick)
	{
	}

	[Token(Token = "0x60004C6")]
	[Address(RVA = "0x4BE360", Offset = "0x4BCD60", VA = "0x1804BE360", Slot = "31")]
	[Server]
	public virtual void ServerPostShoot()
	{
	}

	[Token(Token = "0x60004C7")]
	[Address(RVA = "0x4BE540", Offset = "0x4BCF40", VA = "0x1804BE540")]
	[IteratorStateMachine(typeof(_003CAutoReload_003Ed__23))]
	public IEnumerator AutoReload()
	{
		return null;
	}

	[Token(Token = "0x60004C8")]
	[Address(RVA = "0x4BE5E0", Offset = "0x4BCFE0", VA = "0x1804BE5E0", Slot = "32")]
	[Server]
	public virtual void HandleShootingPlayer(GameObject hitObject, Vector3 hitPoint)
	{
	}

	[Token(Token = "0x60004C9")]
	[Address(RVA = "0x4BEA00", Offset = "0x4BD400", VA = "0x1804BEA00", Slot = "33")]
	[ObserversRpc]
	public virtual void StartSharedEffects(short[] hitPointData, int HitPlayerId, bool didHit, short damage, bool applyDamage)
	{
	}

	[Token(Token = "0x60004CA")]
	[Address(RVA = "0x4BEA30", Offset = "0x4BD430", VA = "0x1804BEA30", Slot = "34")]
	[Client]
	public virtual void LocalEffects()
	{
	}

	[Token(Token = "0x60004CB")]
	[Address(RVA = "0x4BF4A0", Offset = "0x4BDEA0", VA = "0x1804BF4A0", Slot = "35")]
	[IteratorStateMachine(typeof(_003CSharedEffects_003Ed__27))]
	[Client]
	public virtual IEnumerator SharedEffects(Vector3 hitPoint, int HitPlayerId, bool didHit, short damage, bool applyDamage)
	{
		return null;
	}

	[Token(Token = "0x60004CC")]
	[Address(RVA = "0x4BF5E0", Offset = "0x4BDFE0", VA = "0x1804BF5E0", Slot = "36")]
	[Server]
	public virtual void HandleShootNormal(RaycastHit hit)
	{
	}

	[Token(Token = "0x60004CD")]
	[Address(RVA = "0x4BF8F0", Offset = "0x4BE2F0", VA = "0x1804BF8F0")]
	[Server]
	public void Reload()
	{
	}

	[Token(Token = "0x60004CE")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public Weapon()
	{
	}

	[Token(Token = "0x60004CF")]
	[Address(RVA = "0x4BF9A0", Offset = "0x4BE3A0", VA = "0x1804BF9A0", Slot = "37")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60004D0")]
	[Address(RVA = "0x4BFAE0", Offset = "0x4BE4E0", VA = "0x1804BFAE0", Slot = "38")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60004D1")]
	[Address(RVA = "0x4B3B30", Offset = "0x4B2530", VA = "0x1804B3B30", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60004D2")]
	[Address(RVA = "0x4BFB00", Offset = "0x4BE500", VA = "0x1804BFB00")]
	private void RpcWriter___Server_CMDShoot_2914479895(short[] _cameraPosition, short[] _cameraForward, uint tick)
	{
	}

	[Token(Token = "0x60004D3")]
	[Address(RVA = "0x4BFDC0", Offset = "0x4BE7C0", VA = "0x1804BFDC0", Slot = "39")]
	public virtual void RpcLogic___CMDShoot_2914479895(short[] _cameraPosition, short[] _cameraForward, uint tick)
	{
	}

	[Token(Token = "0x60004D4")]
	[Address(RVA = "0x4BFED0", Offset = "0x4BE8D0", VA = "0x1804BFED0")]
	private void RpcReader___Server_CMDShoot_2914479895(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x60004D5")]
	[Address(RVA = "0x4BD890", Offset = "0x4BC290", VA = "0x1804BD890")]
	private void RpcWriter___Target_RPCUpdateGunVariables_2647565069(NetworkConnection target, short currentAmmo)
	{
	}

	[Token(Token = "0x60004D6")]
	[Address(RVA = "0x4C0170", Offset = "0x4BEB70", VA = "0x1804C0170")]
	private void RpcLogic___RPCUpdateGunVariables_2647565069(NetworkConnection target, short currentAmmo)
	{
	}

	[Token(Token = "0x60004D7")]
	[Address(RVA = "0x4C02E0", Offset = "0x4BECE0", VA = "0x1804C02E0")]
	private void RpcReader___Target_RPCUpdateGunVariables_2647565069(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60004D8")]
	[Address(RVA = "0x4C04D0", Offset = "0x4BEED0", VA = "0x1804C04D0")]
	private void RpcWriter___Observers_StartSharedEffects_3088379076(short[] hitPointData, int HitPlayerId, bool didHit, short damage, bool applyDamage)
	{
	}

	[Token(Token = "0x60004D9")]
	[Address(RVA = "0x4C0720", Offset = "0x4BF120", VA = "0x1804C0720", Slot = "40")]
	public virtual void RpcLogic___StartSharedEffects_3088379076(short[] hitPointData, int HitPlayerId, bool didHit, short damage, bool applyDamage)
	{
	}

	[Token(Token = "0x60004DA")]
	[Address(RVA = "0x4C07E0", Offset = "0x4BF1E0", VA = "0x1804C07E0")]
	private void RpcReader___Observers_StartSharedEffects_3088379076(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60004DB")]
	[Address(RVA = "0x4B3B30", Offset = "0x4B2530", VA = "0x1804B3B30", Slot = "41")]
	public override void Awake()
	{
	}
}
