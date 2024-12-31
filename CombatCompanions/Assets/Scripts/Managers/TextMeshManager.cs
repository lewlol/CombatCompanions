using UnityEngine;

public class TextMeshManager : MonoBehaviour
{
    public GameObject textMeshOBJ;

    private void Awake()
    {
        GameEvents.gameEvent.onSpawnTextMesh += SpawnTextMeshOBJ;
    }
    public void SpawnTextMeshOBJ(string text, Vector2 position, int size, Color color, float time)
    {
        Vector2 offset = new Vector2(Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f));
        GameObject newTextMesh = Instantiate(textMeshOBJ, position + offset, Quaternion.identity);
        TextMesh tm = newTextMesh.GetComponent<TextMesh>();

        tm.text = text;
        tm.fontSize = size;
        tm.color = color;

        Destroy(newTextMesh, time);
    }
}
