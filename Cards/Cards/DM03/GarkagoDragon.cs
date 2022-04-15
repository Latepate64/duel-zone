using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM03
{
    class GarkagoDragon : Creature
    {
        public GarkagoDragon() : base("Garkago Dragon", 7, 6000, Engine.Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddDoubleBreakerAbility();
            AddStaticAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, Civilization.Fire));
            AddThisCreatureCanAttackUntappedCreaturesAbility();
            
        }
    }
}
