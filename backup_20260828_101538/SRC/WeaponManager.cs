using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

[Token(Token = "0x2000092")]
public class WeaponManager : NetworkBehaviour
{
	[Token(Token = "0x4000318")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private GameObject ammoText;

	[Token(Token = "0x4000319")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private TMP_Text nextWeaponText;

	[Token(Token = "0x400031A")]
	[FieldOffset(Offset = "0x108")]
	[SerializeField]
	private LocalizedString nextWeaponString;

	[Token(Token = "0x400031B")]
	[FieldOffset(Offset = "0x110")]
	[SerializeField]
	public List<Weapon> weapons;

	[Token(Token = "0x400031C")]
	[FieldOffset(Offset = "0x118")]
	[SerializeField]
	public Transform pressFImage;

	[Token(Token = "0x400031D")]
	[FieldOffset(Offset = "0x120")]
	[HideInInspector]
	public Weapon latestActiveWeapon;

	[Token(Token = "0x400031E")]
	[FieldOffset(Offset = "0x128")]
	[SerializeField]
	private TMP_Text PickUpText;

	[Token(Token = "0x400031F")]
	[FieldOffset(Offset = "0x130")]
	[Header("Shared Gun Variables")]
	[SerializeField]
	public GameObject damagePopup;

	[Token(Token = "0x4000320")]
	[FieldOffset(Offset = "0x138")]
	[SerializeField]
	public Transform damagePopupParent;

	[Token(Token = "0x4000321")]
	[FieldOffset(Offset = "0x140")]
	[SerializeField]
	public Transform gunStart;

	[Token(Token = "0x4000322")]
	[FieldOffset(Offset = "0x148")]
	public TMP_Text ammoNumber;

	[Token(Token = "0x4000323")]
	[FieldOffset(Offset = "0x150")]
	public Image ammoImage;

	[Token(Token = "0x4000324")]
	[FieldOffset(Offset = "0x158")]
	public LayerMask enemyLayer;

	[Token(Token = "0x4000325")]
	[FieldOffset(Offset = "0x15C")]
	public LayerMask shootableLayers;

	[Token(Token = "0x4000326")]
	[FieldOffset(Offset = "0x160")]
	public Rigidbody rootRb;

	[Token(Token = "0x4000327")]
	[FieldOffset(Offset = "0x168")]
	public Rigidbody handRb;

	[Token(Token = "0x4000328")]
	[FieldOffset(Offset = "0x170")]
	public Rigidbody shoulderRb;

	[Token(Token = "0x4000329")]
	[FieldOffset(Offset = "0x178")]
	[HideInInspector]
	public float rbForce;

	[Token(Token = "0x400032A")]
	[FieldOffset(Offset = "0x17C")]
	private bool NetworkInitialize___EarlyWeaponManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x400032B")]
	[FieldOffset(Offset = "0x17D")]
	private bool NetworkInitialize__LateWeaponManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000424")]
	[Address(RVA = "0x4B0D30", Offset = "0x4AF730", VA = "0x1804B0D30", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x6000425")]
	[Address(RVA = "0x4B0DE0", Offset = "0x4AF7E0", VA = "0x1804B0DE0")]
	[IteratorStateMachine(typeof(_003CDelay_003Ed__7))]
	private IEnumerator Delay()
	{
		return null;
	}

	[Token(Token = "0x6000426")]
	[Address(RVA = "0x4B0E80", Offset = "0x4AF880", VA = "0x1804B0E80")]
	public void TryUpdateGunGameWeapon()
	{
	}

	[Token(Token = "0x6000427")]
	[Address(RVA = "0x4B11E0", Offset = "0x4AFBE0", VA = "0x1804B11E0")]
	[TargetRpc]
	private void UpdateWeaponText(NetworkConnection target, int weaponIndex)
	{
	}

	[Token(Token = "0x6000428")]
	[Address(RVA = "0x4B1370", Offset = "0x4AFD70", VA = "0x1804B1370")]
	[Server]
	public void StartPickUp(int index)
	{
	}

	[Token(Token = "0x6000429")]
	[Address(RVA = "0x4B1950", Offset = "0x4B0350", VA = "0x1804B1950")]
	[ObserversRpc]
	private void PickUp(int i)
	{
	}

	[Token(Token = "0x600042A")]
	[Address(RVA = "0x4B1AE0", Offset = "0x4B04E0", VA = "0x1804B1AE0")]
	[IteratorStateMachine(typeof(_003CDisplayWeaponPickupText_003Ed__13))]
	public IEnumerator DisplayWeaponPickupText(string weaponName)
	{
		return null;
	}

	[Token(Token = "0x600042B")]
	[Address(RVA = "0x4B1BE0", Offset = "0x4B05E0", VA = "0x1804B1BE0")]
	[Server]
	public void ServerHideWeapons()
	{
	}

	[Token(Token = "0x600042C")]
	[Address(RVA = "0x4B1D80", Offset = "0x4B0780", VA = "0x1804B1D80")]
	[ObserversRpc]
	private void HideWeapons()
	{
	}

	[Token(Token = "0x600042D")]
	[Address(RVA = "0x4B1EE0", Offset = "0x4B08E0", VA = "0x1804B1EE0")]
	public WeaponManager()
	{
	}

	[Token(Token = "0x600042E")]
	[Address(RVA = "0x4B1FC0", Offset = "0x4B09C0", VA = "0x1804B1FC0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x600042F")]
	[Address(RVA = "0x4B20F0", Offset = "0x4B0AF0", VA = "0x1804B20F0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000430")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000431")]
	[Address(RVA = "0x4B11E0", Offset = "0x4AFBE0", VA = "0x1804B11E0")]
	private void RpcWriter___Target_UpdateWeaponText_2681120339(NetworkConnection target, int weaponIndex)
	{
	}

	[Token(Token = "0x6000432")]
	[Address(RVA = "0x4B2110", Offset = "0x4B0B10", VA = "0x1804B2110")]
	private void RpcLogic___UpdateWeaponText_2681120339(NetworkConnection target, int weaponIndex)
	{
	}

	[Token(Token = "0x6000433")]
	[Address(RVA = "0x4B2290", Offset = "0x4B0C90", VA = "0x1804B2290")]
	private void RpcReader___Target_UpdateWeaponText_2681120339(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000434")]
	[Address(RVA = "0x4B1950", Offset = "0x4B0350", VA = "0x1804B1950")]
	private void RpcWriter___Observers_PickUp_3316948804(int i)
	{
	}

	[Token(Token = "0x6000435")]
	[Address(RVA = "0x4B2460", Offset = "0x4B0E60", VA = "0x1804B2460")]
	private void RpcLogic___PickUp_3316948804(int i)
	{
	}

	[Token(Token = "0x6000436")]
	[Address(RVA = "0x4B2EA0", Offset = "0x4B18A0", VA = "0x1804B2EA0")]
	private void RpcReader___Observers_PickUp_3316948804(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000437")]
	[Address(RVA = "0x4B1D80", Offset = "0x4B0780", VA = "0x1804B1D80")]
	private void RpcWriter___Observers_HideWeapons_2166136261()
	{
	}

	[Token(Token = "0x6000438")]
	[Address(RVA = "0x4B2F00", Offset = "0x4B1900", VA = "0x1804B2F00")]
	private void RpcLogic___HideWeapons_2166136261()
	{
	}

	[Token(Token = "0x6000439")]
	[Address(RVA = "0x4B32B0", Offset = "0x4B1CB0", VA = "0x1804B32B0")]
	private void RpcReader___Observers_HideWeapons_2166136261(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x600043A")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
