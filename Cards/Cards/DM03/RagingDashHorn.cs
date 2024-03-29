﻿using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

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
                Source.Power += 3000;
            }
        }

        public override string ToString()
        {
            return "While all the cards in your mana zone are nature cards, this creature gets +3000 power and has \"double breaker.\"";
        }

        private bool Applies(IGame game)
        {
            var ability = Ability;
            if (ability != null)
            {
                return ability.Controller.ManaZone.Cards.All(x => x.HasCivilization(Civilization.Nature));
            }
            return false;
        }
    }
}
