using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM07
{
    class KingBenthos : Creature
    {
        public KingBenthos() : base("King Benthos", 8, 6000, Subtype.Leviathan, Civilization.Water)
        {
            AddDoubleBreakerAbility();
            AddTapAbility(new KingBenthosEffect());
        }
    }

    class KingBenthosEffect : OneShotEffects.OneShotAreaOfEffect
    {
        public KingBenthosEffect() : base(new CardFilters.OwnersBattleZoneCivilizationCreatureFilter(Civilization.Water))
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new ContinuousEffects.ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(
                new CardFilters.TargetsFilter(GetAffectedCards(game, source).ToArray()),
                new StaticAbilities.ThisCreatureCannotBeBlockedAbility()));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new KingBenthosEffect();
        }

        public override string ToString()
        {
            return "Each of your water creatures gets \"This creature can't be blocked\" until the end of the turn.";
        }
    }
}
