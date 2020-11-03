using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunInventory : MonoBehaviour
{

    [Tooltip("Current weapon gameObject.")]
    [HideInInspector]
    public GameObject currentGun;
    private Animator currentHAndsAnimator;
    [Tooltip("Put Strings of weapon objects from Resources Folder.")]

    public List<GameObject> gunsIHave = new List<GameObject>();

    /*
	 * Calling the method that will update the icons of our guns if we carry any upon start.
	 * Also will spawn a weapon upon start.
	 */
    void Awake()
    {
        StartCoroutine("SpawnWeaponUponStart");//to start with a gun

        if (gunsIHave.Count == 0)
            print("No guns in the inventory");
    }

    /*
	*Waits some time then calls for a waepon spawn
	*/
    IEnumerator SpawnWeaponUponStart()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("Spawn", 0);
    }

    /*
	 * This method is called from Create_Weapon() upon pressing arrow up/down or scrolling the mouse wheel,
	 * It will check if we carry a gun and destroy it, and its then going to load a gun prefab from our Resources Folder.
	 */
    IEnumerator Spawn(int _redniBroj)
    {
        if (weaponChanging)
            weaponChanging.Play();
        else
            print("Missing Weapon Changing music clip.");
        if (currentGun)
        {
            if (currentGun.name.Contains("Gun"))
            {

                currentHAndsAnimator.SetBool("changingWeapon", true);

                yield return new WaitForSeconds(0.8f);//0.8 time to change waepon, but since there is no change weapon animation there is no need to wait fo weapon taken down
                Destroy(currentGun);

                GameObject resource = gunsIHave[_redniBroj];
                currentGun = Instantiate(resource, transform.position, Quaternion.identity);

                AssignHandsAnimator(currentGun);
            }
            else if (currentGun.name.Contains("Sword"))
            {
                currentHAndsAnimator.SetBool("changingWeapon", true);
                yield return new WaitForSeconds(0.25f);//0.5f

                currentHAndsAnimator.SetBool("changingWeapon", false);

                yield return new WaitForSeconds(0.6f);//1
                Destroy(currentGun);

                GameObject resource = (GameObject)Resources.Load(gunsIHave[_redniBroj].ToString());
                currentGun = Instantiate(resource, transform.position, Quaternion.identity);
                AssignHandsAnimator(currentGun);
            }
        }
        else
        {
            GameObject resource = gunsIHave[_redniBroj];
            currentGun = Instantiate(resource, transform.position, Quaternion.identity);

            AssignHandsAnimator(currentGun);
        }


    }


    /*
	* Assigns Animator to the script so we can use it in other scripts of a current gun.
	*/
    void AssignHandsAnimator(GameObject _currentGun)
    {
        if (_currentGun.name.Contains("Gun"))
        {
            currentHAndsAnimator = currentGun.GetComponent<GunScript>().handsAnimator;
        }
    }

    /*
	 * Call this method when player dies.
	 */
    public void DeadMethod()
    {
        Destroy(currentGun);
        Destroy(this);
    }

    /*
	 * Sounds
	 */
    [Header("Sounds")]
    [Tooltip("Sound of weapon changing.")]
    public AudioSource weaponChanging;
}
