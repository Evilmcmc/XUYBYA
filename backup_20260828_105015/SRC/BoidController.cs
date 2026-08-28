using GPUInstancer;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000109")]
public class BoidController : MonoBehaviour
{
	[Token(Token = "0x200010A")]
	public static class BoidProperties
	{
		[Token(Token = "0x4000584")]
		[FieldOffset(Offset = "0x0")]
		public static readonly int BP_boidsData;

		[Token(Token = "0x4000585")]
		[FieldOffset(Offset = "0x4")]
		public static readonly int BP_bufferSize;

		[Token(Token = "0x4000586")]
		[FieldOffset(Offset = "0x8")]
		public static readonly int BP_controllerTransform;

		[Token(Token = "0x4000587")]
		[FieldOffset(Offset = "0xC")]
		public static readonly int BP_controllerVelocity;

		[Token(Token = "0x4000588")]
		[FieldOffset(Offset = "0x10")]
		public static readonly int BP_controllerVelocityVariation;

		[Token(Token = "0x4000589")]
		[FieldOffset(Offset = "0x14")]
		public static readonly int BP_controllerRotationCoeff;

		[Token(Token = "0x400058A")]
		[FieldOffset(Offset = "0x18")]
		public static readonly int BP_controllerNeighborDist;

		[Token(Token = "0x400058B")]
		[FieldOffset(Offset = "0x1C")]
		public static readonly int BP_time;

		[Token(Token = "0x400058C")]
		[FieldOffset(Offset = "0x20")]
		public static readonly int BP_deltaTime;

		[Token(Token = "0x400058D")]
		[FieldOffset(Offset = "0x24")]
		public static readonly int BP_noiseTexture;
	}

	[Token(Token = "0x4000575")]
	[FieldOffset(Offset = "0x20")]
	public int spawnCount;

	[Token(Token = "0x4000576")]
	[FieldOffset(Offset = "0x24")]
	public float spawnRadius;

	[Token(Token = "0x4000577")]
	[FieldOffset(Offset = "0x28")]
	[Range(0.1f, 20f)]
	public float velocity;

	[Token(Token = "0x4000578")]
	[FieldOffset(Offset = "0x2C")]
	[Range(0f, 0.9f)]
	public float velocityVariation;

	[Token(Token = "0x4000579")]
	[FieldOffset(Offset = "0x30")]
	[Range(0.1f, 20f)]
	public float rotationCoeff;

	[Token(Token = "0x400057A")]
	[FieldOffset(Offset = "0x34")]
	[Range(0.1f, 10f)]
	public float neighborDist;

	[Token(Token = "0x400057B")]
	[FieldOffset(Offset = "0x38")]
	public Transform centerTransform;

	[Token(Token = "0x400057C")]
	[FieldOffset(Offset = "0x40")]
	public Texture2D noiseTexture;

	[Token(Token = "0x400057D")]
	[FieldOffset(Offset = "0x48")]
	public string variationBufferName;

	[Token(Token = "0x400057E")]
	[FieldOffset(Offset = "0x50")]
	private Matrix4x4[] _spawnArray;

	[Token(Token = "0x400057F")]
	[FieldOffset(Offset = "0x58")]
	private Vector4[] _variationArray;

	[Token(Token = "0x4000580")]
	[FieldOffset(Offset = "0x60")]
	private GPUInstancerPrefabManager _prefabManager;

	[Token(Token = "0x4000581")]
	[FieldOffset(Offset = "0x68")]
	private ComputeShader _gpuiBoidsCS;

	[Token(Token = "0x4000582")]
	[FieldOffset(Offset = "0x70")]
	private float[] _centerTransformArray;

	[Token(Token = "0x4000583")]
	[FieldOffset(Offset = "0x78")]
	private ComputeBuffer _transformDataBuffer;

	[Token(Token = "0x6000806")]
	[Address(RVA = "0x4F8AD0", Offset = "0x4F74D0", VA = "0x1804F8AD0")]
	private void Start()
	{
	}

	[Token(Token = "0x6000807")]
	[Address(RVA = "0x4F8EC0", Offset = "0x4F78C0", VA = "0x1804F8EC0")]
	public void Spawn(int index)
	{
	}

	[Token(Token = "0x6000808")]
	[Address(RVA = "0x4F9220", Offset = "0x4F7C20", VA = "0x1804F9220")]
	private void Update()
	{
	}

	[Token(Token = "0x6000809")]
	[Address(RVA = "0x4F9810", Offset = "0x4F8210", VA = "0x1804F9810")]
	public BoidController()
	{
	}
}
