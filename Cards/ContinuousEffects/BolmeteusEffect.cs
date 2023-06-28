using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class BolmeteusEffect : ReplacementEffect
    {
        public BolmeteusEffect()
        {
        }

        public BolmeteusEffect(BolmeteusEffect effect) : base(effect)
        {
        }

        public override IGameEvent Apply(IGameEvent gameEvent)
        {
            var e = gameEvent as CreatureBreaksShieldsEvent;
            return new BolmeteusEvent(e.Attacker, e.BreakAmount);
        }

        public override bool CanBeApplied(IGameEvent gameEvent)
        {
            return gameEvent is CreatureBreaksShieldsEvent e && e.Attacker == Source;
        }

        public override IContinuousEffect Copy()
        {
            return new BolmeteusEffect(this);
        }

        public override string ToString()
        {
            return "Whenever this creature would break a shield, your opponent puts that shield into his graveyard instead.";
        }
    }

    class BolmeteusEvent : CreatureMightBreakShieldsEvent
    {
        public BolmeteusEvent(ICard attacker, int breakAmount) : base(attacker, breakAmount)
        {
        }

        public override void Happen(IGame game)
        {
            var cards = Attacker.Owner.ChooseCards(Attacker.Owner.Opponent.ShieldZone.Cards, BreakAmount, BreakAmount, "Choose shields. Your opponent puts those shields into his graveyard.");
            game.Move(null, ZoneType.ShieldZone, ZoneType.Graveyard, cards.ToArray());
        }

        public override string ToString()
        {
            return $"Opponent put {BreakAmount} shields into his graveyard.";
        }
    }
}
