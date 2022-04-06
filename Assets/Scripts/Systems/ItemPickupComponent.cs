using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupComponent : MonoBehaviour
{
    [SerializeField] 
    private ItemScript pickupItem;

    [Tooltip("Manual override for drop amount, if left at -1 it will use the amount from the scriptable object")]
    [SerializeField]
    private int amount = -1;

    [SerializeField] 
    private MeshRenderer propMeshRenderer;

    [SerializeField] 
    private MeshFilter propMeshFilter;

    private ItemScript ItemInstance;
    // Start is called before the first frame update
    void Start()
    {
        InstantiateItem();
    }

    private void InstantiateItem()
    {
        ItemInstance = Instantiate(pickupItem);
        if (amount > 0)
        {
            ItemInstance.SetAmount(amount);
        }

        ApplyMesh();
    }

    private void ApplyMesh()
    {
        if (propMeshFilter)
        {
            propMeshFilter.mesh = pickupItem.itemPrefab.GetComponentInChildren<MeshFilter>().sharedMesh;
        }

        if (propMeshRenderer)
        {
            propMeshRenderer.materials = pickupItem.itemPrefab.GetComponentInChildren<MeshRenderer>().sharedMaterials;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Destroy(gameObject);
    }
}
