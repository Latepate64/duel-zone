using ContinuousEffects;
using Engine;

namespace Cards.DM09
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
