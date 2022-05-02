using UnityEngine;

public class ChangeSeason : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private SpriteRenderer spriteRendererFront, spriteRendererBack;
    [SerializeField] private Sprite spring, summer, winter, autumn;
    [SerializeField] private Animator animator;
    private static readonly int Spring1 = Animator.StringToHash("Spring");
    private static readonly int Summer1 = Animator.StringToHash("Summer");
    private static readonly int Winter1 = Animator.StringToHash("Winter");
    private static readonly int Autumn1 = Animator.StringToHash("Autumn");
    private bool _winter, _summer, _spring, _autumn;


    // Update is called once per frame
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        ChangeSpriteBack(winter);
        _spring = true;
    }
    private void Update()
    {
        ChangeSeasonAnimation();
    }
    

    private void ChangeSpriteFront(Sprite newSprite)
    {
        spriteRendererFront.sprite = newSprite;
    }

    private void ChangeSpriteBack(Sprite newSprite)
    {
        spriteRendererBack.sprite = newSprite;
    }


    private void ChangeSeasonAnimation()
    {
        if (Mathf.Round(_gameManager.CurrentDeg) == 360 && _spring)
        {
            animator.SetTrigger(Spring1);
            ChangeSpriteFront(spring);
            ChangeSpriteBack(spring);
            _spring = false;
            _summer = true;
        }

        if (Mathf.Round(_gameManager.CurrentDeg) == 243 && _summer)
        {
            animator.SetTrigger(Summer1);
            ChangeSpriteFront(summer);
            ChangeSpriteBack(summer);
            _summer = false;
            _autumn = true;
        }

        if (Mathf.Round(_gameManager.CurrentDeg) == 132 && _autumn)
        {
            animator.SetTrigger(Autumn1);
            ChangeSpriteFront(autumn);
            ChangeSpriteBack(autumn);
            _autumn = false;
            _winter = true;
        }

        if (Mathf.Round(_gameManager.CurrentDeg) == 42 && _winter)
        {
            animator.SetTrigger(Winter1);
            ChangeSpriteFront(winter);
            ChangeSpriteBack(winter);
            _winter = false;
            _spring = true;
        }
    }
    
}