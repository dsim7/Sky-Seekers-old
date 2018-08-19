using UnityEngine;

public class FloatingText : MonoBehaviour
{
    private TextMesh _textMesh;
    private Animator _animator;
    private Vector3 _random = new Vector3(0.7f, 0.8f, 0);

    void Awake()
    {
        _textMesh = GetComponent<TextMesh>();
        _animator = GetComponent<Animator>();
    }

	public void Appear(Transform attachedTo, string text, Color color)
    {
        transform.parent.SetParent(attachedTo);
        transform.parent.localPosition = Vector3.zero +
            new Vector3(Random.Range(-_random.x, _random.x),
                        Random.Range(-_random.y, _random.y),
                        Random.Range(-_random.z, _random.z)); 
        _textMesh.text = text;
        _textMesh.color = color;
        _animator.SetTrigger("Appear");
    }
}
