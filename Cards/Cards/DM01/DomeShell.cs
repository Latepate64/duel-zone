using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class DomeShell : Creature
    {
        public DomeShell() : base("Dome Shell", 4, 3000, Engine.Race.ColonyBeetle, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
        }
    }
}
