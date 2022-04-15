using Cards.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class GarkagoDragon : Creature
    {
        public GarkagoDragon() : base("Garkago Dragon", 7, 6000, Engine.Subtype.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddDoubleBreakerAbility();
            AddStaticAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, Engine.Civilization.Fire));
            AddThisCreatureCanAttackUntappedCreaturesAbility();
            
        }
    }
}
