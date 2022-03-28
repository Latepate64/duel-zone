using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM03
{
    class Psyshroom : Creature
    {
        public Psyshroom() : base("Psyshroom", 4, 2000, Common.Subtype.BalloonMushroom, Common.Civilization.Nature)
        {
            AddWheneverThisCreatureAttacksAbility(new PsyshroomEffect());
        }
    }

    class PsyshroomEffect : FromGraveyardIntoManaZoneEffect
    {
        public PsyshroomEffect() : base(new CardFilters.OwnersGraveyardCardFilter(Common.Civilization.Nature), 0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new PsyshroomEffect();
        }

        public override string ToString()
        {
            return "You may put a nature card from your graveyard into your mana zone.";
        }
    }
}
