using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    [SerializeField]
    private AudioClip flap;

    [SerializeField]
    private AudioClip point;
    
    [SerializeField]
    private AudioClip hit;

    public void PlayFlap() {
        AudioSource.PlayClipAtPoint(this.flap, this.transform.position);
    }

    public void PlayPoint() {
        AudioSource.PlayClipAtPoint(this.point, this.transform.position);
    }


    public void PlayHit() {
        AudioSource.PlayClipAtPoint(this.hit, this.transform.position);
    }
}
