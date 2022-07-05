using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 hasNotPackageColor = new Color32(0, 0, 0, 0);
    [SerializeField] float destroyTime;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyTime);
        }
        
        if(other.tag == "Customer" && hasPackage)
        {
            spriteRenderer.color = hasNotPackageColor;
            hasPackage = false;
        }
    }
}
