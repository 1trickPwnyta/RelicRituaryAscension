using RimWorld;
using UnityEngine;

namespace RelicRituaryAscension
{
    public class EndGameTimer : MonoBehaviour
    {
        public static float timeLeft = -1f;

        public void Update()
        {
            Debug.Log("update");
            if (timeLeft > 0f)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft <= 0f)
                {
                    RelicAscensionCountdown.EndGame();
                }
            }
        }
    }
}
