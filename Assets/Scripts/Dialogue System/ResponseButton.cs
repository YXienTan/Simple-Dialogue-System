using UnityEngine;
using UnityEngine.UI;

public class ResponseButton : MonoBehaviour
{
    public int id;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => DialogueManager.Instance.Response(id));
    }
}
