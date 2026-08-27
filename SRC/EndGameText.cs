using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.Localization;

[Token(Token = "0x200003D")]
public class EndGameText : MonoBehaviour
{
	[Token(Token = "0x40000BE")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private LocalizedString[] endGameTexts;

	[Token(Token = "0x40000BF")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private LocalizedString[] teamEndGameTexts;

	[Token(Token = "0x600013D")]
	[Address(RVA = "0x46BBA0", Offset = "0x46A5A0", VA = "0x18046BBA0")]
	public void UpdateWinText(string winnerUsername)
	{
	}

	[Token(Token = "0x600013E")]
	[Address(RVA = "0x46BE10", Offset = "0x46A810", VA = "0x18046BE10")]
	public void UpdateTeamWinText(string winnerTeam)
	{
	}

	[Token(Token = "0x600013F")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public EndGameText()
	{
	}
}
