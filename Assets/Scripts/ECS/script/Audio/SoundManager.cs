
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    [SerializeField] private AudioSource audioSource;
    public SoundDetailList detailList;
    public enum SoundType { Pickup }
    private static bool IsMute = false;

    public void SetSoundState(bool isMute)
    {
        IsMute = isMute;
    }

    public bool GetSoundState()
    {
        return IsMute;
    }

    public void PlaySound(SoundName soundName)
    {
        if (!IsMute)
        {
            var detail = detailList.GetSoundDetails(soundName);
            audioSource.PlayOneShot(detail.soundClip);
        }
    }
}
