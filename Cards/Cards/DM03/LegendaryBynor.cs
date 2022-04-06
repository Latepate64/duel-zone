using Common;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class LegendaryBynor : EvolutionCreature
    {
        public LegendaryBynor() : base("Legendary Bynor", 6, 8000, Subtype.Leviathan, Civilization.Water)
        {
            AddStaticAbilities(new LegendaryBynorEffect());
            AddDoubleBreakerAbility();
        }
    }

    class LegendaryBynorEffect : ContinuousEffect, IUnblockableEffect
    {
        public LegendaryBynorEffect() : base(new CardFilters.OwnersBattleZoneAnotherCivilizationCreatureFilter(Civilization.Water))
        {
        }

        public bool Applies(Engine.ICard attacker, Engine.ICard blocker, IGame game)
        {
            return !IsSourceOfAbility(attacker, game) && attacker.HasCivilization(Civilization.Water);
        }

        public override IContinuousEffect Copy()
        {
            return new LegendaryBynorEffect();
        }

        public override string ToString()
        {
            return "Your other water creatures in the battle zone can't be blocked.";
        }
    }
}
