using Il2CppDummyDll;
using UnityEngine;

namespace GPUInstancer;

[Token(Token = "0x2000153")]
public class ShieldImpact : MonoBehaviour
{
	[Token(Token = "0x400081B")]
	[FieldOffset(Offset = "0x20")]
	private float impactTime;

	[Token(Token = "0x400081C")]
	[FieldOffset(Offset = "0x28")]
	private Material impactMat;

	[Token(Token = "0x6000C47")]
	[Address(RVA = "0x55A250", Offset = "0x558C50", VA = "0x18055A250")]
	private void Awake()
	{
	}

	[Token(Token = "0x6000C48")]
	[Address(RVA = "0x55A390", Offset = "0x558D90", VA = "0x18055A390")]
	private void Update()
	{
	}

	[Token(Token = "0x6000C49")]
	[Address(RVA = "0x55A480", Offset = "0x558E80", VA = "0x18055A480")]
	private void OnCollisionEnter(Collision collision)
	{
	}

	[Token(Token = "0x6000C4A")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public ShieldImpact()
	{
	}
}
