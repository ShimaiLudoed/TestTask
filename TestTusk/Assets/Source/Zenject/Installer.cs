using TMPro;
using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    [SerializeField] private AudioData audioData;
    [SerializeField] private FloatData floatData;
    [SerializeField] private IntData intData;
    [SerializeField] private TextData textData;
    [SerializeField] private TransformData transformData;
    [SerializeField] private LayerData layerData;
    public override void InstallBindings()
    {
    }
}