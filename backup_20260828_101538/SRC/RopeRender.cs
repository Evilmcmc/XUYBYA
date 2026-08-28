using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000062")]
public class RopeRender : MonoBehaviour
{
	[Token(Token = "0x4000181")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private Transform[] positions;

	[Token(Token = "0x4000182")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private LineRenderer lineRenderer;

	[Token(Token = "0x600027B")]
	[Address(RVA = "0x48A2A0", Offset = "0x488CA0", VA = "0x18048A2A0")]
	private void Start()
	{
	}

	[Token(Token = "0x600027C")]
	[Address(RVA = "0x48A2D0", Offset = "0x488CD0", VA = "0x18048A2D0")]
	private void LateUpdate()
	{
	}

	[Token(Token = "0x600027D")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public RopeRender()
	{
	}
}
