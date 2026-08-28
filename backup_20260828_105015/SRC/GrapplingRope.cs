using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000086")]
public class GrapplingRope : MonoBehaviour
{
	[Token(Token = "0x4000254")]
	[FieldOffset(Offset = "0x20")]
	[Header("Animation")]
	private Spring spring;

	[Token(Token = "0x4000255")]
	[FieldOffset(Offset = "0x28")]
	private LineRenderer lr;

	[Token(Token = "0x4000256")]
	[FieldOffset(Offset = "0x30")]
	public GrapplingHook grappleHook;

	[Token(Token = "0x4000257")]
	[FieldOffset(Offset = "0x38")]
	public AudioManager audioManager;

	[Token(Token = "0x4000258")]
	[FieldOffset(Offset = "0x40")]
	public int quality;

	[Token(Token = "0x4000259")]
	[FieldOffset(Offset = "0x44")]
	public float damper;

	[Token(Token = "0x400025A")]
	[FieldOffset(Offset = "0x48")]
	public float strength;

	[Token(Token = "0x400025B")]
	[FieldOffset(Offset = "0x4C")]
	public float velocity;

	[Token(Token = "0x400025C")]
	[FieldOffset(Offset = "0x50")]
	public float waveCount;

	[Token(Token = "0x400025D")]
	[FieldOffset(Offset = "0x54")]
	public float waveHeight;

	[Token(Token = "0x400025E")]
	[FieldOffset(Offset = "0x58")]
	public AnimationCurve affectCurve;

	[Token(Token = "0x400025F")]
	[FieldOffset(Offset = "0x60")]
	[Header("Collisions")]
	public LayerMask collMask;

	[Token(Token = "0x4000260")]
	[FieldOffset(Offset = "0x64")]
	public LayerMask movingCollMask;

	[Token(Token = "0x4000261")]
	[FieldOffset(Offset = "0x68")]
	public float spherecastThickness;

	[Token(Token = "0x4000262")]
	[FieldOffset(Offset = "0x6C")]
	public float originOffset;

	[Token(Token = "0x4000263")]
	[FieldOffset(Offset = "0x70")]
	public float minCollisionDistance;

	[Token(Token = "0x4000264")]
	[FieldOffset(Offset = "0x74")]
	public float hitNormalOffset;

	[Token(Token = "0x4000265")]
	[FieldOffset(Offset = "0x78")]
	public float lerpTime;

	[Token(Token = "0x4000266")]
	[FieldOffset(Offset = "0x7C")]
	public float deleteDistance;

	[Token(Token = "0x400026B")]
	[FieldOffset(Offset = "0xA0")]
	private bool canExit;

	[Token(Token = "0x400026C")]
	[FieldOffset(Offset = "0xA8")]
	[Header("Effects")]
	public string[] RopeColEnterSFX;

	[Token(Token = "0x400026D")]
	[FieldOffset(Offset = "0xB0")]
	public string[] RopeColExitSFX;

	[Token(Token = "0x400026E")]
	[FieldOffset(Offset = "0xB8")]
	[SerializeField]
	private float requiredVelForAudio;

	[Token(Token = "0x400026F")]
	[FieldOffset(Offset = "0xBC")]
	private Vector3 ropeOrientation;

	[Token(Token = "0x17000056")]
	public List<Vector3> ropePositions
	{
		[Token(Token = "0x6000368")]
		[Address(RVA = "0x49DF40", Offset = "0x49C940", VA = "0x18049DF40")]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[Token(Token = "0x6000369")]
		[Address(RVA = "0x49DF50", Offset = "0x49C950", VA = "0x18049DF50")]
		[CompilerGenerated]
		set
		{
		}
	}

	[Token(Token = "0x17000057")]
	public List<Vector3> ropeAnimPoints
	{
		[Token(Token = "0x600036A")]
		[Address(RVA = "0x49DFB0", Offset = "0x49C9B0", VA = "0x18049DFB0")]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[Token(Token = "0x600036B")]
		[Address(RVA = "0x49DFC0", Offset = "0x49C9C0", VA = "0x18049DFC0")]
		[CompilerGenerated]
		set
		{
		}
	}

