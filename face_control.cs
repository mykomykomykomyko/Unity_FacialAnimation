using UnityEngine;

public class FaceAnimator : MonoBehaviour
{   
    public Animator animator;   
    public const string EXPRESSION_NEUTRAL = "Neutral";
    public const string EXPRESSION_HAPPY = "Happy";
    public const string EXPRESSION_SAD = "Sad";
    public const string EXPRESSION_ANGRY = "Angry";
    public void SetExpression(string expression)
    {
        animator.SetTrigger(expression);
    }
    void Update()
    {   
        float emotion = PlayerController.instance.emotion;   
        if (emotion > 0.5f)
        {
            SetExpression(EXPRESSION_HAPPY);
        }
        else if (emotion < -0.5f)
        {
            SetExpression(EXPRESSION_ANGRY);
        }
        else if (emotion < 0) 
        {
            SetExpression(EXPRESSION_SAD);
        }
        else
        {
            SetExpression(EXPRESSION_NEUTRAL);
        }
    }
    public class EmotionRandomizer : MonoBehaviour{
    public const float MIN_EMOTION = -1.0f;
    public const float MAX_EMOTION = 1.0f;   
    public float emotion = 0.0f;
    public float changeRate = 0.1f;
    void Update()
    {
        emotion += Random.Range(-changeRate, changeRate);
        emotion = Mathf.Clamp(emotion, MIN_EMOTION, MAX_EMOTION);
    }
    }
    public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public EmotionRandomizer emotionRandomizer;
    public FaceAnimator faceAnimator;    
    public float emotion;   
    void Awake()
    {
        instance = this;
    }
    void Update()
    {
        emotion = emotionRandomizer.emotion; 
        faceAnimator.Update();
    }
}
}
