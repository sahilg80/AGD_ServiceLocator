using ServiceLocator.Player;
using ServiceLocator.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        [SerializeField]
        private PlayerScriptableObject playerScriptableObject;
        public PlayerService playerService { get; private set; }

        private void Start()
        {
            playerService = new PlayerService(playerScriptableObject);
        }

        private void Update()
        {
            playerService.Update();
        }

    }
}
