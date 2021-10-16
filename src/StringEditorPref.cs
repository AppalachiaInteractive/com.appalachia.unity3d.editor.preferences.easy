using System;
using Appalachia.Utility.Editor.Preferences.Easy.Base;
using UnityEditor;

namespace Appalachia.Utility.Editor.Preferences.Easy
{
    public class StringEditorPref : EasyEditorPref<string>
    {
        public StringEditorPref(
            string path,
            string key,
            string label,
            string defaultValue = default,
            SettingsScope scope = SettingsScope.User,
            int order = 0,
            Func<bool> drawIf = null,
            Func<bool> enableIf = null,
            Action actionButton = null,
            string actionLabel = "Action") : base(
            path,
            key,
            label,
            defaultValue,
            scope,
            order,
            drawIf,
            enableIf,
            actionButton,
            actionLabel
        )
        {
        }

        public override string Value
        {
            get
            {
                if (!EditorPrefs.HasKey(key))
                {
                    EditorPrefs.SetString(key, defaultValue);
                }

                return EditorPrefs.GetString(key, defaultValue);
            }
            set => EditorPrefs.SetString(key, value);
        }

        protected override string Draw()
        {
            return EditorGUILayout.TextField(label, Value);
        }

        protected override string DrawDelayed()
        {
            return EditorGUILayout.DelayedTextField(label, Value);
        }
    }
}
