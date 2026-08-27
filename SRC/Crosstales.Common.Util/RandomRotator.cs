using Il2CppDummyDll;
using UnityEngine;

namespace Crosstales.Common.Util;

[Token(Token = "0x20001CE")]
[DisallowMultipleComponent]
public class RandomRotator : MonoBehaviour
{
	[Token(Token = "0x400094B")]
	[FieldOffset(Offset = "0x20")]
	[Tooltip("Use intervals to change the rotation (default: true).")]
	public bool UseInterval;

	[Token(Token = "0x400094C")]
	[FieldOffset(Offset = "0x24")]
	[Tooltip("Random change interval between min (= x) and max (= y) in seconds (default: x = 10, y = 20).")]
	public Vector2 ChangeInterval;

	[Token(Token = "0x400094D")]
	[FieldOffset(Offset = "0x2C")]
	[Tooltip("Minimum rotation speed per axis (default: 5 for all axis).")]
	public Vector3 SpeedMin;

	[Token(Token = "0x400094E")]
	[FieldOffset(Offset = "0x38")]
	[Tooltip("Minimum rotation speed per axis (default: 15 for all axis).")]
	public Vector3 SpeedMax;

	[Token(Token = "0x400094F")]
	[FieldOffset(Offset = "0x44")]
	[Tooltip("Set the object to a random rotation at Start (default: false).")]
	public bool RandomRotationAtStart;

	[Token(Token = "0x4000950")]
	[FieldOffset(Offset = "0x45")]
	[Tooltip("Random change interval per axis (default: true).")]
	public bool RandomChangeIntervalPerAxis;

	[Token(Token = "0x4000951")]
	[FieldOffset(Offset = "0x46")]
	[Tooltip("Random direction per axis (default: true).")]
	public bool RandomDirectionPerAxis;

	[Token(Token = "0x4000952")]
	[FieldOffset(Offset = "0x48")]
	private Transform _tf;

	[Token(Token = "0x4000953")]
	[FieldOffset(Offset = "0x50")]
	private Vector3 _speed;

	[Token(Token = "0x4000954")]
	[FieldOffset(Offset = "0x5C")]
	private float _elapsedTime;

	[Token(Token = "0x4000955")]
	[FieldOffset(Offset = "0x60")]
	private float _changeTime;

	[Token(Token = "0x4000956")]
	[FieldOffset(Offset = "0x64")]
	private Vector3 _elapsedTimeAxis;

	[Token(Token = "0x4000957")]
	[FieldOffset(Offset = "0x70")]
	private Vector3 _changeTimeAxis;

	[Token(Token = "0x6000EEA")]
	[Address(RVA = "0x5861A0", Offset = "0x584BA0", VA = "0x1805861A0")]
	private void Start()
	{
	}

	[Token(Token = "0x6000EEB")]
	[Address(RVA = "0x586360", Offset = "0x584D60", VA = "0x180586360")]
	private void Update()
	{
	}

	[Token(Token = "0x6000EEC")]
	[Address(RVA = "0x586880", Offset = "0x585280", VA = "0x180586880")]
	public RandomRotator()
	{
	}
}
