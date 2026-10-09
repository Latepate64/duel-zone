using Abilities.Static;
using ContinuousEffects.CanAttackUntappedCreatures;
using ContinuousEffects.PowerModifying;

namespace Cards.DM03
{
    sealed class GarkagoDragon : Creature
    {
        public GarkagoDragon() : base("Garkago Dragon", 7, 6000, Interfaces.Race.ArmoredDragon, Interfaces.Civilization.Fire)
        {
            AddAbilities(new DoubleBreakerAbility());
            AddStaticAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, Interfaces.Civilization.Fire));
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
            
        }
    }
}
