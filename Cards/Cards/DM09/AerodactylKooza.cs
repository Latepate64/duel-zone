using Cards.ContinuousEffects;
using Engine;

namespace Cards.Cards.DM09
{
    class AerodactylKooza : Creature
    {
        public AerodactylKooza() : base("Aerodactyl Kooza", 3, 1000, Race.Armorloid, Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect());
            AddPowerAttackerAbility(3000);
        }
    }
}
