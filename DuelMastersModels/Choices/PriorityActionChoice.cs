using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.Choices
{
    public enum MainActionMode
    {
        EndTurn,
        Charge,
        Use,
        Attack,
    }

    public class PriorityActionRequest : Choice
    {
        public IEnumerable<IHandCard> ChargeCards { get; }
        public IEnumerable<IHandCard> UseCards { get; }
        public IEnumerable<IBattleZoneCreature> AttackCreatures { get; }
        public bool TurnEndable { get; }

        public PriorityActionRequest(IPlayer player, IEnumerable<IHandCard> chargeCards, IEnumerable<IHandCard> useCards, IEnumerable<IBattleZoneCreature> attackCreatures/*, bool turnEndable*/) : base(player)
        {
            ChargeCards = chargeCards;
            UseCards = useCards;
            AttackCreatures = attackCreatures;
            TurnEndable = true; //TODO: Consider situations where it is not possible to end turn. (eg. creature must attack if able)
        }
    }
}