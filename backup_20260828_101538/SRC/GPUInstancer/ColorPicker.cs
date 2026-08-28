using System;
using Il2CppDummyDll;
using UnityEngine;

namespace GPUInstancer;

[Token(Token = "0x200014C")]
public class ColorPicker : MonoBehaviour
{
	[Token(Token = "0x40007DF")]
	[FieldOffset(Offset = "0x20")]
	private Color _color;

	[Token(Token = "0x40007E0")]
	[FieldOffset(Offset = "0x30")]
	private Action<Color> _onValueChange;

	[Token(Token = "0x40007E1")]
	[FieldOffset(Offset = "0x38")]
	private Action _onValueChangeVoid;

	[Token(Token = "0x40007E2")]
	[FieldOffset(Offset = "0x40")]
	private Action _update;

	[Token(Token = "0x170000EA")]
	public Color Color
	{
		[Token(Token = "0x6000C18")]
		[Address(RVA = "0x554930", Offset = "0x553330", VA = "0x180554930")]
		get
		{
			return default(Color);
		}
		[Token(Token = "0x6000C19")]
		[Address(RVA = "0x554940", Offset = "0x553340", VA = "0x180554940")]
		set
		{
		}
	}

	[Token(Token = "0x6000C1A")]
	[Address(RVA = "0x554960", Offset = "0x553360", VA = "0x180554960")]
	public void SetOnValueChangeCallback(Action<Color> onValueChange)
	{
	}

	[Token(Token = "0x6000C1B")]
	[Address(RVA = "0x5549C0", Offset = "0x5533C0", VA = "0x1805549C0")]
	public void SetOnValueChangeCallback(Action onValueChange)
	{
	}

	[Token(Token = "0x6000C1C")]
	[Address(RVA = "0x554A20", Offset = "0x553420", VA = "0x180554A20")]
	private static void RGBToHSV(Color color, out float h, out float s, out float v)
	{
	}

	[Token(Token = "0x6000C1D")]
	[Address(RVA = "0x554CC0", Offset = "0x5536C0", VA = "0x180554CC0")]
	private static bool GetLocalMouse(GameObject go, out Vector2 result)
	{
		return default(bool);
	}

	[Token(Token = "0x6000C1E")]
	[Address(RVA = "0x5551D0", Offset = "0x553BD0", VA = "0x1805551D0")]
	private static Vector2 GetWidgetSize(GameObject go)
	{
		return default(Vector2);
	}

	[Token(Token = "0x6000C1F")]
	[Address(RVA = "0x5552F0", Offset = "0x553CF0", VA = "0x1805552F0")]
	private GameObject GO(string name)
	{
		return null;
	}

	[Token(Token = "0x6000C20")]
	[Address(RVA = "0x555380", Offset = "0x553D80", VA = "0x180555380")]
	private void Setup(Color inputColor)
	{
	}

	[Token(Token = "0x6000C21")]
	[Address(RVA = "0x556A10", Offset = "0x555410", VA = "0x180556A10")]
	public void SetRandomColor()
	{
	}

	[Token(Token = "0x6000C22")]
	[Address(RVA = "0x556BC0", Offset = "0x5555C0", VA = "0x180556BC0")]
	private void Awake()
	{
	}

	[Token(Token = "0x6000C23")]
	[Address(RVA = "0x556BF0", Offset = "0x5555F0", VA = "0x180556BF0")]
	private void Update()
	{
	}

	[Token(Token = "0x6000C24")]
	[Address(RVA = "0x556C20", Offset = "0x555620", VA = "0x180556C20")]
	public ColorPicker()
	{
	}
}
