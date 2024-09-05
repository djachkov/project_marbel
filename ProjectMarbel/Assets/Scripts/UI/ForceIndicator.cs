using UnityEngine;
using UnityEngine.UI;

public class ForceIndicator : MonoBehaviour
{
    public Image indicatorImage;  // Reference to the UI Image used for visualizing force
    public float maxChargeTime = 2f;  // Maximum charge time in seconds

    public float chargeTime = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0)) // Left mouse button is held down
        {
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Clamp(chargeTime, 0, maxChargeTime);
        }
        // Update the visual indicator
        if (indicatorImage != null)
        {
            float fillAmount = chargeTime / maxChargeTime;
            indicatorImage.fillAmount = fillAmount;
        }
    }
    public void Reset()
    {
        chargeTime = 0f;
    }

}