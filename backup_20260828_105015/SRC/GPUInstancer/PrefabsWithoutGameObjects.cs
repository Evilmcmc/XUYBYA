using System.Collections;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.UI;

namespace GPUInstancer;

[Token(Token = "0x2000146")]
public class PrefabsWithoutGameObjects : MonoBehaviour
{
	[Token(Token = "0x40007BC")]
	[FieldOffset(Offset = "0x20")]
	public GPUInstancerPrefabManager prefabManager;

	[Token(Token = "0x40007BD")]
	[FieldOffset(Offset = "0x28")]
	public GPUInstancerPrefab prefab;

	[Token(Token = "0x40007BE")]
	[FieldOffset(Offset = "0x30")]
	public int bufferSize;

	[Token(Token = "0x40007BF")]
	[FieldOffset(Offset = "0x38")]
	public Button addSphere;

	[Token(Token = "0x40007C0")]
	[FieldOffset(Offset = "0x40")]
	public Button removeSphere;

	[Token(Token = "0x40007C1")]
	[FieldOffset(Offset = "0x48")]
	public Button clearSphere;

	[Token(Token = "0x40007C2")]
	[FieldOffset(Offset = "0x50")]
	public Text sphereCountText;

	[Token(Token = "0x40007C3")]
	[FieldOffset(Offset = "0x58")]
	public Text positionUpdateFrequencyText;

	[Token(Token = "0x40007C4")]
	[FieldOffset(Offset = "0x60")]
	public Text scaleUpdateFrequencyText;

	[Token(Token = "0x40007C5")]
	[FieldOffset(Offset = "0x68")]
	public Text colorUpdateFrequencyText;

	[Token(Token = "0x40007C6")]
	[FieldOffset(Offset = "0x70")]
	public string bufferName;

	[Token(Token = "0x40007C7")]
	[FieldOffset(Offset = "0x78")]
	private Matrix4x4[] _matrix4x4Array;

	[Token(Token = "0x40007C8")]
	[FieldOffset(Offset = "0x80")]
	private int sphereCount;

	[Token(Token = "0x40007C9")]
	[FieldOffset(Offset = "0x84")]
	private float positionUpdateFrequency;

	[Token(Token = "0x40007CA")]
	[FieldOffset(Offset = "0x88")]
	private float scaleUpdateFrequency;

	[Token(Token = "0x40007CB")]
	[FieldOffset(Offset = "0x8C")]
	private float colorUpdateFrequency;

	[Token(Token = "0x40007CC")]
	[FieldOffset(Offset = "0x90")]
	private Vector4[] variationData;

	[Token(Token = "0x6000BF1")]
	[Address(RVA = "0x551C20", Offset = "0x550620", VA = "0x180551C20")]
	private void Awake()
	{
	}

	[Token(Token = "0x6000BF2")]
	[Address(RVA = "0x5520B0", Offset = "0x550AB0", VA = "0x1805520B0")]
	[IteratorStateMachine(typeof(_003CUpdatePositions_003Ed__18))]
	private IEnumerator UpdatePositions()
	{
		return null;
	}

	[Token(Token = "0x6000BF3")]
	[Address(RVA = "0x552150", Offset = "0x550B50", VA = "0x180552150")]
	[IteratorStateMachine(typeof(_003CUpdateScale_003Ed__19))]
	private IEnumerator UpdateScale()
	{
		return null;
	}

	[Token(Token = "0x6000BF4")]
	[Address(RVA = "0x5521F0", Offset = "0x550BF0", VA = "0x1805521F0")]
	[IteratorStateMachine(typeof(_003CUpdateColors_003Ed__20))]
	private IEnumerator UpdateColors()
	{
		return null;
	}

	[Token(Token = "0x6000BF5")]
	[Address(RVA = "0x552290", Offset = "0x550C90", VA = "0x180552290")]
	private void AddMatrix4x4ToArray(int instanceCount)
	{
	}

	[Token(Token = "0x6000BF6")]
	[Address(RVA = "0x5525B0", Offset = "0x550FB0", VA = "0x1805525B0")]
	private void RemoveMatrix4x4FromArray(int instanceCount)
	{
	}

	[Token(Token = "0x6000BF7")]
	[Address(RVA = "0x552670", Offset = "0x551070", VA = "0x180552670")]
	private void CheckButtonsAvailablity()
	{
	}

	[Token(Token = "0x6000BF8")]
	[Address(RVA = "0x552780", Offset = "0x551180", VA = "0x180552780")]
	public void SetPositionUpdateFrequency(float updateInterval)
	{
	}

	[Token(Token = "0x6000BF9")]
	[Address(RVA = "0x552900", Offset = "0x551300", VA = "0x180552900")]
	public void SetScaleUpdateFrequency(float updateInterval)
	{
	}

	[Token(Token = "0x6000BFA")]
	[Address(RVA = "0x552A80", Offset = "0x551480", VA = "0x180552A80")]
	public void SetColorUpdateFrequency(float updateInterval)
	{
	}

	[Token(Token = "0x6000BFB")]
	[Address(RVA = "0x552C00", Offset = "0x551600", VA = "0x180552C00")]
	public void AddSpheres()
	{
	}

	[Token(Token = "0x6000BFC")]
	[Address(RVA = "0x552C90", Offset = "0x551690", VA = "0x180552C90")]
	public void RemoveSpheres()
	{
	}

	[Token(Token = "0x6000BFD")]
	[Address(RVA = "0x552DC0", Offset = "0x5517C0", VA = "0x180552DC0")]
	public void ClearSpheres()
	{
	}

	[Token(Token = "0x6000BFE")]
	[Address(RVA = "0x552FB0", Offset = "0x5519B0", VA = "0x180552FB0")]
	public PrefabsWithoutGameObjects()
	{
	}
}
