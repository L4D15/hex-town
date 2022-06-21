using Unity.VisualScripting;

namespace Becerra.Game.VisualScripting
{
    /// <summary>
    /// Bolt unit expecting injection.
    /// Custom units who want to be injected should implement this.
    /// It does nothing special, it's just used to identify what units
    /// to inject to avoid injecting units who don't really need injection.
    /// </summary>
    public interface IInjectableUnit : IUnit
    {
    }
}