using UnityEngine;

public static class VectorExtensions
{
    /// <summary>
    /// sets the y to 0
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    public static Vector3 removeY(this Vector3 vector)
    {
        return new Vector3(vector.x, 0, vector.z);
    }
}