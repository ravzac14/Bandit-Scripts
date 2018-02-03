namespace entities {
	
	public enum AIMode { Defensive, Protector, Offensive, Martyr };
	
		
	public class AISettings {
		public AIMode mode;
		
		public AISettings(AIMode mode) {
			this.mode = mode;
		}
	}
}
