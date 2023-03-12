using UnityEngine;

namespace Menu_Library
{
    class MenuLogger : MonoBehaviour
    {
        public static void LogError(string msg)
        {
            Debug.LogError("[Menu Library] {Error} ==> " + msg);
        }

        public static void LogWarning(string msg)
        {
            Debug.LogWarning("[Menu Library] {Warning} ==> " + msg);
        }

        public static void Log(string msg)
        {
            Debug.Log("[Menu Library] {Log} ==> " + msg);
        }
    }
}
