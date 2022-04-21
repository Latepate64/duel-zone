using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM06
{
    class ProtectiveForce : Spell
    {
        public ProtectiveForce() : base("Protective Force", 1, Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new ProtectiveForceEffect());
        }
    }

    class ProtectiveForceEffect : OneShotEffects.CardSelectionEffect
    {
        public ProtectiveForceEffect() : base(1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ProtectiveForceEffect();
        }

        public override string ToString()
        {
            return "One of your creatures in the battle zone that has \"blocker\" gets +4000 power until the end of the turn.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.AddContinuousEffects(GetSourceAbility(game), new ContinuousEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(4000, cards));
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(GetSourceAbility(game).Controller).Where(x => x.GetAbilities<BlockerAbility>().Any());
        }
    }
}
