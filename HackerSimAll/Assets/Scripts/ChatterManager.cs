using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChatterManager : ChatterManagerBehavior
{
    public Transform chatContent;
    public GameObject chatMessage;
    private string username;

    void Start()
    {
      SEAttributes player = SaveSEAttributes.LoadPlayer();
      username = player.PlayerName;
    }

    // Send message across network
    public void WriteMessage(InputField sender)
    {
        // Checks that message is not empty
        if(!string.IsNullOrEmpty(sender.text) && sender.text.Trim().Length > 0)
        {
            sender.text = sender.text.Replace("\r", string.Empty).Replace("\n", string.Empty);
            networkObject.SendRpc(RPC_TRANSMIT_MESSAGE, Receivers.All, username, sender.text.Trim());
            sender.text = string.Empty;
            sender.ActivateInputField();
        }
    }

    // Recieve message across network
    public override void TransmitMessage(RpcArgs args)
    {
        string username = args.GetNext<string>();
        string message = args.GetNext<string>();

        // Check if username or message is empty
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(message))
            return;

        GameObject newMessage = Instantiate(chatMessage, chatContent);
        Text content = newMessage.GetComponent<Text>();
        content.text = string.Format(content.text, username, message);
    }

    public void Exit()
    {
        // networkObject.Destroy();
        //MultiplayerMenu.leave();
        SceneManager.LoadScene("MultiplayerMenu");
    }
}
