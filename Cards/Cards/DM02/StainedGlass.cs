using Cards.OneShotEffects;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class StainedGlass : Creature
    {
        public StainedGlass() : base("Stained Glass", 3, 1000, Subtype.CyberVirus, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new StainedGlassEffect()));
        }
    }

    class StainedGlassEffect : BounceEffect
    {
        public StainedGlassEffect() : base(new CardFilters.OpponentsBattleZoneChoosableCivilizationCreatureFilter(Civilization.Fire, Civilization.Nature), 0, 1)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new StainedGlassEffect();
        }

        public override string ToString()
        {
            return "You may choose one of your opponent's fire or nature creatures in the battle zone and return it to its owner's hand.";
        }
    }
}
