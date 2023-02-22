using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using ZeroXHUD.Core.Config;

namespace ZeroXHUD.UI
{
    public class ZeroXui : UIState
    {
        List<PlayerPanel> playerPanels = new ();

        public void Refresh()
        {
            try
            {
                var player = Main.LocalPlayer;
                List<Player> sameTeamPlayers = null;
                lock (Main.player)
                {
                    try
                    {
                        sameTeamPlayers = Main.player.Where(p => p.team == player.team && p.active).ToList();
                    }
                    catch
                    {
                        // ignored
                    }
                }

                if (sameTeamPlayers == null) return;

                if (playerPanels.Count != sameTeamPlayers.Count && sameTeamPlayers.Count > 0)
                {
                    RemoveAllChildren();

                    playerPanels = new List<PlayerPanel>();
                    for (var i = 0; i < sameTeamPlayers.Count; i++)
                    {
                        playerPanels.Add(new PlayerPanel());
                    }

                    InitializePanels();
                }

                for (int i = 0; i < sameTeamPlayers.Count; i++)
                {
                    Player sameTeamPlayer = sameTeamPlayers[i];
                    PlayerPanel playerPanel = playerPanels[i];

                    playerPanel.UpdateValues(sameTeamPlayer);
                }

                int level = (player.CountBuffs() + 10) / 11;
                for (int i = 0; i < playerPanels.Count; i++)
                {
                    PlayerPanel playerPanel = playerPanels[i];

                    var verticalOffset = ZeroXModConfig.Instance.CombatPanel.VerticalOffset;
                    if (ZeroXModConfig.Instance.CombatPanel.ShiftWithBuffs)
                    {
                        verticalOffset  += 50 * level;
                    }

                    playerPanel.Top.Set(verticalOffset + 72 * i, 0);
                    playerPanel.Left.Set(ZeroXModConfig.Instance.CombatPanel.HorizontalOffset, 0);
                }
            } 
            catch (Exception ex)
            {
                if (ex is NullReferenceException)
                {
                    //ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral($"{ex}"), Color.White);
                }
            }
        }

        private void InitializePanels()
        {
            foreach (var playerPanel in playerPanels)
            {
                playerPanel.Activate();
                Append(playerPanel);
            }
        }

        public override void OnInitialize()
        {
            InitializePanels();
        }
    }
}
