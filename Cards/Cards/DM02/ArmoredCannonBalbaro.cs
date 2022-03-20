using Common;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class ArmoredCannonBalbaro : EvolutionCreature
    {
        public ArmoredCannonBalbaro() : base("Armored Cannon Balbaro", 3, 3000, Subtype.Human, Civilization.Fire)
        {
            AddAbilities(new ArmoredCannonBalbaroAbility());
        }
    }

    class ArmoredCannonBalbaroAbility : StaticAbility
    {
        public ArmoredCannonBalbaroAbility() : base(new ContinuousEffects.PowerAttackerMultiplierEffect(2000, new CardFilters.BattleZoneSubtypeCreatureFilter(Subtype.Human)))
        {
        }

        public override string ToString()
        {
            return "While attacking, this creature gets +2000 power for each other Human in the battle zone.";
        }
    }
}
