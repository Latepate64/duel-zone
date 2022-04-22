using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class LegendaryBynor : EvolutionCreature
    {
        public LegendaryBynor() : base("Legendary Bynor", 6, 8000, Race.Leviathan, Civilization.Water)
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

        public bool CannotBeBlocked(ICard attacker, ICard blocker, IAttackable targetOfAttack, IGame game)
        {
            return !IsSourceOfAbility(attacker) && attacker.HasCivilization(Civilization.Water);
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
