using Cards.ContinuousEffects;
using Effects.Continuous;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class RagingDashHorn : Creature
    {
        public RagingDashHorn() : base("Raging Dash-Horn", 5, 4000, Race.HornedBeast, Civilization.Nature)
        {
            AddStaticAbilities(new RagingDashHornEffect());
        }
    }

    class RagingDashHornEffect : ContinuousEffect, IPowerModifyingEffect, IAbilityAddingEffect
    {
        public RagingDashHornEffect() : base() { }

        public RagingDashHornEffect(RagingDashHornEffect effect) : base(effect) { }

        public void AddAbility(IGame game)
        {
            if (Applies(game))
            {
                Source.AddGrantedAbility(new StaticAbilities.DoubleBreakerAbility());
            }
        }

        public override IContinuousEffect Copy()
        {
            return new RagingDashHornEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            if (Applies(game))
            {
                (Source as Creature).IncreasePower(3000);
            }
        }

        public override string ToString()
        {
            return "While all the cards in your mana zone are nature cards, this creature gets +3000 power and has \"double breaker.\"";
        }

        private bool Applies(IGame game)
        {
            return Ability != null && Ability.Controller.ManaZone.AreAllCivilizationCards(Civilization.Nature);
        }
    }
}
