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
                PlayerPrefs.SetString("Skin", skin.name);
                this.birdAnimator.SetFrames(skin);
            });
        }
        
        string selectedSkin = PlayerPrefs.GetString("Skin");
        this.birdAnimator.SetFrames(string.IsNullOrEmpty(selectedSkin) ? this.skins[0] : this.skins.Find(s => s.name == selectedSkin));
    }
}
