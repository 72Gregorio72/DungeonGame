using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;

public class ItemButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int buttonID;
    public Item thisItem;

    public ToolTip toolTip;

    private Item GetThisItem(){
        for(int i = 0; i < GameManager.instance.items.Count; i++){
            if(buttonID == i){
                thisItem = GameManager.instance.items[i];
            }
        }

        return thisItem;
    }

    public void CloseButton(){
        GameManager.instance.RemoveItem(GetThisItem());

        thisItem = GetThisItem();
        if(thisItem != null){
            toolTip.ShowToolTip();
            toolTip.UpdateToolTip(GetDetailText(thisItem));
        } else {
            toolTip.HideToolTip();
            toolTip.UpdateToolTip("");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetThisItem();

        if(thisItem != null){
            //Debug.Log(thisItem.itemName);
            toolTip.ShowToolTip();
            toolTip.UpdateToolTip(GetDetailText(thisItem));
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //GetThisItem();

        //if(thisItem != null){
            //Debug.Log(thisItem.itemName);
            toolTip.HideToolTip();
            toolTip.UpdateToolTip("");
        //}
    }

    private string GetDetailText(Item item){
        if(item == null){
            return "";
        } else {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Item: {0} \n\n", item.itemName);
            sb.AppendFormat("Value: {0}$ \n\n" +
                            "Description: {1} \n\n", item.itemPrice, item.itemDescr);
            return sb.ToString();
        }

    }
}
