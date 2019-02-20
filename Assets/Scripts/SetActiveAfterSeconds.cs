using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveAfterSeconds : MonoBehaviour
{
    // Start is called before the first frame update
    float timer;
    [SerializeField]
    double number;
    public GameObject setActive;
    void Start()
    {
        setActive.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // print(timer);
        // print(number);
        // print(timer >= number);
        if(timer >= number) {
           setActive.SetActive(true);
        //    print("something");
        }
    }
}
