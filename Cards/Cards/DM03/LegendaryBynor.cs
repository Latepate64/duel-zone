using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class LegendaryBynor : EvolutionCreature
    {
        public LegendaryBynor() : base("Legendary Bynor", 6, 8000, Engine.Subtype.Leviathan, Engine.Civilization.Water)
        {
            AddStaticAbilities(new LegendaryBynorEffect());
            AddDoubleBreakerAbility();
        }
    }

    class LegendaryBynorEffect : ContinuousEffect, IUnblockableEffect
    {
        public LegendaryBynorEffect() : base()
        {
        }

        public LegendaryBynorEffect(LegendaryBynorEffect effect) : base(effect)
        {
        }

        public bool Applies(ICard attacker, ICard blocker, IGame game)
        {
            return !IsSourceOfAbility(attacker, game) && attacker.HasCivilization(Engine.Civilization.Water);
        }

        public override IContinuousEffect Copy()
        {
            return new LegendaryBynorEffect(this);
        }

        public override string ToString()
        {
            return "Your other water creatures in the battle zone can't be blocked.";
        }
    }
}
