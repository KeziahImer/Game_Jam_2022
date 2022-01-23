using UnityEngine;
using System.IO;

public class CreateBaseMap : MonoBehaviour
{
    public TextMapping baseBloc;

    private Vector2 currentPosition = new Vector2(0, 0);


    // Start is called before the first frame update
    void Start()
    {
        string mapPath = Application.dataPath + "/map.txt";

        SetBaseMap(mapPath);
    }

    //Create map txt file
    private bool GetFileStatus(string mapPath)
    {
        //Creates the map if it doesn't exist
        if (!File.Exists(mapPath)) {
            return (false);
        } else {
            return (true);
        }
    }

    // Update is called once per frame
    private void SetBaseMap(string mapPath)
    {
        File.WriteAllText(mapPath, "Map Created\n\n");
        for (int i = 0; i <= 150; i++) {
            for (int j = 0; j <= 150; j++) {
                Instantiate(baseBloc.prefab, currentPosition, Quaternion.identity, transform);
                File.AppendAllText(mapPath, "d");
                Debug.Log("J = " + j + "I = " + i);
                currentPosition = new Vector2(++currentPosition.x, currentPosition.y);
            }
            File.AppendAllText(mapPath, "\n");
            currentPosition = new Vector2(0, --currentPosition.y);
        }
    }
}
