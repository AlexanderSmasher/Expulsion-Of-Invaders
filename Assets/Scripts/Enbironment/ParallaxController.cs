using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private Renderer BackgroundRenderer;
    [SerializeField] private float Speed;

    private void Update() => BackgroundMove(0, Speed * Time.deltaTime);
    private void BackgroundMove(float x, float y) => BackgroundRenderer.material.mainTextureOffset += new Vector2(x, y);
    public void HorizontalMove(Direction direction)
    {
        if (direction == Direction.Right)
            BackgroundMove(0.05f * Time.deltaTime, 0);
        else if (direction == Direction.Left)
            BackgroundMove(-0.05f * Time.deltaTime, 0);
        else if (direction == Direction.Zero)
            return;
    }
}