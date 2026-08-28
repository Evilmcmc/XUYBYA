using Il2CppDummyDll;
using UnityEngine;

namespace Crosstales.Common.Util;

[Token(Token = "0x20001CF")]
[DisallowMultipleComponent]
public class RandomScaler : MonoBehaviour
{
	[Token(Token = "0x4000958")]
	[FieldOffset(Offset = "0x20")]
	[Tooltip("Use intervals to change the scale (default: true).")]
	public bool UseInterval;

	[Token(Token = "0x4000959")]
	[FieldOffset(Offset = "0x24")]
	[Tooltip("Random change interval between min (= x) and max (= y) in seconds (default: x = 10, y = 20).")]
	public Vector2 ChangeInterval;

	[Token(Token = "0x400095A")]
	[FieldOffset(Offset = "0x2C")]
	[Tooltip("Minimum rotation speed per axis (default: 5 for all axis).")]
	public Vector3 ScaleMin;

	[Token(Token = "0x400095B")]
	[FieldOffset(Offset = "0x38")]
	[Tooltip("Maximum scale per axis (default: 0.1 for all axis).")]
	public Vector3 ScaleMax;

	[Token(Token = "0x400095C")]
	[FieldOffset(Offset = "0x44")]
	[Tooltip("Uniform scaling for all axis (x-axis values will be used, default: true).")]
	public bool Uniform;

	[Token(Token = "0x400095D")]
	[FieldOffset(Offset = "0x45")]
	[Tooltip("Set the object to a random scale at Start (default: false).")]
	public bool RandomScaleAtStart;

	[Token(Token = "0x400095E")]
	[FieldOffset(Offset = "0x48")]
	private Transform _tf;

	[Token(Token = "0x400095F")]
	[FieldOffset(Offset = "0x50")]
	private Vector3 _startScale;

	[Token(Token = "0x4000960")]
	[FieldOffset(Offset = "0x5C")]
	private Vector3 _endScale;

	[Token(Token = "0x4000961")]
	[FieldOffset(Offset = "0x68")]
	private float _elapsedTime;

	[Token(Token = "0x4000962")]
	[FieldOffset(Offset = "0x6C")]
	private float _changeTime;

	[Token(Token = "0x4000963")]
	[FieldOffset(Offset = "0x70")]
	private float _lerpTime;

	[Token(Token = "0x6000EED")]
	[Address(RVA = "0x586D70", Offset = "0x585770", VA = "0x180586D70")]
	private void Start()
	{
	}

	[Token(Token = "0x6000EEE")]
	[Address(RVA = "0x586FE0", Offset = "0x5859E0", VA = "0x180586FE0")]
	private void Update()
	{
	}

	[Token(Token = "0x6000EEF")]
	[Address(RVA = "0x587340", Offset = "0x585D40", VA = "0x180587340")]
	public RandomScaler()
	{
	}
}
