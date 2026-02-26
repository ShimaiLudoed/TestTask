using UnityEngine;
using VContainer;

public class PlayerController 
{
  private readonly PlayerView _playerView;

  [Inject]
  public PlayerController(PlayerView playerView)
  {
    _playerView = playerView;
  }

  public void Jump()
  {
    _playerView.Jump();
  }
}