using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActionResponses
{
    public class DeclareAttackResponse : PlayerActionResponse
    {
        /// <summary>
        /// If Attacker is null, no attack is declared.
        /// </summary>
        public Creature Attacker { get; }

        /// <summary>
        /// If TargetOfAttack is null and Attacker is not null, opponent is attacked.
        /// </summary>
        public Creature TargetOfAttack { get; }

        public DeclareAttackResponse(Creature attacker, Creature targetOfAttack)
        {
            Attacker = attacker;
            TargetOfAttack = targetOfAttack;
        }
    }
}