using Common;
using Common.GameEvents;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM05
{
    class BrutalCharge : Spell
    {
        public BrutalCharge() : base("Brutal Charge", 2, Civilization.Nature)
        {
            AddSpellAbilities(new BrutalChargeEffect());
        }
    }

    class BrutalChargeEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.AddDelayedTriggeredAbility(new DelayedTriggeredAbility(new TriggeredAbilities.AtTheEndOfTurnAbility(game.CurrentTurn.Id, new BrutalChargeDelayedEffect()), source.Source, source.Owner, new Durations.Indefinite(), true));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new BrutalChargeEffect();
        }

        public override string ToString()
        {
            return "At the end of this turn, search your deck. For each of your opponent's shields your creatures broke this turn, you may take a creature from your deck, show it to your opponent, and put it into your hand. Then shuffle your deck.";
        }
    }

    class BrutalChargeDelayedEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var shieldsBroken = game.CurrentTurn.Phases.SelectMany(x => x.GameEvents).OfType<ShieldsBrokenEvent>().Sum(x => x.Amount);
            return new OneShotEffects.TutoringEffect(new CardFilters.OwnersDeckCreatureFilter(), true, shieldsBroken).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new BrutalChargeDelayedEffect();
        }

        public override string ToString()
        {
            return "Search your deck. For each of your opponent's shields your creatures broke this turn, you may take a creature from your deck, show it to your opponent, and put it into your hand. Then shuffle your deck.";
        }
    }
}
