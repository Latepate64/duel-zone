using ContinuousEffects;

namespace Cards.Cards.DM03
{
    class GarkagoDragon : Engine.Creature
    {
        public GarkagoDragon() : base("Garkago Dragon", 7, 6000, Engine.Race.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddStaticAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, Engine.Civilization.Fire));
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
            
        }
    }
}
