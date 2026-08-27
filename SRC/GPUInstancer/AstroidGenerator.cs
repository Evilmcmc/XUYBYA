using System.Collections.Generic;
using Il2CppDummyDll;
using UnityEngine;

namespace GPUInstancer;

[Token(Token = "0x2000143")]
public class AstroidGenerator : MonoBehaviour
{
	[Token(Token = "0x400079B")]
	[FieldOffset(Offset = "0x20")]
	[Range(0f, 200000f)]
	public int count;

	[Token(Token = "0x400079C")]
	[FieldOffset(Offset = "0x28")]
	public List<GPUInstancerPrefab> asteroidObjects;

	[Token(Token = "0x400079D")]
	[FieldOffset(Offset = "0x30")]
	public GPUInstancerPrefabManager prefabManager;

	[Token(Token = "0x400079E")]
	[FieldOffset(Offset = "0x38")]
	public Transform centerTransform;

	[Token(Token = "0x400079F")]
	[FieldOffset(Offset = "0x40")]
	private List<GPUInstancerPrefab> asteroidInstances;

	[Token(Token = "0x40007A0")]
	[FieldOffset(Offset = "0x48")]
	private int instantiatedCount;

	[Token(Token = "0x40007A1")]
	[FieldOffset(Offset = "0x4C")]
	private Vector3 center;

	[Token(Token = "0x40007A2")]
	[FieldOffset(Offset = "0x58")]
	private Vector3 allocatedPos;

	[Token(Token = "0x40007A3")]
	[FieldOffset(Offset = "0x64")]
	private Quaternion allocatedRot;

	[Token(Token = "0x40007A4")]
	[FieldOffset(Offset = "0x74")]
	private Vector3 allocatedLocalEulerRot;

	[Token(Token = "0x40007A5")]
	[FieldOffset(Offset = "0x80")]
	private Vector3 allocatedLocalScale;

	[Token(Token = "0x40007A6")]
	[FieldOffset(Offset = "0x90")]
	private GPUInstancerPrefab allocatedGO;

	[Token(Token = "0x40007A7")]
	[FieldOffset(Offset = "0x98")]
	private GameObject goParent;

	[Token(Token = "0x40007A8")]
	[FieldOffset(Offset = "0xA0")]
	private float allocatedLocalScaleFactor;

	[Token(Token = "0x40007A9")]
	[FieldOffset(Offset = "0xA4")]
	private int columnSize;

	[Token(Token = "0x40007AA")]
	[FieldOffset(Offset = "0xA8")]
	private int columnSpace;

	[Token(Token = "0x6000BDF")]
	[Address(RVA = "0x54F570", Offset = "0x54DF70", VA = "0x18054F570")]
	private void Awake()
	{
	}

	[Token(Token = "0x6000BE0")]
	[Address(RVA = "0x54FC10", Offset = "0x54E610", VA = "0x18054FC10")]
	private void Start()
	{
	}

	[Token(Token = "0x6000BE1")]
	[Address(RVA = "0x54FD60", Offset = "0x54E760", VA = "0x18054FD60")]
	private void SetRandomPosInCircle(Vector3 center, int column, float radius)
	{
	}

	[Token(Token = "0x6000BE2")]
	[Address(RVA = "0x54FEE0", Offset = "0x54E8E0", VA = "0x18054FEE0")]
	private GPUInstancerPrefab InstantiateInCircle(Vector3 center, int column)
	{
		return null;
	}

	[Token(Token = "0x6000BE3")]
	[Address(RVA = "0x5507A0", Offset = "0x54F1A0", VA = "0x1805507A0")]
	public AstroidGenerator()
	{
	}
}
