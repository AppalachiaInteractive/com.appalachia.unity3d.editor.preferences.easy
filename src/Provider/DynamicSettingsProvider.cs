using System;
using System.Collections.Generic;
using System.Linq;
using Appalachia.Utility.Editor.Preferences.Easy.Base;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Utility.Editor.Preferences.Easy.Provider
{
    public class DynamicSettingsProvider : SettingsProvider
    {
        public readonly List<EasyEditorPrefBase> preferences;

        private float _maxLabel;

        public DynamicSettingsProvider(
            string path,
            SettingsScope scopes,
            List<EasyEditorPrefBase> preferences,
            IEnumerable<string> keywords = null) : base(path, scopes, keywords)
        {
            this.preferences = preferences;

            var comparision = new Comparison<EasyEditorPrefBase>(
                (first, second) => first.order.CompareTo(second.order)
            );

            this.preferences.Sort(comparision);
        }

        private static float GetLabelSize(EasyEditorPrefBase p)
        {
            var content = new GUIContent(p.label);
            var width = EditorStyles.label.CalcSize(content);
            return width.x;
        }

        public override void OnGUI(string searchContext)
        {
            if (_maxLabel == 0f)
            {
                _maxLabel = preferences.Select(GetLabelSize).Max();
            }

            var width = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = _maxLabel + 10.0f;
            foreach (var pref in preferences)
            {
                pref.DrawUI();
            }

            EditorGUIUtility.labelWidth = width;
        }
    }
}
