using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000050")]
public class GameSettingsManager : MonoBehaviour
{
	[Token(Token = "0x4000131")]
	[FieldOffset(Offset = "0x20")]
	public bool bounties;

	[Token(Token = "0x4000132")]
	[FieldOffset(Offset = "0x21")]
	public bool gracePeriod;

	[Token(Token = "0x6000202")]
	[Address(RVA = "0x480F10", Offset = "0x47F910", VA = "0x180480F10")]
	public GameSettingsManager()
	{
	}
}
