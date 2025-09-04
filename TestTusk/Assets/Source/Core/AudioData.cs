using UnityEngine;

public class AudioData : MonoBehaviour
{
    [field: SerializeField] public AudioSource AudioSource {get; private set;}
    [field: SerializeField] public AudioClip TakeCoin {get; private set;}
    [field: SerializeField] public AudioClip StartGame {get; private set;}
    [field: SerializeField] public AudioClip EndGame {get; private set;}
    [field: SerializeField] public AudioClip MainTheme {get; private set;}
}
