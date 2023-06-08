using UnityEngine;

public class LetterTile : MonoBehaviour
{
    [SerializeField] private Color m_Color;
    [SerializeField] private Animator tileAnimator;
    [SerializeField] private MeshRenderer m_Renderer;
    
    private void OnMouseDown()
    {
        tileAnimator.SetTrigger("reveal");
    }

    public void SetColor(Color color)
    {
        m_Renderer.materials[0].color = color;
    }
    public void SetMaterial(Material mat)
    {
        m_Renderer.material = mat;
    }
}
