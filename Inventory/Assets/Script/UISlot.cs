using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image iconImage;

    private Item currentItem;
    [SerializeField]private GameObject equipIcon;
    private Charactor ownerChar;

    public void SetItem(Item item)
    {
        currentItem = item;
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
        if (currentItem.isEquipped)
        {
            equipIcon.SetActive(true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(ownerChar == null)
            Debug.Log("캬라");
        if (currentItem == null || ownerChar == null) 
        {
            Debug.Log("장착안됨");
            return; 
        }
        ownerChar.ToggleEquip(currentItem);
        RefreshUI();
        Debug.Log("장착됨");
    }
}
