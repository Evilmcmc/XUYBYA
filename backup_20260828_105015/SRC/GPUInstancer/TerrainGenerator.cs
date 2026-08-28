using System.Runtime.InteropServices;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.UI;

namespace GPUInstancer;

[Token(Token = "0x2000137")]
public class TerrainGenerator : MonoBehaviour
{
	[Token(Token = "0x4000708")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x20")]
	public Texture2D groundTexture;

	[Token(Token = "0x4000709")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x28")]
	public Texture2D detailTexture;

	[Token(Token = "0x400070A")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x30")]
	public GameObject FpsController;

	[Token(Token = "0x400070B")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x38")]
	public GameObject FixedCamera;

	[Token(Token = "0x400070C")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x40")]
	private int terrainSize;

	[Token(Token = "0x400070D")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x44")]
	private int terrainCounter;

	[Token(Token = "0x400070E")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x48")]
	private Vector3 terrainShiftX;

	[Token(Token = "0x400070F")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x54")]
	private Vector3 terrainShiftZ;

	[Token(Token = "0x4000710")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x60")]
	private Terrain[] terrainArray;

	[Token(Token = "0x4000711")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x68")]
	private bool isCurrentCameraFixed;

	[Token(Token = "0x4000712")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x70")]
	private float[,,] alphaMap;

	[Token(Token = "0x4000713")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x78")]
	private Color _healthyColor;

	[Token(Token = "0x4000714")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x88")]
	private Color _dryColor;

	[Token(Token = "0x4000715")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x98")]
	private float _noiseSpread;

	[Token(Token = "0x4000716")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x9C")]
	private float _ambientOcclusion;

	[Token(Token = "0x4000717")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xA0")]
	private float _gradientPower;

	[Token(Token = "0x4000718")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xA4")]
	private float _windIdleSway;

	[Token(Token = "0x4000719")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xA8")]
	private bool _windWavesOn;

	[Token(Token = "0x400071A")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xAC")]
	private float _windWaveTint;

	[Token(Token = "0x400071B")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xB0")]
	private float _windWaveSize;

	[Token(Token = "0x400071C")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xB4")]
	private float _windWaveSway;

	[Token(Token = "0x400071D")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xB8")]
	private Color _windWaveTintColor;

	[Token(Token = "0x400071E")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xC8")]
	private bool _isBillboard;

	[Token(Token = "0x400071F")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xC9")]
	private bool _useCrossQuads;

	[Token(Token = "0x4000720")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xCC")]
	private int _crossQuadCount;

	[Token(Token = "0x4000721")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xD0")]
	private float _crossQuadBillboardDistance;

	[Token(Token = "0x4000722")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xD4")]
	private Vector4 _scale;

	[Token(Token = "0x4000723")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xE4")]
	private bool _isShadowCasting;

	[Token(Token = "0x4000724")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xE5")]
	private bool _isFrustumCulling;

	[Token(Token = "0x4000725")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xE8")]
	private float _frustumOffset;

	[Token(Token = "0x4000726")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xEC")]
	private float _maxDistance;

	[Token(Token = "0x4000727")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xF0")]
	private Vector2 _windVector;

	[Token(Token = "0x4000728")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xF8")]
	private Image _healthyColorImage;

	[Token(Token = "0x4000729")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x100")]
	private Image _dryColorImage;

	[Token(Token = "0x400072A")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x108")]
	private Slider _noiseSpreadSlider;

	[Token(Token = "0x400072B")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x110")]
	private Slider _ambientOcclusionSlider;

	[Token(Token = "0x400072C")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x118")]
	private Slider _gradientPowerSlider;

	[Token(Token = "0x400072D")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x120")]
	private Slider _windIdleSwaySlider;

	[Token(Token = "0x400072E")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x128")]
	private Toggle _windWavesOnToggle;

	[Token(Token = "0x400072F")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x130")]
	private Slider _windWavesTintSlider;

	[Token(Token = "0x4000730")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x138")]
	private Slider _windWavesSizeSlider;

	[Token(Token = "0x4000731")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x140")]
	private Slider _windWavesSwaySlider;

	[Token(Token = "0x4000732")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x148")]
	private Image _windWavesTintColorImage;

	[Token(Token = "0x4000733")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x150")]
	private Toggle _billboardToggle;

	[Token(Token = "0x4000734")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x158")]
	private Toggle _crossQuadsToggle;

	[Token(Token = "0x4000735")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x160")]
	private Slider _crossQuadsCountSlider;

	[Token(Token = "0x4000736")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x168")]
	private Slider _crossQuadsBillboardDistanceSlider;

	[Token(Token = "0x4000737")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x170")]
	private InputField _scaleMinWidthInput;

	[Token(Token = "0x4000738")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x178")]
	private InputField _scaleMaxWidthInput;

	[Token(Token = "0x4000739")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x180")]
	private InputField _scaleMinHeightInput;

	[Token(Token = "0x400073A")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x188")]
	private InputField _scaleMaxHeightInput;

	[Token(Token = "0x400073B")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x190")]
	private Toggle _isShadowCastingToggle;

	[Token(Token = "0x400073C")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x198")]
	private Toggle _isFrustumCullingToggle;

	[Token(Token = "0x400073D")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x1A0")]
	private Slider _frustumOffsetSlider;

	[Token(Token = "0x400073E")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x1A8")]
	private Slider _maxDistanceSlider;

	[Token(Token = "0x400073F")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x1B0")]
	private InputField _windVectorXInput;

	[Token(Token = "0x4000740")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x1B8")]
	private InputField _windVectorZInput;

	[Token(Token = "0x4000741")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x1C0")]
	private Text _helpDescriptionText;

	[Token(Token = "0x4000742")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x1C8")]
	private Text _helpDescriptionTitleText;

	[Token(Token = "0x4000743")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x1D0")]
	private Selectable _addTerrainButton;

	[Token(Token = "0x4000744")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x1D8")]
	private Selectable _removeTerrainButton;

	[Token(Token = "0x4000745")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x1E0")]
	private Canvas _uiCanvas;

	[Token(Token = "0x4000746")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x0")]
	public static readonly string HELPTEXT_detailHealthyColor;

	[Token(Token = "0x4000747")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x8")]
	public static readonly string HELPTEXT_detailDryColor;

	[Token(Token = "0x4000748")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x10")]
	public static readonly string HELPTEXT_noiseSpread;

	[Token(Token = "0x4000749")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x18")]
	public static readonly string HELPTEXT_ambientOcclusion;

	[Token(Token = "0x400074A")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x20")]
	public static readonly string HELPTEXT_gradientPower;

	[Token(Token = "0x400074B")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x28")]
	public static readonly string HELPTEXT_windIdleSway;

	[Token(Token = "0x400074C")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x30")]
	public static readonly string HELPTEXT_windWavesOn;

	[Token(Token = "0x400074D")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x38")]
	public static readonly string HELPTEXT_windWaveTintColor;

	[Token(Token = "0x400074E")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x40")]
	public static readonly string HELPTEXT_windWaveSize;

	[Token(Token = "0x400074F")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x48")]
	public static readonly string HELPTEXT_windWaveSway;

	[Token(Token = "0x4000750")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x50")]
	public static readonly string HELPTEXT_windWaveTint;

	[Token(Token = "0x4000751")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x58")]
	public static readonly string HELPTEXT_isBillboard;

	[Token(Token = "0x4000752")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x60")]
	public static readonly string HELPTEXT_crossQuads;

	[Token(Token = "0x4000753")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x68")]
	public static readonly string HELPTEXT_quadCount;

	[Token(Token = "0x4000754")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x70")]
	public static readonly string HELPTEXT_billboardDistance;

	[Token(Token = "0x4000755")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x78")]
	public static readonly string HELPTEXT_detailScale;

	[Token(Token = "0x4000756")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x80")]
	public static readonly string HELPTEXT_isShadowCasting;

	[Token(Token = "0x4000757")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x88")]
	public static readonly string HELPTEXT_isFrustumCulling;

	[Token(Token = "0x4000758")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x90")]
	public static readonly string HELPTEXT_frustumOffset;

	[Token(Token = "0x4000759")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x98")]
	public static readonly string HELPTEXT_maxDetailDistance;

	[Token(Token = "0x400075A")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xA0")]
	public static readonly string HELPTEXT_windVector;

	[Token(Token = "0x6000B90")]
	[Address(RVA = "0x544610", Offset = "0x543010", VA = "0x180544610")]
	private void Start()
	{
	}

	[Token(Token = "0x6000B91")]
	[Address(RVA = "0x5448E0", Offset = "0x5432E0", VA = "0x1805448E0")]
	private void Update()
	{
	}

	[Token(Token = "0x6000B92")]
	[Address(RVA = "0x544BA0", Offset = "0x5435A0", VA = "0x180544BA0")]
	public void AddTerrain()
	{
	}

	[Token(Token = "0x6000B93")]
	[Address(RVA = "0x544C30", Offset = "0x543630", VA = "0x180544C30")]
	public void RemoveTerrain()
	{
	}

	[Token(Token = "0x6000B94")]
	[Address(RVA = "0x544D50", Offset = "0x543750", VA = "0x180544D50")]
	private void AddInstancer(Terrain terrain)
	{
	}

	[Token(Token = "0x6000B95")]
	[Address(RVA = "0x544FF0", Offset = "0x5439F0", VA = "0x180544FF0")]
	private void UpdateManagers()
	{
	}

	[Token(Token = "0x6000B96")]
	[Address(RVA = "0x5452C0", Offset = "0x543CC0", VA = "0x1805452C0")]
	public void ReInitializeManagers()
	{
	}

	[Token(Token = "0x6000B97")]
	[Address(RVA = "0x545360", Offset = "0x543D60", VA = "0x180545360")]
	private void SetupUI()
	{
	}

	[Token(Token = "0x6000B98")]
	[Address(RVA = "0x5468E0", Offset = "0x5452E0", VA = "0x1805468E0")]
	public void UpdateDetailSettings()
	{
	}

	[Token(Token = "0x6000B99")]
	[Address(RVA = "0x5470B0", Offset = "0x545AB0", VA = "0x1805470B0")]
	public void ShowHelpDescription(Text itemTitle)
	{
	}

	[Token(Token = "0x6000B9A")]
	[Address(RVA = "0x547FE0", Offset = "0x5469E0", VA = "0x180547FE0")]
	public void HideHelpDescription()
	{
	}

	[Token(Token = "0x6000B9B")]
	[Address(RVA = "0x548070", Offset = "0x546A70", VA = "0x180548070")]
	private void ManageButtons()
	{
	}

	[Token(Token = "0x6000B9C")]
	[Address(RVA = "0x5480C0", Offset = "0x546AC0", VA = "0x1805480C0")]
	private void SwitchCameras()
	{
	}

	[Token(Token = "0x6000B9D")]
	[Address(RVA = "0x5483A0", Offset = "0x546DA0", VA = "0x1805483A0")]
	private void GenerateTerrain()
	{
	}

	[Token(Token = "0x6000B9E")]
	[Address(RVA = "0x548B00", Offset = "0x547500", VA = "0x180548B00")]
	private Terrain InitializeTerrainObject(Vector3 position, int terrainSize, float terrainHeight, int baseTextureResolution = 16, int detailResolutionPerPatch = 16, [Optional] TerrainLayer[] terrainLayers, [Optional] DetailPrototype[] detailPrototypes)
	{
		return null;
	}

	[Token(Token = "0x6000B9F")]
	[Address(RVA = "0x5490E0", Offset = "0x547AE0", VA = "0x1805490E0")]
	private TerrainData CreateTerrainData(int terrainSize, float terrainHeight, int baseTextureResolution = 16, int detailResolutionPerPatch = 16, [Optional] TerrainLayer[] terrainLayers, [Optional] DetailPrototype[] detailPrototypes)
	{
		return null;
	}

	[Token(Token = "0x6000BA0")]
	[Address(RVA = "0x5493B0", Offset = "0x547DB0", VA = "0x1805493B0")]
	private void SetDetailMap(Terrain terrain)
	{
	}

	[Token(Token = "0x6000BA1")]
	[Address(RVA = "0x5495B0", Offset = "0x547FB0", VA = "0x1805495B0")]
	public TerrainGenerator()
	{
	}
}
