using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

public class NetworkManager
{
    private TcpClient client;
    private NetworkStream stream;
    private Thread listenThread;

    // 事件定义
    public Action OnWaiting;              // 等待对手
    public Action OnConnected;            // 配对成功
    public Action<string> OnError;        // 出错
    public Action<int> OnGameStart;       // 游戏开始
    public Action<int> OnOpponentScore;   // 对手得分
    public Action OnOpponentQuit;         // 对手退出
    public Action OnOpponentWin;          // 对手赢了

    // 【新增】收到房主的配置 (种子, 提示, 胜利分, 文件名串)
    public Action<int, bool, int, string> OnConfigReceived;

    public bool IsConnected => client != null && client.Connected;

    // 连接并发送握手包
    public void ConnectAndSetup(string ip, int port, string action, string roomId)
    {
        try
        {
            client = new TcpClient(ip, port);
            stream = client.GetStream();

            // 发送握手: "CREATE|1001" 或 "JOIN|1001"
            Send($"{action}|{roomId}");

            listenThread = new Thread(ListenLoop);
            listenThread.IsBackground = true;
            listenThread.Start();
        }
        catch (Exception ex)
        {
            MessageBox.Show("连接服务器失败: " + ex.Message);
        }
    }

    // 【新增】发送游戏配置 (房主调用)
    public void SendGameConfig(int seed, bool isHint, int winScore, string fileNames)
    {
        // 协议: CONFIG|种子|提示|胜利分|文件名1,文件名2
        Send($"CONFIG|{seed}|{isHint}|{winScore}|{fileNames}");
    }

    public void SendScore(int score) => Send("SCORE|" + score);
    public void SendWin() => Send("WIN");
    public void SendQuit() { try { Send("QUIT"); if (client != null) client.Close(); } catch { } }

    private void Send(string msg)
    {
        if (stream == null) return;
        byte[] data = Encoding.UTF8.GetBytes(msg);
        stream.Write(data, 0, data.Length);
    }

    private void ListenLoop()
    {
        byte[] buffer = new byte[102400]; // 缓冲区大一点以防配置太长
        while (true)
        {
            try
            {
                int len = stream.Read(buffer, 0, buffer.Length);
                if (len == 0) break;
                string msg = Encoding.UTF8.GetString(buffer, 0, len);
                HandleMessage(msg);
            }
            catch { break; }
        }
    }

    private void HandleMessage(string msg)
    {
        // 防止粘包，简单用 Split 处理第一条指令
        string[] parts = msg.Split(new char[] { '|' }, 5);
        string command = parts[0];

        if (command == "WAIT") OnWaiting?.Invoke();
        else if (command == "CONNECTED") OnConnected?.Invoke();
        else if (command == "ERROR") OnError?.Invoke(parts[1]);
        else if (command == "START") OnGameStart?.Invoke(int.Parse(parts[1]));
        else if (command == "SCORE") OnOpponentScore?.Invoke(int.Parse(parts[1]));
        else if (command == "QUIT" || msg.Contains("QUIT")) OnOpponentQuit?.Invoke();
        else if (command == "WIN") OnOpponentWin?.Invoke();
        else if (command == "CONFIG")
        {
            // 解析配置
            int seed = int.Parse(parts[1]);
            bool isHint = bool.Parse(parts[2]);
            int winScore = int.Parse(parts[3]);
            string fileNames = parts[4];
            OnConfigReceived?.Invoke(seed, isHint, winScore, fileNames);
        }
    }
}