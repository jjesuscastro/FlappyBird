using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsManager : MonoBehaviour {

    [SerializeField]
    private BirdAnimator birdAnimator;
    
    [SerializeField]
    private GameObject skinPrefab;
    
    [SerializeField]
    private Transform skinsParent;
    
    [SerializeField]
    private List<Skin> skins;

    private void Start() {
        foreach (Skin skin in this.skins) {
            GameObject newSkin = Instantiate(this.skinPrefab, this.skinsParent);
            SkinButton skinButton = newSkin.GetComponent<SkinButton>();
            
            skinButton.SetSkin(skin, delegate {
                this.birdAnimator.SetFrames(skin);
            });
        }
        
        this.birdAnimator.SetFrames(this.skins[0]);
    }
}
