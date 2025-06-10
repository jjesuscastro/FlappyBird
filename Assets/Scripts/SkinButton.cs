using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour {
    [SerializeField]
    private Button button;
    [SerializeField]
    private Image image;

    [SerializeField]
    private TextMeshProUGUI skinName;

    public void SetSkin(Skin skin, UnityAction buttonAction) {
        this.image.sprite = skin.midSprite;
        this.skinName.text = skin.id;
        
        this.button.onClick.AddListener(buttonAction);
    }
}
