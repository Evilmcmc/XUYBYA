using System.IO;
using Il2CppDummyDll;

namespace Crosstales.Common.Util;

[Token(Token = "0x20001D7")]
public class MemoryCacheStream : Stream
{
	[Token(Token = "0x40009BA")]
	[FieldOffset(Offset = "0x28")]
	private byte[] _cache;

	[Token(Token = "0x40009BB")]
	[FieldOffset(Offset = "0x30")]
	private long _writePosition;

	[Token(Token = "0x40009BC")]
	[FieldOffset(Offset = "0x38")]
	private long _readPosition;

	[Token(Token = "0x40009BD")]
	[FieldOffset(Offset = "0x40")]
	private long _length;

	[Token(Token = "0x40009BE")]
	[FieldOffset(Offset = "0x48")]
	private int _size;

	[Token(Token = "0x40009BF")]
	[FieldOffset(Offset = "0x4C")]
	private readonly int _maxSize;

	[Token(Token = "0x17000139")]
	public override bool CanRead
	{
		[Token(Token = "0x6000F8A")]
		[Address(RVA = "0x588930", Offset = "0x587330", VA = "0x180588930", Slot = "7")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x1700013A")]
	public override bool CanSeek
	{
		[Token(Token = "0x6000F8B")]
		[Address(RVA = "0x588930", Offset = "0x587330", VA = "0x180588930", Slot = "8")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x1700013B")]
	public override bool CanWrite
	{
		[Token(Token = "0x6000F8C")]
		[Address(RVA = "0x588930", Offset = "0x587330", VA = "0x180588930", Slot = "10")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x1700013C")]
	public override long Position
	{
		[Token(Token = "0x6000F8D")]
		[Address(RVA = "0x595DA0", Offset = "0x5947A0", VA = "0x180595DA0", Slot = "12")]
		get
		{
			return default(long);
		}
		[Token(Token = "0x6000F8E")]
		[Address(RVA = "0x595DB0", Offset = "0x5947B0", VA = "0x180595DB0", Slot = "13")]
		set
		{
		}
	}

	[Token(Token = "0x1700013D")]
	public override long Length
	{
		[Token(Token = "0x6000F8F")]
		[Address(RVA = "0x543780", Offset = "0x542180", VA = "0x180543780", Slot = "11")]
		get
		{
			return default(long);
		}
	}

	[Token(Token = "0x6000F89")]
	[Address(RVA = "0x595D20", Offset = "0x594720", VA = "0x180595D20")]
	public MemoryCacheStream(int cacheSize = 65536, int maxCacheSize = 67108864)
	{
	}

	[Token(Token = "0x6000F90")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0", Slot = "22")]
	public override void Flush()
	{
	}

	[Token(Token = "0x6000F91")]
	[Address(RVA = "0x595E30", Offset = "0x594830", VA = "0x180595E30", Slot = "31")]
	public override long Seek(long offset, SeekOrigin origin)
	{
		return default(long);
	}

	[Token(Token = "0x6000F92")]
	[Address(RVA = "0x595FA0", Offset = "0x5949A0", VA = "0x180595FA0", Slot = "32")]
	public override void SetLength(long value)
	{
	}

	[Token(Token = "0x6000F93")]
	[Address(RVA = "0x595FE0", Offset = "0x5949E0", VA = "0x180595FE0", Slot = "33")]
	public override int Read(byte[] buffer, int offset, int count)
	{
		return default(int);
	}

	[Token(Token = "0x6000F94")]
	[Address(RVA = "0x5961D0", Offset = "0x594BD0", VA = "0x1805961D0", Slot = "36")]
	public override void Write(byte[] buffer, int offset, int count)
	{
	}

	[Token(Token = "0x6000F95")]
	[Address(RVA = "0x596420", Offset = "0x594E20", VA = "0x180596420")]
	private int read(byte[] buff, int offset, int count)
	{
		return default(int);
	}

	[Token(Token = "0x6000F96")]
	[Address(RVA = "0x5964D0", Offset = "0x594ED0", VA = "0x1805964D0")]
	private void write(byte[] buff, int offset, int count)
	{
	}

	[Token(Token = "0x6000F97")]
	[Address(RVA = "0x596590", Offset = "0x594F90", VA = "0x180596590")]
	private void createCache()
	{
	}
}
