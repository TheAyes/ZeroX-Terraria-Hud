using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria;
using ReLogic.Content;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Chat;
using Terraria.Localization;
using Terraria.Graphics.Renderers;

namespace ZeroXHUD.UI
{
    public class UiHead : UIElement
    {
        Color color = new Color(255, 255, 255);
        public int PlayerIndex { get; set; } = 0;

        public bool IsRendered;

        public override void Draw(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimensions = GetDimensions();

            if (Main.player[PlayerIndex].dead)
            {
                var crossAsset = TextureAssets.MapDeath;

                var position = dimensions.Position();
                position -= new Vector2(crossAsset.Width() / 6, crossAsset.Height() / 3);

                spriteBatch.Draw(crossAsset.Value, position, null, color, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0);
                //spriteBatch.Draw(crossAsset.Value, dimensions.Position(), color);
            }
            else if (Main.player[PlayerIndex].invis)
            {
                // TODO: draw invis sprite
            }
            else
            {
                Main.MapPlayerRenderer.DrawPlayerHead(Main.Camera, Main.player[PlayerIndex], dimensions.Position(), 0.5f, 0.8f, Color.White);
            }
        }

        public override void OnActivate()
        {
            
        }
    }
}
