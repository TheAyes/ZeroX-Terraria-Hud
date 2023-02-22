using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace ZeroXHUD.Core.Config.DataTypes
{
	[BackgroundColor(255, 7, 7)]
	public class SimpleData
	{
		[Header("Awesome")]
		public int Boost;
		public float Percent;

		[Header("Lame")]
		public bool Enabled;

		[DrawTicks]
		[OptionStrings(new string[] { "Pikachu", "Charmander", "Bulbasaur", "Squirtle" })]
		[DefaultValue("Bulbasaur")]
		public string FavoritePokemon;

		public SimpleData()
		{
			FavoritePokemon = "Bulbasaur";
		}

		public override bool Equals(object obj)
		{
			if (obj is SimpleData other)
				return Boost == other.Boost && Percent == other.Percent && Enabled == other.Enabled && FavoritePokemon == other.FavoritePokemon;
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return new { boost = Boost, percent = Percent, enabled = Enabled, FavoritePokemon }.GetHashCode();
		}
	}
}
