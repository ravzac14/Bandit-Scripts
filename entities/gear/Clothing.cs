namespace entities.gear {
  using UnityEngine.Assertions;

  public class Clothing: Gear {
    public Clothing(GearSlot slot): base(slot) {
      Assert.IsTrue(GearHelpers.isClothing(slot));
    }
  }
}
