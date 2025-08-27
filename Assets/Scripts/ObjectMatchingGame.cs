using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(LineRenderer))]
public class ObjectMatchingGame : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private int valoresIguais;
    private bool isDragging;
    private Vector3 endPoint;
    private ObjectMatchForm objectMatchForm;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        // Configuração inicial do LineRenderer
        lineRenderer.enabled = false; // começa invisível
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;

        // Garante que a linha renderize acima dos sprites
        lineRenderer.sortingLayerName = "Default";
        lineRenderer.sortingOrder = 10;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Detecta clique no objeto
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging = true;
                lineRenderer.enabled = true;

                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                lineRenderer.SetPosition(0, mousePosition);
                lineRenderer.SetPosition(1, mousePosition);
            }
        }

        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            lineRenderer.SetPosition(1, mousePosition);
            endPoint = mousePosition;
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;

            // Verifica se soltou sobre outro objeto
            Collider2D hit = Physics2D.OverlapPoint(endPoint);
            if (hit != null && hit.TryGetComponent(out objectMatchForm) && valoresIguais == objectMatchForm.pegar_valores())
            {
                Debug.Log("Acertou!");

                // fixa a linha entre origem e destino
                Vector3 destino = hit.transform.position;
                destino.z = 0f;
                lineRenderer.SetPosition(1, destino);

                // mantém a linha visível
            }
            else
            {
                Debug.Log("Errou!");
                lineRenderer.enabled = false;
                PontosPonto.instance.SubtractScore(1);
            }
        }
    }
}