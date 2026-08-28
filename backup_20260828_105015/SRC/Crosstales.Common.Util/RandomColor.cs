using Il2CppDummyDll;
using UnityEngine;

namespace Crosstales.Common.Util;

[Token(Token = "0x20001CD")]
public class RandomColor : MonoBehaviour
{
	[Token(Token = "0x400093A")]
	[FieldOffset(Offset = "0x20")]
	[Tooltip("Use intervals to change the color (default: true).")]
	public bool UseInterval;

	[Token(Token = "0x400093B")]
	[FieldOffset(Offset = "0x24")]
	[Tooltip("Random change interval between min (= x) and max (= y) in seconds (default: x = 5, y = 10).")]
	public Vector2 ChangeInterval;

	[Token(Token = "0x400093C")]
	[FieldOffset(Offset = "0x2C")]
	[Tooltip("Random hue range between min (= x) and max (= y) (default: x = 0, y = 1).")]
	public Vector2 HueRange;

	[Token(Token = "0x400093D")]
	[FieldOffset(Offset = "0x34")]
	[Tooltip("Random saturation range between min (= x) and max (= y) (default: x = 1, y = 1).")]
	public Vector2 SaturationRange;

	[Token(Token = "0x400093E")]
	[FieldOffset(Offset = "0x3C")]
	[Tooltip("Random value range between min (= x) and max (= y) (default: x = 1, y = 1).")]
	public Vector2 ValueRange;

	[Token(Token = "0x400093F")]
	[FieldOffset(Offset = "0x44")]
	[Tooltip("Random alpha range between min (= x) and max (= y) (default: x = 1, y = 1).")]
	public Vector2 AlphaRange;

	[Token(Token = "0x4000940")]
	[FieldOffset(Offset = "0x4C")]
	[Tooltip("Use gray scale colors (default: false).")]
	public bool GrayScale;

	[Token(Token = "0x4000941")]
	[FieldOffset(Offset = "0x50")]
	[Tooltip("Modify the color of a material instead of the Renderer (default: not set, optional).")]
	public Material Material;

	[Token(Token = "0x4000942")]
	[FieldOffset(Offset = "0x58")]
	[Tooltip("Set the object to a random color at Start (default: false).")]
	public bool RandomColorAtStart;

	[Token(Token = "0x4000943")]
	[FieldOffset(Offset = "0x5C")]
	private float _elapsedTime;

	[Token(Token = "0x4000944")]
	[FieldOffset(Offset = "0x60")]
	private float _changeTime;

	[Token(Token = "0x4000945")]
	[FieldOffset(Offset = "0x68")]
	private Renderer _currentRenderer;

	[Token(Token = "0x4000946")]
	[FieldOffset(Offset = "0x70")]
	private Color32 _startColor;

	[Token(Token = "0x4000947")]
	[FieldOffset(Offset = "0x74")]
	private Color32 _endColor;

	[Token(Token = "0x4000948")]
	[FieldOffset(Offset = "0x78")]
	private float _lerpProgress;

	[Token(Token = "0x4000949")]
	[FieldOffset(Offset = "0x7C")]
	private bool _existsMaterial;

	[Token(Token = "0x400094A")]
	[FieldOffset(Offset = "0x0")]
	private static readonly int COLOR_ID;

	[Token(Token = "0x6000EE6")]
	[Address(RVA = "0x585680", Offset = "0x584080", VA = "0x180585680")]
	private void Start()
	{
	}

	[Token(Token = "0x6000EE7")]
	[Address(RVA = "0x585B40", Offset = "0x584540", VA = "0x180585B40")]
	private void Update()
	{
	}

	[Token(Token = "0x6000EE8")]
	[Address(RVA = "0x5860B0", Offset = "0x584AB0", VA = "0x1805860B0")]
	public RandomColor()
	{
	}
}
