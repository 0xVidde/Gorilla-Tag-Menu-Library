using UnityEngine;

namespace Menu_Library
{
    class MenuLogger : MonoBehaviour
    {
        /// <summary>
        /// Simply logs error to console but with the "[Menu Library]" tag at the back
        /// </summary>
        /// <param name="msg">The message to be sent</param>
        public static void LogError(string msg)
        {
            Debug.LogError  ("[Menu Library] {Error} ==> " + msg);
        }

        /// <summary>
        /// Simply logs warning to console but with the "[Menu Library]" tag at the back
        /// </summary>
        /// <param name="msg">The message to be sent</param>
        public static void LogWarning(string msg)
        {
            Debug.LogWarning("[Menu Library] {Warning} ==> " + msg);
        }

        /// <summary>
        /// Simply logs to console but with the "[Menu Library]" tag at the back
        /// </summary>
        /// <param name="msg">The message to be sent</param>
        public static void Log(string msg)
        {
            Debug.Log       ("[Menu Library] {Log} ==> " + msg);
        }
    }
}
