using System.Diagnostics;
using UnityEngine;

public class OpenKeyboard : MonoBehaviour
{
    private Process process;
    public void Open()
    {
        if (Application.platform == RuntimePlatform.LinuxPlayer)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("gsettings set org.gnome.desktop.a11y.applications screen-keyboard-enabled true");
            Process.Start(startInfo);
        }
        else
        {
            if (process == null)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("osk.exe");
                process = Process.Start(startInfo);
            }
        }
    }

    public void Close()
    {
        if (Application.platform == RuntimePlatform.LinuxPlayer)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("gsettings set org.gnome.desktop.a11y.applications screen-keyboard-enabled false");
            Process.Start(startInfo);
        }
        else
        {
            process.CloseMainWindow();
            process.Close();

            process = null;
        }
    }
}
