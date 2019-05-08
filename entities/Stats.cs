namespace entities {
	using UnityEngine;
	using UnityEngine.Assertions;
	
	public class Stats : MonoBehaviour {
		public int level;
		public int hpCurrent;
		public int hpMax;
		public int staminaCurrent;
		public int staminaMax;

		public int str;
		public int dex;
		public int con;
		public int inte;

		/*
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
		*/
		
		void Awake() {}
		void Start() {}
		void Update() {}
	}
	
	public static class StatsHelpers {
		
		// TODO(zack): Flesh this out
		public static bool isValidStat(int s) { return true; }
		
		public static void addStats(
			GameObject gameObject,
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
			
			if (gameObject.GetComponent<Stats>() == null) {
				gameObject.AddComponent<Stats>();
			}
			
			gameObject.GetComponent<Stats>().level = level;
			gameObject.GetComponent<Stats>().hpCurrent = hpCurrent;
			gameObject.GetComponent<Stats>().hpMax = hpMax;
			gameObject.GetComponent<Stats>().staminaCurrent = staminaCurrent;
			gameObject.GetComponent<Stats>().staminaMax = staminaMax;
			gameObject.GetComponent<Stats>().str = str;
			gameObject.GetComponent<Stats>().dex = dex;
			gameObject.GetComponent<Stats>().con = con;
			gameObject.GetComponent<Stats>().inte = inte;
		}
	}
}
