using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CarInventory : MonoBehaviour
{
    public List<GameObject> carInventory;

    public Transform parentItemInventory;
    public GameObject textItemInventory;

    private void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("Item"))
        {
            carInventory.Add(other.gameObject);
    
            
            GameObject textItem = Instantiate(textItemInventory, parentItemInventory);
            textItem.GetComponent<TMP_Text>().text = other.gameObject.name;

            other.gameObject.SetActive(false);
        }
    }
}
