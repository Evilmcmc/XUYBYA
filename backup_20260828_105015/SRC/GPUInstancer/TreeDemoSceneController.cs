using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.UI;

namespace GPUInstancer;

[Token(Token = "0x200014B")]
public class TreeDemoSceneController : MonoBehaviour
{
	[Token(Token = "0x40007DB")]
	[FieldOffset(Offset = "0x20")]
	public GPUInstancerTreeManager manager;

	[Token(Token = "0x40007DC")]
	[FieldOffset(Offset = "0x28")]
	public Text GPUIStateText;

	[Token(Token = "0x40007DD")]
	[FieldOffset(Offset = "0x30")]
	public Text FPSCountTextText;

	[Token(Token = "0x40007DE")]
	[FieldOffset(Offset = "0x38")]
	private FPS _fpsCounter;

	[Token(Token = "0x6000C13")]
	[Address(RVA = "0x5544A0", Offset = "0x552EA0", VA = "0x1805544A0")]
	private void Awake()
	{
	}

	[Token(Token = "0x6000C14")]
	[Address(RVA = "0x554530", Offset = "0x552F30", VA = "0x180554530")]
	private void Start()
	{
	}

	[Token(Token = "0x6000C15")]
	[Address(RVA = "0x554580", Offset = "0x552F80", VA = "0x180554580")]
	private void Update()
	{
	}

	[Token(Token = "0x6000C16")]
	[Address(RVA = "0x554610", Offset = "0x553010", VA = "0x180554610")]
	public void ToggleManager()
	{
	}

	[Token(Token = "0x6000C17")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public TreeDemoSceneController()
	{
	}
}
