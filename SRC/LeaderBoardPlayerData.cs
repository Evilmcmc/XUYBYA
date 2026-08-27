using Il2CppDummyDll;

[Token(Token = "0x20000EE")]
public class LeaderBoardPlayerData
{
	[Token(Token = "0x40004F6")]
	[FieldOffset(Offset = "0x10")]
	public string username;

	[Token(Token = "0x40004F7")]
	[FieldOffset(Offset = "0x18")]
	public int playerSteamID;

	[Token(Token = "0x40004F8")]
	[FieldOffset(Offset = "0x1C")]
	public short kills;

	[Token(Token = "0x40004F9")]
	[FieldOffset(Offset = "0x1E")]
	public short deaths;

	[Token(Token = "0x40004FA")]
	[FieldOffset(Offset = "0x20")]
	public short assists;

	[Token(Token = "0x40004FB")]
	[FieldOffset(Offset = "0x22")]
	public short bonusPoints;

	[Token(Token = "0x40004FC")]
	[FieldOffset(Offset = "0x24")]
	public short killStreak;

	[Token(Token = "0x40004FD")]
	[FieldOffset(Offset = "0x26")]
	public short maxDistance;

	[Token(Token = "0x40004FE")]
	[FieldOffset(Offset = "0x28")]
	public short ping;

	[Token(Token = "0x40004FF")]
	[FieldOffset(Offset = "0x2A")]
	public bool isHost;

	[Token(Token = "0x4000500")]
	[FieldOffset(Offset = "0x2B")]
	public bool awayTeam;

	[Token(Token = "0x4000501")]
	[FieldOffset(Offset = "0x30")]
	public string hat;

	[Token(Token = "0x4000502")]
	[FieldOffset(Offset = "0x38")]
	public string body;

	[Token(Token = "0x4000503")]
	[FieldOffset(Offset = "0x40")]
	public int color;

	[Token(Token = "0x6000730")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public LeaderBoardPlayerData()
	{
	}

	[Token(Token = "0x6000731")]
	[Address(RVA = "0x4EA990", Offset = "0x4E9390", VA = "0x1804EA990")]
	public LeaderBoardPlayerData(string _username, short _kills, short _deaths, short _assists, int _playerSteamID, bool _isHost, bool _awayTeam, short _bonusPoints, short _killStreak, short _maxDistance, string _hat, string _body, int _color)
	{
	}
}
