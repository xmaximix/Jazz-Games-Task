using Source.Scripts.Player;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Source.Scripts.DI_Container
{
    public class PlayerInstaller : BaseInstaller
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private PlayerEntity playerPrefab;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab(playerPrefab, Lifetime.Scoped);
            builder.RegisterBuildCallback(s =>
            {
                if (spawnPoint != null)
                {
                    var player = s.Resolve<PlayerEntity>();
                    player.transform.position = spawnPoint.position;
                    player.Initialize();
                }
            });
        }
    }
}