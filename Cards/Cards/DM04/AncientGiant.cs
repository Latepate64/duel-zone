using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM04
{
    class AncientGiant : Engine.Creature
    {
        public AncientGiant() : base("Ancient Giant", 8, 9000, Engine.Race.Giant, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(Engine.Civilization.Darkness));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
