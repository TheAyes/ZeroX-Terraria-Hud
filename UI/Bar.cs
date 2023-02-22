using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace ZeroXHUD.UI
{
    public class Bar : UIElement
    {
        private UIPanel border;
        private UIPanel fill;

        private UIText text;
        private Color fillColor = Color.Red;
        private Color borderColor = Color.Black;
        private Color textColor = Color.White;
        private Color textBorderColor = Color.Black;
        private string text1 = "";
        private float value;

        public Color FillColor { get => fillColor; set { fillColor = value; this.Refresh(); } }
        public Color BorderColor { get => borderColor; set { borderColor = value; this.Refresh(); } }
        public Color TextColor { get => textColor; set { textColor = value; this.Refresh(); } }
        public Color TextBorderColor { get => textBorderColor; set { textBorderColor = value; this.Refresh(); } }
        public string Text { get => text1; set { text1 = value; this.Refresh(); } }
        public float Value { get => value; set { this.value = value; this.Refresh(); } }

        public Bar()
        {
            border = new UIPanel();
            fill = new UIPanel();
            text = new UIText("", 0.8f);

            MinHeight.Set(22, 0);
            border.MinHeight = this.MinHeight;
            fill.MinHeight = this.MinHeight;
        }

        public void Refresh()
        {
            fill.BorderColor = Color.Transparent;
            fill.Height.Set(0, 1);
            fill.Width.Set(0, Value);
            fill.MinWidth.Set(0, 0.1f);

            fill.BackgroundColor = Value < 0.01f ? Color.Transparent : FillColor;

            text.VAlign = 0.5f;
            text.HAlign = 0.1f;
            text.TextColor = TextColor;
            text.SetText(Text, 0.8f, false);

            border.Width.Set(0, 1);
            border.Height.Set(0, 1);
            border.BackgroundColor = Color.Transparent;
            border.BorderColor = BorderColor;
        }

        public override void OnActivate()
        {
            Refresh();
            
            Append(fill);        
            
            border.Append(text);         
            Append(border);

            base.OnActivate();
        }
    }
}
