using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM10
{
    class ArmoredRaiderGandaval : EvolutionCreature
    {
        public ArmoredRaiderGandaval() : base("Armored Raider Gandaval", 5, 6000, Engine.Race.Human, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new DogarnTheMarauderEffect(2000));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
