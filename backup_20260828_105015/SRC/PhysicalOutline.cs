using System;
using System.Collections.Generic;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200000B")]
[DisallowMultipleComponent]
public class PhysicalOutline : MonoBehaviour
{
	[Token(Token = "0x200000C")]
	public enum Mode
	{
		[Token(Token = "0x400001F")]
		OutlineAll,
		[Token(Token = "0x4000020")]
		OutlineVisible,
		[Token(Token = "0x4000021")]
		OutlineHidden,
		[Token(Token = "0x4000022")]
		OutlineAndSilhouette,
		[Token(Token = "0x4000023")]
		SilhouetteOnly
	}

	[Serializable]
	[Token(Token = "0x200000D")]
	private class ListVector3
	{
		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x10")]
		public List<Vector3> data;

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
		public ListVector3()
		{
		}
	}

	[Token(Token = "0x4000013")]
	[FieldOffset(Offset = "0x0")]
	private static HashSet<Mesh> registeredMeshes;

	[Token(Token = "0x4000014")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private Mode outlineMode;

	[Token(Token = "0x4000015")]
	[FieldOffset(Offset = "0x24")]
	[SerializeField]
	[ColorUsage(true, true)]
	private Color outlineColor;

	[Token(Token = "0x4000016")]
	[FieldOffset(Offset = "0x34")]
	[SerializeField]
	[Range(0f, 10f)]
	private float outlineWidth;

	[Token(Token = "0x4000017")]
	[FieldOffset(Offset = "0x38")]
	[Header("Optional")]
	[SerializeField]
	[Tooltip("Precompute enabled: Per-vertex calculations are performed in the editor and serialized with the object. Precompute disabled: Per-vertex calculations are performed at runtime in Awake(). This may cause a pause for large meshes.")]
	private bool precomputeOutline;

	[Token(Token = "0x4000018")]
	[FieldOffset(Offset = "0x40")]
	[SerializeField]
	[HideInInspector]
	private List<Mesh> bakeKeys;

	[Token(Token = "0x4000019")]
	[FieldOffset(Offset = "0x48")]
	[SerializeField]
	[HideInInspector]
	private List<ListVector3> bakeValues;

	[Token(Token = "0x400001A")]
	[FieldOffset(Offset = "0x50")]
	private Renderer[] renderers;

	[Token(Token = "0x400001B")]
	[FieldOffset(Offset = "0x58")]
	private Material outlineMaskMaterial;

	[Token(Token = "0x400001C")]
	[FieldOffset(Offset = "0x60")]
	private Material outlineFillMaterial;

	[Token(Token = "0x400001D")]
	[FieldOffset(Offset = "0x68")]
	private bool needsUpdate;

	[Token(Token = "0x17000013")]
	public Mode OutlineMode
	{
		[Token(Token = "0x6000037")]
		[Address(RVA = "0x455000", Offset = "0x453A00", VA = "0x180455000")]
		get
		{
			return default(Mode);
		}
		[Token(Token = "0x6000038")]
		[Address(RVA = "0x455010", Offset = "0x453A10", VA = "0x180455010")]
		set
		{
		}
	}

	[Token(Token = "0x17000014")]
	public Color OutlineColor
	{
		[Token(Token = "0x6000039")]
		[Address(RVA = "0x455020", Offset = "0x453A20", VA = "0x180455020")]
		get
		{
			return default(Color);
		}
		[Token(Token = "0x600003A")]
		[Address(RVA = "0x455030", Offset = "0x453A30", VA = "0x180455030")]
		set
		{
		}
	}

	[Token(Token = "0x17000015")]
	public float OutlineWidth
	{
		[Token(Token = "0x600003B")]
		[Address(RVA = "0x455040", Offset = "0x453A40", VA = "0x180455040")]
		get
		{
			return default(float);
		}
		[Token(Token = "0x600003C")]
		[Address(RVA = "0x455050", Offset = "0x453A50", VA = "0x180455050")]
		set
		{
		}
	}

	[Token(Token = "0x600003D")]
	[Address(RVA = "0x455060", Offset = "0x453A60", VA = "0x180455060")]
	private void Awake()
	{
	}

	[Token(Token = "0x600003E")]
	[Address(RVA = "0x4552D0", Offset = "0x453CD0", VA = "0x1804552D0")]
	private void OnEnable()
	{
	}

	[Token(Token = "0x600003F")]
	[Address(RVA = "0x455600", Offset = "0x454000", VA = "0x180455600")]
	private void OnValidate()
	{
	}

	[Token(Token = "0x6000040")]
	[Address(RVA = "0x455720", Offset = "0x454120", VA = "0x180455720")]
	private void Update()
	{
	}

	[Token(Token = "0x6000041")]
	[Address(RVA = "0x455740", Offset = "0x454140", VA = "0x180455740")]
	private void OnDisable()
	{
	}

	[Token(Token = "0x6000042")]
	[Address(RVA = "0x455A00", Offset = "0x454400", VA = "0x180455A00")]
	private void OnDestroy()
	{
	}

	[Token(Token = "0x6000043")]
	[Address(RVA = "0x455AE0", Offset = "0x4544E0", VA = "0x180455AE0")]
	private void Bake()
	{
	}

	[Token(Token = "0x6000044")]
	[Address(RVA = "0x455D70", Offset = "0x454770", VA = "0x180455D70")]
	private void LoadSmoothNormals()
	{
	}

	[Token(Token = "0x6000045")]
	[Address(RVA = "0x4562D0", Offset = "0x454CD0", VA = "0x1804562D0")]
	private List<Vector3> SmoothNormals(Mesh mesh)
	{
		return null;
	}

	[Token(Token = "0x6000046")]
	[Address(RVA = "0x456E90", Offset = "0x455890", VA = "0x180456E90")]
	private void CombineSubmeshes(Mesh mesh, Material[] materials)
	{
	}

	[Token(Token = "0x6000047")]
	[Address(RVA = "0x457140", Offset = "0x455B40", VA = "0x180457140")]
	private void UpdateMaterialProperties()
	{
	}

	[Token(Token = "0x6000048")]
	[Address(RVA = "0x457420", Offset = "0x455E20", VA = "0x180457420")]
	public PhysicalOutline()
	{
	}
}
