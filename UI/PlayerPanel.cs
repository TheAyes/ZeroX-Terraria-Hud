using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent.UI.Elements;
using Terraria.Localization;
using Terraria.UI;
using ZeroXHUD.Core.Config;
using ZeroXHUD.Utils;

namespace ZeroXHUD.UI
{
    internal class PlayerPanel : UIElement
    {
        private readonly Bar healthBar = new ();
        private readonly Bar manaBar = new ();

        private readonly UiHead playerHead = new ();
        private readonly UIText playerName = new ("AAA-AAA");
        private readonly UIText playerDeathCooldown = new ("AAA-AAA");

        private readonly UIText label1 = new ("AAA-AAA");
        private readonly UIText label2 = new ("AAA-AAA");
        private readonly UIText label3 = new ("AAA-AAA");
        private readonly UIText label4 = new ("AAA-AAA");
        private readonly UIText label5 = new ("AAA-AAA");
        private readonly UIText label6 = new("AAA-AAA");
        private readonly UIText label7 = new ("AAA-AAA");
        private readonly UIText label8 = new ("AAA-AAA");


        public PlayerPanel()
        {
            this.MinHeight.Set(60, 0);
            this.MinWidth.Set(200, 0);
        }

        public void UpdateValues(Player player)
        {
            int life    = player.statLife;
            int maxLife = player.statLifeMax2;

            int mana = player.statMana;
            int maxMana = player.statManaMax2;

            int lifeRegen = player.lifeRegen;
            int manaRegen = player.manaRegen;

            string name = player.name;

            healthBar.Value = (float)life / maxLife;
            healthBar.Text = $"HP: {life}/{maxLife} ({lifeRegen:+#;-#;0})";

            manaBar.Value = (float)mana / maxMana;
            manaBar.Text = $"MP: {mana}/{maxMana} ({manaRegen:+#;-#;0})";

            healthBar.FillColor = ZeroXModConfig.Instance.CombatPanel.HealthBarColor;
            manaBar.FillColor = ZeroXModConfig.Instance.CombatPanel.ManaBarColor;

            this.label1.SetText(player.GetStat(ZeroXModConfig.Instance.CombatPanel.Label1Stat), 0.8f, false);
            this.label2.SetText(player.GetStat(ZeroXModConfig.Instance.CombatPanel.Label2Stat), 0.8f, false);

            this.label3.SetText(player.GetStat(ZeroXModConfig.Instance.CombatPanel.Label3Stat), 0.8f, false);
            this.label4.SetText(player.GetStat(ZeroXModConfig.Instance.CombatPanel.Label4Stat), 0.8f, false);
           
            this.label5.SetText(player.GetStat(ZeroXModConfig.Instance.CombatPanel.Label5Stat), 0.8f, false);
            this.label6.SetText(player.GetStat(ZeroXModConfig.Instance.CombatPanel.Label6Stat), 0.8f, false);

            this.label7.SetText(player.GetStat(ZeroXModConfig.Instance.CombatPanel.Label7Stat), 0.8f, false);
            this.label8.SetText(player.GetStat(ZeroXModConfig.Instance.CombatPanel.Label8Stat), 0.8f, false);

            playerDeathCooldown.SetText(name);

            playerName.SetText(name + (player.respawnTimer > 0 ? $" [{player.respawnTimer/60.0f:0.0}]" : ""));
            playerHead.PlayerIndex = player.whoAmI;
        }

        public override void OnInitialize()
        {
            try
            {
                playerHead.Top.Set(0, 0);
                playerHead.Left.Set(12, 0);
                Append(playerHead);

                playerName.TextColor = new Color(210, 210, 210);
                playerName.SetText("", 1.0f, false);
                playerName.Top.Set(-5, 0);
                playerName.Left.Set(35, 0);
                Append(playerName);

                healthBar.BorderColor = Color.Black;
                healthBar.FillColor = new Color(127, 29, 29);
                healthBar.Width.Set(200, 0);
                healthBar.Height.Set(22, 0);
                healthBar.Top.Set(16, 0);
                healthBar.Left.Set(0, 0);
                Append(healthBar);

                #region | First row of labels |
                label1.TextColor = Color.White;
                label1.Top.Set(20, 0);
                label1.Left.Set(210, 0);
                Append(label1);           

                label3.TextColor = Color.White;
                label3.Top.Set(20, 0);
                label3.Left.Set(300, 0);
                Append(label3);

                label5.TextColor = Color.White;
                label5.Top.Set(20, 0);
                label5.Left.Set(390, 0);
                Append(label5);

                label7.TextColor = Color.White;
                label7.Top.Set(20, 0);
                label7.Left.Set(480, 0);
                Append(label7);
                #endregion

                #region | First row of labels |
                label2.TextColor = Color.White;
                label2.Top.Set(44, 0);
                label2.Left.Set(210, 0);
                Append(label2);

                label4.TextColor = Color.White;
                label4.Top.Set(44, 0);
                label4.Left.Set(300, 0);
                Append(label4);

                label6.TextColor = Color.White;
                label6.Top.Set(44, 0);
                label6.Left.Set(390, 0);
                Append(label6);

                label8.TextColor = Color.White;
                label8.Top.Set(44, 0);
                label8.Left.Set(480, 0);
                Append(label8);
                #endregion

                manaBar.BorderColor = Color.Black;
                manaBar.FillColor = new Color(30, 64, 175);
                manaBar.Width.Set(200, 0);
                manaBar.Height.Set(22, 0);
                manaBar.Top.Set(38, 0);
                manaBar.Left.Set(0, 0);
                Append(manaBar);
            }
            catch (Exception ex)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral($"{ex}"), Color.White);
            }

        }
    }
}
