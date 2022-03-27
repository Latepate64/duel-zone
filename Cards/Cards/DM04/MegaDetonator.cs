using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM04
{
    class MegaDetonator : Spell
    {
        public MegaDetonator() : base("Mega Detonator", 2, Civilization.Fire)
        {
            AddSpellAbilities(new MegaDetonatorEffect());
        }
    }

    class MegaDetonatorEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var discarded = new OneShotEffects.DiscardAnyNumberOfCardsEffect().Apply(game, source);
            return new OneShotEffects.GrantAbilityChoiceEffect(new CardFilters.OwnersBattleZoneCreatureFilter(), discarded.Count(), discarded.Count(), true, new StaticAbilities.DoubleBreakerAbility()).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new MegaDetonatorEffect();
        }

        public override string ToString()
        {
            return "Discard any number of cards from your hand. Then choose the same number of your creatures in the battle zone. Each of those creatures gets \"double breaker\" until the end of the turn.";
        }
    }
}
