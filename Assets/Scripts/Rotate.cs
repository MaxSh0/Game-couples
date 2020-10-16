using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour
{

    public float angle = 180f;
    public GameObject Image;
    public Text Text;
    public bool go;
    public bool Block = false;

    // Сигнал который вызывается при нажатии на карту
    public void Go()
    {
        if (Logic_of_two.Number_card < 2 && (Logic_of_two.OneTextCard == null || Logic_of_two.TwoTextCard == null)&& Logic_of_two.Close == false)
        {
            
            if (Logic_of_two.OneTextCard == null)
            {
                go = true;
                Logic_of_two.OneTextCard = Text;
                Logic_of_two.Number_card++;
            }
            else if (Logic_of_two.OneTextCard.name != Text.name)
            {
                go = true;
                Logic_of_two.TwoTextCard = Text;
                Logic_of_two.Number_card++;
            }
            if (Logic_of_two.OneTextCard == null || Logic_of_two.TwoTextCard == null)
            {
                //Logic_of_two.Number_card++;
            }
            else if (Logic_of_two.OneTextCard.name != Logic_of_two.TwoTextCard.name)
            {
                //Logic_of_two.Number_card++; 
            }

            Debug.Log(Logic_of_two.OneTextCard);
            Debug.Log(Logic_of_two.TwoTextCard);

        }


    }

    void Update()
    {
        //Вращение карты

        //Открыть карту
        if (transform.localEulerAngles.y <= 180 && go)
        {
            if (transform.localEulerAngles.y >= 90)
            {
                Image.SetActive(false);
            }
            transform.Rotate(new Vector3(0, 3, 0));
        }
        //Закрыть карту
        if (transform.localEulerAngles.y >= 180 && Logic_of_two.Close && Text.color != Color.green)
        {
            go = false;
            transform.Rotate(new Vector3(0, 3, 0));
            if (transform.localEulerAngles.y >= 270)
            {
                Image.SetActive(true);
            }

        }


    }
}
