using System;
using UnityEngine;
using Zenject;

public class InputListener : MonoBehaviour
{
  private PlayerController _playerController;

  [Inject]
  public void Construct(PlayerController playerController)
  {
    _playerController = playerController;
  }

  private void Update()
  {
    if(Input.GetKeyDown(KeyCode.Space))
    {
      _playerController.Jump();
    }
  }
}
