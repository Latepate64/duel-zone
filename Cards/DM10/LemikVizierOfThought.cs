using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.DM10
{
    sealed class LemikVizierOfThought : Creature
    {
        public LemikVizierOfThought() : base("Lemik, Vizier of Thought", 5, 3000, Race.Initiate, Civilization.Light)
        {
            AddStaticAbilities(new LemikVizierOfThoughtEffect());
        }
    }

    sealed class LemikVizierOfThoughtEffect : AbilityAddingEffect
    {
        public LemikVizierOfThoughtEffect() : base(new StaticAbility(new ThisCreatureHasBlockerEffect()))
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
            return game.BattleZone.GetCreatures(Controller.Id, Civilization.Water, Civilization.Nature);
        }
    }
}
