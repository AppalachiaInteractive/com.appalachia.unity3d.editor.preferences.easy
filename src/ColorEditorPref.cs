using System;
using Appalachia.Utility.Editor.Preferences.Easy.Base;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Utility.Editor.Preferences.Easy
{
    public class ColorEditorPref : EasyEditorPref<Color>
    {
        public ColorEditorPref(
            string path,
            string key,
            string label,
            Color defaultValue,
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

        public override Color Value
        {
            get
            {
                if (!EditorPrefs.HasKey(key))
                {
                    var dv = (int) ToHex(defaultValue);
                    EditorPrefs.SetInt(key, dv);
                }

                var value = EditorPrefs.GetInt(key);
                var converted = ToRGBA((uint) value);
                return converted;
            }
            set
            {
                var hex = (int) ToHex(value);
                EditorPrefs.SetInt(key, hex);
            }
        }

        protected override Color Draw()
        {
            return EditorGUILayout.ColorField(label, Value);
        }

        protected override Color DrawDelayed()
        {
            return EditorGUILayout.ColorField(label, Value);
        }

        public static uint ToHex(Color c)
        {
            return ((uint) (c.a * 255) << 24) |
                   ((uint) (c.r * 255) << 16) |
                   ((uint) (c.g * 255) << 8) |
                   (uint) (c.b * 255);
        }

        public static Color ToRGBA(uint hex)
        {
            return new(((hex >> 16) & 0xff) / 255f, // r
                ((hex >> 8) & 0xff) / 255f,         // g
                (hex & 0xff) / 255f,                // b
                ((hex >> 24) & 0xff) / 255f         // a
            );
        }
    }
}
