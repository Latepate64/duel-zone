using Cards.ContinuousEffects;
using Cards.TriggeredAbilities;
using Effects.Continuous;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM05
{
    class KingTsunami : Creature
    {
        public KingTsunami() : base("King Tsunami", 12, 12000, Race.Leviathan, Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new KingTsunamiEffect()));
            AddStaticAbilities(new TripleBreakerEffect());
        }
    }

    class KingTsunamiEffect : OneShotEffects.BounceAreaOfEffect
    {
        public KingTsunamiEffect() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new KingTsunamiEffect();
        }

        public override string ToString()
        {
            return "Return all other creatures from the battle zone to their owners' hands.";
        }

        protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetOtherCreatures(Ability.Source.Id);
        }
    }
}
