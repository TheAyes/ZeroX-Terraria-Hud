using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace ZeroXHUD.Core.Config.DataTypes
{
    public enum LabelStatTypes
    {
		[Label("None")]
		[Tooltip("Will display nothing")]
		None,

		[Label("Defense")]
		Defense,

		[Label("Damage per second")]
		Dps,

		[Label("Armor piercing")]
		ArmorPiercing,

		[Label("Speed multiplier")]
		Speed,

		[Label("Slowness multiplier")]
		Slow,

		[Label("Magic damage multiplier")]
		MagicDamageMultiplier,

		[Label("Melee damage multiplier")]
		MeleeDamageMultiplier,

		[Label("Ranged damage multiplier")]
		RangedDamageMultiplier,

		[Label("Summon damage multiplier")]
		SummonDamageMultiplier,

		[Label("Throwing damage multiplier")]
		ThrowingDamageMultiplier,

		[Label("Generic damage multiplier")]
		GenericDamageMultiplier
	}
}
