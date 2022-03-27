using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM03
{
    class GarkagoDragon : Creature
    {
        public GarkagoDragon() : base("Garkago Dragon", 7, 6000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddAbilities(new DoubleBreakerAbility(), new GetsPowerForEachOtherCivilizationCreatureYouControlAbility(Civilization.Fire), new ThisCreatureCanAttackUntappedCreaturesAbility());
        }
    }
}
