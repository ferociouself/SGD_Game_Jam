using UnityEngine;

public class StaticMethods {

	public static float Distance(Vector3 p1, Vector3 p2) {
		return (p2 - p1).magnitude;
	}

	public static float Distance(Vector2 p1, Vector2 p2) {
		return (p2 - p1).magnitude;
	}

	public static bool AlmostEquals(float f1, float f2, float threshold) {
		return Mathf.Abs(f1 - f2) < threshold;
	}

	public static bool AlmostEquals(Vector2 p1, Vector2 p2, float threshold) {
		return Distance(p1, p2) < threshold;
	}

	public static bool AlmostEquals(Vector3 p1, Vector3 p2, float threshold) {
		return Distance(p1, p2) < threshold;
	}
}
