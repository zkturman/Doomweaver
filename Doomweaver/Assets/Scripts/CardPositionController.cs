using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPositionController : MonoBehaviour
{
    [SerializeField]
    private DescriptionFader textDescription;
    [SerializeField]
    private TextFader cardTitle;
    [SerializeField]
    private CardData cardData;
    [SerializeField]
    private int cardId = 0;
    private bool isRotatingToBack = false;
    private bool isRotatingToFront = false;
    private float rotateTime = 0.5f;
    private float rotateTimeDelta = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (textDescription == null)
        {
            textDescription = FindObjectOfType<DescriptionFader>();
        }
        if (cardTitle == null)
        {
            Debug.LogError("Card Title is not set on card.");
        }
        cardTitle.SetText(cardData.CardName);
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotatingToBack)
        {
            rotateCard(true);
        }
        else if (isRotatingToFront)
        {
            rotateCard(false);
        }
    }

    private void OnMouseEnter()
    {
        if (!isRotatingToBack)
        {
            textDescription.SetText(cardData.CardDescription);
            isRotatingToBack = true;
            isRotatingToFront = false;
            float currentRotation = getRotationPercentage();
            textDescription.SetTransparency(currentRotation);
            cardTitle.SetTransparency(currentRotation);
            rotateTimeDelta = rotateTime * currentRotation;
        }
    }

    private void OnMouseExit()
    {
        if (!isRotatingToFront)
        {
            isRotatingToFront = true;
            isRotatingToBack = false;
            float currentRotation = getRotationPercentage();
            textDescription.SetTransparency(currentRotation);
            cardTitle.SetTransparency(currentRotation);
            rotateTimeDelta = rotateTime * (1 - currentRotation);
        }
    }

    private float getRotationPercentage()
    {
        float currentRotation = Mathf.Abs(transform.rotation.eulerAngles.y);
        if (currentRotation > 180f)
        {
            currentRotation -= 360;
        }
        return Mathf.Abs(currentRotation / 180f);
    }

    private void rotateCard(bool rotateToBack)
    {
        float fromAngle = 0f;
        float toAngle = -180f;
        float completionPercentage = rotateTimeDelta / rotateTime;
        if (!rotateToBack)
        {
            completionPercentage = 1 - completionPercentage;
        }
        if (rotateTimeDelta >= rotateTime)
        {
            setCardRotationY(toAngle * completionPercentage);
            textDescription.SetTransparency(1 - completionPercentage); //transparency when facing forward only
            cardTitle.SetTransparency(1 - completionPercentage);
            rotateTimeDelta = 0f;
            isRotatingToBack = false;
            isRotatingToFront = false;
        }
        else
        {
            setCardRotationY(Mathf.Lerp(fromAngle, toAngle, completionPercentage));
            textDescription.SetTransparency(1 - completionPercentage); //transparency when facing forward only
            cardTitle.SetTransparency(1 - completionPercentage);
            rotateTimeDelta += Time.deltaTime;
        }
    }

    private void setCardRotationY(float newRotation)
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, newRotation, transform.rotation.eulerAngles.z);

    }
}
