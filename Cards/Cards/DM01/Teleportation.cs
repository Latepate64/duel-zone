using OneShotEffects;

namespace Cards.Cards.DM01
{
    class Teleportation : Engine.Spell
    {
        public Teleportation() : base("Teleportation", 5, Engine.Civilization.Water)
        {
            AddSpellAbilities(new ChooseUpTo2CreaturesInTheBattleZoneAndReturnThemToTheirOwnersHandsEffect());
        }
    }
}
