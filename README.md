# Easy Editor Preferences for Unity3D
`com.appalachia.unity3d.editor.preferences.easy`
#### Created by Appalachia Interactive
[![openupm](https://img.shields.io/npm/v/com.appalachia.unity3d.editor.preferences.easy?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.appalachia.unity3d.editor.preferences.easy/)
![build](https://img.shields.io/github/workflow/status/AppalachiaInteractive/com.appalachia.unity3d.editor.preferences.easy/CI)
![license](https://img.shields.io/github/license/AppalachiaInteractive/com.appalachia.unity3d.editor.preferences.easy)

Automatically creates, updates, and draws custom Editor Preferences in the Settings window.  Supports bool, float, int, string, as well as **enums** (int-backed) and *color*.

If you're looking for an *even fancier* attribute-based solution, check out `com.appalachia.unity3d.editor.preferences` [here](http://github.com/AppalachiaInteractive/com.appalachia.unity3d.editor.preferences).

## Examples
The following UI (used in `com.appalachia.unity3d.editor.preferences`) is generated by the abbreviated code that follows it.  Notice the post-fix label on the `PreferenceMark` field, and the `Refresh` Button on the `PreferencePath` field.  *Very* fancy.

### The UI
![image](./media/screenshot.png)

### The Code
```cs 
    internal static class AppalachiaMetaPreferences
    {
        private const string _basePath = "Preferences/Appalachia/Preferences";
        private static readonly string _baseKey = nameof(AppalachiaMetaPreferences);

        public static StringEditorPref PreferencePath { get; } = new StringEditorPref(
            _basePath,
            $"{_baseKey}/{nameof(PreferencePath)}",
            "Preference Path",
            "Preferences/My Preferences",
            actionButton: SettingsService.NotifySettingsProviderChanged,
            actionLabel: "Refresh"
        );

        public static BoolEditorPref ShowPreferenceMarker { get; } = new BoolEditorPref(
            _basePath,
            $"{_baseKey}/{nameof(ShowPreferenceMarker)}",
            "Show Preference Mark In Inspector",
            true
        );

        public static EnumEditorPref<PreferenceMarkerCharacter> PreferenceMark { get; } =
            new EnumEditorPref<PreferenceMarkerCharacter>(
                _basePath,
                $"{_baseKey}/{nameof(PreferenceMark)}",
                "Preference Mark",
                PreferenceMarkerCharacter.GreekCapitalXi,
                enableIf: () => ShowPreferenceMarker,
                postfixer: GetMarkerCharacter
            );
        
        public static ColorEditorPref PreferenceMarkColor { get; } =
            new ColorEditorPref(
                _basePath,
                $"{_baseKey}/{nameof(PreferenceMarkColor)}",
                "Preference Mark Color",
                new Color(0.99f, 0.75f, 0.03f, 1.0f),
                enableIf: () => ShowPreferenceMarker
            );
        ...
        ...

        public static string GetMarkerCharacter(PreferenceMarkerCharacter character)
        {
            return character switch
            {
                PreferenceMarkerCharacter.GreekCapitalHeta => "Ͱ",
                PreferenceMarkerCharacter.GreekSmallHeta => "ͱ",
                ....
            };
        }
    }
 
```