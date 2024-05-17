using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; //���� �޸𸮿� ��� ���� instance ���� ����

    [Header("#BGM")]  //��� ����
    public AudioClip bgmClip; //������� ���õ� Ŭ��
    public float bgmVolume;  //������� ���õ� ����     
    AudioSource bgmPlayer;  //������� ���õ� ����� �ҽ�

    [Header("#SFX")] //ȿ����
    public AudioClip[] sfxClips; //ȿ������ ���õ� Ŭ��
    public float sfxVolume;  //ȿ������ ���õ� Ŭ��
    public int channels;  //�پ��� ȿ������ �� �� �ִ� ä�� ���� ����
    AudioSource[] sfxPlayers;  //ȿ������ ���õ� Ŭ��
    int channelIndex;

    public enum Sfx { EnemyHit, PlayerAtk, PlayerHit }


    private void Awake()
    {
        instance = this; //instance �ʱ�ȭ
        Init(); //�ʱ�ȭ �Լ�???
    }

    void Init()
    {
        //����� �÷��̾� �ʱ�ȭ
        GameObject bgmobject = new GameObject("BgmPlayer");
        bgmobject.transform.parent = transform; //������� ����ϴ� �ڽ� ������Ʈ
        bgmPlayer = bgmobject.AddComponent<AudioSource>();  //AddComponent�Լ��� ����� �ҽ� ���� �� ������ ����
        bgmPlayer.playOnAwake = false;  //ĳ���� ������ ������� Ȱ��ȭ
        bgmPlayer.loop = true;  //������� ����
        bgmPlayer.volume = bgmVolume; //����
        bgmPlayer.clip = bgmClip;


        //ȿ���� �÷��̾� �ʱ�ȭ
        GameObject sfxobject = new GameObject("sfxPlayer");
        sfxobject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels]; //ä�� ���� ���� ����� �ҽ� �迭 �ʱ�ȭ, ���� ���빰 �ʱ�ȭ X

        for (int index = 0; index < sfxPlayers.Length; index++) //��� ȿ���� ����� �ҽ� �����ϸ鼭 ����
        {
            sfxPlayers[index] = sfxobject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false ;
            sfxPlayers[index].volume = sfxVolume;
        }

    }

    public void PlayBgm(bool isplay) //����� ��� �Լ�
    {
        if(isplay)
        {
            bgmPlayer.Play();
        }
        else
        {
            bgmPlayer.Stop();
        }
    }



    public void PlaySfx(Sfx sfx) //ȿ���� ��� �Լ�
    {
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            int loopIndex = (index + channelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying)
                continue;

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx];
            sfxPlayers[loopIndex].Play();
            break;

        }

    }

}
