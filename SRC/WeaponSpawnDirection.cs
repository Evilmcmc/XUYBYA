using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000105")]
public class WeaponSpawnDirection : MonoBehaviour
{
	[Token(Token = "0x4000563")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private Image img;

	[Token(Token = "0x4000564")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private Image img2;

	[Token(Token = "0x4000565")]
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	private Image weaponIconImg;

	[Token(Token = "0x4000566")]
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	private Sprite[] weaponIcons;

	[Token(Token = "0x4000567")]
	[FieldOffset(Offset = "0x40")]
	[HideInInspector]
	public Camera cam;

	[Token(Token = "0x4000568")]
	[FieldOffset(Offset = "0x48")]
	[HideInInspector]
	public Transform player;

	[Token(Token = "0x4000569")]
	[FieldOffset(Offset = "0x50")]
	[HideInInspector]
	public GameObject attackCharge;

	[Token(Token = "0x60007F0")]
	[Address(RVA = "0x4F6AE0", Offset = "0x4F54E0", VA = "0x1804F6AE0")]
	private void LateUpdate()
	{
	}

	[Token(Token = "0x60007F1")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public WeaponSpawnDirection()
	{
	}
}
