using System;
using Content.Shared.Ghost.Roles;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.CustomControls;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Localization;
using Robust.Shared.Timing;
using Robust.Shared.Utility;

namespace Content.Client.Ghost.Roles.UI
{
    [GenerateTypedNameReferences]
    public partial class GhostRoleRulesWindow : SS14Window
    {
        private float _timer = 5.0f;
        public GhostRoleRulesWindow(string rules, Action<BaseButton.ButtonEventArgs> requestAction)
        {
            RobustXamlLoader.Load(this);
            Title.SetMessage(FormattedMessage.FromMarkupPermissive(rules + "\n" + Loc.GetString("ghost-roles-window-rules-footer")));
            RequestButton.OnPressed += requestAction;
        }

        protected override void FrameUpdate(FrameEventArgs args)
        {
            base.FrameUpdate(args);
            if (!RequestButton.Disabled) return;
            if (_timer > 0.0)
            {
                _timer -= args.DeltaSeconds;
            }
            else
            {
                RequestButton.Disabled = false;
            }
        }
    }
}