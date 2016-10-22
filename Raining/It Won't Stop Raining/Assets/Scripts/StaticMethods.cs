using UnityEngine;

public class StaticMethods {

	/// <summary>
	/// Returns the distance between the specified Vector3s p1 and p2.
	/// </summary>
	/// <param name="p1">Vector3 P1.</param>
	/// <param name="p2">Vector3 P2.</param>
	public static float Distance(Vector3 p1, Vector3 p2) {
		return (p2 - p1).magnitude;
	}

	/// <summary>
	/// Returns the distance between the specified Vector2s p1 and p2.
	/// </summary>
	/// <param name="p1">Vector2 P1.</param>
	/// <param name="p2">Vector2 P2.</param>
	public static float Distance(Vector2 p1, Vector2 p2) {
		return (p2 - p1).magnitude;
	}

	/// <summary>
	/// Returns true if the two floats differ by less than the threshold value.
	/// </summary>
	/// <returns><c>true</c>, if 2 floats differ by less than threshold, <c>false</c> otherwise.</returns>
	/// <param name="f1">float F1.</param>
	/// <param name="f2">float F2.</param>
	/// <param name="threshold">float threshold.</param>
	public static bool AlmostEquals(float f1, float f2, float threshold) {
		return Mathf.Abs(f1 - f2) < threshold;
	}

	/// <summary>
	/// Returns true if the two Vector2s differ in distance by less than the threshold value.
	/// </summary>
	/// <returns><c>true</c>, if 2 Vector2s differ by less than threshold, <c>false</c> otherwise.</returns>
	/// <param name="f1">Vector2 F1.</param>
	/// <param name="f2">Vector2 F2.</param>
	/// <param name="threshold">float threshold.</param>
	public static bool AlmostEquals(Vector2 p1, Vector2 p2, float threshold) {
		return Distance(p1, p2) < threshold;
	}

	/// <summary>
	/// Returns true if the two Vector3s differ in distance by less than the threshold value.
	/// </summary>
	/// <returns><c>true</c>, if 2 Vector3s differ by less than threshold, <c>false</c> otherwise.</returns>
	/// <param name="f1">Vector3 F1.</param>
	/// <param name="f2">Vector3 F2.</param>
	/// <param name="threshold">float threshold.</param>
	public static bool AlmostEquals(Vector3 p1, Vector3 p2, float threshold) {
		return Distance(p1, p2) < threshold;
	}
}
