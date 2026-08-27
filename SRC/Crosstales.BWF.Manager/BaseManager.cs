using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Crosstales.BWF.Filter;
using Crosstales.Common.Util;
using Il2CppDummyDll;
using UnityEngine;

namespace Crosstales.BWF.Manager;

[Token(Token = "0x200020B")]
[ExecuteInEditMode]
public abstract class BaseManager<S, T> : Singleton<S> where S : Singleton<S> where T : BaseFilter
{
	[Token(Token = "0x4000A98")]
	[FieldOffset(Offset = "0x0")]
	[Tooltip("Disables the ordering of the 'GetAll'-method (prevent possible memory garbage).")]
	[SerializeField]
	private bool disableOrdering;

	[Token(Token = "0x4000A99")]
	[FieldOffset(Offset = "0x0")]
	protected T _filter;

	[Token(Token = "0x1700016E")]
	public bool DisableOrdering
	{
		[Token(Token = "0x60010BC")]
		get
		{
			return default(bool);
		}
		[Token(Token = "0x60010BD")]
		set
		{
		}
	}

	[Token(Token = "0x1700016F")]
	public bool isReady
	{
		[Token(Token = "0x60010BE")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x17000170")]
	protected abstract OnContainsCompleted onContainsCompleted
	{
		[Token(Token = "0x60010BF")]
		get;
	}

	[Token(Token = "0x17000171")]
	protected abstract OnGetAllCompleted onGetAllCompleted
	{
		[Token(Token = "0x60010C0")]
		get;
	}

	[Token(Token = "0x17000172")]
	protected abstract OnReplaceAllCompleted onReplaceAllCompleted
	{
		[Token(Token = "0x60010C1")]
		get;
	}

	[Token(Token = "0x1400000C")]
	public event ContainsComplete OnContainsComplete
	{
		[Token(Token = "0x60010C2")]
		[CompilerGenerated]
		add
		{
		}
		[Token(Token = "0x60010C3")]
		[CompilerGenerated]
		remove
		{
		}
	}

	[Token(Token = "0x1400000D")]
	public event GetAllComplete OnGetAllComplete
	{
		[Token(Token = "0x60010C4")]
		[CompilerGenerated]
		add
		{
		}
		[Token(Token = "0x60010C5")]
		[CompilerGenerated]
		remove
		{
		}
	}

	[Token(Token = "0x1400000E")]
	public event ReplaceAllComplete OnReplaceAllComplete
	{
		[Token(Token = "0x60010C6")]
		[CompilerGenerated]
		add
		{
		}
		[Token(Token = "0x60010C7")]
		[CompilerGenerated]
		remove
		{
		}
	}

	[Token(Token = "0x60010C8")]
	private void Start()
	{
	}

	[Token(Token = "0x60010C9")]
	public string Unmark(string text, string prefix = "<b><color=red>", string postfix = "</color></b>")
	{
		return null;
	}

	[Token(Token = "0x60010CA")]
	protected void onContainsComplete(string text, bool result)
	{
	}

	[Token(Token = "0x60010CB")]
	protected void onGetAllComplete(string text, List<string> badWords)
	{
	}

	[Token(Token = "0x60010CC")]
	protected void onReplaceAllComplete(string originalText, string cleanText)
	{
	}

	[Token(Token = "0x60010CD")]
	protected BaseManager()
	{
	}
}
