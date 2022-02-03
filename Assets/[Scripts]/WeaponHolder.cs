using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [Header("WeaponToSpawn"), SerializeField]
    private GameObject weaponToSpawn;

    private PlayerController playerController;

    private Sprite crosshairImage;

    [SerializeField] private GameObject weaponSocket;
    // Start is called before the first frame update
    void Start()
    {
        GameObject spawnedWeapon = Instantiate(weaponToSpawn, weaponSocket.transform.position, weaponSocket.transform.rotation, weaponSocket.transform);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
