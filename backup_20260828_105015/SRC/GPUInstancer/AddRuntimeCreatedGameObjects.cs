using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using UnityEngine;

namespace GPUInstancer;

[Token(Token = "0x200013D")]
public class AddRuntimeCreatedGameObjects : MonoBehaviour
{
	[Token(Token = "0x4000773")]
	[FieldOffset(Offset = "0x20")]
	public GPUInstancerPrefabManager prefabManager;

	[Token(Token = "0x4000774")]
	[FieldOffset(Offset = "0x28")]
	public Material material;

	[Token(Token = "0x4000775")]
	[FieldOffset(Offset = "0x30")]
	private List<GameObject> instanceList;

	[Token(Token = "0x4000776")]
	[FieldOffset(Offset = "0x38")]
	private GPUInstancerPrefabPrototype prototype;

	[Token(Token = "0x4000777")]
	[FieldOffset(Offset = "0x40")]
	private GameObject prototypeGameObject;

	[Token(Token = "0x6000BC8")]
	[Address(RVA = "0x54C0A0", Offset = "0x54AAA0", VA = "0x18054C0A0")]
	private void Start()
	{
	}

	[Token(Token = "0x6000BC9")]
	[Address(RVA = "0x54C630", Offset = "0x54B030", VA = "0x18054C630")]
	[IteratorStateMachine(typeof(_003CAddRemoveAtRuntime_003Ed__6))]
	private IEnumerator AddRemoveAtRuntime()
	{
		return null;
	}

	[Token(Token = "0x6000BCA")]
	[Address(RVA = "0x54C6D0", Offset = "0x54B0D0", VA = "0x18054C6D0")]
	public void ClearInstances()
	{
	}

	[Token(Token = "0x6000BCB")]
	[Address(RVA = "0x54C8C0", Offset = "0x54B2C0", VA = "0x18054C8C0")]
	public void SetMaterial()
	{
	}

	[Token(Token = "0x6000BCC")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public AddRuntimeCreatedGameObjects()
	{
	}
}
