using DuelMastersModels.Cards;
using DuelMastersModels.Steps;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    public class DeclareAttacker : OptionalCreatureSelection
    {
        public DeclareAttacker(Player player, Collection<Creature> creatures) : base(player, creatures)
        { }

        public override string Message
        {
            get
            {
                if (SelectedCreature != null)
                {
                    return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0} declared {1} as an attacker.", Player.Name, SelectedCreature.Name);
                }
                else
                {
                    return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0} did not declare an attacker.", Player.Name);
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
                    attackDeclarationStep.AttackingCreature = SelectedCreature;
                    SelectedCreature.Tapped = true;
                }
            }
            else
            {
                throw new System.NotSupportedException();
            }
        }
    }
}
