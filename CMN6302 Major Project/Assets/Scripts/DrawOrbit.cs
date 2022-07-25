using UnityEngine;

public class DrawOrbit : MonoBehaviour
{
    private LineRenderer circleRenderer;
    private Material material;
    private Vector3 planet, systemCenter = Vector3.zero;
    private float distance, width = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        Initialisation();
        TraceOrbit(120, distance);
    }

    // Adds a line renderer to the planet (For creating orbital paths), obtains the location of the planet, and calculates the distance between it and the center point.
    void Initialisation()
    {
        circleRenderer = this.gameObject.AddComponent<LineRenderer>();
        circleRenderer.startWidth = width;
        circleRenderer.endWidth = width;
        planet = this.gameObject.transform.position;
        distance = Vector3.Distance(planet, systemCenter);
    }

    // Function to draw orbital lines, by creating multiple "steps" in the line as a point of rotation (eventually meeting up to create a full circle)
    void TraceOrbit(int steps, float radius)
    {
        circleRenderer.positionCount = steps + 1;

        for (int currentStep = 0; currentStep <= steps; currentStep++)
        {
            float progress = ((float)currentStep / steps);
            float radian = progress * 2 * Mathf.PI;
            float xScaled = Mathf.Cos(radian);
            float zScaled = Mathf.Sin(radian);
            float x = xScaled * radius;
            float z = zScaled * radius;

            Vector3 position = new Vector3(x, 0, z);
            circleRenderer.SetPosition(currentStep, position);
        }
        circleRenderer.material = material;
    }
}
