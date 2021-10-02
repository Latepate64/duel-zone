using DuelMastersModels.Choices;
using System;

namespace DuelMastersModels.Abilities.Triggered
{
    public class QuixoticHeroSwineSnoutAbility : AnotherCreaturePutIntoBattleZoneAbility
    {
        public QuixoticHeroSwineSnoutAbility()
        {
        }

        public QuixoticHeroSwineSnoutAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new QuixoticHeroSwineSnoutAbility(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            // This creature gets +3000 power until the end of the turn.
            throw new NotImplementedException();
        }
    }
}
