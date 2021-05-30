using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] private List<GameObject> rocketObjects;
    [SerializeField] private KeyCode keyActive;
    [SerializeField] private float delay;
    [SerializeField] private float countDownTime;
    private int index = 0;
    private List<GunController> rockets;
    private List<bool> ready;
    void Start()
    {
        rockets = new List<GunController>();
        ready = new List<bool>();
        foreach (GameObject rocketObject in rocketObjects)
        {
            rockets.Add(rocketObject.GetComponent<GunController>());
            ready.Add(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.None))
        {
            Debug.Log("ASdasdas");
        }
        if (Input.GetKeyDown(keyActive) && ready[index])
        {
            ready[index] = false;
            rockets[index].Skill();
            Debug.Log("Rocket : " + index.ToString() + " " + ready[index].ToString());
            StartCoroutine(CountDown(index));
            StartCoroutine(DelayChangeRocket());
        }
    }

    IEnumerator DelayChangeRocket()
    {
        yield return new WaitForSeconds(delay);
        index = 1 - index; // swap 0 - 1
    }
    IEnumerator CountDown(int index)
    {
        yield return new WaitForSeconds(countDownTime);
        ready[index] = true;
    }
}
