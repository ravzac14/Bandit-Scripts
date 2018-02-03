namespace managers {
	using Board = map.Board;
	using Random = UnityEngine.Random;
	using Range = generic.Range;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class BoardManager : MonoBehaviour {

		public int columns = 3;
		public int rows = 3;
		public long seed = 1; // TODO(Zack): flesh out this seed nonsense
		
		private Transform boardHolder;
		private Board board;
	
		// TODO(zack): Add more to these when you have a better idea
		void setupBoard(long seed) {
			board = new Board(columns, rows);
		}
		
		void setupScene(long seed) {}
	}
}