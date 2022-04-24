using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM05
{
    class KingTsunami : Creature
    {
        public KingTsunami() : base("King Tsunami", 12, 12000, Race.Leviathan, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new KingTsunamiEffect());
            AddTripleBreakerAbility();
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

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetOtherCreatures(Ability.Source.Id);
        }
    }
}
