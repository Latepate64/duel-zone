using OneShotEffects;

namespace Cards.DM01
{
    sealed class Teleportation : Engine.Spell
    {
        public Teleportation() : base("Teleportation", 5, Interfaces.Civilization.Water)
        {
            AddSpellAbilities(new ChooseUpTo2CreaturesInTheBattleZoneAndReturnThemToTheirOwnersHandsEffect());
        }
    }
}
