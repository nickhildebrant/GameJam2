using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.6f;
    public float slowdownLength = 5f;

    public void SlowMotion() {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
