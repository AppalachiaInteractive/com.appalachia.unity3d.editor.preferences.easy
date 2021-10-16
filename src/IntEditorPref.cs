using System;
using Appalachia.Utility.Editor.Preferences.Easy.Base;
using UnityEditor;

namespace Appalachia.Utility.Editor.Preferences.Easy
{
    public class IntEditorPref : EasyEditorPref<int>
    {
        public IntEditorPref(
            string path,
            string key,
            string label,
            int defaultValue = default,
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

        public override int Value
        {
            get
            {
                if (!EditorPrefs.HasKey(key))
                {
                    EditorPrefs.SetInt(key, defaultValue);
                }

                return EditorPrefs.GetInt(key, defaultValue);
            }
            set => EditorPrefs.SetInt(key, value);
        }

        protected override int Draw()
        {
            return EditorGUILayout.IntField(label, Value);
        }

        protected override int DrawDelayed()
        {
            return EditorGUILayout.DelayedIntField(label, Value);
        }
    }
}
