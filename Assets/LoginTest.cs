using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Text;

public class LoginTest : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField username;
    [SerializeField]
    private TMP_InputField password;

    // Start is called before the first frame update
    void Start()
    {
        password.inputType = TMP_InputField.InputType.Password;
    }

    public void Login()
    {
        ReadString();
    }

    void ReadString()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "Profiles/" + username.text + ".prf");
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        byte[] stringBytes = Encoding.UTF8.GetBytes(reader.ReadLine());
        reader.Close();
    }

    /*
    void ComputeHash(byte[] )
    {
        if (!File.Exists(filePath))
        {
            Debug.Log("Path error: File doesn't exist");
            return;
        }
        Debug.Log("Generating SHA256 hash");

        byte[] fileBytes = File.ReadAllBytes(filePath);
        StringBuilder sb = new StringBuilder();

        using (SHA256Managed sha256 = new SHA256Managed())
        {
            byte[] hash = sha256.ComputeHash(fileBytes);
            foreach (Byte b in hash)
                sb.Append(b.ToString("X2"));
        }
        CreateTextFile(_name + "SHA256.txt", filePath, sb.ToString());
    }*/
}
