using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.UI;

namespace GPUInstancer;

[Token(Token = "0x2000138")]
public class AddRemoveInstances : MonoBehaviour
{
	[Token(Token = "0x400075B")]
	[FieldOffset(Offset = "0x20")]
	public GPUInstancerPrefab prefab;

	[Token(Token = "0x400075C")]
	[FieldOffset(Offset = "0x28")]
	public GPUInstancerPrefabManager prefabManager;

	[Token(Token = "0x400075D")]
	[FieldOffset(Offset = "0x30")]
	private Transform parentTransform;

	[Token(Token = "0x400075E")]
	[FieldOffset(Offset = "0x38")]
	private int instanceCount;

	[Token(Token = "0x400075F")]
	[FieldOffset(Offset = "0x40")]
	private List<GPUInstancerPrefab> instancesList;

	[Token(Token = "0x4000760")]
	[FieldOffset(Offset = "0x48")]
	private List<GPUInstancerPrefab> extraInstancesList;

	[Token(Token = "0x4000761")]
	[FieldOffset(Offset = "0x50")]
	private Toggle addRemoveInstantlyToggle;

	[Token(Token = "0x4000762")]
	[FieldOffset(Offset = "0x58")]
	private Canvas guiCanvas;

	[Token(Token = "0x6000BA3")]
	[Address(RVA = "0x54A1F0", Offset = "0x548BF0", VA = "0x18054A1F0")]
	private void Awake()
	{
	}

	[Token(Token = "0x6000BA4")]
	[Address(RVA = "0x54A470", Offset = "0x548E70", VA = "0x18054A470")]
	private void Start()
	{
	}

	[Token(Token = "0x6000BA5")]
	[Address(RVA = "0x54A6C0", Offset = "0x5490C0", VA = "0x18054A6C0")]
	public void AddInstances()
	{
	}

	[Token(Token = "0x6000BA6")]
	[Address(RVA = "0x54A770", Offset = "0x549170", VA = "0x18054A770")]
	public void RemoveInstances()
	{
	}

	[Token(Token = "0x6000BA7")]
	[Address(RVA = "0x54A820", Offset = "0x549220", VA = "0x18054A820")]
	public void AddExtraInstances()
	{
	}

	[Token(Token = "0x6000BA8")]
	[Address(RVA = "0x54A8D0", Offset = "0x5492D0", VA = "0x18054A8D0")]
	public void RemoveExtraInstances()
	{
	}

	[Token(Token = "0x6000BA9")]
	[Address(RVA = "0x54A980", Offset = "0x549380", VA = "0x18054A980")]
	[IteratorStateMachine(typeof(_003CAddInstancesAtRuntime_003Ed__14))]
	private IEnumerator AddInstancesAtRuntime()
	{
		return null;
	}

	[Token(Token = "0x6000BAA")]
	[Address(RVA = "0x54AA20", Offset = "0x549420", VA = "0x18054AA20")]
	[IteratorStateMachine(typeof(_003CRemoveInstancesAtRuntime_003Ed__15))]
	private IEnumerator RemoveInstancesAtRuntime()
	{
		return null;
	}

	[Token(Token = "0x6000BAB")]
	[Address(RVA = "0x54AAC0", Offset = "0x5494C0", VA = "0x18054AAC0")]
	[IteratorStateMachine(typeof(_003CAddExtraInstancesAtRuntime_003Ed__16))]
	private IEnumerator AddExtraInstancesAtRuntime()
	{
		return null;
	}

	[Token(Token = "0x6000BAC")]
	[Address(RVA = "0x54AB60", Offset = "0x549560", VA = "0x18054AB60")]
	[IteratorStateMachine(typeof(_003CRemoveExtraInstancesAtRuntime_003Ed__17))]
	private IEnumerator RemoveExtraInstancesAtRuntime()
	{
		return null;
	}

	[Token(Token = "0x6000BAD")]
	[Address(RVA = "0x54AC00", Offset = "0x549600", VA = "0x18054AC00")]
	private void LockAllButtons()
	{
	}

	[Token(Token = "0x6000BAE")]
	[Address(RVA = "0x54ADC0", Offset = "0x5497C0", VA = "0x18054ADC0")]
	private void EnableButton(string buttonName)
	{
	}

	[Token(Token = "0x6000BAF")]
	[Address(RVA = "0x54AEB0", Offset = "0x5498B0", VA = "0x18054AEB0")]
	public AddRemoveInstances()
	{
	}
}
