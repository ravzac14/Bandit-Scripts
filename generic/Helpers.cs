namespace generic {
	using System;

	public static class Helpers {
		public static string genId() { return System.Guid.NewGuid().ToString("N"); }
	}
}
