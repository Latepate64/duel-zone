using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.Cards.DM12
{
    class NecrodragonJagraveen : Engine.Creature
    {
        public NecrodragonJagraveen() : base("Necrodragon Jagraveen", 6, 6000, Engine.Race.ZombieDragon, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new OneShotEffects.DestroyAfterBattleEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
