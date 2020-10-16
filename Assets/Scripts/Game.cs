using System.Collections;
using UnityEngine;


public class Game : MonoBehaviour
{
    private System.Random _random = new System.Random();
    public GameObject Card11;
    public GameObject Card12;
    public GameObject Card13;
    public GameObject Card14;
    public GameObject Card21;
    public GameObject Card22;
    public GameObject Card23;
    public GameObject Card24;
    public GameObject WinPanel;
    int[] array = { 1, 1, 2, 2, 3, 3, 4, 4 };




    void Start()
    {
        //Создаем случайный порядок цифр
        Shuffle(array);
        Card11.GetComponent<Rotate>().Text.text = array[0].ToString();
        Card12.GetComponent<Rotate>().Text.text = array[1].ToString();
        Card13.GetComponent<Rotate>().Text.text = array[2].ToString();
        Card14.GetComponent<Rotate>().Text.text = array[3].ToString();
        Card21.GetComponent<Rotate>().Text.text = array[4].ToString();
        Card22.GetComponent<Rotate>().Text.text = array[5].ToString();
        Card23.GetComponent<Rotate>().Text.text = array[6].ToString();
        Card24.GetComponent<Rotate>().Text.text = array[7].ToString();
        Debug.Log(array[0].ToString() + array[1].ToString() + array[2].ToString() + array[3].ToString() + array[4].ToString() + array[5].ToString() + array[6].ToString() + array[7].ToString());

    }


    void Update()
    {
        //Если выбраны одинаковые карты меняем цвет текста и тем самым блокируем их
        if (Logic_of_two.Number_card == 2) {
            if (Logic_of_two.OneTextCard.text == Logic_of_two.TwoTextCard.text && Logic_of_two.OneTextCard != null && Logic_of_two.TwoTextCard != null)
            {
                Logic_of_two.OneTextCard.color = Color.green;
                Logic_of_two.TwoTextCard.color = Color.green;
                Logic_of_two.Number_of_found = Logic_of_two.Number_of_found + 2;
                Logic_of_two.OneTextCard = null;
                Logic_of_two.TwoTextCard = null;
                Logic_of_two.Number_card = 0;
                
                //Если найдены все 8 карт выводим окно с поздравлением
                if (Logic_of_two.Number_of_found == 8)
                {
                    WinPanel.SetActive(true);
                }
            }
            else
            {
                //Если выбраны разные карты, то закрываем эти карты
                StartCoroutine(CloseCard());
            }
        }
        
    }

    IEnumerator CloseCard()
    {
        yield return new WaitForSeconds(1.8f);
        Logic_of_two.Close = true;
 
        Logic_of_two.Number_card = 0;

        StartCoroutine(EndBlock());
    }
    IEnumerator EndBlock()
    {
        yield return new WaitForSeconds(0f);
        
        
        Logic_of_two.Close = false;

        Logic_of_two.OneTextCard = null;
        Logic_of_two.TwoTextCard = null;
    }



    void Shuffle(int[] array)
    {
        int p = array.Length;
        for (int n = p - 1; n > 0; n--)
        {
            int r = _random.Next(0, n);
            int t = array[r];
            array[r] = array[n];
            array[n] = t;
        }
    }

   
}
