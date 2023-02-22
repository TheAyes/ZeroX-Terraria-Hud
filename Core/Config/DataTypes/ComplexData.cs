using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace ZeroXHUD.Core.Config.DataTypes
{
	public class ComplexData
	{
		public List<int> ListOfInts = new List<int>();

		public SimpleData NestedSimple = new SimpleData();

		[Range(2f, 3f)]
		[Increment(.25f)]
		[DrawTicks]
		[DefaultValue(2f)]
		public float IncrementalFloat = 2f;
		public override bool Equals(object obj)
		{
			if (obj is ComplexData other)
				return ListOfInts.SequenceEqual(other.ListOfInts) && IncrementalFloat == other.IncrementalFloat && NestedSimple.Equals(other.NestedSimple);
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return new { ListOfInts, nestedSimple = NestedSimple, IncrementalFloat }.GetHashCode();
		}
	}
}
