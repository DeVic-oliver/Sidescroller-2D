using System.Collections;
using UnityEngine;
using Assets.Scripts.Core.Interfaces;
namespace Assets.Scripts.Core.Classes
{
    public class Movement
    {
        public void MoveMyself(IMoveable movableGameObject, bool isAlive)
        {
            movableGameObject.Move(isAlive);
        }
    }
}