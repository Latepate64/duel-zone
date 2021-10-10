using DuelMastersModels.Choices;

namespace DuelMastersModels.Abilities
{
    public abstract class AsPermanentEntersBattleZoneAbility : StaticAbility
    {
        protected AsPermanentEntersBattleZoneAbility()
        {
        }

        protected AsPermanentEntersBattleZoneAbility(StaticAbility ability) : base(ability)
        {
        }

        public abstract Choice Apply(Duel duel, Decision decision);

        public abstract void Revoke();
    }
}
