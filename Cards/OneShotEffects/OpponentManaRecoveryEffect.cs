using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    abstract class OpponentManaRecoveryEffect : ManaRecoveryEffect
    {
        protected OpponentManaRecoveryEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum, controllerChooses)
        {
        }

        protected OpponentManaRecoveryEffect(OpponentManaRecoveryEffect effect) : base(effect)
        {
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return Applier.Opponent.ManaZone.Cards;
        }
    }
}
