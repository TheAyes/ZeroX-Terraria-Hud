using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using ZeroXHUD.Core.Config.DataTypes;

namespace ZeroXHUD.Utils
{
    public static class Extensions
    {
        public static float GetActualDamageModifier<T>(this Player player) where T : DamageClass
        {
            var damageModifier = player.GetTotalDamage<T>();

            return damageModifier.Additive * damageModifier.Multiplicative;
        }

        public static string GetStat(this Player player, LabelStatTypes labelStat)
        {
            float magicDamage = player.GetActualDamageModifier<MagicDamageClass>();
            float meleeDamage = player.GetActualDamageModifier<MeleeDamageClass>();
            float rangeDamage = player.GetActualDamageModifier<RangedDamageClass>();
            float throwDamage = player.GetActualDamageModifier<ThrowingDamageClass>();
            float summonDamage = player.GetActualDamageModifier<SummonDamageClass>();
            float genericDamage = player.GetActualDamageModifier<GenericDamageClass>();

            int def = player.statDefense;
            int dps = player.getDPS();

            float speed = player.moveSpeed;
            float slow = player.runSlowdown;
            float ap = player.GetArmorPenetration<GenericDamageClass>();

            return labelStat switch
            {
                LabelStatTypes.None => $"",
                LabelStatTypes.Defense => $"DEF: {def:0.00}",
                LabelStatTypes.Dps => $"DPS: {dps:0}",
                LabelStatTypes.ArmorPiercing => $"AP: {ap:0.00}",
                LabelStatTypes.Speed => $"Speed: {speed:0.00}",
                LabelStatTypes.Slow => $"Slow: {slow:0.00}",
                LabelStatTypes.MagicDamageMultiplier => $"Magic: {magicDamage:0.00}",
                LabelStatTypes.MeleeDamageMultiplier => $"Melee: {meleeDamage:0.00}",
                LabelStatTypes.RangedDamageMultiplier => $"Range: {rangeDamage:0.00}",
                LabelStatTypes.SummonDamageMultiplier => $"Summn: {summonDamage:0.00}",
                LabelStatTypes.ThrowingDamageMultiplier => $"Throw: {throwDamage:0.00}",
                LabelStatTypes.GenericDamageMultiplier => $"Damage: {genericDamage:0.00}",
                _ => $"Incorrect",
            };
        }
    }
}
