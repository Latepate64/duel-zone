namespace Engine.Zones
{
    public class SpellStack : Zone, ICopyable<SpellStack>
    {
        public SpellStack() : base(ZoneType.SpellStack)
        {
        }

        public SpellStack(Zone zone) : base(zone)
        {
        }

        public SpellStack Copy()
        {
            return new SpellStack(this);
        }
    }
}
