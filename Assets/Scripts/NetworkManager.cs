using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

    private const string typeName = "MultiPlayer";
    private const string gameName = "Havoc";
    public string stringToEdit = "Your Name";
    private bool isRefreshingHostList = false;
    private HostData[] hostList;

    public GameObject PrefabsObjectsPlayer;


    void OnGUI()
    {
        if (!Network.isClient && !Network.isServer)
        {
            GUI.Box(new Rect(10, 10, 250, 200), "Loader Menu");
            stringToEdit = GUI.TextField(new Rect(20, 40, 200, 20), stringToEdit, 25);
            if (GUI.Button(new Rect(20, 70, 200, 20), "Start Server"))
                StartServer();

            if (GUI.Button(new Rect(20, 100, 200, 20), "Refresh Hosts"))
                RefreshHostList();

            if (hostList != null)
            {
                for (int i = 0; i < hostList.Length; i++)
                {
                    if (GUI.Button(new Rect(20, 130 + (150 * i), 200, 20), hostList[i].gameName))
                        JoinServer(hostList[i]);
                }
            }
        }
    }

    private void StartServer()
    {
        Network.InitializeServer(5, 25000, !Network.HavePublicAddress());
        MasterServer.RegisterHost(typeName, gameName);
    }

    void OnServerInitialized()
    {
        CreatePlayer();
    }


    void Update()
    {
        if (isRefreshingHostList && MasterServer.PollHostList().Length > 0)
        {
            isRefreshingHostList = false;
            hostList = MasterServer.PollHostList();
        }
    }

    private void RefreshHostList()
    {
        if (!isRefreshingHostList)
        {
            isRefreshingHostList = true;
            MasterServer.RequestHostList(typeName);
        }
    }


    private void JoinServer(HostData hostData)
    {
        Network.Connect(hostData);
    }

    void OnConnectedToServer()
    {
        CreatePlayer();
    }


    private void CreatePlayer()
    {
        Network.Instantiate(PrefabsObjectsPlayer, Vector3.up * 5, Quaternion.identity, 0);
    }
}
