using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Token(Token = "0x20000D5")]
[RequireComponent(typeof(Image))]
public class Tab_Button : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	[Token(Token = "0x400046D")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private TabGroup tabGroup;

	[Token(Token = "0x400046E")]
	[FieldOffset(Offset = "0x28")]
	[HideInInspector]
	public Image backGround;

	[Token(Token = "0x600065E")]
	[Address(RVA = "0x4DBC80", Offset = "0x4DA680", VA = "0x1804DBC80")]
	private void Start()
	{
	}

	[Token(Token = "0x600065F")]
	[Address(RVA = "0x4DBE70", Offset = "0x4DA870", VA = "0x1804DBE70", Slot = "4")]
	public void OnPointerClick(PointerEventData eventData)
	{
	}

	[Token(Token = "0x6000660")]
	[Address(RVA = "0x4DBEA0", Offset = "0x4DA8A0", VA = "0x1804DBEA0", Slot = "5")]
	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	[Token(Token = "0x6000661")]
	[Address(RVA = "0x4DC040", Offset = "0x4DAA40", VA = "0x1804DC040", Slot = "6")]
	public void OnPointerExit(PointerEventData eventData)
	{
	}

	[Token(Token = "0x6000662")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public Tab_Button()
	{
	}
}
