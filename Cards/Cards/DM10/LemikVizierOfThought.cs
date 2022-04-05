using Cards.ContinuousEffects;
using Common;
using Engine.ContinuousEffects;

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
        public LemikVizierOfThoughtEffect() : base(new CardFilters.OwnersBattleZoneCivilizationCreatureFilter(Civilization.Water, Civilization.Nature), new Durations.Indefinite(), new StaticAbilities.BlockerAbility())
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
    }
}
