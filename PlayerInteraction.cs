using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class PlayerInteraction : MonoBehaviour
{
    public string text;
    public bool exist = false;
    public bool APget = false;
    public bool EEget = false; 
    public bool MEget = false;
    public bool Afget = false;
    public bool Amget = false;
    public int Boxremain = 5;


   

    // Start is called before the first frame update
    void Start()
    {
        Textchange(1);
        Present();
       
        //GetComponent<AudioSource>().volume = 0.1f;
    }

    // Update is called once per frame
   


   

    public void Existornot(int n)
    {

        if (n == 1)
        {
            exist = false;
        }
        else if (n == 2)
        {
            exist = true;
        }

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && exist == false)
        {
            Present();
            exist = true;
        }

        pickUp();
       
    }

    public void Present()
    {
        exist = true;
        PopUpSystem pop1 = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
        pop1.PopUpInstru(text);
    }
        public void Textchange(int n)
    {
        
            

            if (n == 1)
            {
                text = "<size=15>" + "Hi traveler, welcome to the New Earth in 2020. I am Dr. X. \n\n It is probably a planet much like the one you live in. Generally, we divided the whole planet into 5 regions: Asia and Pacific, Europe and Eurasia, Middle East and North Africa, Africa (excl. MENA), Americas. Also, there are men and women living on the planet, like your Earth.\n\n Although most of the inhabitants of the planet lead a happy life, unfortunately, you know, there is no place to avoid war, even on this planet. In order to mediate the war, people signed peace agreements. My job is to find out whether women have had a better life and their status has been improved in the signing of these peace agreements or not.\n\n" + "</size>";
            }
            else if (n == 2)
            {
                exist = true;
                n = 1;
                text = "<size=13>" + "Aha, maybe my story is too academic and serious, please forgive me… Newcomer, please feel free to walk around here and enjoy the unique scenery. Use “W” key to move forward, use “A” key and “D” key to turn around. Use the mouse wheel to zoom in and out of the field of view. If you are tired, you can also stop and sit on the ground...by doing nothing.\n\nAs you play, you may encounter some landmarks. They may allow you to learn more about the peace agreements, conflict, and women between 1990-2020. Click “G” key to check the landmark when you get close to it.After you have visited the five areas and found all the landmarks, we will show you something special ...\n\nHave fun! (You can press the space bar at any time to get this tip back.)\nDoc.X" + "</size>";
                //PopUpSystem pop2 = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
               // pop2.PopUpInstru(text);

            }
       
    }


    public void pickUp()
    {
        Debug.DrawRay(transform.position, transform.forward * 2.0f, Color.green);
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] colls = Physics.OverlapSphere(transform.position, 5f); //获取周围物品
            foreach (Collider collider in colls)
            {
                if (collider.gameObject.tag == "pick" && Vector3.Angle(collider.gameObject.transform.position - transform.position, transform.forward) <= 45)
                {
                    print("GET!");
                    


                    if (collider.gameObject == GameObject.Find("APinfo") && APget == false)
                    {
                        PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
                        pop.PopUpInfo("<size=15>" + "Here is Asia and Pacific. They signed 377 peace agreements between 1990 and 2020. However, only 45 of them involve women and gender, which is the smallest proportion. It shows that compared with other areas, there is less extra care for women in conflicts. What caused this phenomenon?" + "</size>");
                       // print("GET22!");
                        APget = true;
                        Boxremain--;
                        Destroy(collider.gameObject, 0.2f);
                        PlayerController.open.Play();
                    }
                    if (collider.gameObject == GameObject.Find("EEinfo") && EEget == false)
                    {
                        PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
                        pop.PopUpInfo("<size=15>" + "This is Europe and Eurasia. They have a lot of peace agreements but just a few related to gender aspects. Besides, the local agreement was relatively concentrated in the early 1990s, but declined over time. Does this demonstrate Europe has done a better job of protecting women's rights？" + "</size>");
                        // print("GET22!");
                        EEget = true;
                        Boxremain--;
                        Destroy(collider.gameObject, 0.2f);
                        PlayerController.open.Play();
                    }
                    if (collider.gameObject == GameObject.Find("MEinfo") && MEget == false)
                    {
                        PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
                        pop.PopUpInfo("<size=15>" + "The number of peace agreements signed in the Middle East and North Africa is relatively medium compared to other regions, but they are concentrated in Israel, Palestinian Territory, Lebanon, Syria, and Iraq. Further research on the rights and interests of women in these countries will help us to further explore the extent to which peace agreements affect women and gender equality." + "</size>");
                        // print("GET22!");
                        MEget = true;
                        Boxremain--;
                        Destroy(collider.gameObject, 0.2f);
                        PlayerController.open.Play();
                    }
                    if (collider.gameObject == GameObject.Find("Afinfo") && Afget == false)
                    {
                        PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
                        pop.PopUpInfo("<size=15>" + "This is Africa(excl MENA). They have the largest number of peace agreements both in all and gender related part, at the same time the proportion of there is also the highest. So many wars have brought disaster to this place. It is hoped that these peace agreements will enable local women to gain a higher status and lead a better life." + "</size>");
                        // print("GET22!");
                        Afget = true;
                        Boxremain--;
                        Destroy(collider.gameObject, 0.2f);
                        PlayerController.open.Play();
                    }
                    if (collider.gameObject == GameObject.Find("Aminfo") && Amget == false)
                    {
                        PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
                        pop.PopUpInfo("<size=15>" + "This is Americas. Interesting, there is a blank of records of peace agreements related to the Americas at the beginning of the 21st century(2000 - 2012). Maybe the lack of data is due to a relatively peaceful period in the Americas in the early 21st century?" + "</size>");
                        // print("GET22!");
                        Amget = true;
                        Boxremain--;
                        Destroy(collider.gameObject, 0.2f);
                        PlayerController.open.Play();
                    }




                }
            }
        }

    }
   
        public void End()
    {
        if(Boxremain == 0)
        {
            PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
            pop.PopUpInfo("<size=10>" + "Hi, how do you feel on this new Earth?\nI think you have learned about the situation in different regions during your travels, and you have also generated more thoughts.\nWe all have a dream, that is to let the world no longer have conflicts, and the vulnerable groups in conflict——those women can get more protection.\n This path of exploration will be continued by yourself after you go back. Remember to pay more attention to women, girls and gender issues in conflict.\n Your trip has come to an end. I think you miss what you saw just now. But don’t worry, as long as you go out.\nThat better New earth is right in front of you...\n\nDoc. X" + "</size>");

        }
        

    }




}
