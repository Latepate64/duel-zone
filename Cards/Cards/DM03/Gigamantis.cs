using Cards.ContinuousEffects;
using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class Gigamantis : EvolutionCreature
    {
        public Gigamantis() : base("Gigamantis", 4, 5000, Subtype.GiantInsect, Civilization.Nature)
        {
            AddAbilities(new GigamantisAbility());
        }
    }

    class GigamantisAbility : Engine.Abilities.StaticAbility
    {
        public GigamantisAbility() : base(new GigamantisEffect())
        {
        }
    }

    class GigamantisEffect : WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect
    {
        public GigamantisEffect() : base(new CardFilters.OwnersBattleZoneAnotherCivilizationCreatureFilter(Civilization.Nature))
        {
        }

        public override IContinuousEffect Copy()
        {
            return new GigamantisEffect();
        }

        public override string ToString()
        {
            return "Whenever another of your nature creatures would be put into your graveyard from the battle zone, put it into your mana zone instead.";
        }
    }
}
