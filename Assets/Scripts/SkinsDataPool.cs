using System.Linq;
using UnityEngine;

public class SkinsDataPool : MonoBehaviour
{
    [SerializeField]
    private SkinsManager skinsManager;

    private void Awake() {
        this.skinsManager.LoadSkins(Resources.LoadAll<Skin>("Skins").ToList());
    }
}
