using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200002D")]
public class CrusherObstacle : NetworkBehaviour
{
	[Token(Token = "0x4000085")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	public float frequency;

	[Token(Token = "0x4000086")]
	[FieldOffset(Offset = "0xFC")]
	[SerializeField]
	public float magnitude;

	[Token(Token = "0x4000087")]
	[FieldOffset(Offset = "0x100")]
	private Vector3 startPosition;

	[Token(Token = "0x4000088")]
	[FieldOffset(Offset = "0x10C")]
	private bool NetworkInitialize___EarlyCrusherObstacleAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000089")]
	[FieldOffset(Offset = "0x10D")]
	private bool NetworkInitialize__LateCrusherObstacleAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60000D7")]
	[Address(RVA = "0x465120", Offset = "0x463B20", VA = "0x180465120")]
	private float EaseIn(float t)
	{
		return default(float);
	}

	[Token(Token = "0x60000D8")]
	[Address(RVA = "0x465130", Offset = "0x463B30", VA = "0x180465130")]
	private float Flip(float x)
	{
		return default(float);
	}

	[Token(Token = "0x60000D9")]
	[Address(RVA = "0x465140", Offset = "0x463B40", VA = "0x180465140")]
	private float Spike(float t)
	{
		return default(float);
	}

	[Token(Token = "0x60000DA")]
	[Address(RVA = "0x465170", Offset = "0x463B70", VA = "0x180465170", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x60000DB")]
	[Address(RVA = "0x465250", Offset = "0x463C50", VA = "0x180465250")]
	private void Update()
	{
	}

	[Token(Token = "0x60000DC")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public CrusherObstacle()
	{
	}

	[Token(Token = "0x60000DD")]
	[Address(RVA = "0x464E20", Offset = "0x463820", VA = "0x180464E20", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60000DE")]
	[Address(RVA = "0x464E40", Offset = "0x463840", VA = "0x180464E40", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60000DF")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60000E0")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}
