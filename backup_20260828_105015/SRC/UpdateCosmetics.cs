using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000090")]
public class UpdateCosmetics : NetworkBehaviour
{
	[Token(Token = "0x4000307")]
	[FieldOffset(Offset = "0xF8")]
	[Header("Color")]
	[SerializeField]
	private ParticleSystemRenderer[] particleSystems;

	[Token(Token = "0x4000308")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private List<Material> playerColors;

	[Token(Token = "0x4000309")]
	[FieldOffset(Offset = "0x108")]
	[Header("Hat")]
	[SerializeField]
	private CosmeticPack[] cosmeticPacks;

	[Token(Token = "0x400030A")]
	[FieldOffset(Offset = "0x110")]
	[SerializeField]
	private Transform hatParent;

	[Token(Token = "0x400030B")]
	[FieldOffset(Offset = "0x118")]
	[SerializeField]
	[ColorUsage(true, true)]
	private Color outlineColor;

	[Token(Token = "0x400030C")]
	[FieldOffset(Offset = "0x128")]
	[Header("Body")]
	[SerializeField]
	private SkinnedMeshRenderer bodyMesh;

	[Token(Token = "0x400030D")]
	[FieldOffset(Offset = "0x130")]
	[SerializeField]
	private MeshRenderer headMesh;

	[Token(Token = "0x400030E")]
	[FieldOffset(Offset = "0x138")]
	[SerializeField]
	private bool isJuggernaut;

	[Token(Token = "0x400030F")]
	[FieldOffset(Offset = "0x140")]
	[HideInInspector]
	public readonly SyncVar<int> playerColor;

	[Token(Token = "0x4000310")]
	[FieldOffset(Offset = "0x148")]
	[HideInInspector]
	public readonly SyncVar<string> playerHat;

	[Token(Token = "0x4000311")]
	[FieldOffset(Offset = "0x150")]
	[HideInInspector]
	public readonly SyncVar<string> playerBody;

	[Token(Token = "0x4000312")]
	[FieldOffset(Offset = "0x158")]
	private bool NetworkInitialize___EarlyUpdateCosmeticsAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000313")]
	[FieldOffset(Offset = "0x159")]
	private bool NetworkInitialize__LateUpdateCosmeticsAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000403")]
	[Address(RVA = "0x4ADE20", Offset = "0x4AC820", VA = "0x1804ADE20", Slot = "7")]
	public override void OnStartNetwork()
	{
	}

	[Token(Token = "0x6000404")]
	[Address(RVA = "0x4ADF80", Offset = "0x4AC980", VA = "0x1804ADF80", Slot = "9")]
	public override void OnStopNetwork()
	{
	}

	[Token(Token = "0x6000405")]
	[Address(RVA = "0x4AE0E0", Offset = "0x4ACAE0", VA = "0x1804AE0E0", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x6000406")]
	[Address(RVA = "0x4AE210", Offset = "0x4ACC10", VA = "0x1804AE210")]
	[ServerRpc]
	public void CMDInitializeCosmetics(int color, string hat, string body)
	{
	}

	[Token(Token = "0x6000407")]
	[Address(RVA = "0x4AE220", Offset = "0x4ACC20", VA = "0x1804AE220")]
	public void SendPlayerColor(int oldValue, int newValue, bool asServer)
	{
	}

	[Token(Token = "0x6000408")]
	[Address(RVA = "0x4AE8C0", Offset = "0x4AD2C0", VA = "0x1804AE8C0")]
	public void SendPlayerHat(string oldValue, string newValue, bool asServer)
	{
	}

	[Token(Token = "0x6000409")]
	[Address(RVA = "0x4AED10", Offset = "0x4AD710", VA = "0x1804AED10")]
	public void SendPlayerBody(string oldValue, string newValue, bool asServer)
	{
	}

	[Token(Token = "0x600040A")]
	[Address(RVA = "0x4AF520", Offset = "0x4ADF20", VA = "0x1804AF520")]
	public UpdateCosmetics()
	{
	}

	[Token(Token = "0x600040B")]
	[Address(RVA = "0x4AF770", Offset = "0x4AE170", VA = "0x1804AF770", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x600040C")]
	[Address(RVA = "0x4AF880", Offset = "0x4AE280", VA = "0x1804AF880", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600040D")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x600040E")]
	[Address(RVA = "0x4AF900", Offset = "0x4AE300", VA = "0x1804AF900")]
	private void RpcWriter___Server_CMDInitializeCosmetics_26082628(int color, string hat, string body)
	{
	}

	[Token(Token = "0x600040F")]
	[Address(RVA = "0x4AFB00", Offset = "0x4AE500", VA = "0x1804AFB00")]
	public void RpcLogic___CMDInitializeCosmetics_26082628(int color, string hat, string body)
	{
	}

	[Token(Token = "0x6000410")]
	[Address(RVA = "0x4AFC10", Offset = "0x4AE610", VA = "0x1804AFC10")]
	private void RpcReader___Server_CMDInitializeCosmetics_26082628(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x6000411")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
