using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using Engine.Steps;
using System;

namespace Cards.Cards.DM11
{
    class SlashAndBurn : Spell
    {
        public SlashAndBurn() : base("Slash and Burn", 4, Civilization.Darkness, Civilization.Fire)
        {
            AddSpellAbilities(new SlashAndBurnEffect());
        }
    }

    class SlashAndBurnEffect : OneShotEffect
    {
        public SlashAndBurnEffect()
        {
        }

        public SlashAndBurnEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            game.AddDelayedTriggeredAbility(new SlashAndBurnDelayedAbility(Ability));
        }

        public override IOneShotEffect Copy()
        {
            return new SlashAndBurnEffect(this);
        }

        public override string ToString()
        {
            return "Whenever any of your opponent's creatures is destroyed this turn, your opponent chooses a card in his mana zone and puts it into his graveyard. Then he chooses one of his shields and puts it into his graveyard.";
        }
    }

    class SlashAndBurnDelayedAbility : DelayedTriggeredAbility, IExpirable
    {
        public SlashAndBurnDelayedAbility(IAbility ability) : base(new SlashAndBurnAbility(), ability.Source, ability.Controller, false)
        {
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }
    }

    class SlashAndBurnAbility : LinkedTriggeredAbility
    {
        public SlashAndBurnAbility()
        {
        }

        public SlashAndBurnAbility(LinkedTriggeredAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is CardMovedEvent e && e.Source == ZoneType.BattleZone && e.Destination == ZoneType.Graveyard && e.CardInDestinationZone.Owner == Controller.Opponent;
        }

        public override IAbility Copy()
        {
            return new SlashAndBurnAbility(this);
        }

        public override void Resolve(IGame game)
        {
            Controller.Opponent.BurnOwnMana(game, this);
            var shield = Controller.Opponent.ChooseCard(Controller.Opponent.ShieldZone.Cards, ToString());
            game.Move(this, ZoneType.ShieldZone, ZoneType.Graveyard, shield);
        }

        public override string ToString()
        {
            return "Whenever any of your opponent's creatures is destroyed, your opponent chooses a card in his mana zone and puts it into his graveyard. Then he chooses one of his shields and puts it into his graveyard.";
        }

        public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
        {
            return Copy() as ITriggeredAbility;
        }
    }
}
