using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; //정적 메모리에 담기 위한 instance 변수 선언

    [Header("#StartBGM")]  //시작 음악
    public AudioClip bgmClip; //배경음과 관련된 클립
    public float bgmVolume;  //배경음과 관련된 볼륨     
    AudioSource bgmPlayer;  //배경음과 관련된 오디오 소스

    [Header("#ProBGM")]  //게임 진행시 음악
    public AudioClip probgmClip; //배경음과 관련된 클립
    public float probgmVolume;  //배경음과 관련된 볼륨     
    AudioSource probgmPlayer;  //배경음과 관련된 오디오 소스

    [Header("#SFX")] //효과음
    public AudioClip[] sfxClips; //효과음과 관련된 클립
    public float sfxVolume;  //효과음과 관련된 클립
    public int channels;  //다양한 효과음을 낼 수 있는 채널 개수 변수
    AudioSource[] sfxPlayers;  //효과음과 관련된 클립
    int channelIndex;

    public enum Sfx { EnemyHit, PlayerAtk, PlayerHit, ItemCon, ItemEqu } //적군 타격, 플레이어 공격, 플레이어 타격, 소비 아이템 장착, 무기 아이템 장착


    private void Awake()
    {
        instance = this; //instance 초기화
        Init(); //초기화 함수???
    }

    void Init()
    {
        //배경음 플레이어 초기화
        GameObject bgmobject = new GameObject("BgmPlayer");
        bgmobject.transform.parent = transform; //배경음을 담당하는 자식 오브젝트
        bgmPlayer = bgmobject.AddComponent<AudioSource>();  //AddComponent함수로 오디오 소스 생성 후 변수에 저장
        bgmPlayer.playOnAwake = false;  //캐릭터 누를때 배경음악 활성화
        bgmPlayer.loop = true;  //배경음악 루프
        bgmPlayer.volume = bgmVolume; //볼륨
        bgmPlayer.clip = bgmClip;


        //효과음 플레이어 초기화
        GameObject sfxobject = new GameObject("sfxPlayer");
        sfxobject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels]; //채널 값을 통해 오디오 소스 배열 초기화, 실제 내용물 초기화 X

        for (int index = 0; index < sfxPlayers.Length; index++) //모든 효과음 오디오 소스 생성하면서 저장
        {
            sfxPlayers[index] = sfxobject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].volume = sfxVolume;
        }

    }

    public void PlayBgm(bool isplay) //배경음 재생 함수
    {
        if (isplay)
        {
            bgmPlayer.Play();
        }
        else
        {
            bgmPlayer.Stop();
        }
    }



    public void PlaySfx(Sfx sfx) //효과음 재생 함수
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
