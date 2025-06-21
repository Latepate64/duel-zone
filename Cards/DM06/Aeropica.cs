using Engine.Abilities;

namespace Cards.DM06
{
    class Aeropica : Engine.Creature
    {
        public Aeropica() : base("Aeropica", 7, 4000, Interfaces.Race.SeaHacker, Interfaces.Civilization.Water)
        {
            AddAbilities(new TapAbility(new OneShotEffects.ChooseCreaturesInTheBattleZoneAndReturnItToItsOwnersHandEffect()));
        }
    }
}
