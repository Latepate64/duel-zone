using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class Teleportation : Spell
    {
        public Teleportation() : base("Teleportation", 5, Common.Civilization.Water)
        {
            AddSpellAbilities(new ChooseUpTo2CreaturesInTheBattleZoneAndReturnThemToTheirOwnersHandsEffect());
        }
    }
}
