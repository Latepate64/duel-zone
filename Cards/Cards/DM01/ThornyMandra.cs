using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class ThornyMandra : Creature
    {
        public ThornyMandra() : base("Thorny Mandra", 5, 4000, Subtype.TreeFolk, Civilization.Nature)
        {
            AddAbilities(new WhenThisCreatureIsPutIntoTheBattleZoneAbility(new ThornyMandraEffect()));
        }
    }

    class ThornyMandraEffect : FromGraveyardIntoManaZoneEffect
    {
        public ThornyMandraEffect() : base(new OwnersGraveyardCreatureFilter(), 0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ThornyMandraEffect();
        }

        public override string ToString()
        {
            return "You may put a creature from your graveyard into your mana zone.";
        }
    }
}
