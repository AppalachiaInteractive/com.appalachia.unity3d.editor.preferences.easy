using System;
using Appalachia.Utility.Editor.Preferences.Easy.Base;
using UnityEditor;

namespace Appalachia.Utility.Editor.Preferences.Easy
{
    public class FloatEditorPref : EasyEditorPref<float>
    {
        public FloatEditorPref(
            string path,
            string key,
            string label,
            float defaultValue = default,
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

        public override float Value
        {
            get
            {
                if (!EditorPrefs.HasKey(key))
                {
                    EditorPrefs.SetFloat(key, defaultValue);
                }

                return EditorPrefs.GetFloat(key, defaultValue);
            }
            set => EditorPrefs.SetFloat(key, value);
        }

        protected override float Draw()
        {
            return EditorGUILayout.FloatField(label, Value);
        }

        protected override float DrawDelayed()
        {
            return EditorGUILayout.DelayedFloatField(label, Value);
        }
    }
}
