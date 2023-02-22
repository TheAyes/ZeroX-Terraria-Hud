using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Chat;
using Terraria.GameInput;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ZeroXHUD.Core
{
    public class ZeroXPlayer : ModPlayer
    {
        private ZeroXPlayer()
        {
            ZeroXhud.InitializeModPlayer(this);
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            var keybinds = ZeroXhud.ModSystemInstance.Keybinds;

            foreach (var keybind in keybinds.Where(keybind => keybind.Value.Item1.JustPressed))
            {
                try
                {
                    keybind.Value.Item2?.Invoke();
                }
                catch
                {
                    // ignored
                }
            }
        }
    }
}
