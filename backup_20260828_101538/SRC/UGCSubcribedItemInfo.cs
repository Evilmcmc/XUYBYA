using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using Steamworks;
using UnityEngine;

[Token(Token = "0x20000FF")]
public class UGCSubcribedItemInfo : MonoBehaviour
{
	[Token(Token = "0x4000536")]
	[FieldOffset(Offset = "0x20")]
	private CallResult<SteamUGCRequestUGCDetailsResult_t> OnSteamUGCRequestUGCDetailsResultCallResult;

	[Token(Token = "0x4000537")]
	[FieldOffset(Offset = "0x0")]
	private static CallResult<RemoteStorageDownloadUGCResult_t> OnDowloadUGCPreviewFileResultCallResult;

	[Token(Token = "0x4000538")]
	[FieldOffset(Offset = "0x28")]
	private List<TemporaryMapData> temporaryMapData;

	[Token(Token = "0x4000539")]
	[FieldOffset(Offset = "0x8")]
	public static List<MapToggleData> mapToggleData;

	[Token(Token = "0x60007BA")]
	[Address(RVA = "0x4F27E0", Offset = "0x4F11E0", VA = "0x1804F27E0")]
	public void GetCustomMaps()
	{
	}

	[Token(Token = "0x60007BB")]
	[Address(RVA = "0x4F2A50", Offset = "0x4F1450", VA = "0x1804F2A50")]
	private void OnDestroy()
	{
	}

	[Token(Token = "0x60007BC")]
	[Address(RVA = "0x4F2BE0", Offset = "0x4F15E0", VA = "0x1804F2BE0")]
	private PublishedFileId_t[] GetSubscribedContent()
	{
		return null;
	}

	[Token(Token = "0x60007BD")]
	[Address(RVA = "0x4F2C40", Offset = "0x4F1640", VA = "0x1804F2C40")]
	[IteratorStateMachine(typeof(_003CGetSubscribedUGCContentInfo_003Ed__7))]
	public IEnumerator GetSubscribedUGCContentInfo()
	{
		return null;
	}

	[Token(Token = "0x60007BE")]
	[Address(RVA = "0x4F2CE0", Offset = "0x4F16E0", VA = "0x1804F2CE0")]
	private void LoadMainMenu()
	{
	}

	[Token(Token = "0x60007BF")]
	[Address(RVA = "0x4F2E00", Offset = "0x4F1800", VA = "0x1804F2E00")]
	private void OnSteamUGCRequestUGCDetailsResult(SteamUGCRequestUGCDetailsResult_t pCallback, bool bIOFailure)
	{
	}

	[Token(Token = "0x60007C0")]
	[Address(RVA = "0x4F3190", Offset = "0x4F1B90", VA = "0x1804F3190")]
	private void OnRemoteStorageDownloaded(RemoteStorageDownloadUGCResult_t param, bool bIOFailure)
	{
	}

	[Token(Token = "0x60007C1")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public UGCSubcribedItemInfo()
	{
	}
}
