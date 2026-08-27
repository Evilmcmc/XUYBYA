using System.Collections.Generic;
using Il2CppDummyDll;
using UnityEngine;

namespace EZCameraShake;

[Token(Token = "0x20001BD")]
[AddComponentMenu("EZ Camera Shake/Camera Shaker")]
public class CameraShaker : MonoBehaviour
{
	[Token(Token = "0x400090B")]
	[FieldOffset(Offset = "0x0")]
	public static CameraShaker Instance;

	[Token(Token = "0x400090C")]
	[FieldOffset(Offset = "0x8")]
	private static Dictionary<string, CameraShaker> instanceList;

	[Token(Token = "0x400090D")]
	[FieldOffset(Offset = "0x20")]
	public Vector3 DefaultPosInfluence;

	[Token(Token = "0x400090E")]
	[FieldOffset(Offset = "0x2C")]
	public Vector3 DefaultRotInfluence;

	[Token(Token = "0x400090F")]
	[FieldOffset(Offset = "0x38")]
	public Vector3 RestPositionOffset;

	[Token(Token = "0x4000910")]
	[FieldOffset(Offset = "0x44")]
	public Vector3 RestRotationOffset;

	[Token(Token = "0x4000911")]
	[FieldOffset(Offset = "0x50")]
	private Vector3 posAddShake;

	[Token(Token = "0x4000912")]
	[FieldOffset(Offset = "0x5C")]
	private Vector3 rotAddShake;

	[Token(Token = "0x4000913")]
	[FieldOffset(Offset = "0x68")]
	private List<CameraShakeInstance> cameraShakeInstances;

	[Token(Token = "0x17000109")]
	public List<CameraShakeInstance> ShakeInstances
	{
		[Token(Token = "0x6000E3B")]
		[Address(RVA = "0x578AD0", Offset = "0x5774D0", VA = "0x180578AD0")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x6000E33")]
	[Address(RVA = "0x577FE0", Offset = "0x5769E0", VA = "0x180577FE0")]
	private void Awake()
	{
	}

	[Token(Token = "0x6000E34")]
	[Address(RVA = "0x578120", Offset = "0x576B20", VA = "0x180578120")]
	private void LateUpdate()
	{
	}

	[Token(Token = "0x6000E35")]
	[Address(RVA = "0x578550", Offset = "0x576F50", VA = "0x180578550")]
	public static CameraShaker GetInstance(string name)
	{
		return null;
	}

	[Token(Token = "0x6000E36")]
	[Address(RVA = "0x578670", Offset = "0x577070", VA = "0x180578670")]
	public CameraShakeInstance Shake(CameraShakeInstance shake)
	{
		return null;
	}

	[Token(Token = "0x6000E37")]
	[Address(RVA = "0x5786D0", Offset = "0x5770D0", VA = "0x1805786D0")]
	public CameraShakeInstance ShakeOnce(float magnitude, float roughness, float fadeInTime, float fadeOutTime)
	{
		return null;
	}

	[Token(Token = "0x6000E38")]
	[Address(RVA = "0x5787C0", Offset = "0x5771C0", VA = "0x1805787C0")]
	public CameraShakeInstance ShakeOnce(float magnitude, float roughness, float fadeInTime, float fadeOutTime, Vector3 posInfluence, Vector3 rotInfluence)
	{
		return null;
	}

	[Token(Token = "0x6000E39")]
	[Address(RVA = "0x5788C0", Offset = "0x5772C0", VA = "0x1805788C0")]
	public CameraShakeInstance StartShake(float magnitude, float roughness, float fadeInTime)
	{
		return null;
	}

	[Token(Token = "0x6000E3A")]
	[Address(RVA = "0x5789C0", Offset = "0x5773C0", VA = "0x1805789C0")]
	public CameraShakeInstance StartShake(float magnitude, float roughness, float fadeInTime, Vector3 posInfluence, Vector3 rotInfluence)
	{
		return null;
	}

	[Token(Token = "0x6000E3C")]
	[Address(RVA = "0x578B50", Offset = "0x577550", VA = "0x180578B50")]
	private void OnDestroy()
	{
	}

	[Token(Token = "0x6000E3D")]
	[Address(RVA = "0x578C00", Offset = "0x577600", VA = "0x180578C00")]
	public CameraShaker()
	{
	}
}
