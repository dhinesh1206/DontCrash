using HedgehogTeam.EasyTouch;
using UnityEngine;

public class PlayerSwitchController : MonoBehaviour
{

    public GameObject car1, car2;

    void OnEnable()
    {
        EasyTouch.On_TouchStart += PlayerSwitch;
    }

    private void OnDisable()
    {
        EasyTouch.On_TouchStart -= PlayerSwitch;
    }

    void PlayerSwitch(Gesture gesture)
    {
        BoxCollider[] colliders1 = car1.GetComponentsInChildren<BoxCollider>();
        foreach (var item in colliders1)
        {
            item.enabled = !item.enabled;
        }
        BoxCollider[] colliders2 = car2.GetComponentsInChildren<BoxCollider>();
        foreach (var item in colliders2)
        {
            item.enabled = !item.enabled;
        }
        car1.GetComponent<Renderer>().enabled = !car1.GetComponent<Renderer>().enabled;
        car2.GetComponent<Renderer>().enabled = !car2.GetComponent<Renderer>().enabled;
    }
}
