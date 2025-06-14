using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;

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

        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            var e = gameEvent as CreatureBreaksShieldsEvent;
            return new BolmeteusEvent(e.Attacker, e.BreakAmount);
        }

        public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
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

    class BolmeteusEvent(Card attacker, int breakAmount) : CreatureMightBreakShieldsEvent(attacker, breakAmount)
    {
        public override void Happen(IGame game)
        {
            var owner = Attacker.Owner;
            var cards = owner.ChooseCards(game.GetOpponent(owner).ShieldZone.Cards, BreakAmount, BreakAmount, "Choose shields. Your opponent puts those shields into his graveyard.");
            game.Move(null, ZoneType.ShieldZone, ZoneType.Graveyard, [.. cards]);
        }

        public override string ToString()
        {
            return $"Opponent put {BreakAmount} shields into his graveyard.";
        }
    }
}
