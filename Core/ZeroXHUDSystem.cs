using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Chat;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using ZeroXHUD.Core.Config;
using ZeroXHUD.UI;

namespace ZeroXHUD.Core
{
    public class ZeroXhudSystem : ModSystem
    {
        private UserInterface userInterface;
        private ZeroXui ui;

        public Dictionary<string, (ModKeybind, Action)> Keybinds { get; set; } = new();

        public ZeroXhudSystem()
        {
            ZeroXhud.InitializeModSystem(this);
        }

        internal void ShowMyUi()
        {
            userInterface?.SetState(ui);
        }

        internal void HideMyUi()
        {
            userInterface?.SetState(null);
        }

        private bool globalHudVisibility = false;
        private void OnToggleHudPressed()
        {
            globalHudVisibility = !globalHudVisibility;
        }

        public override void OnModLoad()
        {
            this.Mod.Logger.Debug($"HUDSystem OnModLoad fired with Mod: {Mod.DisplayName}");

            var bind = KeybindLoader.RegisterKeybind(Mod, "Toggle HUD", Microsoft.Xna.Framework.Input.Keys.OemTilde);

            Keybinds.Add("toggle_hud", (bind, OnToggleHudPressed));

            

            if (!Main.dedServ)
            {
                userInterface = new UserInterface();
                ui = new ZeroXui();

                ui.Activate();
            }
        }

        public override void OnWorldLoad()
        {
            if(ZeroXModConfig.Instance.ShowCombatPanelByDefault)
            {
                globalHudVisibility = true;
            }
            else
            {
                globalHudVisibility = false;
            }
        }

        private GameTime lastUpdateUiGameTime;
        public override void UpdateUI(GameTime gameTime)
        {
            if(userInterface?.CurrentState != null)
            {
                userInterface.Update(gameTime);
            }

            lastUpdateUiGameTime = gameTime;
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "MyMod: MyInterface",
                    delegate
                    {
                        if (lastUpdateUiGameTime != null && userInterface?.CurrentState != null)
                        {
                            userInterface.Draw(Main.spriteBatch, lastUpdateUiGameTime);
                        }
                        return true;
                    },
                       InterfaceScaleType.UI));
            }
        }

        public override void PostUpdatePlayers()
        {
            try
            {
                if (!Main.playerInventory && globalHudVisibility)
                {
                    ShowMyUi();
                }
                else
                {
                    HideMyUi();
                }

                if (userInterface?.CurrentState != null)
                {
                    if (ui != null)
                    {
                        ui.Refresh();
                    }
                }
                else
                {

                }
            }
            catch(Exception ex)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral($"{ex}"), Color.White);
            }

            base.PostUpdatePlayers();
        }
    }
}
