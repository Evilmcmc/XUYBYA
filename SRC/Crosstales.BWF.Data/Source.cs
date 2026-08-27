using System;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.Serialization;

namespace Crosstales.BWF.Data;

[Serializable]
[Token(Token = "0x2000233")]
[HelpURL("https://www.crosstales.com/media/data/assets/badwordfilter/api/class_crosstales_1_1_b_w_f_1_1_data_1_1_source.html")]
[CreateAssetMenu(fileName = "New Source", menuName = "Bad Word Filter PRO/Source", order = 1000)]
public class Source : ScriptableObject
{
	[Token(Token = "0x4000B9C")]
	[FieldOffset(Offset = "0x18")]
	[FormerlySerializedAs("Name")]
	[SerializeField]
	[Header("Information")]
	[Tooltip("Name of the source.")]
	private string sourceName;

	[Token(Token = "0x4000B9D")]
	[FieldOffset(Offset = "0x20")]
	[FormerlySerializedAs("Culture")]
	[SerializeField]
	[Tooltip("Culture of the source (ISO 639-1).")]
	private string culture;

	[Token(Token = "0x4000B9E")]
	[FieldOffset(Offset = "0x28")]
	[FormerlySerializedAs("Description")]
	[SerializeField]
	[Tooltip("Description for the source (optional).")]
	private string description;

	[Token(Token = "0x4000B9F")]
	[FieldOffset(Offset = "0x30")]
	[FormerlySerializedAs("Icon")]
	[SerializeField]
	[Tooltip("Icon to represent the source (e.g. country flag, optional)")]
	private Sprite icon;

	[Token(Token = "0x4000BA0")]
	[FieldOffset(Offset = "0x38")]
	[FormerlySerializedAs("URL")]
	[SerializeField]
	[Header("Settings")]
	[Tooltip("URL of a text file containing all regular expressions for this source. Add also the protocol-type ('http://', 'file://' etc.).")]
	private string url;

	[Token(Token = "0x4000BA1")]
	[FieldOffset(Offset = "0x40")]
	[FormerlySerializedAs("Resource")]
	[SerializeField]
	[Tooltip("Text file containing all regular expressions for this source.")]
	private TextAsset resource;

	[Token(Token = "0x4000BA2")]
	[FieldOffset(Offset = "0x48")]
	[SerializeField]
	[Tooltip("Indicates if the 'Resource' is used as fallback in case the URL could not be loaded.")]
	private bool isResourceFallback;

	[Token(Token = "0x170001A3")]
	public string SourceName
	{
		[Token(Token = "0x6001215")]
		[Address(RVA = "0x457C10", Offset = "0x456610", VA = "0x180457C10")]
		get
		{
			return null;
		}
		[Token(Token = "0x6001216")]
		[Address(RVA = "0x5AA540", Offset = "0x5A8F40", VA = "0x1805AA540")]
		set
		{
		}
	}

	[Token(Token = "0x170001A4")]
	public string Culture
	{
		[Token(Token = "0x6001217")]
		[Address(RVA = "0x5C1A10", Offset = "0x5C0410", VA = "0x1805C1A10")]
		get
		{
			return null;
		}
		[Token(Token = "0x6001218")]
		[Address(RVA = "0x4FC180", Offset = "0x4FAB80", VA = "0x1804FC180")]
		set
		{
		}
	}

	[Token(Token = "0x170001A5")]
	public string Description
	{
		[Token(Token = "0x6001219")]
		[Address(RVA = "0x48F970", Offset = "0x48E370", VA = "0x18048F970")]
		get
		{
			return null;
		}
		[Token(Token = "0x600121A")]
		[Address(RVA = "0x5C0720", Offset = "0x5BF120", VA = "0x1805C0720")]
		set
		{
		}
	}

	[Token(Token = "0x170001A6")]
	public Sprite Icon
	{
		[Token(Token = "0x600121B")]
		[Address(RVA = "0x5B9630", Offset = "0x5B8030", VA = "0x1805B9630")]
		get
		{
			return null;
		}
		[Token(Token = "0x600121C")]
		[Address(RVA = "0x554960", Offset = "0x553360", VA = "0x180554960")]
		set
		{
		}
	}

	[Token(Token = "0x170001A7")]
	public string URL
	{
		[Token(Token = "0x600121D")]
		[Address(RVA = "0x595DA0", Offset = "0x5947A0", VA = "0x180595DA0")]
		get
		{
			return null;
		}
		[Token(Token = "0x600121E")]
		[Address(RVA = "0x5549C0", Offset = "0x5533C0", VA = "0x1805549C0")]
		set
		{
		}
	}

	[Token(Token = "0x170001A8")]
	public TextAsset Resource
	{
		[Token(Token = "0x600121F")]
		[Address(RVA = "0x543780", Offset = "0x542180", VA = "0x180543780")]
		get
		{
			return null;
		}
		[Token(Token = "0x6001220")]
		[Address(RVA = "0x5C1A20", Offset = "0x5C0420", VA = "0x1805C1A20")]
		set
		{
		}
	}

	[Token(Token = "0x170001A9")]
	public bool IsResourceFallback
	{
		[Token(Token = "0x6001221")]
		[Address(RVA = "0x5C1A80", Offset = "0x5C0480", VA = "0x1805C1A80")]
		get
		{
			return default(bool);
		}
		[Token(Token = "0x6001222")]
		[Address(RVA = "0x5C1A90", Offset = "0x5C0490", VA = "0x1805C1A90")]
		set
		{
		}
	}

	[Token(Token = "0x170001AA")]
	public int RegexCount
	{
		[Token(Token = "0x6001223")]
		[Address(RVA = "0x5C1AA0", Offset = "0x5C04A0", VA = "0x1805C1AA0")]
		get
		{
			return default(int);
		}
	}

	[Token(Token = "0x170001AB")]
	public string[] Regexes
	{
		[Token(Token = "0x6001224")]
		[Address(RVA = "0x5415C0", Offset = "0x53FFC0", VA = "0x1805415C0")]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[Token(Token = "0x6001225")]
		[Address(RVA = "0x513CC0", Offset = "0x5126C0", VA = "0x180513CC0")]
		[CompilerGenerated]
		set
		{
		}
	}

	[Token(Token = "0x6001226")]
	[Address(RVA = "0x5C1AB0", Offset = "0x5C04B0", VA = "0x1805C1AB0", Slot = "3")]
	public override string ToString()
	{
		return null;
	}

	[Token(Token = "0x6001227")]
	[Address(RVA = "0x5C1EE0", Offset = "0x5C08E0", VA = "0x1805C1EE0", Slot = "0")]
	public override bool Equals(object obj)
	{
		return default(bool);
	}

	[Token(Token = "0x6001228")]
	[Address(RVA = "0x5C2200", Offset = "0x5C0C00", VA = "0x1805C2200", Slot = "2")]
	public override int GetHashCode()
	{
		return default(int);
	}

	[Token(Token = "0x6001229")]
	[Address(RVA = "0x5C2380", Offset = "0x5C0D80", VA = "0x1805C2380")]
	public Source()
	{
	}
}
