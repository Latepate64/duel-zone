using ContinuousEffects;

namespace Cards.DM04
{
    class AncientGiant : Engine.Creature
    {
        public AncientGiant() : base("Ancient Giant", 8, 9000, Interfaces.Race.Giant, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(Interfaces.Civilization.Darkness));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
