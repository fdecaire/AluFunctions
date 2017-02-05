using System;
using AluFunctions;
using Xunit;

namespace AluTests
{
	public class UnitTest1
	{
		[Theory]
		[InlineData(0, 0, 0, 5, 5, 5, 5, 5, 5, 0)]
		[InlineData(0, 0, 5, 5, 5, 0, 5, 5, 5, 0)]
		[InlineData(0, 5, 0, 0, 0, 5, 5, 5, 0, 5)]
		[InlineData(0, 5, 5, 5, 0, 5, 5, 5, 5, 0)]
		[InlineData(5, 0, 0, 0, 0, 5, 0, 5, 5, 5)]
		[InlineData(5, 0, 5, 5, 0, 0, 5, 5, 5, 0)]
		[InlineData(5, 5, 0, 5, 5, 0, 5, 0, 5, 5)]
		[InlineData(5, 5, 5, 0, 0, 0, 5, 5, 5, 0)]
		public void TTL74381_function_selector(int s0, int s1, int s2, int g19, int g20, int g21, int g14, int g15, int g16,
			int g22)
		{
			var alu = new TTL74381();

			alu.S0 = s0 == 5;
			alu.S1 = s1 == 5;
			alu.S2 = s2 == 5;
			alu.Cn = false;
			alu.RunCircuit();

			Assert.Equal(g19 == 5, alu.Gate19);
			Assert.Equal(g20 == 5, alu.Gate20);
			Assert.Equal(g21 == 5, alu.Gate21);
			Assert.Equal(g14 == 5, alu.Gate14);
			Assert.Equal(g15 == 5, alu.Gate15);
			Assert.Equal(g16 == 5, alu.Gate16);
			Assert.Equal(g22 == 5, alu.Gate22);
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0)]
		[InlineData(0, 5, 5, 0, 5, 0)]
		[InlineData(5, 0, 5, 0, 5, 0)]
		[InlineData(5, 5, 0, 5, 0, 5)]
		public void TTL74381_add_a0_b0(int a0, int b0, int g63, int g64, int f0, int f1)
		{
			var alu = new TTL74381();

			alu.S0 = true;
			alu.S1 = true;
			alu.S2 = false;
			alu.Cn = false;
			alu.A0 = a0 == 5;
			alu.A1 = false;
			alu.A2 = false;
			alu.A3 = false;
			alu.B0 = b0 == 5;
			alu.B1 = false;
			alu.B2 = false;
			alu.B3 = false;

			alu.RunCircuit();

			Assert.Equal(f0 == 5, alu.F0);
			Assert.Equal(f1 == 5, alu.F1);
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0)]
		[InlineData(0, 5, 5, 0, 5, 0)]
		[InlineData(5, 0, 5, 0, 5, 0)]
		[InlineData(5, 5, 0, 5, 0, 5)]
		public void TTL74381_add_a1_b1(int a1, int b1, int g65, int g66, int f1, int f2)
		{
			var alu = new TTL74381();

			alu.S0 = true;
			alu.S1 = true;
			alu.S2 = false;
			alu.Cn = false;
			alu.A0 = false;
			alu.A1 = a1 == 5;
			alu.A2 = false;
			alu.A3 = false;
			alu.B0 = false;
			alu.B1 = b1 == 5;
			alu.B2 = false;
			alu.B3 = false;

			alu.RunCircuit();

			Assert.Equal(f1 == 5, alu.F1);
			Assert.Equal(f2 == 5, alu.F2);
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0)]
		[InlineData(0, 5, 5, 0, 5, 0)]
		[InlineData(5, 0, 5, 0, 5, 0)]
		[InlineData(5, 5, 0, 5, 0, 5)]
		public void TTL74381_add_a2_b2(int a2, int b2, int g67, int g68, int f2, int f3)
		{
			var alu = new TTL74381();

			alu.S0 = true;
			alu.S1 = true;
			alu.S2 = false;
			alu.Cn = false;
			alu.A0 = false;
			alu.A1 = false;
			alu.A2 = a2 == 5;
			alu.A3 = false;
			alu.B0 = false;
			alu.B1 = false;
			alu.B2 = b2 == 5;
			alu.B3 = false;

			alu.RunCircuit();

			Assert.Equal(f2 == 5, alu.F2);
			Assert.Equal(f3 == 5, alu.F3);
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0)]
		[InlineData(0, 5, 5, 0, 5, 0)]
		[InlineData(5, 0, 5, 0, 5, 0)]
		[InlineData(5, 5, 0, 5, 0, 5)]
		public void TTL74381_add_a3_b3(int a3, int b3, int g69, int g70, int f3, int cn)
		{
			var alu = new TTL74381();

			alu.S0 = true;
			alu.S1 = true;
			alu.S2 = false;
			alu.Cn = false;
			alu.A0 = false;
			alu.A1 = false;
			alu.A2 = false;
			alu.A3 = a3 == 5;
			alu.B0 = false;
			alu.B1 = false;
			alu.B2 = false;
			alu.B3 = b3 == 5;

			alu.RunCircuit();

			Assert.Equal(f3 == 5, alu.F3);
			Assert.Equal(cn == 5, alu.Cn4);
		}

		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
		[InlineData(0, 5, 0, 5, 0, 0, 5, 0, 0, 5, 5, 5)]
		[InlineData(0, 0, 5, 5, 0, 0, 5, 5, 0, 5, 5, 0)]
		public void TTL74381_add(int a3, int a2, int a1, int a0, int b3, int b2, int b1, int b0, int f3, int f2, int f1,
			int f0)
		{
			var alu = new TTL74381();

			alu.S0 = true;
			alu.S1 = true;
			alu.S2 = false;
			alu.Cn = false;

			alu.A0 = a0 == 5;
			alu.A1 = a1 == 5;
			alu.A2 = a2 == 5;
			alu.A3 = a3 == 5;
			alu.B0 = b0 == 5;
			alu.B1 = b1 == 5;
			alu.B2 = b2 == 5;
			alu.B3 = b3 == 5;

			alu.RunCircuit();

			Assert.Equal(f0 == 5, alu.F0);
			Assert.Equal(f1 == 5, alu.F1);
			Assert.Equal(f2 == 5, alu.F2);
			Assert.Equal(f3 == 5, alu.F3);
		}

	}
}
