using ContinuousEffects;

namespace Cards.DM01
{
    class DomeShell : Engine.Creature
    {
        public DomeShell() : base("Dome Shell", 4, 3000, Interfaces.Race.ColonyBeetle, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
        }
    }
}
