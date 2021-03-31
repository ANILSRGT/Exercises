using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFire : MonoBehaviour
{
    [SerializeField] private GameObject counterCanvas;
    [SerializeField] private GameObject counterPrefab;
    private GameObject[] floors;
    private GameObject[] apartments;
    [HideInInspector()] public static bool[] hasFire; // [Index of apartment] = hasFire (true or false)

    private void Start()
    {
        int apartmentCount = 0;
        floors = new GameObject[this.transform.childCount];
        for (int i = 0; i < this.transform.childCount; i++)
        {
            floors[i] = this.transform.GetChild(i).gameObject;
            apartmentCount += floors[i].transform.childCount;
        }

        apartments = new GameObject[apartmentCount];
        int apartmentIndex = 0;
        for (int i = 0; i < floors.Length; i++)
        {
            for (int j = 0; j < apartmentCount / floors.Length; j++)
            {
                apartments[apartmentIndex] = floors[i].transform.GetChild(j).gameObject;
                apartmentIndex++;
            }
        }

        hasFire = new bool[apartmentCount];
        for (int i = 0; i < apartmentCount; i++)
        {
            hasFire[i] = false;
        }

        StartCoroutine(CounterInstantiate());
    }

    private IEnumerator CounterInstantiate()
    {
        yield return new WaitForSeconds(1.5f);

        while (true)
        {
            int randApartment = Random.Range(0, apartments.Length);

            if (hasFire[randApartment])
            {
                continue;
            }

            GameObject newCounter = Instantiate(counterPrefab, apartments[randApartment].transform.localPosition, Quaternion.identity, counterCanvas.transform);
            newCounter.name = randApartment + "_Counter";
            newCounter.transform.SetParent(counterCanvas.transform);
            newCounter.transform.position = apartments[randApartment].transform.position + new Vector3(0, 0.6f, 0);
            newCounter.transform.localScale = new Vector3(1, 1, 1);

            hasFire[randApartment] = true;
            StartCoroutine(apartments[randApartment].GetComponent<ApartmentCtrl>().CounterAndChangeSprite(Random.Range(8, 14), randApartment));

            float randSeconds = Random.Range(4f, 6f);
            yield return new WaitForSeconds(randSeconds);
        }
    }
}
