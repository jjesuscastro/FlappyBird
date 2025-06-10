using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour {
    [SerializeField]
    private Button button;
    [SerializeField]
    private Image image;

    public void SetSkin(Skin skin, UnityAction buttonAction) {
        this.image.sprite = skin.midSprite;
        
        this.button.onClick.AddListener(buttonAction);
    }
}
