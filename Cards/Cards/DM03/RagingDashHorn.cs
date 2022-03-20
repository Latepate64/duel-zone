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
            AddAbilities(new RagingDashHornAbility());
        }
    }

    class RagingDashHornAbility : Engine.Abilities.StaticAbility
    {
        public RagingDashHornAbility() : base(new RagingDashHornEffect())
        {
        }
    }

    class RagingDashHornEffect : CharacteristicModifyingEffect, IPowerModifyingEffect, IAbilityAddingEffect
    {
        public RagingDashHornEffect() : base(new TargetFilter(), new Engine.Durations.Indefinite()) { }

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
            return "While all the cards in your mana zone are nature cards, this creature gets +3000 power and has \"double breaker (This creature breaks 2 shields).\"";
        }

        private bool Applies(IGame game)
        {
            var ability = game.GetAbility(SourceAbility);
            if (ability != null)
            { 
                var player = game.GetPlayer(ability.Owner);
                return player != null && player.ManaZone.Cards.All(x => x.Civilizations.Contains(Civilization.Nature));
            }
            return false;
        }
    }
}
