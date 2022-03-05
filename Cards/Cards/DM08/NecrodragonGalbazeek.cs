using Common;

namespace Cards.Cards.DM08
{
    class NecrodragonGalbazeek : Creature
    {
        public NecrodragonGalbazeek() : base("Necrodragon Galbazeek", 6, Civilization.Darkness, 9000, Subtype.ZombieDragon)
        {
            // Whenever this creature attacks, choose one of your shields and put it into your graveyard.
            Abilities.Add(new TriggeredAbilities.AttackAbility(new OneShotEffects.SelfShieldBurnEffect()));
            Abilities.Add(new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
