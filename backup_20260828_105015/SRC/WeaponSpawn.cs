using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000101")]
public class WeaponSpawn : NetworkBehaviour
{
	[Token(Token = "0x400053F")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private ParticleSystem destructionEffect;

	[Token(Token = "0x4000540")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private GameObject[] pickups;

	[Token(Token = "0x4000541")]
	[FieldOffset(Offset = "0x108")]
	public readonly SyncVar<int> index;

	[Token(Token = "0x4000542")]
	[FieldOffset(Offset = "0x110")]
	[HideInInspector]
	public readonly SyncVar<int> pickup_index;

	[Token(Token = "0x4000543")]
	[FieldOffset(Offset = "0x118")]
	[Header("LODs and Materials")]
	[SerializeField]
	private MeshRenderer LOD0_Renderer;

	[Token(Token = "0x4000544")]
	[FieldOffset(Offset = "0x120")]
	[SerializeField]
	private Material LOD0_On_Material;

	[Token(Token = "0x4000545")]
	[FieldOffset(Offset = "0x128")]
	[SerializeField]
	private Material LOD0_Off_Material;

	[Token(Token = "0x4000546")]
	[FieldOffset(Offset = "0x130")]
	[SerializeField]
	private MeshRenderer LOD1_Renderer;

	[Token(Token = "0x4000547")]
	[FieldOffset(Offset = "0x138")]
	[SerializeField]
	private Material LOD1_On_Material;

	[Token(Token = "0x4000548")]
	[FieldOffset(Offset = "0x140")]
	[SerializeField]
	private Material LOD1_Off_Material;

	[Token(Token = "0x4000549")]
	[FieldOffset(Offset = "0x148")]
	[SerializeField]
	private MeshRenderer LOD2_Renderer;

	[Token(Token = "0x400054A")]
	[FieldOffset(Offset = "0x150")]
	[SerializeField]
	private Material LOD2_On_Material;

	[Token(Token = "0x400054B")]
	[FieldOffset(Offset = "0x158")]
	[SerializeField]
	private Material LOD2_Off_Material;

	[Token(Token = "0x400054C")]
	[FieldOffset(Offset = "0x160")]
	[SerializeField]
	private MeshRenderer LOD3_Renderer;

	[Token(Token = "0x400054D")]
	[FieldOffset(Offset = "0x168")]
	[SerializeField]
	private Material LOD3_On_Material;

	[Token(Token = "0x400054E")]
	[FieldOffset(Offset = "0x170")]
	[SerializeField]
	private Material LOD3_Off_Material;

	[Token(Token = "0x400054F")]
	[FieldOffset(Offset = "0x178")]
	[SerializeField]
	private GameObject[] gradients;

	[Token(Token = "0x4000550")]
	[FieldOffset(Offset = "0x180")]
	[SerializeField]
	private Material Health_Gradient;

	[Token(Token = "0x4000551")]
	[FieldOffset(Offset = "0x188")]
	[SerializeField]
	private Material Weapon_Gradient;

	[Token(Token = "0x4000552")]
	[FieldOffset(Offset = "0x190")]
	[SerializeField]
	private GameObject particles;

	[Token(Token = "0x4000553")]
	[FieldOffset(Offset = "0x198")]
	[SerializeField]
	private AudioSource pickupSFX;

	[Token(Token = "0x4000554")]
	[FieldOffset(Offset = "0x1A0")]
	private bool NetworkInitialize___EarlyWeaponSpawnAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000555")]
	[FieldOffset(Offset = "0x1A1")]
	private bool NetworkInitialize__LateWeaponSpawnAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60007C8")]
	[Address(RVA = "0x4F3F90", Offset = "0x4F2990", VA = "0x1804F3F90", Slot = "7")]
	public override void OnStartNetwork()
	{
	}

	[Token(Token = "0x60007C9")]
	[Address(RVA = "0x4F4040", Offset = "0x4F2A40", VA = "0x1804F4040", Slot = "9")]
	public override void OnStopNetwork()
	{
	}

	[Token(Token = "0x60007CA")]
	[Address(RVA = "0x4F40F0", Offset = "0x4F2AF0", VA = "0x1804F40F0")]
	[ObserversRpc]
	private void PlaySound()
	{
	}

	[Token(Token = "0x60007CB")]
	[Address(RVA = "0x4F4250", Offset = "0x4F2C50", VA = "0x1804F4250")]
	private void UpdateWeaponSpawn(int oldPickup, int newPickup, bool asServer)
	{
	}

	[Token(Token = "0x60007CC")]
	[Address(RVA = "0x4F4F40", Offset = "0x4F3940", VA = "0x1804F4F40")]
	[Server]
	public void EnableWeaponPickup()
	{
	}

	[Token(Token = "0x60007CD")]
	[Address(RVA = "0x4F5180", Offset = "0x4F3B80", VA = "0x1804F5180")]
	[Server]
	public void DisablePickup()
	{
	}

	[Token(Token = "0x60007CE")]
	[Address(RVA = "0x4F5240", Offset = "0x4F3C40", VA = "0x1804F5240")]
	[Server]
	public void EnableHealthPickup()
	{
	}

	[Token(Token = "0x60007CF")]
	[Address(RVA = "0x4F5310", Offset = "0x4F3D10", VA = "0x1804F5310")]
	[Server]
	public void StartMovingPickup(int playerPickingUpWeapon)
	{
	}

	[Token(Token = "0x60007D0")]
	[Address(RVA = "0x4F5600", Offset = "0x4F4000", VA = "0x1804F5600")]
	[IteratorStateMachine(typeof(_003CCooldownTimer_003Ed__29))]
	[Server]
	private IEnumerator CooldownTimer(int playerPickingUpCharge)
	{
		return null;
	}

	[Token(Token = "0x60007D1")]
	[Address(RVA = "0x4F5710", Offset = "0x4F4110", VA = "0x1804F5710")]
	public WeaponSpawn()
	{
	}

	[Token(Token = "0x60007D2")]
	[Address(RVA = "0x4F58D0", Offset = "0x4F42D0", VA = "0x1804F58D0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60007D3")]
	[Address(RVA = "0x4F59B0", Offset = "0x4F43B0", VA = "0x1804F59B0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60007D4")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60007D5")]
	[Address(RVA = "0x4F40F0", Offset = "0x4F2AF0", VA = "0x1804F40F0")]
	private void RpcWriter___Observers_PlaySound_2166136261()
	{
	}

	[Token(Token = "0x60007D6")]
	[Address(RVA = "0x4F5A20", Offset = "0x4F4420", VA = "0x1804F5A20")]
	private void RpcLogic___PlaySound_2166136261()
	{
	}

	[Token(Token = "0x60007D7")]
	[Address(RVA = "0x4F5A50", Offset = "0x4F4450", VA = "0x1804F5A50")]
	private void RpcReader___Observers_PlaySound_2166136261(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60007D8")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
