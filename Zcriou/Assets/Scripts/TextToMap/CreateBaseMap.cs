using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class CreateBaseMap : MonoBehaviour
{
    public TextMapping[] mappingData;
    public string map;
    public int frequency;
    public int height;
    public int width;

    private Vector2 currentPosition = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        string mapPath = Application.dataPath + "/map.txt";

        GenBaseTxt(mapPath);
    }

    // Update is called once per frame
    private void GenBaseTxt(string mapPath)
    {
        int index = 0;
        int size = height * width;
        char[] mapAsChars = new char[size + height];

        for (int i = 0; i < height; i++) {
            for (int j = 0; j < width; j++) {
                mapAsChars[index] = 'd';
                index++;
                Debug.Log("J = " + j + " I = " + i + " index = " + index);
            }
            mapAsChars[index] = '\n';
            index++;
        }
        map = new string(mapAsChars);
        SetRessourcesTxt(mapPath);
    }

    private void SetRessourcesTxt(string mapPath)
    {
        int rand = 0;
        char[] mapAsChars = map.ToCharArray();

        for (int i = 0; i < map.Length; i++) {
            rand = Random.Range(0, frequency);
            if (rand <= 10 && mapAsChars[i] != '\n') {
                mapAsChars[i] = 't';
            } else if (rand <= 15 && mapAsChars[i] != '\n') {
                mapAsChars[i] = 'r';
            } else if (rand <= 17 && mapAsChars[i] != '\n') {
                mapAsChars[i] = 'c';
            } else if (rand <= 19 && mapAsChars[i] != '\n') {
                mapAsChars[i] = 'i';
            } else if (rand <= 21 && mapAsChars[i] != '\n') {
                mapAsChars[i] = 'f';
            } else if (rand <= 23 && mapAsChars[i] != '\n') {
                mapAsChars[i] = 'e';
            } else if (rand <= 25 && mapAsChars[i] != '\n') {
                mapAsChars[i] = 'w';
            }
        }
        map = new string(mapAsChars);

        Debug.Log(map.Length);
        File.WriteAllText(mapPath, map);
        GenerateMap();
    }

    // Update is called once per frame
    private void GenerateMap()
    {
        string[] rows = Regex.Split(map, "\r\n|\r|\n");

        foreach(string row in rows) {
            foreach(char c in row) {
                foreach(TextMapping tm in mappingData) {
                    if (c == tm.character) {
                        Instantiate(tm.prefab, currentPosition, Quaternion.identity, transform);
                    }
                }
                currentPosition = new Vector2(++currentPosition.x, currentPosition.y);
            }
            currentPosition = new Vector2(0, --currentPosition.y);
        }
    }
}
