using ContinuousEffects;

namespace Cards.DM03
{
    sealed class GarkagoDragon : Engine.Creature
    {
        public GarkagoDragon() : base("Garkago Dragon", 7, 6000, Interfaces.Race.ArmoredDragon, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddStaticAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, Interfaces.Civilization.Fire));
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
            
        }
    }
}
