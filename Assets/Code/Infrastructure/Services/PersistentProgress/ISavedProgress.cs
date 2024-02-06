

namespace Code.Infrastructure.Services.PersistentProgress
{
    public interface ISavedProgress
    {
        void UpdateProgress(PlayerProgress progress);

    }

    public interface ISavedProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }
}
