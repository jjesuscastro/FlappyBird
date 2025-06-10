using UnityEngine;

[CreateAssetMenu(menuName = "Skin", fileName = "New Skin", order = 1)]
public class Skin : ScriptableObject {
    public string id;
    public Sprite upSprite;
    public Sprite midSprite;
    public Sprite downSprite;
}
