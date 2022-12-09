using UnityEngine;

namespace Scripts.Utils
{
    public static class JumpRaycaster
    {
        /// <summary>
        /// Fires a ray from the middle of the gameobject that returns a bool value if collides with another collider;
        /// </summary>
        /// <param name="gameObjectCollider">The gameobject collider that will be a jump check</param>
        /// <returns>True if ray hits another collider | False if not hits another collider</returns>
        public static bool CheckIfIsGrounded(Collider gameObjectCollider)
        {
            float distoToGround = gameObjectCollider.bounds.extents.y;
            bool isGrounded = Physics.Raycast(gameObjectCollider.transform.position, Vector3.down, distoToGround + 0.1f);

            if (isGrounded)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Fires a ray from the middle of the gameobject that returns a bool value if collides with another collider
        /// </summary>
        /// <param name="gameObjectCollider">The gameobject collider that will be a jump check</param>
        /// <param name="spaceBetweenColliderAndGround">A customizable distance between gameobject collider and 'ground' collider. Default space 0.1f</param>
        /// <returns>True if ray hits another collider | False if not hits another collider</returns>
        public static bool CheckIfIsGrounded(Collider gameObjectCollider, float spaceBetweenColliderAndGround = 0.1f)
        {
            float distoToGround = gameObjectCollider.bounds.extents.y;
            bool isGrounded = Physics.Raycast(gameObjectCollider.transform.position, Vector3.down, distoToGround + spaceBetweenColliderAndGround);

            if (isGrounded)
            {
                return true;
            }

            return false;
        }
    }
}


