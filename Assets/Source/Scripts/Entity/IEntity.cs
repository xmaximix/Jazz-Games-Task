using Source.Scripts.Health;

namespace Source.Scripts.Entity
{
    public interface IEntity
    {
        public EntityHealth Health { get; }
    }
}