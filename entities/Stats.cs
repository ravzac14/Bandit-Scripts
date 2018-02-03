namespace entities {
	using UnityEngine.Assertions;
	
	public class Stats {
		public int level;
		public int hpCurrent;
		public int hpMax;
		public int staminaCurrent;
		public int staminaMax;

		public int str;
		public int dex;
		public int con;
		public int inte;

		// NOTE(zack): If you add to here, probably also add to the Entity constructor
		public Stats(
			int level,
			int hpCurrent,
                	int hpMax,
                	int staminaCurrent,
                	int staminaMax,
			int str,
			int dex,
			int con,
			int inte) {
			Assert.IsTrue(hpCurrent <= hpMax);
			Assert.IsTrue(staminaCurrent <= staminaMax);
			Assert.IsTrue(isValidStat(str));
			Assert.IsTrue(isValidStat(dex));
			Assert.IsTrue(isValidStat(con));
			Assert.IsTrue(isValidStat(inte));
			this.level = level;
			this.hpCurrent = hpCurrent;
			this.hpMax = hpMax;
			this.staminaCurrent = staminaCurrent;
			this.staminaMax = staminaMax;
			this.str = str;
			this.dex = dex;
			this.con = con;
			this.inte = inte;
		}

		// TODO(zack): Flesh this out
		private bool isValidStat(int s) { return true; }
	}
}
