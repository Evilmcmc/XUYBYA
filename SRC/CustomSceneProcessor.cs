using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Managing.Scened;
using Il2CppDummyDll;
using Steamworks;
using UnityEngine;
using UnityEngine.SceneManagement;

[Token(Token = "0x20000DB")]
public class CustomSceneProcessor : DefaultSceneProcessor
{
	[Token(Token = "0x4000485")]
	[FieldOffset(Offset = "0x50")]
	private Callback<DownloadItemResult_t> downloadItemResult;

	[Token(Token = "0x4000486")]
	[FieldOffset(Offset = "0x0")]
	private static AssetBundle loadedLevel;

	[Token(Token = "0x4000487")]
	[FieldOffset(Offset = "0x58")]
	private LoadSceneParameters sceneLoadParameters;

	[Token(Token = "0x6000681")]
	[Address(RVA = "0x4DF910", Offset = "0x4DE310", VA = "0x1804DF910", Slot = "13")]
	public override bool IsPercentComplete()
	{
		return default(bool);
	}

	[Token(Token = "0x6000682")]
	[Address(RVA = "0x4DF940", Offset = "0x4DE340", VA = "0x1804DF940", Slot = "14")]
	public override float GetPercentComplete()
	{
		return default(float);
	}

	[Token(Token = "0x6000683")]
	[Address(RVA = "0x4DF9C0", Offset = "0x4DE3C0", VA = "0x1804DF9C0", Slot = "11")]
	public override void BeginLoadAsync(string sceneName, LoadSceneParameters parameters)
	{
	}

	[Token(Token = "0x6000684")]
	[Address(RVA = "0x4DFCD0", Offset = "0x4DE6D0", VA = "0x1804DFCD0")]
	[IteratorStateMachine(typeof(_003CPrepareToDownload_003Ed__6))]
	private IEnumerator PrepareToDownload()
	{
		return null;
	}

	[Token(Token = "0x6000685")]
	[Address(RVA = "0x4DFD70", Offset = "0x4DE770", VA = "0x1804DFD70")]
	private bool IsOldWorkshopMap(PublishedFileId_t publishedFileId)
	{
		return default(bool);
	}

	[Token(Token = "0x6000686")]
	[Address(RVA = "0x4DFF30", Offset = "0x4DE930", VA = "0x1804DFF30")]
	private void OnDownloadItemCallback(DownloadItemResult_t result)
	{
	}

	[Token(Token = "0x6000687")]
	[Address(RVA = "0x4E0C90", Offset = "0x4DF690", VA = "0x1804E0C90")]
	[IteratorStateMachine(typeof(_003COld_LoadLevel_003Ed__9))]
	private IEnumerator Old_LoadLevel(string path)
	{
		return null;
	}

	[Token(Token = "0x6000688")]
	[Address(RVA = "0x4E0D90", Offset = "0x4DF790", VA = "0x1804E0D90")]
	[IteratorStateMachine(typeof(_003CDisconnect_003Ed__10))]
	private IEnumerator Disconnect()
	{
		return null;
	}

	[Token(Token = "0x6000689")]
	[Address(RVA = "0x4E0DD0", Offset = "0x4DF7D0", VA = "0x1804E0DD0")]
	[IteratorStateMachine(typeof(_003CNew_LoadLevel_003Ed__11))]
	private IEnumerator New_LoadLevel(string cached_contents_filename)
	{
		return null;
	}

	[Token(Token = "0x600068A")]
	[Address(RVA = "0x4E0ED0", Offset = "0x4DF8D0", VA = "0x1804E0ED0", Slot = "12")]
	public override void BeginUnloadAsync(Scene scene)
	{
	}

	[Token(Token = "0x600068B")]
	[Address(RVA = "0x4E1050", Offset = "0x4DFA50", VA = "0x1804E1050")]
	[IteratorStateMachine(typeof(_003CUnloadLevel_003Ed__13))]
	private IEnumerator UnloadLevel(Scene scene)
	{
		return null;
	}

	[Token(Token = "0x600068C")]
	[Address(RVA = "0x4E1100", Offset = "0x4DFB00", VA = "0x1804E1100")]
	public CustomSceneProcessor()
	{
	}
}
