using Cards.CardFilters;
using Engine.Abilities;

namespace Cards.Cards.DM03
{
    class MuramasaDukeOfBlades : Creature
    {
        public MuramasaDukeOfBlades() : base("Muramasa, Duke of Blades", 6, 3000, Common.Subtype.Human, Common.Civilization.Fire)
        {
            AddAbilities(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new MuramasaDukeOfBladesEffect()));
        }
    }

    class MuramasaDukeOfBladesEffect : OneShotEffects.DestroyEffect
    {
        public MuramasaDukeOfBladesEffect() : base(new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(2000), 0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new MuramasaDukeOfBladesEffect();
        }

        public override string ToString()
        {
            return "You may destroy one of your opponent's creatures that has power 2000 or less.";
        }
    }
}
