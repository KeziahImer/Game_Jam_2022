using UnityEngine;
using System.Text.RegularExpressions;

public class TxtToMap : MonoBehaviour
{
    public TextMapping[] mappingData;
    public TextAsset mapText;

    private Vector2 currentPosition = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    // Update is called once per frame
    private void GenerateMap()
    {
        string[] rows = Regex.Split(mapText.text, "\r\n|\r|\n");

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
