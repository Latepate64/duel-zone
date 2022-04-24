using Engine.Abilities;

namespace Engine.GameEvents
{
    public class DrawCardEvent : GameEvent
    {
        public DrawCardEvent(IPlayer player, ICard card, IAbility ability)
        {
            Ability = ability;
            Card = card;
            Player = player;
        }

        public IAbility Ability { get; }
        public ICard Card { get; }
        public IPlayer Player { get; }

        public override void Happen(IGame game)
        {
            game.Move(Ability, ZoneType.Deck, ZoneType.Hand, Card);
        }

        public override string ToString()
        {
            return $"{Player} drew {Card}.";
        }
    }
}
