using Abilities.Static;
using ContinuousEffects.PowerModifying;

namespace Cards.DM10
{
    sealed class ArmoredRaiderGandaval : EvolutionCreature
    {
        public ArmoredRaiderGandaval() : base("Armored Raider Gandaval", 5, 6000, Interfaces.Race.Human, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new DogarnTheMarauderEffect(2000));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
