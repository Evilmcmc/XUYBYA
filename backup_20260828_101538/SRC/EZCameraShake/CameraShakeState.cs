using Il2CppDummyDll;

namespace EZCameraShake;

[Token(Token = "0x20001BA")]
public enum CameraShakeState
{
	[Token(Token = "0x40008FA")]
	FadingIn,
	[Token(Token = "0x40008FB")]
	FadingOut,
	[Token(Token = "0x40008FC")]
	Sustained,
	[Token(Token = "0x40008FD")]
	Inactive
}
