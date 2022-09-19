
    public class SoundManager:Singleton<SoundManager>
    {
        private static bool IsMute = false;

        public static void SetSoundState(bool isMute)
        {
            IsMute = isMute;
        }

        public static bool GetSoundState()
        {
            return IsMute;
        }
        
    }
