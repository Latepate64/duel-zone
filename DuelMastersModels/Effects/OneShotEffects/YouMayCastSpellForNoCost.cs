using DuelMastersModels.Cards;

namespace DuelMastersModels.Effects.OneShotEffects
{
    public class YouMayCastSpellForNoCost : OneShotEffect
    {
        public Spell Spell { get; private set; }

        public YouMayCastSpellForNoCost(Spell spell)
        {
            Spell = spell;
        }

        public override PlayerActions.PlayerAction Apply()
        {
            throw new System.NotImplementedException();
        }
    }
}
