using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image iconImage;

    public GameObject equipIcon;
    public Item currentItem;
    public bool isEquipped=false;
    private Charactor ownerChar;
    public void Initialize(Item item, Charactor character)
    {
        currentItem = item;
        ownerChar = character;
        RefreshUI();
    }

    public void RefreshUI()
    {
        if (currentItem == null)
        {
            iconImage.sprite = null;
            iconImage.enabled = false;
            return;
        }

        iconImage.sprite = currentItem.icon;
        iconImage.enabled = true;

        equipIcon.SetActive(isEquipped);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentItem == null || ownerChar == null) 
        {
            return; 
        }
        ownerChar.ToggleEquip(this);
        RefreshUI();
        UIStatus.instance.SetStatusUI();
    }
}
