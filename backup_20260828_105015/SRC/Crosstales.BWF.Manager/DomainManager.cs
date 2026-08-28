using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Crosstales.BWF.Data;
using Crosstales.BWF.Filter;
using Crosstales.BWF.Provider;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.Serialization;

namespace Crosstales.BWF.Manager;

[Token(Token = "0x2000213")]
[DisallowMultipleComponent]
[HelpURL("https://www.crosstales.com/media/data/assets/badwordfilter/api/class_crosstales_1_1_b_w_f_1_1_manager_1_1_domain_manager.html")]
public class DomainManager : BaseManager<DomainManager, DomainFilter>
{
	[Token(Token = "0x4000AC0")]
	[FieldOffset(Offset = "0x50")]
	[FormerlySerializedAs("ReplaceChars")]
	[Header("Specific Settings")]
	[Tooltip("Replace characters for domains (default: *).")]
	[SerializeField]
	private string replaceChars;

	[Token(Token = "0x4000AC1")]
	[FieldOffset(Offset = "0x58")]
	[FormerlySerializedAs("DomainProvider")]
	[Header("Domain Providers")]
	[Tooltip("List of all domain providers.")]
	[SerializeField]
	private List<DomainProvider> domainProvider;

	[Token(Token = "0x4000AC2")]
	[FieldOffset(Offset = "0x60")]
	[Header("Events")]
	public OnContainsCompleted OnContainsCompleted;

	[Token(Token = "0x4000AC3")]
	[FieldOffset(Offset = "0x68")]
	public OnGetAllCompleted OnGetAllCompleted;

	[Token(Token = "0x4000AC4")]
	[FieldOffset(Offset = "0x70")]
	public OnReplaceAllCompleted OnReplaceAllCompleted;

	[Token(Token = "0x4000AC5")]
	[FieldOffset(Offset = "0x78")]
	private Thread _worker;

	[Token(Token = "0x1700017D")]
	public string ReplaceChars
	{
		[Token(Token = "0x60010FB")]
		[Address(RVA = "0x5A5280", Offset = "0x5A3C80", VA = "0x1805A5280")]
		get
		{
			return null;
		}
		[Token(Token = "0x60010FC")]
		[Address(RVA = "0x5A52A0", Offset = "0x5A3CA0", VA = "0x1805A52A0")]
		set
		{
		}
	}

	[Token(Token = "0x1700017E")]
	public List<DomainProvider> DomainProvider
	{
		[Token(Token = "0x60010FD")]
		[Address(RVA = "0x5A7900", Offset = "0x5A6300", VA = "0x1805A7900")]
		get
		{
			return null;
		}
		[Token(Token = "0x60010FE")]
		[Address(RVA = "0x5A9510", Offset = "0x5A7F10", VA = "0x1805A9510")]
		set
		{
		}
	}

