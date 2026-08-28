using Il2CppDummyDll;
using Steamworks;

[Token(Token = "0x20000D8")]
public class LobbyListData
{
	[Token(Token = "0x4000473")]
	[FieldOffset(Offset = "0x10")]
	public CSteamID lobbyId;

	[Token(Token = "0x4000474")]
	[FieldOffset(Offset = "0x18")]
	public bool containsFriend;

	[Token(Token = "0x6000668")]
	[Address(RVA = "0x4DC520", Offset = "0x4DAF20", VA = "0x1804DC520")]
	public LobbyListData(CSteamID newLobbyId, bool newContainsFriend)
	{
	}
}
