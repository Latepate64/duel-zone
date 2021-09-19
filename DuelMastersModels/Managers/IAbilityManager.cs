using DuelMastersModels.Abilities;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using DuelMastersModels.Choices;
using System.Collections.Generic;
using DuelMastersModels.Zones;

namespace DuelMastersModels.Managers
{
    public interface IAbilityManager
    {
        bool IsAbilityBeingResolved { get; }
        bool IsAbilityBeingResolvedSpellAbility { get; }

        PlayerActionWithEndInformation ContinueResolution(Duel duel);
        ICollection<IContinuousEffect> GetContinuousEffectsGeneratedByCard(ICard card, IPlayer player, BattleZone battleZone);
        int GetSpellAbilityCount(ISpell spell);
        void RemovePendingAbility(NonStaticAbility ability);
        void SetAbilityBeingResolved(NonStaticAbility ability);
        void StartResolvingSpellAbility(ISpell spell);
        void TriggerWheneverAnotherCreatureIsPutIntoTheBattleZoneAbilities(IEnumerable<IBattleZoneCreature> creatures);
        void TriggerWheneverAPlayerCastsASpellAbilities(IEnumerable<IBattleZoneCreature> creatures);
        void TriggerWhenYouPutThisCreatureIntoTheBattleZoneAbilities(IBattleZoneCreature creature);
        SelectAbilityToResolve TryGetSelectAbilityToResolve(IPlayer player);
    }
}