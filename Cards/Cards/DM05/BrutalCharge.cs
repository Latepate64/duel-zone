using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using Engine.GameEvents;
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
        public override void Apply(IGame game)
        {
            game.AddDelayedTriggeredAbility(new DelayedTriggeredAbility(new TriggeredAbilities.AtTheEndOfTurnAbility(game.CurrentTurn.Id, new BrutalChargeDelayedEffect()), Ability.Source, Ability.ControllerPlayer, true));
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
        public BrutalChargeDelayedEffect()
        {
        }

        public BrutalChargeDelayedEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var shieldsBroken = game.CurrentTurn.GameEvents.OfType<CreatureBreaksShieldsEvent>().Sum(x => x.BreakAmount);
            var creatures = Controller.ChooseCards(Controller.Deck.Creatures, 0, shieldsBroken, ToString()).ToArray();
            Controller.Reveal(game, creatures);
            game.Move(Ability, ZoneType.Deck, ZoneType.Hand, creatures);
            Controller.ShuffleDeck(game);
            Controller.Unreveal(creatures);
        }

        public override IOneShotEffect Copy()
        {
            return new BrutalChargeDelayedEffect(this);
        }

        public override string ToString()
        {
            return "Search your deck. For each of your opponent's shields your creatures broke this turn, you may take a creature from your deck, show it to your opponent, and put it into your hand. Then shuffle your deck.";
        }
    }
}
