using System.Collections.Generic;
using Crosstales.Common.Model.Enum;
using Il2CppDummyDll;
using UnityEngine;

namespace Crosstales.Common.Util;

[Token(Token = "0x20001CB")]
public class PlatformController : MonoBehaviour
{
	[Token(Token = "0x4000932")]
	[FieldOffset(Offset = "0x20")]
	[Header("Configuration")]
	[Tooltip("Selected platforms for the controller.")]
	public List<Platform> Platforms;

	[Token(Token = "0x4000933")]
	[FieldOffset(Offset = "0x28")]
	[Tooltip("Enable or disable the 'Objects' for the selected 'Platforms' (default: true).")]
	public bool Active;

	[Token(Token = "0x4000934")]
	[FieldOffset(Offset = "0x30")]
	[Header("GameObjects")]
	[Tooltip("Selected objects for the controller.")]
	public GameObject[] Objects;

	[Token(Token = "0x4000935")]
	[FieldOffset(Offset = "0x38")]
	[Header("MonoBehaviour Scripts")]
	[Tooltip("Selected scripts for the controller.")]
	public MonoBehaviour[] Scripts;

	[Token(Token = "0x4000936")]
	[FieldOffset(Offset = "0x40")]
	protected Platform _currentPlatform;

	[Token(Token = "0x6000EDC")]
	[Address(RVA = "0x5849D0", Offset = "0x5833D0", VA = "0x1805849D0", Slot = "4")]
	protected virtual void Awake()
	{
	}

	[Token(Token = "0x6000EDD")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	private void Start()
	{
	}

	[Token(Token = "0x6000EDE")]
	[Address(RVA = "0x584B10", Offset = "0x583510", VA = "0x180584B10")]
	protected void selectPlatform()
	{
	}

	[Token(Token = "0x6000EDF")]
	[Address(RVA = "0x584BB0", Offset = "0x5835B0", VA = "0x180584BB0")]
	protected void activateGameObjects()
	{
	}

	[Token(Token = "0x6000EE0")]
	[Address(RVA = "0x584FD0", Offset = "0x5839D0", VA = "0x180584FD0")]
	protected void activateScripts()
	{
	}

	[Token(Token = "0x6000EE1")]
	[Address(RVA = "0x5853F0", Offset = "0x583DF0", VA = "0x1805853F0")]
	public PlatformController()
	{
	}
}
