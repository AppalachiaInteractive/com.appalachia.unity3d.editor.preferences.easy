using System;
using UnityEditor;

namespace Appalachia.Editor.Preferences.Easy.Base
{
    public abstract class EasyEditorPrefBase
    {
        public readonly string path;
        public readonly string key;
        public readonly string label;
        public readonly int order;
        public readonly Func<bool> drawIf;
        public readonly Func<bool> enableIf;
        public readonly Action actionButton;
        public readonly string actionLabel;

        protected EasyEditorPrefBase(
            string path,
            string key,
            string label,
            SettingsScope scope,
            int order,
            Func<bool> drawIf,
            Func<bool> enableIf,
            Action actionButton,
            string actionLabel)
        {
            this.path = path;
            this.key = key;
            this.label = label;
            this.order = order;
            this.enableIf = enableIf;
            this.drawIf = drawIf;
            this.actionButton = actionButton;
            this.actionLabel = actionLabel;

            EditorPrefCollection.Register(path, scope, this);
        }

        public abstract void DrawUI();

        public abstract void DrawDelayedUI();
    }
}
