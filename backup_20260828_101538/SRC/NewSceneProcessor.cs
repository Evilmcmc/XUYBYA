using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Managing.Scened;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

[Token(Token = "0x2000131")]
public sealed class NewSceneProcessor : SceneProcessorBase
{
	[Serializable]
	[Token(Token = "0x2000132")]
	private class SceneReference
	{
		[Token(Token = "0x40006FD")]
		[FieldOffset(Offset = "0x10")]
		public string name;

		[Token(Token = "0x40006FE")]
		[FieldOffset(Offset = "0x18")]
		public AssetReference reference;

		[Token(Token = "0x6000B86")]
		[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
		public SceneReference()
		{
		}
	}

	[Token(Token = "0x40006F6")]
	[FieldOffset(Offset = "0x38")]
	private readonly Dictionary<int, AsyncOperationHandle<SceneInstance>> _loadedScenesByHandle;

	[Token(Token = "0x40006F7")]
	[FieldOffset(Offset = "0x40")]
	private readonly List<Scene> _loadedScenes;

	[Token(Token = "0x40006F8")]
	[FieldOffset(Offset = "0x48")]
	private readonly List<AsyncOperationHandle<SceneInstance>> _loadingAsyncOperations;

	[Token(Token = "0x40006F9")]
	[FieldOffset(Offset = "0x50")]
	private AsyncOperationHandle<SceneInstance> _currentAsyncOperation;

	[Token(Token = "0x40006FA")]
	[FieldOffset(Offset = "0x68")]
	private AsyncOperation _currentBasicAsyncOperation;

	[Token(Token = "0x40006FB")]
	[FieldOffset(Offset = "0x70")]
	private Dictionary<string, AssetReference> _compiledAddressableReferences;

	[Token(Token = "0x40006FC")]
	[FieldOffset(Offset = "0x78")]
	[Tooltip("List of scene names and refs for which we allow loading.")]
	[SerializeField]
	private List<SceneReference> _rawSceneReferences;

	[Token(Token = "0x6000B78")]
	[Address(RVA = "0x5429C0", Offset = "0x5413C0", VA = "0x1805429C0")]
	private void Awake()
	{
	}

	[Token(Token = "0x6000B79")]
	[Address(RVA = "0x542BB0", Offset = "0x5415B0", VA = "0x180542BB0", Slot = "5")]
	public override void LoadStart(LoadQueueData queueData)
	{
	}

	[Token(Token = "0x6000B7A")]
	[Address(RVA = "0x542BB0", Offset = "0x5415B0", VA = "0x180542BB0", Slot = "6")]
	public override void LoadEnd(LoadQueueData queueData)
	{
	}

	[Token(Token = "0x6000B7B")]
	[Address(RVA = "0x542BC0", Offset = "0x5415C0", VA = "0x180542BC0")]
	private void ResetProcessor()
	{
	}

	[Token(Token = "0x6000B7C")]
	[Address(RVA = "0x542C30", Offset = "0x541630", VA = "0x180542C30")]
	public static bool IsValidScene(string sceneName)
	{
		return default(bool);
	}

	[Token(Token = "0x6000B7D")]
	[Address(RVA = "0x542E70", Offset = "0x541870", VA = "0x180542E70", Slot = "11")]
	public override void BeginLoadAsync(string sceneName, LoadSceneParameters parameters)
	{
	}

	[Token(Token = "0x6000B7E")]
	[Address(RVA = "0x543110", Offset = "0x541B10", VA = "0x180543110", Slot = "12")]
	public override void BeginUnloadAsync(Scene scene)
	{
	}

	[Token(Token = "0x6000B7F")]
	[Address(RVA = "0x5434C0", Offset = "0x541EC0", VA = "0x1805434C0", Slot = "13")]
	public override bool IsPercentComplete()
	{
		return default(bool);
	}

	[Token(Token = "0x6000B80")]
	[Address(RVA = "0x543670", Offset = "0x542070", VA = "0x180543670", Slot = "14")]
	public override float GetPercentComplete()
	{
		return default(float);
	}

	[Token(Token = "0x6000B81")]
	[Address(RVA = "0x543780", Offset = "0x542180", VA = "0x180543780", Slot = "16")]
	public override List<Scene> GetLoadedScenes()
	{
		return null;
	}

	[Token(Token = "0x6000B82")]
	[Address(RVA = "0x543790", Offset = "0x542190", VA = "0x180543790")]
	public void AddLoadedScene(AsyncOperationHandle<SceneInstance> loadHandle)
	{
	}

	[Token(Token = "0x6000B83")]
	[Address(RVA = "0x543A40", Offset = "0x542440", VA = "0x180543A40", Slot = "17")]
	public override void ActivateLoadedScenes()
	{
	}

	[Token(Token = "0x6000B84")]
	[Address(RVA = "0x543CD0", Offset = "0x5426D0", VA = "0x180543CD0", Slot = "18")]
	[IteratorStateMachine(typeof(_003CAsyncsIsDone_003Ed__19))]
	public override IEnumerator AsyncsIsDone()
	{
		return null;
	}

	[Token(Token = "0x6000B85")]
	[Address(RVA = "0x543D70", Offset = "0x542770", VA = "0x180543D70")]
	public NewSceneProcessor()
	{
	}
}
