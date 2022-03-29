using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM08
{
    class MagmadragonJagalzor : TurboRushCreature
    {
        public MagmadragonJagalzor() : base("Magmadragon Jagalzor", 6, 6000, Subtype.VolcanoDragon, Civilization.Fire)
        {
            AddDoubleBreakerAbility();
            AddTurboRushAbility(new MagmadragonJagalzorEffect());
        }
    }

    class MagmadragonJagalzorEffect : SpeedAttackerEffect
    {
        public MagmadragonJagalzorEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter(), new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new MagmadragonJagalzorEffect();
        }

        public override string ToString()
        {
            return "Each of your creatures in the battle zone has \"speed attacker.\"";
        }
    }
}
