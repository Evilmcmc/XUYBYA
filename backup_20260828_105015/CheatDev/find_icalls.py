import json
import re

with open(r'c:\Users\Windows 25H2\OneDrive\Desktop\XUYBYA\CheatDev\Il2CppDumper\stringliteral.json', 'r', encoding='utf-8') as f:
    data = json.load(f)

icalls = []
for item in data:
    s = item.get('value', '')
    if 'UnityEngine.' in s and '::' in s:
        icalls.append(s)

print("Found icalls:", len(icalls))
for c in icalls[:40]:
    print("  ", c)
