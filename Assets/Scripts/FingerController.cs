using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;



public class FingerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform phalanx1;
    [SerializeField] Transform phalanx2;
    [SerializeField] Transform phalanx3;
    [SerializeField] float spinSpeed = 1f;

    [SerializeField] int min_angle_prox = -30;
    [SerializeField] int max_angle_prox = 30;
    [SerializeField] int min_angle_mid = -30;
    [SerializeField] int max_angle_mid = 30;


    SerialPort sp; // = new SerialPort("COM7", 9600);

    float x_ref;
    float y_ref;


    void Start()
    {
        sp = new SerialPort("COM7", 9600);
        sp.Open();
        //sp.ReadTimeOut = 1;
        x_ref = 0;
        y_ref = 0;
    }

    private void OnGUI()
    {
        int w = Screen.width, h = Screen.height;
        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = Time.deltaTime * 1000.0f;
        float fps = 1.0f / Time.deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
    Vector3 phalanx1EulerAngles;
    Vector3 phalanx2EulerAngles;
    Vector3 phalanx3EulerAngles;

    private float sin(float value)
    {
        return Mathf.Sin(value);
    }
    private float cos(float value)
    {
        return Mathf.Cos(value);
    }
    private float atan(float value)
    {
        return Mathf.Atan(value);
    }
    private float sqrt(float value)
    {
        return Mathf.Sqrt(value);
    }



    // Update is called once per frame
    void Update()
    {
        //TUNAYA NOT : Buraya Inputlarý besleyebilirsin. Þu anda 1-6 ya kadar rakamlarla açýlarý kontrol ediyorsun

        if (sp.IsOpen)
        {
            try
            {

                //MoveObject(sp.ReadByte());

                //int angle = Mathf.Clamp(sp.ReadByte()*120/256 +min_angle, min_angle, max_angle);
                string arduinoInput = sp.ReadLine();

                //Debug.Log(sp.ReadLine());

                float th2 = int.Parse(arduinoInput.Split(',')[0]);
                float th9 = int.Parse(arduinoInput.Split(',')[1]);

                //if (x_ref == th2 && y_ref == th9)
                //{
                //    return;
                //}
                //Debug.Log("test");

                //th2 =  Mathf.Clamp(th2  + min_angle_mid, min_angle_mid, max_angle_mid);
                //th9 = -Mathf.Clamp(th9 + min_angle_prox, min_angle_prox, max_angle_prox);

                int a11, a12, a2, a3, a41, aG, a5, a51, a6, a71, a8, a9;
                float thG, beta2;
                a11 = 22; a12 = 48; a2 = 64; a3 = 40;
                a41 = 49; aG = 21; a5 = 57; a51 = 99;
                a6 = 34; a71 = 40; a8 = 100; a9 = 120;
                thG = 0.5955f; beta2 = 1.428f;

                float a42 = 49 / 2;
                float a72 = 31 / 2;

                //x_ref = th2; 
                //y_ref = th9;

                th2 = th2 * Mathf.PI / 180;
                th9 = th9 * Mathf.PI / 180;
                float K1 = (a11 * a11 + a12 * a12 + a2 * a2 + a41 * a41 + a42 * a42 - a3 * a3) + 2 * a2 * a11 * sin(th2) - 2 * a2 * a12 * cos(th2);
                float K2 = -2 * ((a11 * a41 - a12 * a42) + a2 * a41 * sin(th2) + a2 * a42 * cos(th2));
                float K3 = -2 * ((a11 * a42 + a12 * a41) - a2 * a41 * cos(th2) + a2 * a42 * sin(th2));
                float A_4 = K1 - K2;
                float B_4 = 2 * K3;
                float C_4 = K1 + K2;
                float th4 = 2 * atan((-B_4 - sqrt(B_4 * B_4 - (4 * A_4 * C_4))) / (2 * A_4));

                float K4 = (a11 * a11 + a12 * a12 + a2 * a2 + a3 * a3 - a41 * a41 - a42 * a42) + 2 * a2 * a11 * sin(th2) - 2 * a2 * a12 * cos(th2);
                float K5 = 2 * (-a12 * a3 + a2 * a3 * cos(th2));
                float K6 = 2 * (a11 * a3 + a2 * a3 * sin(th2));
                float A_3 = K4 - K5;
                float B_3 = 2 * K6;
                float C_3 = K4 + K5;
                float th3 = 2 * atan((-B_3 + sqrt(B_3 * B_3 - (4 * A_3 * C_3))) / (2 * A_3));

                float K7 = ((a2 * a2 + a3 * a3 + a51 * a51 + aG * aG + a9 * a9 - a8 * a8) + 2 * a2 * a3 * cos(th2 - th3) - 2 * a2 * a9 * cos(th2 - th9) - 2 * a2 * aG * cos(th2 - thG) - 2 * a3 * a9 * cos(th3 - th9) - 2 * a3 * aG * cos(th3 - thG) + 2 * a9 * aG * cos(th9 - thG));
                float K8 = 2 * a51 * (a2 * cos(th2) + a3 * cos(th3) - a9 * cos(th9) - aG * cos(thG));
                float K9 = 2 * a51 * (a2 * sin(th2) + a3 * sin(th3) - a9 * sin(th9) - aG * sin(thG));
                float A_5 = K7 - K8;
                float B_5 = 2 * K9;
                float C_5 = K7 + K8;
                float th5 = 2 * atan((-B_5 - sqrt(B_5 * B_5 - (4 * A_5 * C_5))) / (2 * A_5)) - beta2;

                float K10 = (a41 * a41 + a42 * a42 + a5 * a5 + a71 * a71 + a72 * a72 - a6 * a6) - 2 * a5 * (a41 * sin(th4 - th5) + a42 * cos(th4 - th5));
                float K11 = 2 * (-a5 * a71 * sin(th5) - a5 * a72 * cos(th5) + (a42 * a72 - a41 * a71) * cos(th4) + (a41 * a72 + a42 * a71) * sin(th4));
                float K12 = 2 * (+a5 * a71 * cos(th5) - a5 * a72 * sin(th5) + (a42 * a72 - a41 * a71) * sin(th4) - (a41 * a72 + a42 * a71) * cos(th4));
                float A_7 = K10 - K11;
                float B_7 = 2 * K12;
                float C_7 = K10 + K11;
                float th7 = 2 * atan((-B_7 - sqrt(B_7 * B_7 - (4 * A_7 * C_7))) / (2 * A_7));


                th4 = th4 * 180 / Mathf.PI;
                th7 = th7 * 180 / Mathf.PI;

                if ((-180.0 < th4 && th4 < 180.0) && (-180 < th7 && th7 < 180))
                {



                    Debug.Log(th4);
                    //int angle_4 = 
                    //int angle_7 = 

                    phalanx2EulerAngles = new Vector3(0, 180-th7,0);
                    phalanx2.eulerAngles = phalanx2EulerAngles;

                    phalanx3EulerAngles = new Vector3(0, 180-th4,0);
                    phalanx3.eulerAngles = phalanx3EulerAngles;

                }
            }

            catch
            {

            }
        }


        /*if (Input.GetKey(KeyCode.Alpha1))
        {
            phalanx1.eulerAngles = new Vector3(0, 0, phalanx1.eulerAngles.z + spinSpeed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            phalanx1.eulerAngles = new Vector3(0, 0, phalanx1.eulerAngles.z - spinSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            phalanx2.eulerAngles = new Vector3(0, 0, phalanx2.eulerAngles.z + spinSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            phalanx2.eulerAngles = new Vector3(0, 0, phalanx2.eulerAngles.z - spinSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            phalanx3.eulerAngles = new Vector3(0, 0, phalanx3.eulerAngles.z + spinSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            phalanx3.eulerAngles = new Vector3(0, 0, phalanx3.eulerAngles.z - spinSpeed * Time.deltaTime);

        }
        */



        // aþaðýdaki þekilde olabilir

        /*

        phalanx1EulerAngles = new Vector3(0, 0, phalanx1acisi);
        phalanx2EulerAngles = new Vector3(0, 0, phalanx2acisi);
        phalanx3EulerAngles = new Vector3(0, 0, phalanx3acisi);


        phalanx1.eulerAngles = phalanx1EulerAngles;
        phalanx2.eulerAngles = phalanx2EulerAngles;
        phalanx3.eulerAngles = phalanx3EulerAngles;
        */
    }
}
