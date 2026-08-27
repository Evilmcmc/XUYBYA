using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.Rendering;

[Token(Token = "0x200006E")]
public class MenuCameraMovement : MonoBehaviour
{
	[Token(Token = "0x40001C3")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private float yspeed;

	[Token(Token = "0x40001C4")]
	[FieldOffset(Offset = "0x24")]
	[SerializeField]
	private float ymag;

	[Token(Token = "0x40001C5")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private float xspeed;

	[Token(Token = "0x40001C6")]
	[FieldOffset(Offset = "0x2C")]
	[SerializeField]
	private float xmag;

	[Token(Token = "0x40001C7")]
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	private float camLerpSpeed;

	[Token(Token = "0x40001C8")]
	[FieldOffset(Offset = "0x34")]
	[SerializeField]
	private Vector3 mainRot;

	[Token(Token = "0x40001C9")]
	[FieldOffset(Offset = "0x40")]
	[SerializeField]
	private Vector3 mainPos;

	[Token(Token = "0x40001CA")]
	[FieldOffset(Offset = "0x4C")]
	[SerializeField]
	private Vector3 tutRot;

	[Token(Token = "0x40001CB")]
	[FieldOffset(Offset = "0x58")]
	[SerializeField]
	private Vector3 tutPos;

	[Token(Token = "0x40001CC")]
	[FieldOffset(Offset = "0x64")]
	[SerializeField]
	private Vector3 screenRot;

	[Token(Token = "0x40001CD")]
	[FieldOffset(Offset = "0x70")]
	[SerializeField]
	private Vector3 screenPos;

	[Token(Token = "0x40001CE")]
	[FieldOffset(Offset = "0x7C")]
	[SerializeField]
	private Vector3 customizationRot;

	[Token(Token = "0x40001CF")]
	[FieldOffset(Offset = "0x88")]
	[SerializeField]
	private Vector3 customizationPos;

	[Token(Token = "0x40001D0")]
	[FieldOffset(Offset = "0x94")]
	private int state;

	[Token(Token = "0x40001D1")]
	[FieldOffset(Offset = "0x98")]
	[SerializeField]
	private Volume volume;

	[Token(Token = "0x40001D2")]
	[FieldOffset(Offset = "0xA0")]
	[SerializeField]
	private float volumeLerpSpeed;

	[Token(Token = "0x60002C0")]
	[Address(RVA = "0x48DDD0", Offset = "0x48C7D0", VA = "0x18048DDD0")]
	private void Start()
	{
	}

	[Token(Token = "0x60002C1")]
	[Address(RVA = "0x48DDE0", Offset = "0x48C7E0", VA = "0x18048DDE0")]
	private void Update()
	{
	}

	[Token(Token = "0x60002C2")]
	[Address(RVA = "0x48DDD0", Offset = "0x48C7D0", VA = "0x18048DDD0")]
	public void MoveCamToMain()
	{
	}

	[Token(Token = "0x60002C3")]
	[Address(RVA = "0x48F100", Offset = "0x48DB00", VA = "0x18048F100")]
	public void MoveCamToTutorial()
	{
	}

	[Token(Token = "0x60002C4")]
	[Address(RVA = "0x48F110", Offset = "0x48DB10", VA = "0x18048F110")]
	public void MoveCamToTV()
	{
	}

	[Token(Token = "0x60002C5")]
	[Address(RVA = "0x48F120", Offset = "0x48DB20", VA = "0x18048F120")]
	public void MoveCamToCustomization()
	{
	}

	[Token(Token = "0x60002C6")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public MenuCameraMovement()
	{
	}
}
