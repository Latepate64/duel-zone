using Cards.ContinuousEffects;
using Engine;

namespace Cards.Cards.DM09
{
    class SnaptongueLizard : Creature
    {
        public SnaptongueLizard() : base("Snaptongue Lizard", 6, 3000, Race.DuneGecko, Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect());
            AddStaticAbilities(new PowerAttackerEffect(3000));
        }
    }
}
