using Zenject;

namespace Becerra.Game.Output
{
    public interface IGameService
    {
        bool IsPlaying { get; }

        void Pause();

        void Resume();
    }
}