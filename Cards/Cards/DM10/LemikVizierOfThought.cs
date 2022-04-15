using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.Cards.DM10
{
    class LemikVizierOfThought : Creature
    {
        public LemikVizierOfThought() : base("Lemik, Vizier of Thought", 5, 3000, Subtype.Initiate, Civilization.Light)
        {
            AddStaticAbilities(new LemikVizierOfThoughtEffect());
        }
    }

    class LemikVizierOfThoughtEffect : AbilityAddingEffect
    {
        public LemikVizierOfThoughtEffect() : base(new StaticAbilities.BlockerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new LemikVizierOfThoughtEffect();
        }

        public override string ToString()
        {
            return "Each of your water creatures and nature creatures in the battle zone has \"blocker.\"";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game)
        {
            return game.BattleZone.GetCreatures(GetController(game).Id, Civilization.Water, Civilization.Nature);
        }
    }
}
