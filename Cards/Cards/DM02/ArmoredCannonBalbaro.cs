using Common;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class ArmoredCannonBalbaro : EvolutionCreature
    {
        public ArmoredCannonBalbaro() : base("Armored Cannon Balbaro", 3, 3000, Subtype.Human, Civilization.Fire)
        {
            AddAbilities(new StaticAbility(new ContinuousEffects.PowerAttackerMultiplierEffect(2000, new CardFilters.BattleZoneCreatureFilter(Subtype.Human))));
        }
    }
}
