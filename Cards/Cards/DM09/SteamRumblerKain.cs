using Common;

namespace Cards.Cards.DM09
{
    class SteamRumblerKain : Creature
    {
        public SteamRumblerKain() : base("Steam Rumbler Kain", 4, 5000, Subtype.Armorloid, Civilization.Fire)
        {
            // Whenever this creature attacks, choose one of your shields and put it into your graveyard.
            AddAbilities(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.SelfShieldBurnEffect()));
        }
    }
}
