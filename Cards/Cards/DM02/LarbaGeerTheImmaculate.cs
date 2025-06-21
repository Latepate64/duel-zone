using TriggeredAbilities;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM02
{
    class LarbaGeerTheImmaculate : EvolutionCreature
    {
        public LarbaGeerTheImmaculate() : base("Larba Geer, the Immaculate", 3, 5000, Race.Guardian, Civilization.Light)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new LarbaGeerTheImmaculateEffect()));
        }
    }

    class LarbaGeerTheImmaculateEffect : OneShotEffects.TapAreaOfEffect
    {
        public LarbaGeerTheImmaculateEffect() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new LarbaGeerTheImmaculateEffect();
        }

        public override string ToString()
        {
            return "Tap all your opponent's creatures in the battle zone that have \"blocker.\"";
        }

        protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.CreaturesThatHaveBlockerOwnedBy(game.GetOpponent(Ability.Controller));
        }
    }
}
