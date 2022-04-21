using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM01
{
    class BurningPower : Spell
    {
        public BurningPower() : base("Burning Power", 1, Civilization.Fire)
        {
            AddSpellAbilities(new BurningPowerEffect());
        }
    }

    class BurningPowerEffect : CardSelectionEffect
    {
        public BurningPowerEffect() : base(1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new BurningPowerEffect();
        }

        public override string ToString()
        {
            return "One of your creatures gets \"power attacker +2000\" until the end of the turn.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.AddContinuousEffects(GetSourceAbility(game), new ContinuousEffects.ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(2000, cards));
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(GetSourceAbility(game).Controller);
        }
    }
}
