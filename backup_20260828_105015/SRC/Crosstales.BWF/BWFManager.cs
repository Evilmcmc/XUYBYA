using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Crosstales.BWF.Data;
using Crosstales.BWF.Model.Enum;
using Crosstales.Common.Util;
using Il2CppDummyDll;
using UnityEngine;

namespace Crosstales.BWF;

[Token(Token = "0x20001DD")]
[ExecuteInEditMode]
[HelpURL("https://www.crosstales.com/media/data/assets/badwordfilter/api/class_crosstales_1_1_b_w_f_1_1_b_w_f_manager.html")]
public class BWFManager : Singleton<BWFManager>
{
	[Token(Token = "0x20001DE")]
	public delegate void BWFReady();

	[Token(Token = "0x40009CA")]
	[FieldOffset(Offset = "0x28")]
	[Tooltip("Disables the ordering of the 'GetAll'-method (prevent possible memory garbage).")]
	public bool DisableOrdering;

	[Token(Token = "0x40009CB")]
	[FieldOffset(Offset = "0x29")]
	private bool _sentReady;

	[Token(Token = "0x40009CC")]
	[FieldOffset(Offset = "0x30")]
	private Thread _worker;

	[Token(Token = "0x40009CD")]
	[FieldOffset(Offset = "0x38")]
	private readonly List<string> _getAllResult;

	[Token(Token = "0x40009CE")]
	[FieldOffset(Offset = "0x40")]
	[Header("Events")]
	public OnReady OnReady;

	[Token(Token = "0x40009CF")]
	[FieldOffset(Offset = "0x48")]
	public OnContainsCompleted OnContainsCompleted;

	[Token(Token = "0x40009D0")]
	[FieldOffset(Offset = "0x50")]
	public OnGetAllCompleted OnGetAllCompleted;

	[Token(Token = "0x40009D1")]
	[FieldOffset(Offset = "0x58")]
	public OnReplaceAllCompleted OnReplaceAllCompleted;

