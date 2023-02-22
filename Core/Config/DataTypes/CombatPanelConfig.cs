using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace ZeroXHUD.Core.Config.DataTypes
{
    public class CombatPanelConfig
    {

        [Header("Position")]
        [Label("Vertical offset")]
        [Tooltip("Vertical offset from the top-right corner of the screen in pixels")]
        [DefaultValue(86)]
        public int VerticalOffset { get; set; } = 86;

        [Label("Horizontal offset")]
        [Tooltip("Horizontal offset from the top-right corner of the screen in pixels")]
        [DefaultValue(35)]
        public int HorizontalOffset { get; set; } = 35;

        [Label("Shift with buffs")]
        [Tooltip("If enabled, combat panel will shift downwards for each new row of buffs")]
        [DefaultValue(true)]
        public bool ShiftWithBuffs { get; set; } = true;

        [Header("Bars")]
        [Label("Health bar color")]
        [DefaultValue(typeof(Color), "127, 29, 29, 255")]
        public Color HealthBarColor { get; set; } = new Color(127, 29, 29);

        [Label("Mana bar color")]
        [DefaultValue(typeof(Color), "30, 64, 175, 255")]
        public Color ManaBarColor { get; set; } = new Color(30, 64, 175);

        [Header("Labels")]

        [DrawTicks]
        [Label("1st label stat")]
        [DefaultValue(typeof(LabelStatTypes), "Defense")]
        public LabelStatTypes Label1Stat { get; set; } = LabelStatTypes.Defense;

        [DrawTicks]
        [Label("2nd label stat")]
        [DefaultValue(typeof(LabelStatTypes), "DPS")]
        public LabelStatTypes Label2Stat { get; set; } = LabelStatTypes.Dps;

        [DrawTicks]
        [Label("3rd label stat")]
        [DefaultValue(typeof(LabelStatTypes), "Speed")]
        public LabelStatTypes Label3Stat { get; set; } = LabelStatTypes.Speed;

        [DrawTicks]
        [Label("4th label stat")]
        [DefaultValue(typeof(LabelStatTypes), "ArmorPiercing")]
        public LabelStatTypes Label4Stat { get; set; } = LabelStatTypes.ArmorPiercing;

        [DrawTicks]
        [Label("5th label stat")]
        [DefaultValue(typeof(LabelStatTypes), "MagicDamageMultiplier")]
        public LabelStatTypes Label5Stat { get; set; } = LabelStatTypes.MagicDamageMultiplier;

        [DrawTicks]
        [Label("6th label stat")]
        [DefaultValue(typeof(LabelStatTypes), "MeleeDamageMultiplier")]
        public LabelStatTypes Label6Stat { get; set; } = LabelStatTypes.MeleeDamageMultiplier;

        [DrawTicks]
        [Label("7th label stat")]
        [DefaultValue(typeof(LabelStatTypes), "RangedDamageMultiplier")]
        public LabelStatTypes Label7Stat { get; set; } = LabelStatTypes.RangedDamageMultiplier;

        [DrawTicks]
        [Label("8th label stat")]
        [DefaultValue(typeof(LabelStatTypes), "SummonDamageMultiplier")]
        public LabelStatTypes Label8Stat { get; set; } = LabelStatTypes.SummonDamageMultiplier;
    }
}
