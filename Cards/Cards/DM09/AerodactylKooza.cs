using Cards.ContinuousEffects;
using Effects.Continuous;
using Engine;

namespace Cards.Cards.DM09
{
    class AerodactylKooza : Creature
    {
        public AerodactylKooza() : base("Aerodactyl Kooza", 3, 1000, Race.Armorloid, Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect());
            AddStaticAbilities(new PowerAttackerEffect(3000));
        }
    }
}
