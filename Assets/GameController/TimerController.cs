using System;
using Player;
using UI;
using UI.GameUIWindow;
using UnityEngine;
using Zenject;

namespace GameController
{
    public class TimerController : ITickable
    {
        public Action OnTimeLeft;
        private readonly GameUIWindowController _gameUIWindowController;
        private readonly TickableManager _manager;

        private float _addSeconds;
        private float _currentTime;

        private bool _activeTimer;
        TimerController(
            GameUIWindowController gameUIWindowController,
            TickableManager manager)
        {
            _gameUIWindowController = gameUIWindowController;
            _manager = manager;
            _manager.Add(this);
        }
        public void Tick()
        {
            if (_activeTimer)
            {
                _currentTime -= Time.deltaTime;
                _gameUIWindowController.UpdateTimerText(_currentTime);

                if (_currentTime <= 0)
                {
                    OnTimeLeft?.Invoke();
                    ActiveTimer(false);
                }
            }
        }

        public void SetTime(float time, float startTime)
        {
            _addSeconds = time;
            _currentTime = startTime;
        }

        public void ActiveTimer( bool value)
        {
            _activeTimer = value;
        }

        public void AddTime(PlayerView playerView, int seconds)
        {
            _currentTime += _addSeconds;
        }
    }
}