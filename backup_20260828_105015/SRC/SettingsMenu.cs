using Il2CppDummyDll;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Localization;
using UnityEngine.UI;

[Token(Token = "0x2000046")]
public class SettingsMenu : MonoBehaviour
{
	[Token(Token = "0x40000E8")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private AudioMixer audioMixer;

	[Token(Token = "0x40000E9")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private Slider camSenseSlider;

	[Token(Token = "0x40000EA")]
	[FieldOffset(Offset = "0x30")]
	private Resolution[] resolutions;

	[Token(Token = "0x40000EB")]
	[FieldOffset(Offset = "0x38")]
	private int resolutionIndex;

	[Token(Token = "0x40000EC")]
	[FieldOffset(Offset = "0x40")]
	[SerializeField]
	private TMP_Text fullscreenText;

	[Token(Token = "0x40000ED")]
	[FieldOffset(Offset = "0x48")]
	[SerializeField]
	private TMP_Text resolutionText;

	[Token(Token = "0x40000EE")]
	[FieldOffset(Offset = "0x50")]
	[SerializeField]
	private TMP_Text qualityText;

	[Token(Token = "0x40000EF")]
	[FieldOffset(Offset = "0x58")]
	private int qualityIndex;

	[Token(Token = "0x40000F0")]
	[FieldOffset(Offset = "0x5C")]
	private bool isFullscreen;

	[Token(Token = "0x40000F1")]
	[FieldOffset(Offset = "0x60")]
	private RagdollCameraController camController;

	[Token(Token = "0x40000F2")]
	[FieldOffset(Offset = "0x68")]
	[Header("Sound")]
	[SerializeField]
	private Slider masterVolume;

	[Token(Token = "0x40000F3")]
	[FieldOffset(Offset = "0x70")]
	[SerializeField]
	private Slider SFXVolume;

	[Token(Token = "0x40000F4")]
	[FieldOffset(Offset = "0x78")]
	[SerializeField]
	private Slider musicVolume;

	[Token(Token = "0x40000F5")]
	[FieldOffset(Offset = "0x80")]
	[SerializeField]
	private Slider voiceVolume;

	[Token(Token = "0x40000F6")]
	[FieldOffset(Offset = "0x88")]
	[SerializeField]
	private Slider ambienceVolume;

	[Token(Token = "0x40000F7")]
	[FieldOffset(Offset = "0x90")]
	[SerializeField]
	private Slider camSense;

	[Token(Token = "0x40000F8")]
	[FieldOffset(Offset = "0x98")]
	[Header("Words")]
	[SerializeField]
	private LocalizedString fullScreenWord;

	[Token(Token = "0x40000F9")]
	[FieldOffset(Offset = "0xA0")]
	[SerializeField]
	private LocalizedString onWord;

	[Token(Token = "0x40000FA")]
	[FieldOffset(Offset = "0xA8")]
	[SerializeField]
	private LocalizedString offWord;

	[Token(Token = "0x40000FB")]
	[FieldOffset(Offset = "0xB0")]
	[SerializeField]
	private LocalizedString qualityWord;

	[Token(Token = "0x40000FC")]
	[FieldOffset(Offset = "0xB8")]
	[SerializeField]
	private LocalizedString veryLowWord;

	[Token(Token = "0x40000FD")]
	[FieldOffset(Offset = "0xC0")]
	[SerializeField]
	private LocalizedString lowWord;

	[Token(Token = "0x40000FE")]
	[FieldOffset(Offset = "0xC8")]
	[SerializeField]
	private LocalizedString mediumWord;

	[Token(Token = "0x40000FF")]
	[FieldOffset(Offset = "0xD0")]
	[SerializeField]
	private LocalizedString highWord;

	[Token(Token = "0x4000100")]
	[FieldOffset(Offset = "0xD8")]
	[SerializeField]
	private LocalizedString veryHighWord;

	[Token(Token = "0x4000101")]
	[FieldOffset(Offset = "0xE0")]
	[SerializeField]
	private LocalizedString resolutionWord;

	[Token(Token = "0x600019A")]
	[Address(RVA = "0x475DC0", Offset = "0x4747C0", VA = "0x180475DC0")]
	private void Start()
	{
	}

	[Token(Token = "0x600019B")]
	[Address(RVA = "0x476F70", Offset = "0x475970", VA = "0x180476F70")]
	private void OnEnable()
	{
	}

	[Token(Token = "0x600019C")]
	[Address(RVA = "0x476FF0", Offset = "0x4759F0", VA = "0x180476FF0")]
	private void OnDisable()
	{
	}

	[Token(Token = "0x600019D")]
	[Address(RVA = "0x4770B0", Offset = "0x475AB0", VA = "0x1804770B0")]
	private void OnLocaleChanged(UnityEngine.Localization.Locale newLocale)
	{
	}

	[Token(Token = "0x600019E")]
	[Address(RVA = "0x4774B0", Offset = "0x475EB0", VA = "0x1804774B0")]
	public void SetMasterVolume(float volume)
	{
	}

	[Token(Token = "0x600019F")]
	[Address(RVA = "0x477540", Offset = "0x475F40", VA = "0x180477540")]
	public void SetSFXVolume(float volume)
	{
	}

	[Token(Token = "0x60001A0")]
	[Address(RVA = "0x4775D0", Offset = "0x475FD0", VA = "0x1804775D0")]
	public void SetMusicVolume(float volume)
	{
	}

	[Token(Token = "0x60001A1")]
	[Address(RVA = "0x477660", Offset = "0x476060", VA = "0x180477660")]
	public void SetVoiceVolume(float volume)
	{
	}

	[Token(Token = "0x60001A2")]
	[Address(RVA = "0x4776F0", Offset = "0x4760F0", VA = "0x1804776F0")]
	public void SetAmbienceVolume(float volume)
	{
	}

	[Token(Token = "0x60001A3")]
	[Address(RVA = "0x477780", Offset = "0x476180", VA = "0x180477780")]
	public void SetFullscreen()
	{
	}

	[Token(Token = "0x60001A4")]
	[Address(RVA = "0x4778D0", Offset = "0x4762D0", VA = "0x1804778D0")]
	public void NextQuality()
	{
	}

	[Token(Token = "0x60001A5")]
	[Address(RVA = "0x477A90", Offset = "0x476490", VA = "0x180477A90")]
	public void PreviousQuality()
	{
	}

	[Token(Token = "0x60001A6")]
	[Address(RVA = "0x477C50", Offset = "0x476650", VA = "0x180477C50")]
	public void NextResolution()
	{
	}

	[Token(Token = "0x60001A7")]
	[Address(RVA = "0x477FD0", Offset = "0x4769D0", VA = "0x180477FD0")]
	public void PreviousResolution()
	{
	}

	[Token(Token = "0x60001A8")]
	[Address(RVA = "0x478350", Offset = "0x476D50", VA = "0x180478350")]
	public void SetCameraSensitivity(float newValue)
	{
	}

	[Token(Token = "0x60001A9")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public SettingsMenu()
	{
	}
}
