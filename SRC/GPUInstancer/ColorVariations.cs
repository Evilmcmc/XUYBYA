using System.Collections.Generic;
using Il2CppDummyDll;
using UnityEngine;

namespace GPUInstancer;

[Token(Token = "0x200013F")]
public class ColorVariations : MonoBehaviour
{
	[Token(Token = "0x400077D")]
	[FieldOffset(Offset = "0x20")]
	public GPUInstancerPrefab prefab;

	[Token(Token = "0x400077E")]
	[FieldOffset(Offset = "0x28")]
	public GPUInstancerPrefabManager prefabManager;

	[Token(Token = "0x400077F")]
	[FieldOffset(Offset = "0x30")]
	public int instances;

	[Token(Token = "0x4000780")]
	[FieldOffset(Offset = "0x38")]
	public string bufferName;

	[Token(Token = "0x4000781")]
	[FieldOffset(Offset = "0x40")]
	private List<GPUInstancerPrefab> goList;

	[Token(Token = "0x6000BD4")]
	[Address(RVA = "0x54D430", Offset = "0x54BE30", VA = "0x18054D430")]
	private void Start()
	{
	}

	[Token(Token = "0x6000BD5")]
	[Address(RVA = "0x54DCC0", Offset = "0x54C6C0", VA = "0x18054DCC0")]
	private void Update()
	{
	}

	[Token(Token = "0x6000BD6")]
	[Address(RVA = "0x54DFC0", Offset = "0x54C9C0", VA = "0x18054DFC0")]
	public ColorVariations()
	{
	}
}
