using ContinuousEffects;

namespace Cards.DM11
{
    class WarlordAilzonius : EvolutionCreature
    {
        public WarlordAilzonius() : base("Warlord Ailzonius", 5, 8000, Interfaces.Race.Gladiator, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddStaticAbilities(new OpponentCannotChooseThisCreatureEffect());
        }
    }
}
