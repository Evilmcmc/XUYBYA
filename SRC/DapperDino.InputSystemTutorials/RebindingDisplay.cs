using Il2CppDummyDll;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DapperDino.InputSystemTutorials;

[Token(Token = "0x200015E")]
public class RebindingDisplay : MonoBehaviour
{
	[Token(Token = "0x400086B")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private string actionName;

	[Token(Token = "0x400086C")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private PlayerInput playerInput;

	[Token(Token = "0x400086D")]
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	private TMP_Text bindingDisplayNameText;

	[Token(Token = "0x400086E")]
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	private GameObject startRebindObject;

	[Token(Token = "0x400086F")]
	[FieldOffset(Offset = "0x40")]
	[SerializeField]
	private GameObject waitingForInputObject;

	[Token(Token = "0x4000870")]
	[FieldOffset(Offset = "0x48")]
	private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

	[Token(Token = "0x4000871")]
	private const string RebindsKey = "rebinds";

	[Token(Token = "0x6000CC8")]
	[Address(RVA = "0x5641B0", Offset = "0x562BB0", VA = "0x1805641B0")]
	private void Start()
	{
	}

	[Token(Token = "0x6000CC9")]
	[Address(RVA = "0x5641C0", Offset = "0x562BC0", VA = "0x1805641C0")]
	public void LoadKeyBindings()
	{
	}

	[Token(Token = "0x6000CCA")]
	[Address(RVA = "0x5645B0", Offset = "0x562FB0", VA = "0x1805645B0")]
	public void Save()
	{
	}

	[Token(Token = "0x6000CCB")]
	[Address(RVA = "0x564A00", Offset = "0x563400", VA = "0x180564A00")]
	public void StartRebinding()
	{
	}

	[Token(Token = "0x6000CCC")]
	[Address(RVA = "0x564C80", Offset = "0x563680", VA = "0x180564C80")]
	private void RebindComplete()
	{
	}

	[Token(Token = "0x6000CCD")]
	[Address(RVA = "0x5652B0", Offset = "0x563CB0", VA = "0x1805652B0")]
	private bool CheckForDuplicateBindings(InputAction newAction, int bindingIndex, bool allCompositeParts = false)
	{
		return default(bool);
	}

	[Token(Token = "0x6000CCE")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public RebindingDisplay()
	{
	}
}
