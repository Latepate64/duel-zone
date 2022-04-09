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

        public MarchingMotherboardAbility(IOneShotEffect effect) : base(effect)
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

        protected override bool TriggersFrom(Engine.ICard card, IGame game)
        {
            return card.Owner == Controller && card.Id != Source && card.Subtypes.Intersect(new Subtype[] { Subtype.CyberCluster, Subtype.CyberLord, Subtype.CyberMoon, Subtype.CyberVirus }).Any();
        }
    }
}
