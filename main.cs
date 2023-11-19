using GameNetcodeStuff;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(DaySpeedModifier.Modifier), "Day Speed Modifier", "1.0.0", "tairasoul")]
[assembly: MelonGame("ZeekerssRBLX", "Lethal Company")]

namespace DaySpeedModifier
{
    public class Modifier: MelonMod
    {
        private TimeOfDay timeOfDay;
        private PlayerControllerB localPlayer;
        public override void OnUpdate()
        {
            if (GameObject.FindFirstObjectByType<TimeOfDay>())
            {
                timeOfDay = GameObject.FindFirstObjectByType<TimeOfDay>();
            }

            if (localPlayer == null || localPlayer.gameObject == null)
            {
                if (GameObject.FindFirstObjectByType<GameNetworkManager>() != null && GameObject.FindFirstObjectByType<GameNetworkManager>().localPlayerController != null)
                {
                    localPlayer = GameObject.FindFirstObjectByType<GameNetworkManager>().localPlayerController;
                }
            }
            base.OnUpdate();
        }

        public override void OnLateUpdate()
        {
            if (localPlayer != null && timeOfDay != null && timeOfDay.gameObject != null)
            {
                if (localPlayer.IsHost)
                {
                    timeOfDay.globalTimeSpeedMultiplier = 0.5f;
                }
            }
            base.OnLateUpdate();
        }
    }
}
