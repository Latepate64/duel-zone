using TriggeredAbilities;
using OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;

namespace Cards.DM01
{
    class ThornyMandra : Creature
    {
        public ThornyMandra() : base("Thorny Mandra", 5, 4000, Race.TreeFolk, Civilization.Nature)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ThornyMandraEffect()));
        }
    }

    class ThornyMandraEffect : FromGraveyardIntoManaZoneEffect
    {
        public ThornyMandraEffect() : base(0, 1, true)
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

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return Controller.Graveyard.Creatures;
        }
    }
}
