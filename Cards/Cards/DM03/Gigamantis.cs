using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM03
{
    class Gigamantis : EvolutionCreature
    {
        public Gigamantis() : base("Gigamantis", 4, 5000, Subtype.GiantInsect, Civilization.Nature)
        {
            AddAbilities(new Engine.Abilities.StaticAbility(new WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(new CardFilters.OwnersBattleZoneAnotherCivilizationCreatureFilter(Civilization.Nature))));
        }
    }
}
