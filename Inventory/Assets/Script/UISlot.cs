using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image iconImage;

    public Item currentItem;
    public GameObject equipIcon;
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
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(ownerChar == null)
        if (currentItem == null || ownerChar == null) 
        {
            return; 
        }
        ownerChar.ToggleEquip(currentItem, equipIcon);
        RefreshUI();
        UIStatus.instance.SetStatusUI();
    }
}
