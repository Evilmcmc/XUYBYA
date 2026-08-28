using System.Collections.Generic;
using Il2CppDummyDll;
using UnityEngine;

namespace GPUInstancer;

[Token(Token = "0x200014A")]
public class ShaderGraphVariationsController : MonoBehaviour
{
	[Token(Token = "0x40007D6")]
	[FieldOffset(Offset = "0x20")]
	public GPUInstancerPrefab prefab;

	[Token(Token = "0x40007D7")]
	[FieldOffset(Offset = "0x28")]
	public GPUInstancerPrefabManager prefabManager;

	[Token(Token = "0x40007D8")]
	[FieldOffset(Offset = "0x30")]
	public int instances;

	[Token(Token = "0x40007D9")]
	[FieldOffset(Offset = "0x38")]
	private string bufferName;

	[Token(Token = "0x40007DA")]
	[FieldOffset(Offset = "0x40")]
	private List<GPUInstancerPrefab> goList;

	[Token(Token = "0x6000C11")]
	[Address(RVA = "0x553A80", Offset = "0x552480", VA = "0x180553A80")]
	private void Start()
	{
	}

	[Token(Token = "0x6000C12")]
	[Address(RVA = "0x5543D0", Offset = "0x552DD0", VA = "0x1805543D0")]
	public ShaderGraphVariationsController()
	{
	}
}
