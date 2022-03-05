using Common;

namespace Cards.Cards.DM09
{
    class SteamRumblerKain : Creature
    {
        public SteamRumblerKain() : base("Steam Rumbler Kain", 4, Civilization.Fire, 5000, Subtype.Armorloid)
        {
            // Whenever this creature attacks, choose one of your shields and put it into your graveyard.
            Abilities.Add(new TriggeredAbilities.AttackAbility(new OneShotEffects.SelfShieldBurnEffect()));
        }
    }
}
