using Abilities.Triggered;
using ContinuousEffects;
using OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM09
{
    class StratosphereGiant : Creature
    {
        public StratosphereGiant() : base("Stratosphere Giant", 8, 13000, Race.Giant, Civilization.Nature)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new StratosphereGiantEffect()));
            AddStaticAbilities(new TripleBreakerEffect());
        }
    }

    class StratosphereGiantEffect : CardMovingChoiceEffect<Creature>
    {
        public StratosphereGiantEffect() : base(0, 2, false, ZoneType.Hand, ZoneType.BattleZone)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new StratosphereGiantEffect();
        }

        public override string ToString()
        {
            return "Your opponent chooses up to 2 creatures in his hand and puts them into the battle zone.";
        }

        protected override IEnumerable<Creature> GetSelectableCards(IGame game, IAbility source)
        {
            return GetOpponent(game).Hand.Creatures;
        }
    }
}
