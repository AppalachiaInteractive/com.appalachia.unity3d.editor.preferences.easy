using System;
using Appalachia.Utility.Editor.Preferences.Easy.Provider;
using UnityEditor;

namespace Appalachia.Utility.Editor.Preferences.Easy.Base
{
    public abstract class EasyEditorPrefBase
    {
        public readonly Action actionButton;
        public readonly string actionLabel;
        public readonly Func<bool> drawIf;
        public readonly Func<bool> enableIf;
        public readonly string key;
        public readonly string label;
        public readonly int order;
        public readonly string path;

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
