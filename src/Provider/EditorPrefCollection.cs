using System;
using System.Collections.Generic;
using System.Linq;
using Appalachia.Utility.Editor.Preferences.Easy.Base;
using UnityEditor;

namespace Appalachia.Utility.Editor.Preferences.Easy.Provider
{
    public static class EditorPrefCollection
    {
        private static bool _settingsRetrieved;

        private static readonly Dictionary<string, List<EasyEditorPrefBase>> _userSettingsByPath =
            new();

        private static readonly Dictionary<string, List<EasyEditorPrefBase>>
            _projectSettingsByPath = new();

        [SettingsProviderGroup]
        public static SettingsProvider[] GetSettingsProviders()
        {
            _settingsRetrieved = true;

            if ((_userSettingsByPath == null) || (_projectSettingsByPath == null))
            {
                return null;
            }

            var providers = new List<DynamicSettingsProvider>();

            foreach (var scope in Enum.GetValues(typeof(SettingsScope)).Cast<SettingsScope>())
            {
                var pathCollection = scope == SettingsScope.Project
                    ? _projectSettingsByPath
                    : _userSettingsByPath;

                foreach (var path in pathCollection.Keys)
                {
                    var preferences = pathCollection[path];

                    var label = path.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries)
                                    .Last();

                    var provider =
                        new DynamicSettingsProvider(path, SettingsScope.User, preferences)
                        {
                            label = label
                        };

                    providers.Add(provider);
                }
            }

            return providers.ToArray();
        }

        public static void Register(string path, SettingsScope scope, EasyEditorPrefBase pref)
        {
            var pathCollection = scope == SettingsScope.Project
                ? _projectSettingsByPath
                : _userSettingsByPath;

            if (!pathCollection.ContainsKey(path))
            {
                pathCollection.Add(path, new List<EasyEditorPrefBase>());
            }

            pathCollection[path].Add(pref);

            if (_settingsRetrieved)
            {
                SettingsService.NotifySettingsProviderChanged();
            }
        }
    }
}
