using System.Collections;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Localization;
using UnityEngine.Video;

[Token(Token = "0x20000C4")]
public class Tutorial : MonoBehaviour
{
	[Token(Token = "0x400040F")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private MenuCameraMovement camMove;

	[Token(Token = "0x4000410")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private MainMenu mainMenuManager;

	[Token(Token = "0x4000411")]
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	private Animator animator;

	[Token(Token = "0x4000412")]
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	private LocalizedString skipLocalString;

	[Token(Token = "0x4000413")]
	[FieldOffset(Offset = "0x40")]
	[SerializeField]
	private LocalizedString[] bigBoyLocalStrings;

	[Token(Token = "0x4000414")]
	[FieldOffset(Offset = "0x48")]
	[SerializeField]
	private LocalizedString bigBoyName;

	[Token(Token = "0x4000415")]
	[FieldOffset(Offset = "0x50")]
	[SerializeField]
	private TextMeshProUGUI dialogueText;

	[Token(Token = "0x4000416")]
	[FieldOffset(Offset = "0x58")]
	[SerializeField]
	private TextMeshProUGUI skipText;

	[Token(Token = "0x4000417")]
	[FieldOffset(Offset = "0x60")]
	[SerializeField]
	private float dialogueSpeed;

	[Token(Token = "0x4000418")]
	[FieldOffset(Offset = "0x64")]
	private bool isSpeaking;

	[Token(Token = "0x4000419")]
	[FieldOffset(Offset = "0x68")]
	[SerializeField]
	private AudioClip[] dialogueTypingSoundClips;

	[Token(Token = "0x400041A")]
	[FieldOffset(Offset = "0x70")]
	[SerializeField]
	private AudioSource audioSource;

	[Token(Token = "0x400041B")]
	[FieldOffset(Offset = "0x78")]
	[Header("Videos")]
	[SerializeField]
	private VideoPlayer videoPlayer;

	[Token(Token = "0x400041C")]
	[FieldOffset(Offset = "0x80")]
	[SerializeField]
	private VideoClip offlineVideo;

	[Token(Token = "0x400041D")]
	[FieldOffset(Offset = "0x88")]
	[SerializeField]
	private VideoClip grapplingVideo;

	[Token(Token = "0x400041E")]
	[FieldOffset(Offset = "0x90")]
	[SerializeField]
	private VideoClip momentumVideo;

	[Token(Token = "0x400041F")]
	[FieldOffset(Offset = "0x98")]
	[SerializeField]
	private VideoClip shootVideo;

	[Token(Token = "0x4000420")]
	[FieldOffset(Offset = "0xA0")]
	[Header("Keybindings")]
	[SerializeField]
	private PlayerInput playerInput;

	[Token(Token = "0x4000421")]
	[FieldOffset(Offset = "0xA8")]
	private int currentDialogue;

	[Token(Token = "0x6000600")]
	[Address(RVA = "0x4D4760", Offset = "0x4D3160", VA = "0x1804D4760")]
	private bool HasCompletedAllAchievements()
	{
		return default(bool);
	}

	[Token(Token = "0x6000601")]
	[Address(RVA = "0x4D47C0", Offset = "0x4D31C0", VA = "0x1804D47C0")]
	public void StartTutorial()
	{
	}

	[Token(Token = "0x6000602")]
	[Address(RVA = "0x4D4BF0", Offset = "0x4D35F0", VA = "0x1804D4BF0")]
	private void UpdateSkipString()
	{
	}

	[Token(Token = "0x6000603")]
	[Address(RVA = "0x4D4D50", Offset = "0x4D3750", VA = "0x1804D4D50")]
	public void StopTutorial()
	{
	}

	[Token(Token = "0x6000604")]
	[Address(RVA = "0x4D4FE0", Offset = "0x4D39E0", VA = "0x1804D4FE0")]
	private string GetKeybindingName(string action)
	{
		return null;
	}

	[Token(Token = "0x6000605")]
	[Address(RVA = "0x4D5360", Offset = "0x4D3D60", VA = "0x1804D5360")]
	public string GetString(int currentDialogue)
	{
		return null;
	}

	[Token(Token = "0x6000606")]
	[Address(RVA = "0x4D56A0", Offset = "0x4D40A0", VA = "0x1804D56A0")]
	public void NextDialgoue(InputAction.CallbackContext ctx)
	{
	}

	[Token(Token = "0x6000607")]
	[Address(RVA = "0x4D58C0", Offset = "0x4D42C0", VA = "0x1804D58C0")]
	[IteratorStateMachine(typeof(_003CStartDialogue_003Ed__26))]
	private IEnumerator StartDialogue(string dialogue, int dialogueTextTime)
	{
		return null;
	}

	[Token(Token = "0x6000608")]
	[Address(RVA = "0x4D59C0", Offset = "0x4D43C0", VA = "0x1804D59C0")]
	public Tutorial()
	{
	}
}
