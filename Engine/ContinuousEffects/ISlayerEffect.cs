namespace Engine.ContinuousEffects
{
    public interface ISlayerEffect : IContinuousEffect
    {
        bool Applies(ICreature creature, ICard against, IGame game);
    }
}
