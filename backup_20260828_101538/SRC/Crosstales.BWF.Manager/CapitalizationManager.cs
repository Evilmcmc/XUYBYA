using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Crosstales.BWF.Filter;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.Serialization;

namespace Crosstales.BWF.Manager;

[Token(Token = "0x200020C")]
[DisallowMultipleComponent]
[HelpURL("https://www.crosstales.com/media/data/assets/badwordfilter/api/class_crosstales_1_1_b_w_f_1_1_manager_1_1_capitalization_manager.html")]
public class CapitalizationManager : BaseManager<CapitalizationManager, CapitalizationFilter>
{
	[Token(Token = "0x4000A9D")]
	[FieldOffset(Offset = "0x50")]
	[FormerlySerializedAs("CapitalizationCharsNumber")]
	[Header("Specific Settings")]
	[Tooltip("Defines the number of allowed capital letters in a row. (default: 3).")]
	[SerializeField]
	private int capitalizationCharsNumber;

	[Token(Token = "0x4000A9E")]
	[FieldOffset(Offset = "0x58")]
	[Header("Events")]
	public OnContainsCompleted OnContainsCompleted;

	[Token(Token = "0x4000A9F")]
	[FieldOffset(Offset = "0x60")]
	public OnGetAllCompleted OnGetAllCompleted;

	[Token(Token = "0x4000AA0")]
	[FieldOffset(Offset = "0x68")]
	public OnReplaceAllCompleted OnReplaceAllCompleted;

	[Token(Token = "0x4000AA1")]
	[FieldOffset(Offset = "0x70")]
	private Thread _worker;

	[Token(Token = "0x17000173")]
	public int CapitalizationCharsNumber
	{
		[Token(Token = "0x60010CE")]
		[Address(RVA = "0x5A78A0", Offset = "0x5A62A0", VA = "0x1805A78A0")]
		get
		{
			return default(int);
		}
		[Token(Token = "0x60010CF")]
		[Address(RVA = "0x5A78C0", Offset = "0x5A62C0", VA = "0x1805A78C0")]
		set
		{
		}
	}

	[Token(Token = "0x17000174")]
	protected override OnContainsCompleted onContainsCompleted
	{
		[Token(Token = "0x60010D0")]
		[Address(RVA = "0x5A7900", Offset = "0x5A6300", VA = "0x1805A7900", Slot = "7")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000175")]
	protected override OnGetAllCompleted onGetAllCompleted
	{
		[Token(Token = "0x60010D1")]
		[Address(RVA = "0x59E250", Offset = "0x59CC50", VA = "0x18059E250", Slot = "8")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000176")]
	protected override OnReplaceAllCompleted onReplaceAllCompleted
	{
		[Token(Token = "0x60010D2")]
		[Address(RVA = "0x59E2C0", Offset = "0x59CCC0", VA = "0x18059E2C0", Slot = "9")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x60010D3")]
	[Address(RVA = "0x5A7910", Offset = "0x5A6310", VA = "0x1805A7910", Slot = "4")]
	protected override void Awake()
	{
	}

	[Token(Token = "0x60010D4")]
	[Address(RVA = "0x5A7A90", Offset = "0x5A6490", VA = "0x1805A7A90", Slot = "6")]
	protected override void OnApplicationQuit()
	{
	}

	[Token(Token = "0x60010D5")]
	[Address(RVA = "0x5A7B10", Offset = "0x5A6510", VA = "0x1805A7B10")]
	private void OnValidate()
	{
	}

	[Token(Token = "0x60010D6")]
	[Address(RVA = "0x5A7B60", Offset = "0x5A6560", VA = "0x1805A7B60")]
	public static void ResetObject()
	{
	}

	[Token(Token = "0x60010D7")]
	[Address(RVA = "0x5A7BC0", Offset = "0x5A65C0", VA = "0x1805A7BC0")]
	public void Load()
	{
	}

	[Token(Token = "0x60010D8")]
	[Address(RVA = "0x5A7CA0", Offset = "0x5A66A0", VA = "0x1805A7CA0")]
	public bool Contains(string text)
	{
		return default(bool);
	}

	[Token(Token = "0x60010D9")]
	[Address(RVA = "0x5A7D30", Offset = "0x5A6730", VA = "0x1805A7D30")]
	public void ContainsAsync(string text)
	{
	}

	[Token(Token = "0x60010DA")]
	[Address(RVA = "0x5A7E40", Offset = "0x5A6840", VA = "0x1805A7E40")]
	public List<string> GetAll(string text)
	{
		return null;
	}

	[Token(Token = "0x60010DB")]
	[Address(RVA = "0x5A7F30", Offset = "0x5A6930", VA = "0x1805A7F30")]
	public void GetAllAsync(string text)
	{
	}

	[Token(Token = "0x60010DC")]
	[Address(RVA = "0x5A8040", Offset = "0x5A6A40", VA = "0x1805A8040")]
	public string ReplaceAll(string text, bool markOnly = false, string prefix = "", string postfix = "")
	{
		return null;
	}

	[Token(Token = "0x60010DD")]
	[Address(RVA = "0x5A80F0", Offset = "0x5A6AF0", VA = "0x1805A80F0")]
	public void ReplaceAllAsync(string text, bool markOnly = false, string prefix = "", string postfix = "")
	{
	}

	[Token(Token = "0x60010DE")]
	[Address(RVA = "0x5A8130", Offset = "0x5A6B30", VA = "0x1805A8130")]
	public string Mark(string text, bool replace = false, string prefix = "<b><color=red>", string postfix = "</color></b>")
	{
		return null;
	}

	[Token(Token = "0x60010DF")]
	[Address(RVA = "0x5A81E0", Offset = "0x5A6BE0", VA = "0x1805A81E0")]
	[IteratorStateMachine(typeof(_003CcontainsAsync_003Ed__26))]
	private IEnumerator containsAsync(string text)
	{
		return null;
	}

	[Token(Token = "0x60010E0")]
	[Address(RVA = "0x5A82E0", Offset = "0x5A6CE0", VA = "0x1805A82E0")]
	[IteratorStateMachine(typeof(_003CgetAllAsync_003Ed__27))]
	private IEnumerator getAllAsync(string text)
	{
		return null;
	}

	[Token(Token = "0x60010E1")]
	[Address(RVA = "0x5A83E0", Offset = "0x5A6DE0", VA = "0x1805A83E0")]
	[IteratorStateMachine(typeof(_003CreplaceAllAsync_003Ed__28))]
	private IEnumerator replaceAllAsync(string text, bool markOnly = false, string prefix = "", string postfix = "")
	{
		return null;
	}

	[Token(Token = "0x60010E2")]
	[Address(RVA = "0x5A85A0", Offset = "0x5A6FA0", VA = "0x1805A85A0")]
	public CapitalizationManager()
	{
	}
}
