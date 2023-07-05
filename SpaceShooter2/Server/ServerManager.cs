using Newtonsoft.Json;
using SpaceShooter2.ConnectUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using SocketIOClient;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace SpaceShooter2.Server
{
    public class ServerManager : INotifyPropertyChanged
    {
        private const string SERVER_URL = "http://127.0.0.1:3000";
        private readonly HttpClient _client = new HttpClient();
        private SocketIO _socket;

        public Form CurrForm;
        private ObservableCollection<string> _usersNames;
        private bool _isGameOnline;
        private bool _isWinner;
        private bool _isRequestReceived;
        private string _playRequestString;
        private string _rivalName;
        private bool _isAlone = true;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<string> UsersNames
        {
            get { return _usersNames; }
            set
            {
                _usersNames = value;
                OnPropertyChanged("UsersNames");
            }
        }
        public string RivalName
        {
            get { return _rivalName; }
            set
            {
                _rivalName = value;
                OnPropertyChanged("RivalName");
            }
        }
        public bool IsGameOnline { get => _isGameOnline; set => _isGameOnline = value; }
        public bool IsRequestReceived { get => _isRequestReceived; set => _isRequestReceived = value; }
        public bool IsWinner { get => _isWinner; set => _isWinner = value; }
        public bool IsAlone { get => _isAlone; set => _isAlone = value; }

        public string PlayRequestString { get => _playRequestString; set => _playRequestString = value; }

       
        public ServerManager()
        {
            InitWebSocketConnection();
        }
        public async void InitWebSocketConnection()
        {
            _socket = new SocketIO("http://127.0.0.1:3001/");
            DeclareGetDataEvents();
            try
            {
                await _socket.ConnectAsync();
            }
            catch
            {
                MessageBox.Show("Make sure you are connected to the server" ,"Server Error");
            }
        }



        
        private void DeclareGetDataEvents()
        {
            _socket.On("OnlineFreeUsers", (users) =>
            {
                UsersNames = JsonConvert.DeserializeObject<ObservableCollection<string>>($"[{users.ToString().Trim(new Char[] { '[', ']', '\\' })}]");
            });
            _socket.On("WantedPlay", (rivalName) =>
            {
                IsRequestReceived = true;
                RivalName = rivalName.ToString().Trim(new Char[] { '[', ']', '\"' });
            });
            _socket.On("StartPlay", (data) =>
            {
                IsGameOnline = true;
                IsAlone = false;
                IsWinner = false;
                CurrForm.Invoke((MethodInvoker)(() =>
                {
                    CurrForm.Visible = false;
                    new SpaceShooter(this).ShowDialog();
                }));
            });

            _socket.On("RefusedPlay", (data) =>
            {
                PlayRequestString = $"{RivalName} refused to play against you";
            });
        }


        public void ReadyToPlay(string userName)
        {
            _socket.EmitAsync("ReadyToPlay", userName);
        }

        public void AgreeToPlay(string currentUserName)
        {
            string jsonRequest = $"{{\"Player1\": \"{currentUserName}\", \"Player2\": \"{RivalName}\"}}";
            _socket.EmitAsync("AgreeToPlay", jsonRequest);
            IsRequestReceived = false;
        }

        public void RefuseToPlay()
        {
            string jsonRequest = $"{{\"refusedName\": \"{RivalName}\"}}";
            _socket.EmitAsync("RefuseToPlay", jsonRequest);
            IsRequestReceived = false;
        }

        public void UpdatePoints(string username, int points)
        {
            string jsonRequest = $"{{\"Username\": \"{username}\", \"Points\": \"{points}\"}}";
            _socket.EmitAsync("UpdatePoints", jsonRequest);
        }

        public void EndGame(string currentUserName)
        {
            string jsonRequest = $"{{\"Player\": \"{currentUserName}\", \"RivalName\": \"{RivalName}\"}}";
            _socket.EmitAsync("EndGame", jsonRequest);
        }

        public void SendRequestToPlay(string requestedPlayer, string requestingPlayer)
        {
            RivalName = requestedPlayer;
            string jsonRequest = $"{{\"RequestedPlayerName\": \"{requestedPlayer}\", \"RequestingPlayerName\": \"{requestingPlayer}\"}}";
            _socket.EmitAsync("WantToPlay", jsonRequest);
        }
        public void PlayerDisconnected()
        {
            _socket.EmitAsync("PlayerDisconnected", _socket.Id);
        }
      
        public int CheckRivalPoints()
        {
            try
            {
                  return Task.Run(async () =>
                  {
                      var queryString = HttpUtility.ParseQueryString(string.Empty);
                      queryString["RivalName"] = RivalName;
                      var uri = $"{SERVER_URL}/CheckRivalPoints?{queryString}";
                      var response = await _client.GetAsync(uri);
                      var content = await response.Content.ReadAsStringAsync();
                      return JsonConvert.DeserializeObject<int>(content);
                  }).Result;
            }
            catch
            {
                return 0;
            }
        }

        public User CheckUserLogin(string username, string password)
        {
            try
            {
                return Task.Run(async () =>
                {
                    var queryString = HttpUtility.ParseQueryString(String.Empty);
                    queryString["Name"] = username;
                    queryString["Password"] = password;
                    var uri = $"{SERVER_URL}/Login?{queryString}";
                    var response = await _client.GetAsync(uri);
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<User>(content);
                }).Result;
            }
            catch
            {
                MessageBox.Show("Server not connected");
                return null;
            }

        }

        public void CreateUser(User user)
        {
            try
            {
                Task.Run(async () =>
                {
                    var queryString = HttpUtility.ParseQueryString(String.Empty);
                    queryString["Name"] = user.Name;
                    queryString["Email"] = user.Email;
                    queryString["Password"] = user.Password;
                    var uri = $"{SERVER_URL}/AddNewUser?{queryString}";
                    await _client.PostAsync(uri, null);
                });
            }
            catch
            {
                MessageBox.Show("Server not connected");
            }
        }


        public bool IsEmailExist(string email)
        {
            try
            {
                return Task.Run(async () =>
                {
                    var queryString = HttpUtility.ParseQueryString(String.Empty);
                    queryString["Email"] = email;
                    var uri = $"{SERVER_URL}/IsEmailExist?{queryString}";
                    var response = await _client.GetAsync(uri);
                    var content = await response.Content.ReadAsStringAsync();
                    return content == "true";
                }).Result;
            }
            catch
            {
                MessageBox.Show("Server not connected");
                return false;
            }


        }

        public bool IsNameExist(string name)
        {
            try
            {
                return Task.Run(async () =>
                {
                    var queryString = HttpUtility.ParseQueryString(String.Empty);
                    queryString["Name"] = name;
                    var uri = $"{SERVER_URL}/IsNameExist?{queryString}";
                    var response = await _client.GetAsync(uri);
                    var content = await response.Content.ReadAsStringAsync();
                    return content == "true";
                }).Result;
            }
            catch
            {
                MessageBox.Show("Server not connected");
                return false;
            }

        }
        public void ResetPassword(string newPassword, string email)
        {
            try
            {
                Task.Run(async () =>
                {
                    var queryString = HttpUtility.ParseQueryString(String.Empty);
                    queryString["Email"] = email;
                    queryString["Password"] = newPassword;
                    var uri = $"{SERVER_URL}/ResetPassword?{queryString}";
                    await _client.PostAsync(uri, null);
                });
            }
            catch
            {
                MessageBox.Show("Server not connected");
            }
        }
    }
}
