using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using Steamworks;
using UnityEngine;
using UnityEngine.Audio;

[Token(Token = "0x20000B5")]
public class ResourceManager : MonoBehaviour
{
	[Token(Token = "0x40003E6")]
	[FieldOffset(Offset = "0x20")]
	private Callback<DownloadItemResult_t> _downloadItemResult;

	[Token(Token = "0x40003E7")]
	[FieldOffset(Offset = "0x0")]
	[HideInInspector]
	public static ResourceManager singleton;

	[Token(Token = "0x40003E8")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private GameObject spawnPoint;

	[Token(Token = "0x40003E9")]
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	private GameObject weaponSpawn;

	[Token(Token = "0x40003EA")]
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	private AudioMixerGroup musicMixerGroup;

	[Token(Token = "0x40003EB")]
	[FieldOffset(Offset = "0x8")]
	[HideInInspector]
	public static List<CustomMap> workShopMaps;

	[Token(Token = "0x60005B0")]
	[Address(RVA = "0x4CEF80", Offset = "0x4CD980", VA = "0x1804CEF80")]
	private void OnEnable()
	{
	}

	[Token(Token = "0x60005B1")]
	[Address(RVA = "0x4CF050", Offset = "0x4CDA50", VA = "0x1804CF050")]
	private void OnDisable()
	{
	}

	[Token(Token = "0x60005B2")]
	[Address(RVA = "0x4CF0F0", Offset = "0x4CDAF0", VA = "0x1804CF0F0")]
	private void OnDownloadItemCallback(DownloadItemResult_t result)
	{
	}

	[Token(Token = "0x60005B3")]
	[Address(RVA = "0x4CF210", Offset = "0x4CDC10", VA = "0x1804CF210")]
	private void Start()
	{
	}

	[Token(Token = "0x60005B4")]
	[Address(RVA = "0x4CF4D0", Offset = "0x4CDED0", VA = "0x1804CF4D0")]
	public PublishedFileId_t[] GetSubscribedContent()
	{
		return null;
	}

	[Token(Token = "0x60005B5")]
	[Address(RVA = "0x4CF540", Offset = "0x4CDF40", VA = "0x1804CF540")]
	public void ProcessSubscription(PublishedFileId_t fileId)
	{
	}

	[Token(Token = "0x60005B6")]
	[Address(RVA = "0x4CFBC0", Offset = "0x4CE5C0", VA = "0x1804CFBC0")]
	public void DownloadFile(ulong fileID)
	{
	}

	[Token(Token = "0x60005B7")]
	[Address(RVA = "0x4D0590", Offset = "0x4CEF90", VA = "0x1804D0590")]
	public void OnSubscription()
	{
	}

	[Token(Token = "0x60005B8")]
	[Address(RVA = "0x4D0640", Offset = "0x4CF040", VA = "0x1804D0640")]
	[IteratorStateMachine(typeof(_003CLoadDownloadedLevels_003Ed__14))]
	private IEnumerator LoadDownloadedLevels(string path, PublishedFileId_t fileId)
	{
		return null;
	}

	[Token(Token = "0x60005B9")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public ResourceManager()
	{
	}
}
