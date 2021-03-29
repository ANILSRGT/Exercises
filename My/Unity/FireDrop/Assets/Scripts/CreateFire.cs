using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFire : MonoBehaviour
{
    [SerializeField] private GameObject counterCanvas;
    [SerializeField] private GameObject counterPrefab;
    private GameObject[] floors;

    private void Start()
    {
        floors = new GameObject[this.transform.childCount];
        for (int i = 0; i < this.transform.childCount; i++)
        {
            floors[i] = this.transform.GetChild(i).gameObject;
        }

        StartCoroutine(CounterInstantiate());
    }

    private IEnumerator CounterInstantiate()
    {
        yield return new WaitForSeconds(1.5f);
        while (true)
        {
            GameObject apartment;
            while (true)
            {
                int randFloor = Random.Range(0, floors.Length);
                int randApartment = Random.Range(0, floors[randFloor].transform.childCount);
                apartment = floors[randFloor].transform.GetChild(randApartment).gameObject;

                bool hasCounter = false;

                for (int i = 0; i < counterCanvas.transform.childCount; i++)
                {
                    if (counterCanvas.transform.GetChild(i).gameObject.name == apartment.name + "_Counter")
                    {
                        hasCounter = true;
                        break;
                    }
                }

                if (!hasCounter)
                {
                    break;
                }
            }

            GameObject newCounter = Instantiate(counterPrefab, apartment.transform.localPosition, Quaternion.identity, counterCanvas.transform);
            newCounter.name = apartment.name + "_Counter";
            newCounter.transform.SetParent(counterCanvas.transform);
            newCounter.transform.position = apartment.transform.position + new Vector3(0, 0.6f, 0);
            newCounter.transform.localScale = new Vector3(1, 1, 1);

            apartment.GetComponent<ApartmentCtrl>().HasFire = true;

            float randSeconds = Random.Range(3f, 4f);
            yield return new WaitForSeconds(randSeconds);
        }
    }
}
