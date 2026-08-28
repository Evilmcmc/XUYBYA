using Il2CppDummyDll;
using Steamworks;

[Token(Token = "0x20000FD")]
internal class TemporaryMapData
{
	[Token(Token = "0x4000530")]
	[FieldOffset(Offset = "0x10")]
	public string name;

	[Token(Token = "0x4000531")]
	[FieldOffset(Offset = "0x18")]
	public PublishedFileId_t id;

	[Token(Token = "0x4000532")]
	[FieldOffset(Offset = "0x20")]
	public UGCHandle_t handle;

	[Token(Token = "0x60007B8")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public TemporaryMapData()
	{
	}
}
