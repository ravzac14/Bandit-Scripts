namespace entities.gear {

	public enum GearSlot { Head, Body, Boot, MainHand, OffHand, TwoHand }

  public static class GearHelpers {
    public static bool isWeapon(GearSlot slot) {
      return (slot == GearSlot.MainHand) || (slot == GearSlot.OffHand) || (slot == GearSlot.TwoHand);
    }

    public static bool isClothing(GearSlot slot) {
      return !isWeapon(slot);
    }
  }
	
	public class Gear: InventoryItem {
		public GearSlot slot;
		
		public Gear(GearSlot slot) {
			this.slot = slot;
		}

		public bool usesHead() { return slot == GearSlot.Head; }
		public bool usesBody() { return slot == GearSlot.Body; }
		public bool usesBoot() { return slot == GearSlot.Boot; }
		public bool usesTwoHand() { return slot == GearSlot.TwoHand; }
		public bool usesMainHand() { return usesTwoHand() || slot == GearSlot.MainHand; }
		public bool usesOffHand() { return usesTwoHand() || slot == GearSlot.OffHand; }
	}
	
}
