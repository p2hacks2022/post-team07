using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider soundSlider;

    // Start is called before the first frame update
    void Start()
    {
        audioMixer.GetFloat("Sound_Volume", out float soundVolume);
        soundSlider.value = soundVolume;
    }
    public void SetSound(float volume)
    {
        /* �X���C�_�[�̈ʒu�ɂ����Sound_Volume��volume���ϓ�
          (�X���C�_�[��AudioSource��Volume���A��) */
        audioMixer.SetFloat("Sound_Volume", volume);
    }
}
