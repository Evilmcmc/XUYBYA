using System.Collections.Generic;
using FishNet.Connection;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000017")]
public class BanManager : MonoBehaviour
{
	[Token(Token = "0x400004E")]
	[FieldOffset(Offset = "0x0")]
	[HideInInspector]
	public static List<string> bannedIDs;

	[Token(Token = "0x6000077")]
	[Address(RVA = "0x459E40", Offset = "0x458840", VA = "0x180459E40")]
	public static void BanPlayer(NetworkConnection connection)
	{
	}

	[Token(Token = "0x6000078")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public BanManager()
	{
	}
}
