# Translated
A simple translation asset for Unity, made with clean C# 8.0 code
# Requirements
- .NET 4.x
- Newtonsoft.Json (https://www.newtonsoft.com/json)
- TextMeshPRO
- Basic JSON knowledge
# Steps to enable
1. Attach `CLocalization` to an emtpy `GameObject` that is always active
2. Configure the script to your liking with identifiers
3. Create a new `.txt` file with JSON-format such as:
`{ "COOKIE_BUTTON": "Cookie Button" }`
4. Drag the text file into the identifier fields on `CLocalization`
5. Add the `LocalizationSupport` script to the TextMeshPRO text you want to be translated
6. Change the text of the TMP to whatever key you put in the text file, in this example; `COOKIE_BUTTON`
7. Start your game and there you go, it should now be translated!
