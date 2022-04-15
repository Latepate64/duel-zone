using Cards.OneShotEffects;

namespace Cards.Cards.DM02
{
    class HorridWorm : Creature
    {
        public HorridWorm() : base("Horrid Worm", 3, 2000, Engine.Subtype.ParasiteWorm, Engine.Civilization.Darkness)
        {
            AddWheneverThisCreatureAttacksAbility(new OpponentRandomDiscardEffect());
        }
    }
}
