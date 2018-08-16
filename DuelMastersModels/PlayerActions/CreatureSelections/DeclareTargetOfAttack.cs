using DuelMastersModels.Cards;
using DuelMastersModels.Steps;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    public class DeclareTargetOfAttack : OptionalCreatureSelection
    {
        public DeclareTargetOfAttack(Player player, Collection<Creature> creatures) : base(player, creatures)
        { }

        public override string Message
        {
            get
            {
                if (SelectedCreature != null)
                {
                    return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0} declared {1} as a target of the attack.", Player.Name, SelectedCreature.Name);
                }
                else
                {
                    return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0} declared their opponent as a target of the attack.", Player.Name);
                }
            }
        }

        public override void Perform(Duel duel)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException("duel");
            }
            else if (duel.CurrentTurn.CurrentStep is AttackDeclarationStep attackDeclarationStep)
            {
                if (SelectedCreature != null)
                {
                    attackDeclarationStep.AttackedCreature = SelectedCreature;
                }
            }
            else
            {
                throw new System.NotSupportedException();
            }
        }
    }
}