namespace map {
	using generic;
	using System;
	using System.Collections.Generic;
	using UnityEngine;
	
	// TODO(zack): Add to these when you have a better idea of what goes in these
	[Serializable]
	public class Board {
		public int width;  // X
		public int height; // Y
		public List<ValueWithPosition<BoardUnit>> units;
		
		public Board(int width, int height) {
			this.width = width;
			this.height = height;
			this.units = new List<ValueWithPosition<BoardUnit>>();
			BoardHelpers.fillPositionsWithEmpty<BoardUnit>(this.width, this.height, this.units);
		}
	}
	
	[Serializable]
	public class BoardUnit {
		public int width;  // X
		public int height; // Y
		public List<ValueWithPosition<GameObject>> objects;
		
		public BoardUnit(int width, int height) {
			this.width = width;
			this.height = height;
			this.objects = new List<ValueWithPosition<GameObject>>();
			BoardHelpers.fillPositionsWithEmpty<GameObject>(this.width, this.height, this.objects);
		}
	}
	
	[Serializable]
	public class ValueWithPosition<T> {
		public Option<T> value;
		public Vector3 position;
		
		public ValueWithPosition(Option<T> value, Vector3 position) {
			this.value = value;
			this.position = position;
		}
		
		public bool isOccupied() {
			return value.isDefined();
		}
	}
	
	public static class BoardHelpers {
		public static ValueWithPosition<T> empty<T>(int x, int y) { 
			return new ValueWithPosition<T>(new None<T>(), new Vector3(x, y, 0)); 
		}
		
		public static void fillPositionsWithEmpty<T>(int x, int y, List<ValueWithPosition<T>> list) {
			for (int i = 0; i < x; i++) {
			    for (int j = 0; j < y; j++) {
					list.Add(empty<T>(i, j));
				};
			};
			return;
		}
	}
}
