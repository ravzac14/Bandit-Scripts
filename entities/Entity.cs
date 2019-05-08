namespace entities {
	using entities.gear;
	using generic;
	using System;
	using System.Collections.Generic;
	using UnityEngine;
	
	public enum EntityType { Unknown, Player, NPC, Breakable }

	// TODO(zack): Add to these when you have a better idea of what goes in these
	[Serializable]
	public class Entity {

		public EntityType entityType;
		public GameObject gameObject;
		
		public Entity() {
			entityType = EntityType.Unknown;
			gameObject = new GameObject();
		}
		
		public Entity(EntityType newEntityType, GameObject newGameObject) {
			entityType = newEntityType;
			gameObject = newGameObject;
		}
	}
	
	/* TODO(zack): This is all bad. Refactor to components
	public enum Faction { Ally, Neutral, Enemy }
	
	public abstract class Entity {
		public string id; // UUID
		public string name; // Printable name
		public Inventory inventory;
		public Stats stats;
		public Option<Faction> maybeFaction;

		public Option<Clothing> headSlot;
		public Option<Clothing> bodySlot;
		public Option<Clothing> bootSlot;
		public Option<Weapon> mainHandSlot;
		public Option<Weapon> offHandSlot;

		public Entity(
			string name,
			int level,
      int hpMax,
      int staminaMax,
      int str,
      int dex,
      int con,
      int inte) {
			this.id = Helpers.genId();
			this.name = name;
			this.stats = new Stats(level, hpMax, hpMax, staminaMax, staminaMax, str, dex, con, inte);
			this.inventory = new Inventory();
			this.headSlot = new None<Clothing>();
			this.bodySlot = new None<Clothing>();
			this.bootSlot = new None<Clothing>();
			this.mainHandSlot = new None<Weapon>();
			this.offHandSlot = new None<Weapon>();
		}

		public Entity(
			string name,
			int hpCurrent,
      int hpMax,
      int staminaCurrent,
      int staminaMax,
      int str,
      int dex,
      int con,
      int inte,
			List<InventoryItem> items,
			Option<Faction> maybeFaction,
			Option<Clothing> headSlot, 
			Option<Clothing> bodySlot, 
			Option<Clothing> bootSlot, 
			Option<Weapon> mainHandSlot, 
			Option<Weapon> offHandSlot) {
			Assert.IsTrue(headSlot.isEmpty() || headSlot.get().usesHead());
			Assert.IsTrue(bodySlot.isEmpty() || bodySlot.get().usesBody());
			Assert.IsTrue(bootSlot.isEmpty() || bootSlot.get().usesBoot());
			Assert.IsTrue(mainHandSlot.isEmpty() || mainHandSlot.get().usesMainHand());
			Assert.IsTrue(
				offHandSlot.isEmpty() || 
				!(mainHandSlot.isDefined() && mainHandSlot.get().usesTwoHand()) && 
				offHandSlot.get().usesOffHand());

			this.id = Helpers.genId();
			this.name = name;
			this.stats = new Stats(1, hpCurrent, hpMax, staminaCurrent, staminaMax, str, dex, con, inte);
			this.inventory = new Inventory(items);
			this.headSlot = headSlot;
			this.bodySlot = bodySlot;
			this.bootSlot = bootSlot;
			this.mainHandSlot = mainHandSlot;
			this.offHandSlot = offHandSlot;
		}
	} */
}
