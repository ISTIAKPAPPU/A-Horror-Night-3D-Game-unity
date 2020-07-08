using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject InventoryMenu;
    [SerializeField] GameObject KnifeImage;
    [SerializeField] GameObject KnifeButton;
    [SerializeField] GameObject BatImage;
    [SerializeField] GameObject BatButton;
    [SerializeField] GameObject AxeImage;
    [SerializeField] GameObject AxeButton;
    [SerializeField] GameObject GunImage;
    [SerializeField] GameObject GunButton;
    [SerializeField] GameObject KnifeBlank;
    [SerializeField] GameObject BatBlank;
    [SerializeField] GameObject AxeBlank;
    [SerializeField] GameObject GunBlank;



    private bool InventoryMenuCheck = false;
    private bool ExitInventory = true;
    void Start()
    {
        InventoryMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {

            if(InventoryMenuCheck==false)
            {
              ExitInventory = false;
              StartCoroutine(InventoryStart());
              
            }
            else if (InventoryMenuCheck == true)
            {
                if (ExitInventory == true)
                {
                    Time.timeScale = 1f;
                    Cursor.visible = false;
                    InventoryMenu.gameObject.SetActive(false);
                    InventoryMenuCheck = false;
                }
            }
              
        }
        

    }
    public void ChooseKnife()
    {
        SaveScript.WeaponID = 1;
        SaveScript.WeaponChange = true;
    }
    public void ChooseBat()
    {
        SaveScript.WeaponID = 2;
        SaveScript.WeaponChange = true;
    }
    public void ChooseAxe()
    {
        SaveScript.WeaponID = 3;
        SaveScript.WeaponChange = true;
    }
    public void ChooseGun()
    {
        SaveScript.WeaponID = 4;
        SaveScript.WeaponChange = true;
    }
    IEnumerator InventoryStart()
    {
        InventoryMenu.gameObject.SetActive(true);
        Cursor.visible = true;
        InventoryMenuCheck = true;
        InventoryCheck();
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
        ExitInventory = true;

    }
     void InventoryCheck()
    {
        if (SaveScript.HaveKnife == true)
        {
            KnifeImage.gameObject.SetActive(true);
            KnifeButton.gameObject.SetActive(true);
            KnifeBlank.gameObject.SetActive(false);
        }
        if (SaveScript.HaveKnife == false)
        {
            KnifeImage.gameObject.SetActive(false);
            KnifeButton.gameObject.SetActive(false);
            KnifeBlank.gameObject.SetActive(true);
        }
        if (SaveScript.HaveBat == true)
        {
            BatImage.gameObject.SetActive(true);
            BatButton.gameObject.SetActive(true);
            BatBlank.gameObject.SetActive(false);
        }
        if (SaveScript.HaveBat == false)
        {
            BatImage.gameObject.SetActive(false);
            BatButton.gameObject.SetActive(false);
            BatBlank.gameObject.SetActive(true);
        }
        if (SaveScript.HaveAxe == true)
        {
            AxeImage.gameObject.SetActive(true);
            AxeButton.gameObject.SetActive(true);
            AxeBlank.gameObject.SetActive(false);
        }
        if (SaveScript.HaveAxe == false)
        {
            AxeImage.gameObject.SetActive(false);
            AxeButton.gameObject.SetActive(false);
            AxeBlank.gameObject.SetActive(true);
        }
        if (SaveScript.HaveGun == true)
        {
            GunImage.gameObject.SetActive(true);
            GunButton.gameObject.SetActive(true);
            GunBlank.gameObject.SetActive(false);
        }
        if (SaveScript.HaveGun == false)
        {
            GunImage.gameObject.SetActive(false);
            GunButton.gameObject.SetActive(false);
            GunBlank.gameObject.SetActive(true);
        }
    }
}
