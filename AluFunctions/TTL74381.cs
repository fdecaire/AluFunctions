using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluFunctions
{
	public class TTL74381
	{
		public bool S0 { get; set; }
		public bool S1 { get; set; }
		public bool S2 { get; set; }
		public bool Cn { get; set; }
		public bool A0 { get; set; }
		public bool B0 { get; set; }
		public bool A1 { get; set; }
		public bool B1 { get; set; }
		public bool A2 { get; set; }
		public bool B2 { get; set; }
		public bool A3 { get; set; }
		public bool B3 { get; set; }

		// outputs
		public bool F0 { get; private set; }
		public bool F1 { get; private set; }
		public bool F2 { get; private set; }
		public bool F3 { get; private set; }
		public bool OVR { get; private set; }
		public bool Cn4 { get; private set; }
		public bool P { get; private set; }
		public bool G { get; private set; }

		public bool Gate14 { get; private set; }
		public bool Gate15 { get; private set; }
		public bool Gate16 { get; private set; }
		public bool Gate19 { get; private set; }
		public bool Gate20 { get; private set; }
		public bool Gate21 { get; private set; }
		public bool Gate22 { get; private set; }

		public void RunCircuit()
		{
			// selector logic
			
			bool gate0 = !S0;
			bool gate1 = S0;
			bool gate2 = !S1;
			bool gate3 = S1;
			bool gate4 = !S2;
			bool gate5 = S2;
			
			bool gate6 = gate4 && gate2 && gate1;
			bool gate7 = gate4 && gate3 && gate0;
			bool gate8 = gate5 && gate3 && gate1;
			bool gate9 = gate2 && gate1;
			bool gate10 = gate5 && gate1;
			bool gate11 = gate3 && gate0;
			bool gate12 = gate3 && gate1;
			bool gate13 = gate5 && gate2;
			
			Gate14 = !(gate4 && gate2 && gate1);
			Gate15 = !(gate4 && gate3 && gate1);
			Gate16 = !(gate4 && gate3 && gate0);
			bool gate17 = gate4 && gate1;
			bool gate18 = gate4 && gate3;
			Gate19 = !(gate6 || gate7 || gate8);
			Gate20 = !(gate9 || gate10 || gate11);
			Gate21 = !(gate12 || gate13);
			Gate22 = gate17 || gate18;

			// alu inputs
			bool gate23 = !A0;
			bool gate24 = !B0;
			
			bool gate25 = !A1;
			bool gate26 = !B1;
			bool gate27 = !A2;
			bool gate28 = !B2;
			bool gate29 = !A3;
			bool gate30 = !B3;
			
			// bit 0
			bool gate31 = Gate21 && A0 && gate24;
			bool gate32 = Gate20 && A0 && B0;
			bool gate33 = Gate21 && gate23 && B0;
			bool gate34 = Gate19 && gate23 && gate24;
			
			bool gate35 = Gate16 && A0 && gate24;
			bool gate36 = Gate15 && A0 && B0;
			bool gate37 = Gate14 && gate23 && B0;
			bool gate38 = gate23 && gate24;

			// bit 1
			bool gate39 = Gate21 && A1 && gate26;
			bool gate40 = Gate20 && A1 && B1;
			bool gate41 = Gate21 && gate25 && B1;
			bool gate42 = Gate19 && gate25 && gate26;
			bool gate43 = Gate16 && A1 && gate26;
			bool gate44 = Gate15 && A1 && B1;
			bool gate45 = Gate14 && gate25 && B1;
			bool gate46 = gate25 && gate26;

			// bit 2
			bool gate47 = Gate21 && A2 && gate28;
			bool gate48 = Gate20 && A2 && B2;
			bool gate49 = Gate21 && gate27 && B2;
			bool gate50 = Gate19 && gate27 && gate28;
			bool gate51 = Gate16 && A2 && gate28;
			bool gate52 = Gate15 && A2 && B2;
			bool gate53 = Gate14 && gate27 && B2;
			bool gate54 = gate27 && gate28;

			// bit 3
			bool gate55 = Gate21 && A3 && gate30;
			bool gate56 = Gate20 && A3 && B3;
			bool gate57 = Gate21 && gate29 && B3;
			bool gate58 = Gate19 && gate29 && gate30;
			bool gate59 = Gate16 && A3 && gate30;
			bool gate60 = Gate15 && A3 && B3;
			bool gate61 = Gate14 && gate29 && B3;
			bool gate62 = gate29 && gate30;
			
			bool gate63 = !(gate31 || gate32 || gate33 || gate34);
			
			bool gate64 = !(gate35 || gate36 || gate37 || gate38);

			bool gate65 = !(gate39 || gate40 || gate41 || gate42);
			bool gate66 = !(gate43 || gate44 || gate45 || gate46);

			bool gate67 = !(gate47 || gate48 || gate49 || gate50);
			bool gate68 = !(gate51 || gate52 || gate53 || gate54);

			bool gate69 = !(gate55 || gate56 || gate57 || gate58);
			bool gate70 = !(gate59 || gate60 || gate61 || gate62);
			
			bool gate71 = !(Gate22 && Cn);
			
			bool gate72 = Gate22 && Cn && gate63;
			bool gate73 = Gate22 && gate64;

			bool gate74 = Gate22 && Cn && gate63 && gate65;
			bool gate75 = Gate22 && gate65 && gate64;
			bool gate76 = Gate22 && gate66;

			bool gate77 = Gate22 && Cn && gate63 && gate65 && gate67;
			bool gate78 = Gate22 && gate65 && gate67 && gate64;
			bool gate79 = Gate22 && gate67 && gate66;
			bool gate80 = Gate22 && gate68;

			bool gate81 = Cn && gate63 && gate65 && gate67 && gate69;
			bool gate82 = gate63 && gate65 && gate67 && gate69 && gate64;
			bool gate83 = gate64 && gate69 && gate66;
			bool gate84 = gate69 && gate68;
			bool gate85 = gate70;

			bool gate86 = gate63 && gate65 && gate67 && gate69;
			bool gate87 = gate65 && gate67 && gate69 && gate64;
			bool gate88 = gate67 && gate69 && gate66;
			bool gate89 = gate69 && gate68;
			bool gate90 = gate70;
			
			bool gate91 = !(gate72 || gate73);
			bool gate92 = !(gate74 || gate75 || gate76);
			bool gate93 = !(gate77 || gate78 || gate79 || gate80);
			bool gate94 = !(gate81 || gate82 || gate83 || gate84 || gate85);
			bool gate95 = !(gate87 || gate88 || gate89 || gate90);
			
			F0 = !(gate63 ^ gate71);
			F1 = !(gate65 ^ gate91);
			F2 = !(gate67 ^ gate92);
			F3 = !(gate69 ^ gate93);
			OVR = gate93 ^ gate94;
			Cn4 = !gate94;
			P = gate86;
			G = gate95;
			


			//F0 = !(!((!(S1 && S0 || S2 && !S1) && A0 && !B0) || ((!(!S1 && S0 || S2 && S0 || S1 && !S0)) && A0 && B0) || ((!(S1 && S0 || S2 && !S1)) && !A0 && B0) || ((!(!S2 && !S1 && S0 || !S2 && S1 && !S0 || S2 && S1 && S0)) && !A0 && !B0)) ^ !((!S2 && S0 || !S2 && S1) && Cn));
		}
	}
}
