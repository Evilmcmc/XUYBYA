using System.Collections.Generic;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x20000AE")]
public class PlayerProfilePictureCosmetics : MonoBehaviour
{
	[Token(Token = "0x40003C7")]
	[FieldOffset(Offset = "0x20")]
	[Header("Cosmetics")]
	[SerializeField]
	private CosmeticPack[] packs;

	[Token(Token = "0x40003C8")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private Transform hatParent;

	[Token(Token = "0x40003C9")]
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	private SkinnedMeshRenderer bodyMesh;

	[Token(Token = "0x40003CA")]
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	private MeshRenderer headMesh;

	[Token(Token = "0x40003CB")]
	[FieldOffset(Offset = "0x40")]
	[SerializeField]
	private List<Material> playerColors;

	[Token(Token = "0x40003CC")]
	[FieldOffset(Offset = "0x48")]
	[Header("Image")]
	[SerializeField]
	private Camera IconCamera;

	[Token(Token = "0x40003CD")]
	[FieldOffset(Offset = "0x50")]
	[SerializeField]
	private RawImage IconImage;

	[Token(Token = "0x40003CE")]
	[FieldOffset(Offset = "0x58")]
	private RenderTexture renderTexture;

	[Token(Token = "0x600056B")]
	[Address(RVA = "0x4C9A50", Offset = "0x4C8450", VA = "0x1804C9A50")]
	public void UpdateProfilePicture(string hat, string body, int color)
	{
	}

	[Token(Token = "0x600056C")]
	[Address(RVA = "0x4C9D40", Offset = "0x4C8740", VA = "0x1804C9D40")]
	private void UpdateHat(string playerHat)
	{
	}

	[Token(Token = "0x600056D")]
	[Address(RVA = "0x4C9F40", Offset = "0x4C8940", VA = "0x1804C9F40")]
	private void UpdateBody(string playerBody)
	{
	}

	[Token(Token = "0x600056E")]
	[Address(RVA = "0x4CA0A0", Offset = "0x4C8AA0", VA = "0x1804CA0A0")]
	private void UpdateColor(int playerColor)
	{
	}

	[Token(Token = "0x600056F")]
	[Address(RVA = "0x4CA520", Offset = "0x4C8F20", VA = "0x1804CA520")]
	private void LoadProfilePicture()
	{
	}

	[Token(Token = "0x6000570")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public PlayerProfilePictureCosmetics()
	{
	}
}
