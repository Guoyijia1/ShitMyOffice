using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//音效管理
public class PlayerSoundMgr : MonoBehaviour
{
    public List<AudioClip> m_SoundClips;

    private AudioSource m_As;

    private void Start() {
        m_As = GetComponent<AudioSource>();
    }

    //播放跳跃音效
    public void PlayJumpSound()
    { 
        m_As.PlayOneShot( m_SoundClips[0]);
    }

    //播放下滑
    public void PlayeMoveDown()
    {
         m_As.PlayOneShot( m_SoundClips[1]);
    }

    //丢石头
    public void TrowRock() 
    {
        m_As.PlayOneShot( m_SoundClips[2]);
    }

    //被撞
    public void PlayHit()
    {
          m_As.PlayOneShot( m_SoundClips[3]);
    }

    //石头打击声音
    public void PlayeRockHit()
    {
         m_As.PlayOneShot( m_SoundClips[4]);
    }

    //角色死亡
    public void PlayDie()
    {
        m_As.PlayOneShot(m_SoundClips[5]);
    }
}
