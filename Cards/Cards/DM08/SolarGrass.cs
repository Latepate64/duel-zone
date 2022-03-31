﻿using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM08
{
    class SolarGrass : TurboRushCreature
    {
        public SolarGrass() : base("Solar Grass", 5, 3000, Subtype.StarlightTree, Civilization.Light)
        {
            AddTurboRushAbility(new TriggeredAbilities.WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new SolarGrassEffect()));
        }
    }

    class SolarGrassEffect : OneShotEffects.UntapAreaOfEffect
    {
        public SolarGrassEffect() : base(new SolarGrassFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new SolarGrassEffect();
        }

        public override string ToString()
        {
            return "Untap all your creatures in the battle zone except Solar Grasses.";
        }
    }

    class SolarGrassFilter : CardFilters.OwnersBattleZoneCreatureFilter
    {
        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return base.Applies(card, game, player) && card.Name != "Solar Grass";
        }

        public override CardFilter Copy()
        {
            return new SolarGrassFilter();
        }

        public override string ToString()
        {
            return "all your creatures in the battle zone except Solar Grasses";
        }
    }
}