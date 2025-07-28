//using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; // برای دسترسی به Image

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public AudioClip mainMenuMusic;
    public AudioClip gameOverMusic;

    public Image buttonImage;  // مرجع به تصویر دکمه
    public Sprite musicOnSprite;  // تصویر دکمه برای حالت فعال
    public Sprite musicOffSprite; // تصویر دکمه برای حالت غیرفعال

    private AudioSource audioSource;
    private bool isPlaying = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject); // حذف نمونه‌های اضافی
        }
    }

    public void PlayMainMenuMusic()
    {
        PlayMusic(mainMenuMusic, true);
    }

    public void PlayGameOverMusic()
    {
        PlayMusic(gameOverMusic, false);
    }

    private void PlayMusic(AudioClip clip, bool loop)
    {
        if (audioSource == null) return; // اگه Destroy شده بود
        if (audioSource.clip == clip) return;

        // توقف موزیک قبلی
        audioSource.Stop();

        // پخش موزیک جدید
        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.Play();
    }

    public void StopMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    public void MusicToggleButton()
    {
        if (audioSource != null && isPlaying)
        {
            // ذخیره حجم قبلی و تنظیم به صفر
            audioSource.mute = true; // صدا را صفر می‌کنیم
            buttonImage.sprite = musicOffSprite; // تغییر تصویر دکمه به حالت غیرفعال
            isPlaying = false;
        }
        else if (audioSource != null && !isPlaying)
        {
            // بازگرداندن حجم صدا به حالت اولیه
            audioSource.mute = false;
            buttonImage.sprite = musicOnSprite; // تغییر تصویر دکمه به حالت فعال
            isPlaying = true;
        }
    }
}
