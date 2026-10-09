using ContinuousEffects.PowerModifying;

namespace Cards.DM01
{
    sealed class ArmoredWalkerUrherion : Creature
    {
        public ArmoredWalkerUrherion() : base("Armored Walker Urherion", 4, 3000, Interfaces.Race.Armorloid, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect(2000, Interfaces.Race.Human));
        }
    }
}
