using ContinuousEffects;
using Interfaces;

namespace Cards.DM09
{
    sealed class SnaptongueLizard : Creature
    {
        public SnaptongueLizard() : base("Snaptongue Lizard", 6, 3000, Race.DuneGecko, Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect());
            AddStaticAbilities(new PowerAttackerEffect(3000));
        }
    }
}
