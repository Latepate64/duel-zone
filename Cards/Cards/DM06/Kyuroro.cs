﻿using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;

namespace Cards.Cards.DM06
{
    class Kyuroro : Creature
    {
        public Kyuroro() : base("Kyuroro", 6, 2000, Race.CyberLord, Civilization.Water)
        {
            AddStaticAbilities(new KyuroroEffect());
        }
    }

    class KyuroroEffect : ReplacementEffect
    {
        public KyuroroEffect()
        {
        }

        public KyuroroEffect(KyuroroEffect effect) : base(effect)
        {
        }

        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            var e = gameEvent as BreakShieldsEvent;
            return new KyuroroEvent(e.Attacker, e.BreakAmount);
        }

        public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is BreakShieldsEvent e && e.Attacker.Owner == game.GetOpponent(GetController(game)).Id;
        }

        public override IContinuousEffect Copy()
        {
            return new KyuroroEffect(this);
        }

        public override string ToString()
        {
            return "Whenever an opponent's creature would break a shield, you choose the shield instead of your opponent.";
        }
    }

    class KyuroroEvent : MightBreakShieldsEvents
    {
        public KyuroroEvent(ICard attacker, int breakAmount) : base(attacker, breakAmount)
        {
        }

        public override void Happen(IGame game)
        {
            var opponent = game.GetOpponent(game.GetPlayer(Attacker.Owner));
            var cards = opponent.ChooseCards(opponent.ShieldZone.Cards, BreakAmount, BreakAmount, "Choose shields to break.");
            game.PutFromShieldZoneToHand(cards, true);
        }

        public override string ToString()
        {
            return $"{Attacker} broke {BreakAmount} shields.";
        }
    }
}
