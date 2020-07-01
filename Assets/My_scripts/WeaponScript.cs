using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private int CurrentWeapon;
    [SerializeField] GameObject Knife;
    [SerializeField] GameObject Baseball;
    [SerializeField] GameObject Axe;
    [SerializeField] GameObject Gun;
    [SerializeField] float WaitTime=0f;

    private Animator anim;
    private bool WeaponVisible = false;
    private bool Attack = true;

    // Start is called before the first frame update
    void Start()
    {
        SaveScript.WeaponChange = true;
        CurrentWeapon = SaveScript.WeaponID;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.WeaponChange == true)
        {
            Assignweapon();
        }
        if (CurrentWeapon > 0 && CurrentWeapon < 4)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (WeaponVisible == false)
                {
                    WeaponVisible = true;
                    anim.SetBool("ready", true);

                }
                else if (WeaponVisible == true)
                {
                    WeaponVisible = false;
                    anim.SetBool("ready", false);

                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Attack == true)
                {
                    if (CurrentWeapon == 1)
                    {
                        anim.SetInteger("weaponstrike", 1);
                        Attack = false;
                        StartCoroutine(WeaponWait());
                    }
                    if (CurrentWeapon == 2)
                    {
                        anim.SetInteger("weaponstrike", 2);
                        Attack = false;
                        StartCoroutine(WeaponWait());
                    }
                    if (CurrentWeapon == 3)
                    {
                        anim.SetInteger("weaponstrike", 3);
                        Attack = false;
                        StartCoroutine(WeaponWait());
                    }

                }

            }
        }
        if (CurrentWeapon == 4)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (WeaponVisible == false)
                {
                    WeaponVisible = true;
                    anim.SetBool("gunaim", true);

                }
                else if (WeaponVisible == true)
                {
                    WeaponVisible = false;
                    anim.SetBool("gunaim", false);

                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Attack == true)
                {
                    if (CurrentWeapon == 4)
                    {
                        anim.SetInteger("weaponstrike", 4);
                        Attack = false;
                        StartCoroutine(WeaponWait());
                    }
                   

                }

            }

        }

        //temp

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SaveScript.WeaponID = 0;
            Assignweapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SaveScript.WeaponID = 1;
            Assignweapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SaveScript.WeaponID = 2;
            Assignweapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SaveScript.WeaponID = 3;
            Assignweapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SaveScript.WeaponID = 4;
            Assignweapon();
        }

    }
    void Assignweapon()
    {
        CurrentWeapon = SaveScript.WeaponID;
        SaveScript.WeaponChange = false;
        if (CurrentWeapon == 0)
        {
            Knife.gameObject.SetActive(false);
            Baseball.gameObject.SetActive(false);
            Axe.gameObject.SetActive(false);
            Gun.gameObject.SetActive(false);
        }
        if (CurrentWeapon == 1)
        {
            Knife.gameObject.SetActive(true);
            Baseball.gameObject.SetActive(false);
            Axe.gameObject.SetActive(false);
            Gun.gameObject.SetActive(false);
            WaitTime = 1f;
        }
        if (CurrentWeapon == 2)
        {
            Knife.gameObject.SetActive(false);
            Baseball.gameObject.SetActive(true);
            Axe.gameObject.SetActive(false);
            Gun.gameObject.SetActive(false);
            WaitTime = 1.2f;
        }
        if (CurrentWeapon == 3)
        {
            Knife.gameObject.SetActive(false);
            Baseball.gameObject.SetActive(false);
            Axe.gameObject.SetActive(true);
            Gun.gameObject.SetActive(false);
            WaitTime = 1.6f;
        }
        if (CurrentWeapon == 4)
        {
            Knife.gameObject.SetActive(false);
            Baseball.gameObject.SetActive(false);
            Axe.gameObject.SetActive(false);
            Gun.gameObject.SetActive(true);
            WaitTime = 0.5f;
        }
    }
    IEnumerator WeaponWait()
    {
        yield return new WaitForSeconds(WaitTime);
        Attack =true;
        anim.SetInteger("weaponstrike", 0);


    }
}
