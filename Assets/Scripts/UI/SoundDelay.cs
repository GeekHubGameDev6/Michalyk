#region

using UnityEngine;

#endregion

public class SoundDelay : MonoBehaviour
{
    public AudioSource Ambient1;
    public AudioSource Ambient2;
    public AudioSource ShipHorn;

    private void Start()
    {
        ShipHorn.PlayDelayed(1f);
        Ambient1.PlayDelayed(1f);
        Ambient2.PlayDelayed(1f);
    }
}