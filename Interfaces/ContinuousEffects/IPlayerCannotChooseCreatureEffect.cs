namespace Interfaces.ContinuousEffects
{
    public interface IPlayerCannotChooseCreatureEffect : IContinuousEffect
    {
        bool PlayerCannotChooseCreature(ICreature creature, System.Guid player, IGame game);
    }
}
