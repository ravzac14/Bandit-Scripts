namespace entities.gear {
  using UnityEngine.Assertions;

  public class Weapon: Gear {
    public Weapon(GearSlot slot): base(slot) {
      Assert.IsTrue(GearHelpers.isWeapon(slot));
    }
  }
}
