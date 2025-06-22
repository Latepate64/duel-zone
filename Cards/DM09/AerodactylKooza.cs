using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM09
{
    sealed class AerodactylKooza : Creature
    {
        public AerodactylKooza() : base("Aerodactyl Kooza", 3, 1000, Race.Armorloid, Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect());
            AddStaticAbilities(new PowerAttackerEffect(3000));
        }
    }
}
