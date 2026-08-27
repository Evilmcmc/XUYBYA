using System.Collections.Generic;
using Il2CppDummyDll;

namespace Crosstales.BWF;

[Token(Token = "0x20001EC")]
public delegate void GetAllComplete(string originalText, List<string> badWords);
