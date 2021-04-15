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

    public class ChargeChoice : Choice, ICardUsageChoice, IAttackerChoice, IEndTurnChoice
    {
        public IEnumerable<IHandCard> ChargeCards { get; }
        public IEnumerable<IHandCard> UseCards { get; }
        public IEnumerable<IBattleZoneCreature> AttackCreatures { get; }
        public bool TurnEndable { get; }

        public ChargeChoice(IPlayer player) : base(player)
        {
            //, ActivePlayer.Hand.Cards, usableCards, duel.GetCreaturesThatCanAttack(ActivePlayer)

            ChargeCards = player.Hand.Cards;
            //UseCards //TODO: Check which cards can be used
            //AttackCreatures //TODO: Check which creatures are able to attack
            TurnEndable = true; //TODO: Consider situations where it is not possible to end turn. (eg. creature must attack if able)
        }
    }
}