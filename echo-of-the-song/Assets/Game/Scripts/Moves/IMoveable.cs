using UnityEngine;

namespace Game.Scripts.Moves
{
    public interface IMoveable<in T>
    {
        public void HandleDirection(T direction);
        public Vector3 MovementDirection { get; }
    }
}