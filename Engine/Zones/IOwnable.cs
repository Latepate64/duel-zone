namespace Engine.Zones
{
    public interface IOwnable
    {
        IPlayer Owner { get; }
    }

    abstract class OwnableZone : Zone, IOwnable
    {
        protected OwnableZone(ZoneType type) : base(type)
        {
        }

        protected OwnableZone(OwnableZone zone) : base(zone)
        {
        }

        public IPlayer Owner { get; }
    }
}
