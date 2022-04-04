using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM03
{
    class RagingDashHorn : Creature
    {
        public RagingDashHorn() : base("Raging Dash-Horn", 5, 4000, Subtype.HornedBeast, Civilization.Nature)
        {
            AddStaticAbilities(new RagingDashHornEffect());
        }
    }

    class RagingDashHornEffect : ContinuousEffect, IPowerModifyingEffect, IAbilityAddingEffect
    {
        public RagingDashHornEffect() : base(new TargetFilter(), new Durations.Indefinite()) { }

        public RagingDashHornEffect(RagingDashHornEffect effect) : base(effect) { }

        public void AddAbility(IGame game)
        {
            if (Applies(game))
            {
                GetAffectedCards(game).ToList().ForEach(x => x.AddGrantedAbility(new StaticAbilities.DoubleBreakerAbility()));
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
                GetAffectedCards(game).ToList().ForEach(x => x.Power += 3000);
            }
        }

        public override string ToString()
        {
            return "While all the cards in your mana zone are nature cards, this creature gets +3000 power and has \"double breaker.\"";
        }

        private bool Applies(IGame game)
        {
            var ability = game.GetAbility(SourceAbility);
            if (ability != null)
            {
                return ability.GetController(game).ManaZone.Cards.All(x => x.HasCivilization(Civilization.Nature));
            }
            return false;
        }
    }
}
