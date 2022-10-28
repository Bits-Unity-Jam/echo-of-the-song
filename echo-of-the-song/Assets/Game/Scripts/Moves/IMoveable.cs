namespace Game.Scripts.Moves
{
    public interface IMoveable<in T>
    {
        public void HandleDirection(T direction);
    }
}