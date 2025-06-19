using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class Aeropica : Creature
    {
        public Aeropica() : base("Aeropica", 7, 4000, Engine.Race.SeaHacker, Engine.Civilization.Water)
        {
            AddAbilities(new TapAbility(new OneShotEffects.ChooseCreaturesInTheBattleZoneAndReturnItToItsOwnersHandEffect()));
        }
    }
}
