using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject step1;
    [SerializeField] GameObject step2;  
    [SerializeField] GameObject step3;
    [SerializeField] GameObject step4;
    [SerializeField] GameObject step5;

    [SerializeField] NextButton next1;
    [SerializeField] NextButton next2;
    [SerializeField] NextButton next3;
    [SerializeField] NextButton next4;
    [SerializeField] NextButton okButton;
    void Start()
    {
        next1.OnNextButtonClicked += ActivateStep2;
        next2.OnNextButtonClicked += ActivateStep3;
        next3.OnNextButtonClicked += ActivateStep4;
        next4.OnNextButtonClicked += ActivateStep5;
        okButton.OnNextButtonClicked += CloseTutorials;

        ActivateStep1();
    }
    private void ActivateStep1()

    {
        step1.SetActive(true);
    }

    private void ActivateStep2()
    {
        step1.SetActive(false);
        step2.SetActive(true);
    }

    private void ActivateStep3()
    {
        step2.SetActive(false);
        step3.SetActive(true);
    }

    private void ActivateStep4()
    {
        step3.SetActive(false);
        step4.SetActive(true);
    }

    private void ActivateStep5()
    {
        step4.SetActive(false);
        step5.SetActive(true);
    }

    private void CloseTutorials()
    {
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        next1.OnNextButtonClicked -= ActivateStep2;
        next2.OnNextButtonClicked -= ActivateStep3;
        next3.OnNextButtonClicked -= ActivateStep4;
        next4.OnNextButtonClicked -= ActivateStep5;
        okButton.OnNextButtonClicked -= CloseTutorials;
    }
}