	[Token(Token = "0x1700017F")]
	public List<Source> Sources
	{
		[Token(Token = "0x60010FF")]
		[Address(RVA = "0x5A5560", Offset = "0x5A3F60", VA = "0x1805A5560")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000180")]
	public int TotalRegexCount
	{
		[Token(Token = "0x6001100")]
		[Address(RVA = "0x5A9570", Offset = "0x5A7F70", VA = "0x1805A9570")]
		get
		{
			return default(int);
		}
	}

	[Token(Token = "0x17000181")]
	protected override OnContainsCompleted onContainsCompleted
	{
		[Token(Token = "0x6001101")]
		[Address(RVA = "0x59E250", Offset = "0x59CC50", VA = "0x18059E250", Slot = "7")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000182")]
	protected override OnGetAllCompleted onGetAllCompleted
	{
		[Token(Token = "0x6001102")]
		[Address(RVA = "0x59E2C0", Offset = "0x59CCC0", VA = "0x18059E2C0", Slot = "8")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000183")]
	protected override OnReplaceAllCompleted onReplaceAllCompleted
	{
		[Token(Token = "0x6001103")]
		[Address(RVA = "0x59E330", Offset = "0x59CD30", VA = "0x18059E330", Slot = "9")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x6001104")]
	[Address(RVA = "0x5A9720", Offset = "0x5A8120", VA = "0x1805A9720", Slot = "4")]
	protected override void Awake()
	{
	}

	[Token(Token = "0x6001105")]
	[Address(RVA = "0x5A98A0", Offset = "0x5A82A0", VA = "0x1805A98A0")]
	private void OnValidate()
	{
	}

	[Token(Token = "0x6001106")]
	[Address(RVA = "0x5A99C0", Offset = "0x5A83C0", VA = "0x1805A99C0", Slot = "6")]
	protected override void OnApplicationQuit()
	{
	}

	[Token(Token = "0x6001107")]
	[Address(RVA = "0x5A9A40", Offset = "0x5A8440", VA = "0x1805A9A40")]
	public static void ResetObject()
	{
	}

	[Token(Token = "0x6001108")]
	[Address(RVA = "0x5A9AA0", Offset = "0x5A84A0", VA = "0x1805A9AA0")]
	public void Load()
	{
	}

	[Token(Token = "0x6001109")]
	[Address(RVA = "0x5A5D90", Offset = "0x5A4790", VA = "0x1805A5D90")]
	public bool Contains(string text, params string[] sourceNames)
	{
		return default(bool);
	}

	[Token(Token = "0x600110A")]
	[Address(RVA = "0x5A9B90", Offset = "0x5A8590", VA = "0x1805A9B90")]
	public void ContainsAsync(string text, params string[] sourceNames)
	{
	}

	[Token(Token = "0x600110B")]
	[Address(RVA = "0x5A9D00", Offset = "0x5A8700", VA = "0x1805A9D00")]
	public List<string> GetAll(string text, params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x600110C")]
	[Address(RVA = "0x5A9DC0", Offset = "0x5A87C0", VA = "0x1805A9DC0")]
	public void GetAllAsync(string text, params string[] sourceNames)
	{
	}

	[Token(Token = "0x600110D")]
	[Address(RVA = "0x5A6160", Offset = "0x5A4B60", VA = "0x1805A6160")]
	public string ReplaceAll(string text, bool markOnly = false, string prefix = "", string postfix = "", params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x600110E")]
	[Address(RVA = "0x5A9F30", Offset = "0x5A8930", VA = "0x1805A9F30")]
	public void ReplaceAllAsync(string text, bool markOnly = false, string prefix = "", string postfix = "", params string[] sourceNames)
	{
	}

	[Token(Token = "0x600110F")]
	[Address(RVA = "0x5A61F0", Offset = "0x5A4BF0", VA = "0x1805A61F0")]
	public string Mark(string text, bool replace = false, string prefix = "<b><color=red>", string postfix = "</color></b>", params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x6001110")]
	[Address(RVA = "0x5A9F70", Offset = "0x5A8970", VA = "0x1805A9F70")]
	[IteratorStateMachine(typeof(_003CcontainsAsync_003Ed__34))]
	private IEnumerator containsAsync(string text, params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x6001111")]
	[Address(RVA = "0x5AA0D0", Offset = "0x5A8AD0", VA = "0x1805AA0D0")]
	[IteratorStateMachine(typeof(_003CgetAllAsync_003Ed__35))]
	private IEnumerator getAllAsync(string text, params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x6001112")]
	[Address(RVA = "0x5AA230", Offset = "0x5A8C30", VA = "0x1805AA230")]
	[IteratorStateMachine(typeof(_003CreplaceAllAsync_003Ed__36))]
	private IEnumerator replaceAllAsync(string text, bool markOnly = false, string prefix = "", string postfix = "", params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x6001113")]
	[Address(RVA = "0x5AA440", Offset = "0x5A8E40", VA = "0x1805AA440")]
	public DomainManager()
	{
	}
}
