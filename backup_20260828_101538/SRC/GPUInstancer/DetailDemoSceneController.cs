using System.Collections.Generic;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.UI;

namespace GPUInstancer;

[Token(Token = "0x2000140")]
public class DetailDemoSceneController : MonoBehaviour
{
	[Token(Token = "0x2000141")]
	private enum CameraModes
	{
		[Token(Token = "0x4000794")]
		FPMode,
		[Token(Token = "0x4000795")]
		SpaceshipMode,
		[Token(Token = "0x4000796")]
		MowerMode
	}

	[Token(Token = "0x2000142")]
	private enum QualityMode
	{
		[Token(Token = "0x4000798")]
		Low,
		[Token(Token = "0x4000799")]
		Mid,
		[Token(Token = "0x400079A")]
		High
	}

	[Token(Token = "0x4000782")]
	[FieldOffset(Offset = "0x20")]
	public GameObject fpController;

	[Token(Token = "0x4000783")]
	[FieldOffset(Offset = "0x28")]
	public GameObject spaceshipCamera;

	[Token(Token = "0x4000784")]
	[FieldOffset(Offset = "0x30")]
	public GameObject grassMowerCamera;

	[Token(Token = "0x4000785")]
	[FieldOffset(Offset = "0x38")]
	public GPUInstancerDetailManager detailManager;

	[Token(Token = "0x4000786")]
	[FieldOffset(Offset = "0x40")]
	public bool persistRemoval;

	[Token(Token = "0x4000787")]
	[FieldOffset(Offset = "0x48")]
	private GameObject _uiCanvas;

	[Token(Token = "0x4000788")]
	[FieldOffset(Offset = "0x50")]
	private GameObject _spaceShipControlsText;

	[Token(Token = "0x4000789")]
	[FieldOffset(Offset = "0x58")]
	private GameObject _grassMowerControlsText;

	[Token(Token = "0x400078A")]
	[FieldOffset(Offset = "0x60")]
	private GameObject _loadingTerrainDetailsText;

	[Token(Token = "0x400078B")]
	[FieldOffset(Offset = "0x68")]
	private Text _currentQualityModeText;

	[Token(Token = "0x400078C")]
	[FieldOffset(Offset = "0x70")]
	private Transform _spaceShip;

	[Token(Token = "0x400078D")]
	[FieldOffset(Offset = "0x78")]
	private Transform _grassMower;

	[Token(Token = "0x400078E")]
	[FieldOffset(Offset = "0x80")]
	private GameObject _activeCameraGO;

	[Token(Token = "0x400078F")]
	[FieldOffset(Offset = "0x88")]
	private CameraModes _currentCameraMode;

	[Token(Token = "0x4000790")]
	[FieldOffset(Offset = "0x90")]
	private ParticleSystem _spaceShipThrusterGlow;

	[Token(Token = "0x4000791")]
	[FieldOffset(Offset = "0x98")]
	private QualityMode _currentQualityMode;

	[Token(Token = "0x4000792")]
	[FieldOffset(Offset = "0xA0")]
	private List<int[,]> detailMapData;

	[Token(Token = "0x6000BD7")]
	[Address(RVA = "0x54E090", Offset = "0x54CA90", VA = "0x18054E090")]
	private void Awake()
	{
	}

	[Token(Token = "0x6000BD8")]
	[Address(RVA = "0x54E5F0", Offset = "0x54CFF0", VA = "0x18054E5F0")]
	private void Update()
	{
	}

	[Token(Token = "0x6000BD9")]
	[Address(RVA = "0x54EA70", Offset = "0x54D470", VA = "0x18054EA70")]
	private void SwitchCameraMode()
	{
	}

	[Token(Token = "0x6000BDA")]
	[Address(RVA = "0x54EAA0", Offset = "0x54D4A0", VA = "0x18054EAA0")]
	private void SetCameraMode(CameraModes cameraMode)
	{
	}

	[Token(Token = "0x6000BDB")]
	[Address(RVA = "0x54EFB0", Offset = "0x54D9B0", VA = "0x18054EFB0")]
	private void DisableLoadingTerrainDetailsText()
	{
	}

	[Token(Token = "0x6000BDC")]
	[Address(RVA = "0x54F110", Offset = "0x54DB10", VA = "0x18054F110")]
	private void SetQualityMode(QualityMode qualityMode)
	{
	}

	[Token(Token = "0x6000BDD")]
	[Address(RVA = "0x54F310", Offset = "0x54DD10", VA = "0x18054F310")]
	private void SetPrototypesByQuality(QualityMode qualityMode)
	{
	}

	[Token(Token = "0x6000BDE")]
	[Address(RVA = "0x54F520", Offset = "0x54DF20", VA = "0x18054F520")]
	public DetailDemoSceneController()
	{
	}
}
