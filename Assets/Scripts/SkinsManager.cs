using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkinsManager : MonoBehaviour {
    [SerializeField]
    private BirdAnimator birdAnimator;
    
    [SerializeField]
    private GameObject skinPrefab;
    
    [SerializeField]
    private Transform skinsParent;
    
    private List<Skin> skins;
    
    public void LoadSkins(List<Skin> skins) {
        this.skins = skins;
        
        foreach (Skin skin in this.skins) {
            GameObject newSkin = Instantiate(this.skinPrefab, this.skinsParent);
            SkinButton skinButton = newSkin.GetComponent<SkinButton>();
            
            skinButton.SetSkin(skin, delegate {
                PlayerPrefs.SetString("Skin", skin.name);
                this.birdAnimator.SetFrames(skin);
            });
        }
        
        string selectedSkin = PlayerPrefs.GetString("Skin");
        this.birdAnimator.SetFrames(this.skins.DefaultIfEmpty(this.skins[0]).First(s => s.name == selectedSkin));
    }
}
