using UnityEngine;
using TMPro;

public class SpawnItemsRandomly : MonoBehaviour
{
    public GameObject prefab;
    public LayerMask ground;
    public int numObjects;
    public int numOfObjectsLeft;
    public TMP_Text count;

    void Start()
    {
        // loop through spawning the stupid boxes
        for (var i = 0; i < numObjects; i++)
        {
            count.text = numOfObjectsLeft.ToString() + "/" + numObjects.ToString();
            // declare min and max
            int min, max;
            // debug cause im stupid
            Debug.Log("Spawning item");
            // there probably is a better way to do this, but idrk
            if (Random.Range(0, 2) == 0)
            {
                min = 2;
                max = 6;
            } else { 
                min = 8;
                max = 10;
            }

            // create a game object which is instantiated
            GameObject spawnedItem = Instantiate(prefab, new Vector3(Random.Range(-14, 15), Random.Range(min, max), Random.Range(11, 52)), Quaternion.identity);
            // repeditaly move down until touching ground layer
            while (!Physics.CheckBox(spawnedItem.transform.position, new Vector3(0.1f, 0.1f, 0.1f), Quaternion.identity, ground))
            {
                Vector3 pos = spawnedItem.transform.position;
                pos.y -= 0.1f;
                spawnedItem.transform.position = pos;
            }
            spawnedItem.transform.localScale = new Vector3(Random.Range(0.5f, 2), Random.Range(0.5f, 2), Random.Range(0.5f, 2));
            spawnedItem.name = "Cube Clone " + i;


        }
    }
}
