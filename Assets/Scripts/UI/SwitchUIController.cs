using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;


public class SwitchUIController : MonoBehaviour
{
    [Header("Tutorial UI")]
    [SerializeField]
    List<Image> tutorialImages;
    [SerializeField]
    Text swipeTextLabel;

    [Header("Counter")]
    [SerializeField]
    Text counterLabel;

    SwipeController swipe;
    SwitchController switchController;

    bool firsSwipe = true;

    void Start()
    {
        swipe = GetComponent<SwipeController>();
        switchController = GetComponent<SwitchController>();
        swipe.OnSwipeAction += disableTutorial;
    }



    // Update is called once per frame
    void Update()
    {
        counterLabel.text = switchController.Counter.ToString();
    }

    void disableTutorial(SwipeDirection direction)
    {
        if(direction == SwipeDirection.Down && firsSwipe)
        {
            firsSwipe = false;
            foreach(Image i in tutorialImages)
            {
                i.DOFade(0,1f);
            }
            swipeTextLabel.DOFade(0,1f);
        }
    }
}
