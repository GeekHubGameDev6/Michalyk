#region

using UnityEngine;

#endregion

public class BackgroundMove : MonoBehaviour
{
    public GameObject background;
    public GameObject player;
    public float speedMultiplier = 0.3f;

    private void Update()
    {
        var y = -player.GetComponent<Transform>().localPosition.y + 0.1f;
        var x = background.GetComponent<Transform>().localPosition.x;
        background.transform.localPosition = new Vector3(x, y, 1);
        background.GetComponent<Transform>().Translate(Vector3.left * Time.deltaTime * speedMultiplier);
    }
}