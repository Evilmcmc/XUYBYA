using Il2CppDummyDll;
using UnityEngine;

namespace DG.Tweening;

[Token(Token = "0x20001B1")]
public static class DOTweenCYInstruction
{
	[Token(Token = "0x20001B2")]
	public class WaitForCompletion : CustomYieldInstruction
	{
		[Token(Token = "0x40008F0")]
		[FieldOffset(Offset = "0x10")]
		private readonly Tween t;

		[Token(Token = "0x170000F5")]
		public override bool keepWaiting
		{
			[Token(Token = "0x6000E0C")]
			[Address(RVA = "0x576720", Offset = "0x575120", VA = "0x180576720", Slot = "7")]
			get
			{
				return default(bool);
			}
		}

		[Token(Token = "0x6000E0D")]
		[Address(RVA = "0x5414B0", Offset = "0x53FEB0", VA = "0x1805414B0")]
		public WaitForCompletion(Tween tween)
		{
		}
	}

	[Token(Token = "0x20001B3")]
	public class WaitForRewind : CustomYieldInstruction
	{
		[Token(Token = "0x40008F1")]
		[FieldOffset(Offset = "0x10")]
		private readonly Tween t;

		[Token(Token = "0x170000F6")]
		public override bool keepWaiting
		{
			[Token(Token = "0x6000E0E")]
			[Address(RVA = "0x576760", Offset = "0x575160", VA = "0x180576760", Slot = "7")]
			get
			{
				return default(bool);
			}
		}

		[Token(Token = "0x6000E0F")]
		[Address(RVA = "0x5414B0", Offset = "0x53FEB0", VA = "0x1805414B0")]
		public WaitForRewind(Tween tween)
		{
		}
	}

	[Token(Token = "0x20001B4")]
	public class WaitForKill : CustomYieldInstruction
	{
		[Token(Token = "0x40008F2")]
		[FieldOffset(Offset = "0x10")]
		private readonly Tween t;

		[Token(Token = "0x170000F7")]
		public override bool keepWaiting
		{
			[Token(Token = "0x6000E10")]
			[Address(RVA = "0x5767D0", Offset = "0x5751D0", VA = "0x1805767D0", Slot = "7")]
			get
			{
				return default(bool);
			}
		}

		[Token(Token = "0x6000E11")]
		[Address(RVA = "0x5414B0", Offset = "0x53FEB0", VA = "0x1805414B0")]
		public WaitForKill(Tween tween)
		{
		}
	}

	[Token(Token = "0x20001B5")]
	public class WaitForElapsedLoops : CustomYieldInstruction
	{
		[Token(Token = "0x40008F3")]
		[FieldOffset(Offset = "0x10")]
		private readonly Tween t;

		[Token(Token = "0x40008F4")]
		[FieldOffset(Offset = "0x18")]
		private readonly int elapsedLoops;

		[Token(Token = "0x170000F8")]
		public override bool keepWaiting
		{
			[Token(Token = "0x6000E12")]
			[Address(RVA = "0x5767F0", Offset = "0x5751F0", VA = "0x1805767F0", Slot = "7")]
			get
			{
				return default(bool);
			}
		}

		[Token(Token = "0x6000E13")]
		[Address(RVA = "0x576830", Offset = "0x575230", VA = "0x180576830")]
		public WaitForElapsedLoops(Tween tween, int elapsedLoops)
		{
		}
	}

	[Token(Token = "0x20001B6")]
	public class WaitForPosition : CustomYieldInstruction
	{
		[Token(Token = "0x40008F5")]
		[FieldOffset(Offset = "0x10")]
		private readonly Tween t;

		[Token(Token = "0x40008F6")]
		[FieldOffset(Offset = "0x18")]
		private readonly float position;

		[Token(Token = "0x170000F9")]
		public override bool keepWaiting
		{
			[Token(Token = "0x6000E14")]
			[Address(RVA = "0x576890", Offset = "0x575290", VA = "0x180576890", Slot = "7")]
			get
			{
				return default(bool);
			}
		}

		[Token(Token = "0x6000E15")]
		[Address(RVA = "0x5768E0", Offset = "0x5752E0", VA = "0x1805768E0")]
		public WaitForPosition(Tween tween, float position)
		{
		}
	}

	[Token(Token = "0x20001B7")]
	public class WaitForStart : CustomYieldInstruction
	{
		[Token(Token = "0x40008F7")]
		[FieldOffset(Offset = "0x10")]
		private readonly Tween t;

		[Token(Token = "0x170000FA")]
		public override bool keepWaiting
		{
			[Token(Token = "0x6000E16")]
			[Address(RVA = "0x576940", Offset = "0x575340", VA = "0x180576940", Slot = "7")]
			get
			{
				return default(bool);
			}
		}

		[Token(Token = "0x6000E17")]
		[Address(RVA = "0x5414B0", Offset = "0x53FEB0", VA = "0x1805414B0")]
		public WaitForStart(Tween tween)
		{
		}
	}
}
