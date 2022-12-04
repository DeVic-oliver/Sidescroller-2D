namespace Assets.Scripts.Core.Classes.Static
{
   public static class LifeStatusParser
    {
        /// <summary>
        /// Parsers the life status of a gameo bject that have health points and returns true or false if it sill health points
        /// </summary>
        /// <param name="healthPoints">The health points of the game object</param>
        /// <returns>True if still alive | False if health points equals 0</returns>
        public static bool GetLifeStatusBasedOnHealth(int healthPoints)
        {
            if (healthPoints <= 0)
            {
                return false;
            }
            return true;
        }
    }
}