	[Token(Token = "0x17000142")]
	public bool isReady
	{
		[Token(Token = "0x6000FC2")]
		[Address(RVA = "0x598980", Offset = "0x597380", VA = "0x180598980")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x17000143")]
	public int TotalRegexCount
	{
		[Token(Token = "0x6000FC3")]
		[Address(RVA = "0x598EB0", Offset = "0x5978B0", VA = "0x180598EB0")]
		get
		{
			return default(int);
		}
	}

	[Token(Token = "0x14000008")]
	public event BWFReady OnBWFReady
	{
		[Token(Token = "0x6000FC4")]
		[Address(RVA = "0x599060", Offset = "0x597A60", VA = "0x180599060")]
		[CompilerGenerated]
		add
		{
		}
		[Token(Token = "0x6000FC5")]
		[Address(RVA = "0x599150", Offset = "0x597B50", VA = "0x180599150")]
		[CompilerGenerated]
		remove
		{
		}
	}

	[Token(Token = "0x14000009")]
	public event ContainsComplete OnContainsComplete
	{
		[Token(Token = "0x6000FC6")]
		[Address(RVA = "0x599240", Offset = "0x597C40", VA = "0x180599240")]
		[CompilerGenerated]
		add
		{
		}
		[Token(Token = "0x6000FC7")]
		[Address(RVA = "0x599330", Offset = "0x597D30", VA = "0x180599330")]
		[CompilerGenerated]
		remove
		{
		}
	}

	[Token(Token = "0x1400000A")]
	public event GetAllComplete OnGetAllComplete
	{
		[Token(Token = "0x6000FC8")]
		[Address(RVA = "0x599420", Offset = "0x597E20", VA = "0x180599420")]
		[CompilerGenerated]
		add
		{
		}
		[Token(Token = "0x6000FC9")]
		[Address(RVA = "0x599510", Offset = "0x597F10", VA = "0x180599510")]
		[CompilerGenerated]
		remove
		{
		}
	}

	[Token(Token = "0x1400000B")]
	public event ReplaceAllComplete OnReplaceAllComplete
	{
		[Token(Token = "0x6000FCA")]
		[Address(RVA = "0x599600", Offset = "0x598000", VA = "0x180599600")]
		[CompilerGenerated]
		add
		{
		}
		[Token(Token = "0x6000FCB")]
		[Address(RVA = "0x5996F0", Offset = "0x5980F0", VA = "0x1805996F0")]
		[CompilerGenerated]
		remove
		{
		}
	}

	[Token(Token = "0x6000FCC")]
	[Address(RVA = "0x5997E0", Offset = "0x5981E0", VA = "0x1805997E0", Slot = "6")]
	protected override void OnApplicationQuit()
	{
	}

	[Token(Token = "0x6000FCD")]
	[Address(RVA = "0x599860", Offset = "0x598260", VA = "0x180599860")]
	private void Update()
	{
	}

	[Token(Token = "0x6000FCE")]
	[Address(RVA = "0x5998F0", Offset = "0x5982F0", VA = "0x1805998F0")]
	public void Load(ManagerMask mask = ManagerMask.All)
	{
	}

	[Token(Token = "0x6000FCF")]
	[Address(RVA = "0x599A90", Offset = "0x598490", VA = "0x180599A90")]
	public List<Source> Sources(ManagerMask mask = ManagerMask.All)
	{
		return null;
	}

	[Token(Token = "0x6000FD0")]
	[Address(RVA = "0x599ED0", Offset = "0x5988D0", VA = "0x180599ED0")]
	public bool Contains(string text, ManagerMask mask = ManagerMask.All, params string[] sourceNames)
	{
		return default(bool);
	}

	[Token(Token = "0x6000FD1")]
	[Address(RVA = "0x599F20", Offset = "0x598920", VA = "0x180599F20")]
	public void ContainsAsync(string text, ManagerMask mask = ManagerMask.All, params string[] sourceNames)
	{
	}

	[Token(Token = "0x6000FD2")]
	[Address(RVA = "0x59A090", Offset = "0x598A90", VA = "0x18059A090")]
	public List<string> GetAll(string text, ManagerMask mask = ManagerMask.All, params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x6000FD3")]
	[Address(RVA = "0x59A0E0", Offset = "0x598AE0", VA = "0x18059A0E0")]
	public void GetAllAsync(string text, ManagerMask mask = ManagerMask.All, params string[] sourceNames)
	{
	}

	[Token(Token = "0x6000FD4")]
	[Address(RVA = "0x59A250", Offset = "0x598C50", VA = "0x18059A250")]
	public string ReplaceAll(string text, ManagerMask mask = ManagerMask.All, params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x6000FD5")]
	[Address(RVA = "0x59A2C0", Offset = "0x598CC0", VA = "0x18059A2C0")]
	public string ReplaceAll(string text, ManagerMask mask, bool markOnly, string prefix, string postfix, params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x6000FD6")]
	[Address(RVA = "0x59A330", Offset = "0x598D30", VA = "0x18059A330")]
	public void ReplaceAllAsync(string text, ManagerMask mask = ManagerMask.All, params string[] sourceNames)
	{
	}

	[Token(Token = "0x6000FD7")]
	[Address(RVA = "0x59A380", Offset = "0x598D80", VA = "0x18059A380")]
	public void ReplaceAllAsync(string text, ManagerMask mask, bool markOnly, string prefix, string postfix, params string[] sourceNames)
	{
	}

	[Token(Token = "0x6000FD8")]
	[Address(RVA = "0x59A3D0", Offset = "0x598DD0", VA = "0x18059A3D0")]
	public string Mark(string text, List<string> unwantedWords, string prefix = "<b><color=red>", string postfix = "</color></b>")
	{
		return null;
	}

	[Token(Token = "0x6000FD9")]
	[Address(RVA = "0x59AA00", Offset = "0x599400", VA = "0x18059AA00")]
	public string Mark(string text, bool replace = false, string prefix = "<b><color=red>", string postfix = "</color></b>", ManagerMask mask = ManagerMask.All, params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x6000FDA")]
	[Address(RVA = "0x59AD40", Offset = "0x599740", VA = "0x18059AD40")]
	public string Unmark(string text, string prefix = "<b><color=red>", string postfix = "</color></b>")
	{
		return null;
	}

	[Token(Token = "0x6000FDB")]
	[Address(RVA = "0x59AE30", Offset = "0x599830", VA = "0x18059AE30")]
	[IteratorStateMachine(typeof(_003CcontainsAsync_003Ed__40))]
	private IEnumerator containsAsync(string text, ManagerMask mask = ManagerMask.All, params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x6000FDC")]
	[Address(RVA = "0x59AFA0", Offset = "0x5999A0", VA = "0x18059AFA0")]
	[IteratorStateMachine(typeof(_003CgetAllAsync_003Ed__41))]
	private IEnumerator getAllAsync(string text, ManagerMask mask = ManagerMask.All, params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x6000FDD")]
	[Address(RVA = "0x59B110", Offset = "0x599B10", VA = "0x18059B110")]
	[IteratorStateMachine(typeof(_003CreplaceAllAsync_003Ed__42))]
	private IEnumerator replaceAllAsync(string text, ManagerMask mask = ManagerMask.All, bool markOnly = false, string prefix = "", string postfix = "", params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x6000FDE")]
	[Address(RVA = "0x59B330", Offset = "0x599D30", VA = "0x18059B330")]
	private static void contains(out bool result, string text, ManagerMask mask = ManagerMask.All, params string[] sourceNames)
	{
	}

	[Token(Token = "0x6000FDF")]
	[Address(RVA = "0x59B570", Offset = "0x599F70", VA = "0x18059B570")]
	private static void getAll(out List<string> result, string text, ManagerMask mask = ManagerMask.All, params string[] sourceNames)
	{
	}

	[Token(Token = "0x6000FE0")]
	[Address(RVA = "0x59BDA0", Offset = "0x59A7A0", VA = "0x18059BDA0")]
	private static void replaceAll(out string result, string text, ManagerMask mask = ManagerMask.All, bool markOnly = false, string prefix = "", string postfix = "", params string[] sourceNames)
	{
	}

	[Token(Token = "0x6000FE1")]
	[Address(RVA = "0x59C1F0", Offset = "0x59ABF0", VA = "0x18059C1F0")]
	private void onBWFReady()
	{
	}

	[Token(Token = "0x6000FE2")]
	[Address(RVA = "0x59C270", Offset = "0x59AC70", VA = "0x18059C270")]
	private void onContainsComplete(string text, bool result)
	{
	}

	[Token(Token = "0x6000FE3")]
	[Address(RVA = "0x59C330", Offset = "0x59AD30", VA = "0x18059C330")]
	private void onGetAllComplete(string text, List<string> badWords)
	{
	}

	[Token(Token = "0x6000FE4")]
	[Address(RVA = "0x59C4D0", Offset = "0x59AED0", VA = "0x18059C4D0")]
	private void onReplaceAllComplete(string originalText, string cleanText)
	{
	}

	[Token(Token = "0x6000FE5")]
	[Address(RVA = "0x59C580", Offset = "0x59AF80", VA = "0x18059C580")]
	public BWFManager()
	{
	}
}
