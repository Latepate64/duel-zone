using Cards.TriggeredAbilities;
using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM09
{
    class MarchingMotherboard : Creature
    {
        public MarchingMotherboard() : base("Marching Motherboard", 6, 2000, Subtype.CyberVirus, Civilization.Water)
        {
            AddTriggeredAbility(new MarchingMotherboardAbility(new OneShotEffects.YouMayDrawCardsEffect(1)));
        }
    }

    class MarchingMotherboardAbility : WheneverCreatureIsPutIntoTheBattleZoneAbility
    {
        public MarchingMotherboardAbility(MarchingMotherboardAbility ability) : base(ability)
        {
        }

        public MarchingMotherboardAbility(IOneShotEffect effect) : base(effect, new MarchingMotherboardFilter())
        {
        }

        public override IAbility Copy()
        {
            return new MarchingMotherboardAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever you put another creature that has Cyber in its race into the battle zone, {GetEffectText()}";
        }
    }

    class MarchingMotherboardFilter : CardFilters.OwnersOtherBattleZoneCreatureFilter
    {
        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return base.Applies(card, game, player) && card.Subtypes.Intersect(new Subtype[] { Subtype.CyberCluster, Subtype.CyberLord, Subtype.CyberMoon, Subtype.CyberVirus }).Any();
        }

        public override CardFilter Copy()
        {
            return new MarchingMotherboardFilter();
        }

        public override string ToString()
        {
            return "another creature that has Cyber in its race";
        }
    }
}
