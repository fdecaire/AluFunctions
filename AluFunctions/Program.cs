using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace AluFunctions
{
	class Program
	{
		static void Main(string[] args)
		{
			File.Delete(@"c:\temp\eprom_alu.hex");
			DumpALULogicToRom();

			//var result = CalculateChecksum("10003000FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");
		}

		private static void DumpALULogicToRom()
		{
			OutputHex(":020000040000FA");
			var alu = new TTL74381();
			string outputrow = "";
			int rowNumber = 0;

			for (int inputs = 0; inputs < 4096; inputs++)
			{
				alu.S0 = (inputs & 0x001) == 0x001;
				alu.S1 = (inputs & 0x002) == 0x002;
				alu.S2 = (inputs & 0x004) == 0x004;
				alu.Cn = (inputs & 0x008) == 0x008;
				alu.A0 = (inputs & 0x010) == 0x010;
				alu.B0 = (inputs & 0x020) == 0x020;
				alu.A1 = (inputs & 0x040) == 0x040;
				alu.B1 = (inputs & 0x080) == 0x080;
				alu.A2 = (inputs & 0x100) == 0x100;
				alu.B2 = (inputs & 0x200) == 0x200;
				alu.A3 = (inputs & 0x400) == 0x400;
				alu.B3 = (inputs & 0x800) == 0x800;
				alu.RunCircuit();

				int result = 0;

				if (alu.F0)
				{
					result |= 0x1;
				}
				if (alu.F1)
				{
					result |= 0x2;
				}
				if (alu.F2)
				{
					result |= 0x4;
				}
				if (alu.F3)
				{
					result |= 0x8;
				}

				// outputs: s0,s1,s2,s3,ovr,cn4,p,g
				if (alu.OVR)
				{
					result |= 0x10;
				}
				if (alu.Cn4)
				{
					result |= 0x20;
				}
				if (alu.P)
				{
					result |= 0x40;
				}
				if (alu.G)
				{
					result |= 0x80;
				}

				outputrow += result.ToString("X2");

				//
				if (inputs % 16 == 15)
				{
					//10 000000
					// add 10

					outputrow = "10" + rowNumber.ToString("X4") + "00" + outputrow;
					outputrow = ":" + outputrow + CalculateChecksum(outputrow);

					OutputHex(outputrow);

					rowNumber += 0x10;
					outputrow = "";
				}
			}
		}

		private static string CalculateChecksum(string dataToCalculate)
		{
			byte[] buf = SoapHexBinary.Parse(dataToCalculate).Value;

			int chkSum = buf.Aggregate(0, (s, b) => s += b) & 0xff;
			chkSum = (0x100 - chkSum) & 0xff;

			return chkSum.ToString("X2");
		}

		private static void OutputHex(string result)
		{
			using (var writer = new StreamWriter(@"c:\temp\eprom_alu.hex", true))
			{
				writer.WriteLine(result);
			}
		}
	}
}
