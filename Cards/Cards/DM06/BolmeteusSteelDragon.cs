using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using System.Linq;

namespace Cards.Cards.DM06
{
    class BolmeteusSteelDragon : Creature
    {
        public BolmeteusSteelDragon() : base("Bolmeteus Steel Dragon", 1, 7000, Race.ArmoredDragon, Civilization.Fire) //TODO: MANA cost
        {
            AddDoubleBreakerAbility();
            AddStaticAbilities(new BolmeteusEffect());
        }
    }

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
            var e = gameEvent as BreakShieldsEvent;
            return new BolmeteusEvent(e.Attacker, e.BreakAmount);
        }

        public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is BreakShieldsEvent e && e.Attacker == GetSourceCard(game);
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

    class BolmeteusEvent : MightBreakShieldsEvents
    {
        public BolmeteusEvent(ICard attacker, int breakAmount) : base(attacker, breakAmount)
        {
        }

        public override void Happen(IGame game)
        {
            var owner = game.GetPlayer(Attacker.Owner);
            var cards = owner.ChooseCards(game.GetOpponent(owner).ShieldZone.Cards, BreakAmount, BreakAmount, "Choose shields. Your opponent puts those shields into his graveyard.");
            game.Move(ZoneType.ShieldZone, ZoneType.Graveyard, cards.ToArray());
        }

        public override string ToString()
        {
            return $"Opponent put {BreakAmount} shields into his graveyard.";
        }
    }
}
