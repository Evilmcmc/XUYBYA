using System.Collections.Generic;
using Il2CppDummyDll;
using TMPro;
using UnityEngine;

[Token(Token = "0x20000C8")]
public class DialogueText : MonoBehaviour
{
	[Token(Token = "0x4000432")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private float x_wobble;

	[Token(Token = "0x4000433")]
	[FieldOffset(Offset = "0x24")]
	[SerializeField]
	private float y_wobble;

	[Token(Token = "0x4000434")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private float magnitude;

	[Token(Token = "0x4000435")]
	[FieldOffset(Offset = "0x2C")]
	[SerializeField]
	private bool alwaysUpdateText;

	[Token(Token = "0x4000436")]
	[FieldOffset(Offset = "0x30")]
	private TMP_Text textMesh;

	[Token(Token = "0x4000437")]
	[FieldOffset(Offset = "0x38")]
	private Mesh mesh;

	[Token(Token = "0x4000438")]
	[FieldOffset(Offset = "0x40")]
	private Vector3[] vertices;

	[Token(Token = "0x4000439")]
	[FieldOffset(Offset = "0x48")]
	private List<int> wordIndexes;

	[Token(Token = "0x400043A")]
	[FieldOffset(Offset = "0x50")]
	private List<int> wordLengths;

	[Token(Token = "0x600061A")]
	[Address(RVA = "0x4D6FA0", Offset = "0x4D59A0", VA = "0x1804D6FA0")]
	private void Start()
	{
	}

	[Token(Token = "0x600061B")]
	[Address(RVA = "0x4D73F0", Offset = "0x4D5DF0", VA = "0x1804D73F0")]
	private void Update()
	{
	}

	[Token(Token = "0x600061C")]
	[Address(RVA = "0x4D7EC0", Offset = "0x4D68C0", VA = "0x1804D7EC0")]
	private Vector2 Wobble(float time)
	{
		return default(Vector2);
	}

	[Token(Token = "0x600061D")]
	[Address(RVA = "0x4D7F10", Offset = "0x4D6910", VA = "0x1804D7F10")]
	public DialogueText()
	{
	}
}
