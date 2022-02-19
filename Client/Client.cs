using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Common;
using Common.GameEvents;
using Common.Choices;

namespace Client
{
    internal class Client
    {
        internal Player _player;

        private TcpClient _client;
        private const int BufferSize = 256 * 256 * 16;
        internal LobbyPanel _lobbyPanel;
        internal TablePage _tablePage;
        internal MenuPage _menuPage;

        internal Client()
        {
        }

        internal void Connect(string hostname, int port)
        {
            //_client.Connect(hostname, port);
            _client = new(hostname, port);
            //_client = new();
            //_client.BeginConnect()
        }

        internal async Task ReadLoop()
        {
            try
            {
                while (_client.Connected)
                {
                    if (_client.Available > 0)
                    {
                        var objects = Read();
                        foreach (var obj in objects)
                        {
                            Process(obj);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
        }

        private void Process(object obj)
        {
            if (obj is CreateTable createTable)
            {
                if (_player.Id == createTable.Table.Host.Id)
                {
                    CreateTable(createTable);
                }
            }
            else if (obj is ClientConnected connected)
            {
                ClientConnected(connected);
            }
            else if (obj is JoinTable joinTable)
            {
                JoinTable(joinTable);
            }
            else if (obj is LeaveTable)
            {
                LeaveTable(obj);
            }
            else if (obj is PlayerChangeName name)
            {
                if (_player.Id == name.Player.Id)
                {
                    SetClientName(obj, name);
                } 
            }
            else if (obj is StartGame startGame)
            {
                StartGame(startGame);
            }
            else if (obj is GameEvent e)
            {
                Process(e);
            }
            else if (obj is Choice c)
            {
                Process(c);
            }
            else if (obj is ReadyToStartGame ready)
            {
                ReadyToStartGame(ready);
            }
        }

        private void ReadyToStartGame(ReadyToStartGame ready)
        {
            if (_player.Id == ready.Player.Id)
            {
                _tablePage.Invoke(new MethodInvoker(delegate { _tablePage._gameSetupForm._gameSetupTable._startButton.Text = "Waiting for opponent"; })); 
            }
        }

        private void ClientConnected(ClientConnected connected)
        {
            if (_player == null)
            {
                _player = connected.ConnectedPlayer;
                WriteAsync(new PlayerChangeName { Player = new Player(_player) { Name = _menuPage._userNameBox.Text } });
            }
            _lobbyPanel.Invoke(new MethodInvoker(delegate { _lobbyPanel.UpdateTables(connected.Tables); }));
        }

        private void JoinTable(JoinTable joinTable)
        {
            _lobbyPanel._chatBox.Invoke(new MethodInvoker(delegate { _lobbyPanel._chatBox.Text += joinTable; _lobbyPanel._chatBox.Text += Environment.NewLine; }));
            if (_player.Id == joinTable.Table.Guest.Id)
            {
                _lobbyPanel.OnCreateOrJoinTable();
            }
        }

        private void StartGame(StartGame startGame)
        {
            _tablePage.OnStartGame(startGame);
        }

        private void Process(Choice c)
        {
            _tablePage.Process(c);
        }

        private void Process(GameEvent e)
        {
            _tablePage.Process(e);
        }

        private void SetClientName(object obj, PlayerChangeName name)
        {
            _player.Name = name.Player.Name;
            _lobbyPanel._chatBox.Invoke(new MethodInvoker(delegate { WriteChatBox(obj.ToString()); _lobbyPanel._chatBox.Text += Environment.NewLine; }));
        }

        private void LeaveTable(object obj)
        {
            _tablePage.OnExitTable();
            _lobbyPanel._chatBox.Invoke(new MethodInvoker(delegate { WriteChatBox(obj.ToString()); _lobbyPanel._chatBox.Text += Environment.NewLine; }));
        }

        private void CreateTable(CreateTable obj)
        {
            _lobbyPanel.OnCreateOrJoinTable();
            _lobbyPanel._chatBox.Invoke(new MethodInvoker(delegate { WriteChatBox(obj.ToString()); _lobbyPanel._chatBox.Text += Environment.NewLine; }));
            //if (obj.HumanOpponent)
            //{
            //    _lobbyPanel.Invoke(new MethodInvoker(delegate { _lobbyPanel._tables.Items.Add(obj.Table.Id.ToString()); })); 
            //}
        }

        private void WriteChatBox(string text)
        {
            _lobbyPanel._chatBox.Text += text;
        }

        internal void EndConnect()
        {
            _client.GetStream().Close();
            _client.Close();
        }

        internal void WriteAsync(object obj)
        {
            byte[] bytesToSend = Encoding.ASCII.GetBytes(Serializer.Serialize(obj));
            if (_client.Connected)
            {
                _ = _client.GetStream().WriteAsync(bytesToSend);
            }
        }

        private List<object> Read()
        {
            byte[] data = new byte[BufferSize];
            return Serializer.Deserialize(Encoding.Default.GetString(data, 0, _client.GetStream().Read(data, 0, data.Length)).Trim());
        }
    }
}
