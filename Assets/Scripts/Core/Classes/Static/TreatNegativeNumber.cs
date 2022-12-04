using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core.Classes.Static
{
    public static class TreatNegativeNumber
    {
        /// <summary>
        /// Treat negative value and returns 0 when found it
        /// </summary>
        /// <param name="value">Value to be passed</param>
        /// <returns> 0 When value is negative or the original value passed</returns>
        public static int GetTreatedValue(int value)
        {
            if (value <= 0)
            {
                return 0;
            }
            return value;
        }
    }
}