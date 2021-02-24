using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reading
{
    
}
public class DataExercise : MonoBehaviour
{
    private List<string> words;
    private Dictionary<float, Reading> sensorData; 
    // Start is called before the first frame update
    void Start()
    {
        sensorData = new Dictionary<float, Reading>();
    }

    IEnumerator SensorReading()
    {
        //while(sensorData < 100)
        {
            float time = Time.realtimeSinceStartup;
            //sensorData.Add(time, new Reading(Random.value, Random.value, Random.value));

            Reading r = sensorData[time];
            print("Reading: " + r);
            yield return new WaitForSeconds(5);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
