using Il2CppDummyDll;
using Steamworks;
using UnityEngine;
using UnityEngine.Localization;

[Token(Token = "0x2000052")]
public class GetMatchInfo : MonoBehaviour
{
	[Token(Token = "0x4000137")]
	[FieldOffset(Offset = "0x20")]
	[Header("Map Names")]
	[SerializeField]
	private LocalizedString suburb;

	[Token(Token = "0x4000138")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private LocalizedString city;

	[Token(Token = "0x4000139")]
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	private LocalizedString train;

	[Token(Token = "0x400013A")]
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	private LocalizedString factory;

	[Token(Token = "0x400013B")]
	[FieldOffset(Offset = "0x40")]
	[SerializeField]
	private LocalizedString skyscraper;

	[Token(Token = "0x400013C")]
	[FieldOffset(Offset = "0x48")]
	[SerializeField]
	private LocalizedString islands;

	[Token(Token = "0x400013D")]
	[FieldOffset(Offset = "0x50")]
	[SerializeField]
	private LocalizedString feast;

	[Token(Token = "0x400013E")]
	[FieldOffset(Offset = "0x58")]
	[Header("Gamemode Names")]
	[SerializeField]
	private LocalizedString[] gameModes;

	[Token(Token = "0x400013F")]
	[FieldOffset(Offset = "0x60")]
	[Header("Match Length Names")]
	[SerializeField]
	private LocalizedString minutes;

	[Token(Token = "0x4000140")]
	[FieldOffset(Offset = "0x68")]
	[Header("Barrels Names")]
	[SerializeField]
	private LocalizedString tooMany;

	[Token(Token = "0x4000141")]
	[FieldOffset(Offset = "0x70")]
	[SerializeField]
	private LocalizedString aLot;

	[Token(Token = "0x4000142")]
	[FieldOffset(Offset = "0x78")]
	[SerializeField]
	private LocalizedString aFew;

	[Token(Token = "0x4000143")]
	[FieldOffset(Offset = "0x80")]
	[SerializeField]
	private LocalizedString none;

	[Token(Token = "0x4000144")]
	[FieldOffset(Offset = "0x88")]
	[SerializeField]
	private LocalizedString barrelsText;

	[Token(Token = "0x4000145")]
	[FieldOffset(Offset = "0x90")]
	[Header("Miscellaneous")]
	[SerializeField]
	private LocalizedString informationNotFound;

	[Token(Token = "0x600020D")]
	[Address(RVA = "0x481BA0", Offset = "0x4805A0", VA = "0x180481BA0")]
	public void OpenMatchInfo()
	{
	}

	[Token(Token = "0x600020E")]
	[Address(RVA = "0x482CA0", Offset = "0x4816A0", VA = "0x180482CA0")]
	public void CloseMatchInfo()
	{
	}

	[Token(Token = "0x600020F")]
	[Address(RVA = "0x482D30", Offset = "0x481730", VA = "0x180482D30")]
	private string GetMapName(CSteamID lobbyID)
	{
		return null;
	}

	[Token(Token = "0x6000210")]
	[Address(RVA = "0x4830B0", Offset = "0x481AB0", VA = "0x1804830B0")]
	private string GetGameMode(CSteamID lobbyID)
	{
		return null;
	}

	[Token(Token = "0x6000211")]
	[Address(RVA = "0x4832C0", Offset = "0x481CC0", VA = "0x1804832C0")]
	private string GetMatchLength(CSteamID lobbyID)
	{
		return null;
	}

	[Token(Token = "0x6000212")]
	[Address(RVA = "0x4833A0", Offset = "0x481DA0", VA = "0x1804833A0")]
	private string GetBarrels(CSteamID lobbyID)
	{
		return null;
	}

	[Token(Token = "0x6000213")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public GetMatchInfo()
	{
	}
}
