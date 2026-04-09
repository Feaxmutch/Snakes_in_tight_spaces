using Model;

namespace ViewModel
{
    public class LevelVM
    {
        public LevelVM(Level level, IUnityUpdate unityUpdate)
        {
            unityUpdate.Updated += level.OnUpdate;
        }
    }
}