	[Token(Token = "0x17000058")]
	public List<Vector3> ropeNormals
	{
		[Token(Token = "0x600036C")]
		[Address(RVA = "0x49E020", Offset = "0x49CA20", VA = "0x18049E020")]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[Token(Token = "0x600036D")]
		[Address(RVA = "0x49E030", Offset = "0x49CA30", VA = "0x18049E030")]
		[CompilerGenerated]
		set
		{
		}
	}

	[Token(Token = "0x17000059")]
	public List<MovingObjectRopePos> movingRopePositions
	{
		[Token(Token = "0x600036E")]
		[Address(RVA = "0x49E090", Offset = "0x49CA90", VA = "0x18049E090")]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[Token(Token = "0x600036F")]
		[Address(RVA = "0x49E0A0", Offset = "0x49CAA0", VA = "0x18049E0A0")]
		[CompilerGenerated]
		set
		{
		}
	}

	[Token(Token = "0x6000370")]
	[Address(RVA = "0x49E100", Offset = "0x49CB00", VA = "0x18049E100")]
	private void OnDrawGizmos()
	{
	}

	[Token(Token = "0x6000371")]
	[Address(RVA = "0x49E3B0", Offset = "0x49CDB0", VA = "0x18049E3B0")]
	private void Awake()
	{
	}

	[Token(Token = "0x6000372")]
	[Address(RVA = "0x49E4E0", Offset = "0x49CEE0", VA = "0x18049E4E0")]
	private void LateUpdate()
	{
	}

	[Token(Token = "0x6000373")]
	[Address(RVA = "0x49E590", Offset = "0x49CF90", VA = "0x18049E590")]
	public void StartGrapple()
	{
	}

	[Token(Token = "0x6000374")]
	[Address(RVA = "0x49E970", Offset = "0x49D370", VA = "0x18049E970")]
	private void DrawRope()
	{
	}

	[Token(Token = "0x6000375")]
	[Address(RVA = "0x49EB90", Offset = "0x49D590", VA = "0x18049EB90")]
	private void DrawRopeAnim()
	{
	}

	[Token(Token = "0x6000376")]
	[Address(RVA = "0x49F6A0", Offset = "0x49E0A0", VA = "0x18049F6A0")]
	private void DetectCollisionEnter()
	{
	}

	[Token(Token = "0x6000377")]
	[Address(RVA = "0x4A04A0", Offset = "0x49EEA0", VA = "0x1804A04A0")]
	private bool IsAudioSourcePlaying(string[] array)
	{
		return default(bool);
	}

	[Token(Token = "0x6000378")]
	[Address(RVA = "0x4A05C0", Offset = "0x49EFC0", VA = "0x1804A05C0")]
	private void UpdateRopeNormal(Vector3 newNormal)
	{
	}

	[Token(Token = "0x6000379")]
	[Address(RVA = "0x4A07A0", Offset = "0x49F1A0", VA = "0x1804A07A0")]
	private void DetectCollisionExits()
	{
	}

	[Token(Token = "0x600037A")]
	[Address(RVA = "0x4A1130", Offset = "0x49FB30", VA = "0x1804A1130")]
	private bool isIntPosMoving(int i)
	{
		return default(bool);
	}

	[Token(Token = "0x600037B")]
	[Address(RVA = "0x4A12B0", Offset = "0x49FCB0", VA = "0x1804A12B0")]
	private void AddPosToRope(Vector3 _pos, Vector3 _normal)
	{
	}

	[Token(Token = "0x600037C")]
	[Address(RVA = "0x4A1420", Offset = "0x49FE20", VA = "0x1804A1420")]
	private void UpdateRopePositions()
	{
	}

	[Token(Token = "0x600037D")]
	[Address(RVA = "0x4A1930", Offset = "0x4A0330", VA = "0x1804A1930")]
	private void LastSegmentGoToPlayerPos()
	{
	}

	[Token(Token = "0x600037E")]
	[Address(RVA = "0x4A1B30", Offset = "0x4A0530", VA = "0x1804A1B30")]
	public GrapplingRope()
	{
	}
}
